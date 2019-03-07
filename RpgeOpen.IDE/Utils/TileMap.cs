using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using RpgeOpen.IDE.Extensions;

using TiledLib;
using Size = RpgeOpen.Models.Size;

namespace RpgeOpen.IDE.Utils
{
    internal class TileMap : IDisposable
    {
        public string TmxPath { get; }
        public Size TileSize { get; private set; }

        public TileMap( string tmxPath ) {
            TmxPath = tmxPath;
        }

        public Image Image { get; private set; }

        public void Load(string tileSheetsDir) {
            if( Image != null )
                return;

            using( var stream = File.OpenRead( TmxPath ) ) {
                var map = Map.FromStream(stream);

                TileSize = new Size( map.CellWidth, map.CellHeight );
                Image = new Bitmap( map.Width * TileSize.Width, map.Height * TileSize.Height );

                var tileSheets = new Dictionary<string, Image>();
                using( var graphic = Graphics.FromImage( Image ) ) {
                    map.Fetch( (x, y, tilesetName, tileRow, tileCol ) => {
                        Image tileSet;
                        if (!tileSheets.TryGetValue(tilesetName, out tileSet))
                        {
                            tileSet = Image.FromFile(Path.Combine(tileSheetsDir, tilesetName));
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
