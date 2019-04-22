using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TiledSharp;

namespace RpgeOpen.Shared.Extensions
{
    public delegate void FetchTmxMapAction(int x, int y, string tileSet, int tileRow, int tileCol);

    public static class TiledMapExtensions {
        public static void Fetch( this TmxMap map, FetchTmxMapAction action ) {
            foreach( var layer in map.Layers ) {
                for( int y = 0, i = 0; y < map.Height; y++ )
                    for( int x = 0; x < map.Width; x++, i++ ) {
                        var gid = layer.Tiles[i].Gid;
                        if( gid == 0 )
                            continue;

                        var tileset = map.Tilesets.Single(ts => gid >= ts.FirstGid && ts.FirstGid + ts.TileCount > gid);

                        int tileWidth = tileset.Image.Width.Value / map.TileWidth;
                        int col = (gid -1) % tileWidth;
                        int row = (int)Math.Floor((double)(gid -1) / tileWidth);

                        action( x, y, tileset.Image.Source, row, col );
                    }
            }
        }
    }
}
