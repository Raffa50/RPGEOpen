using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using RpgeOpen.Models.Entities;
using RpgeOpen.Player.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace RpgeOpen.Player.Utils
{
    public class TiledMap : Map, IGameObject {
        private TmxMap map;

        public void Dispose()
        {
            
        }

        public void Draw(GameTime time)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void LoadContent(ContentManager Content)
        {
            map = new TmxMap(Path.Combine("Content", Project.Paths.Maps, TmxPath));

            //TileSize = new Size(map.TileWidth, map.TileHeight);
        }

        public void Update(GameTime time)
        {
            throw new NotImplementedException();
        }
    }
}
