using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RpgeOpen.Models;
using RpgeOpen.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using RpgeOpen.Shared.Extensions;

using TiledSharp;
using RpgeOpen.Core.Interfaces;
using RpgeOpen.Shared;

namespace RpgeOpen.Core.Maps
{
    public class TiledMap : Map, IGameObject {
        public Size Size { get; private set; }
        private TmxMap map;
        private Size tileSize;
        private readonly Dictionary<string, Texture2D> tileSheets = new Dictionary<string, Texture2D>();
        public IDictionary<(int,int),MapBlock> Blocks { get; }

        [Obsolete]
        public TiledMap( Map m ) : base(m.TmxPath, m.PassabilityLayer) {
            DisplayName = m.DisplayName;
            Blocks = new Dictionary<(int,int),MapBlock>();
        }

        public void Dispose()
        {
            foreach( var t in tileSheets.Values ) {
                t.Dispose();
            }
            tileSheets.Clear();
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch) {
            map.Fetch(
                ( x, y, tilesetName, tileRow, tileCol ) => {
                    spriteBatch.Draw(
                        tileSheets[tilesetName],
                        new Rectangle(x * tileSize.Width, y * tileSize.Height, tileSize.Width, tileSize.Height),
                        new Rectangle(tileCol * tileSize.Width, tileRow * tileSize.Height, tileSize.Width, tileSize.Height),
                        Color.White
                    );
                } );
        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager Content)
        {
            map = new TmxMap(Path.Combine("Content", Constants.Paths.Maps, TmxPath));
            tileSize = new Size(map.TileWidth, map.TileHeight);
            Size = new Size( map.Width * map.TileWidth, map.Height * map.TileHeight );

            foreach( var ts in map.Tilesets ) {
                var imgPath = ts.Image.Source;
                var t= Content.Load<Texture2D>(Path.Combine(Constants.Paths.TileSheets, Path.GetFileNameWithoutExtension(imgPath)));
                tileSheets.Add( imgPath, t );
            }

            for (int r = 0; r < NumTiles.Width; r++)
                for (int c = 0; c < NumTiles.Height; c++)
                    if(PassabilityLayer[r, c] != PassabilityType.Allow)
                        Blocks.Add((r,c), new MapBlock(PassabilityLayer[r, c], tileSize, r, c));
        }

        public void Update(GameTime time)
        {
        }
    }
}
