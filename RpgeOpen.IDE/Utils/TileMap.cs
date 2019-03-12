using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using Newtonsoft.Json;

using RpgeOpen.IDE.Extensions;
using RpgeOpen.Models.Entities;

using Map = TiledLib.Map;
using Size = RpgeOpen.Models.Size;

namespace RpgeOpen.IDE.Utils
{
    internal class TileMap : Models.Entities.Map, IDisposable
    {
        [JsonIgnore]
        public Size TileSize { get; private set; }
        [JsonIgnore]
        public Image Image { get; private set; }

        public TileMap( Models.Entities.Map map ) :base(map.TmxPath, map.Size) {
        }

        public void Load(string projectDir) {
            if( Image != null )
                return;

            using( var stream = File.OpenRead( Path.Combine(projectDir, Project.Paths.Maps, TmxPath) ) ) {
                var map = Map.FromStream(stream);

                TileSize = new Size( map.CellWidth, map.CellHeight );
                Image = new Bitmap( map.Width * TileSize.Width, map.Height * TileSize.Height );

                var tileSheets = new Dictionary<string, Image>();
                using( var graphic = Graphics.FromImage( Image ) ) {
                    map.Fetch( (x, y, tilesetName, tileRow, tileCol ) => {
                        Image tileSet;
                        if (!tileSheets.TryGetValue(tilesetName, out tileSet))
                        {
                            tileSet = Image.FromFile(Path.Combine(projectDir, Project.Paths.TileSheets, tilesetName));
                            tileSheets.Add(tilesetName, tileSet);
                        }

                        graphic.DrawImage(
                            tileSet,
                            new Rectangle(x * TileSize.Width, y * TileSize.Height, TileSize.Width, TileSize.Height),
                            new Rectangle(tileCol * TileSize.Width, tileRow * TileSize.Height, TileSize.Width, TileSize.Height),
                            GraphicsUnit.Pixel);
                    } );
                }

                foreach( var img in tileSheets) {
                    img.Value.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Image?.Dispose();
            Image = null;
        }
    }
}
