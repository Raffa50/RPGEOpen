using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TiledLib;
using TiledLib.Layer;

namespace RpgeOpen.IDE.Extensions
{
    public delegate void FetchTmxMapAction(int x, int y, string tileSet, int tileRow, int tileCol);

    public static class TiledMapExtensions {
        public static void Fetch( this Map map, FetchTmxMapAction action ) {
            foreach( var layer in map.Layers.OfType<TileLayer>() ) {
                for( int y = 0, i = 0; y < layer.Height; y++ )
                    for( int x = 0; x < layer.Width; x++, i++ ) {
                        var gid = layer.Data[i];
                        if( gid == 0 )
                            continue;

                        var tileset = map.Tilesets.Single(ts => gid >= ts.FirstGid && ts.FirstGid + ts.TileCount > gid);
                        var tile = tileset[gid];

                        action( x, y, tileset.Name, tile.Top, tile.Left );
                    }
            }
        }
    }
}
