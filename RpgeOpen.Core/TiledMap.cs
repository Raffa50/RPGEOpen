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

namespace RpgeOpen.Core
{
    public class TiledMap : Map, IGameObject {
        public Size Size { get; private set; }
        private TmxMap map;
        private Size tileSize;
        private readonly Dictionary<string, Texture2D> tileSheets = new Dictionary<string, Texture2D>();

        [Obsolete]
        public TiledMap( Map m ) : base(m.TmxPath, m.NumTiles) {
            DisplayName = m.DisplayName;
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
            map = new TmxMap(Path.Combine("Content", Project.Paths.Maps, TmxPath));
            tileSize = new Size(map.TileWidth, map.TileHeight);
            Size = new Size( map.Width * map.TileWidth, map.Height * map.TileHeight );

            foreach( var ts in map.Tilesets ) {
                var imgPath = ts.Image.Source;
                var t= Content.Load<Texture2D>(Path.Combine(Project.Paths.TileSheets, Path.GetFileNameWithoutExtension(imgPath)));
                tileSheets.Add( imgPath, t );
            }
        }

        public void Update(GameTime time)
        {
        }
    }
}
