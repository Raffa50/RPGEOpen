using RpgeOpen.Models;
using RpgeOpen.Models.Entities;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using TiledSharp;

namespace RpgeOpen.IDE.Utils
{
    internal static class TiledImporter
    {
        public static Size ImportTmx( string tmxPath, string projectDir ) {
            if(!Path.GetExtension(tmxPath).Contains( "tmx" ))
                throw new ArgumentException("Invalid file");

            var tmxDir = Path.GetDirectoryName(tmxPath);
            var tiledMap = new TmxMap(tmxPath);
            var size = new Size(tiledMap.Width, tiledMap.Height);

            using ( var tmxReadStream = File.OpenRead( tmxPath ) ) {
                var document = XDocument.Load(tmxReadStream);
                var tilesets = document.Root.Elements().Where( e => e.Name == "tileset");
                foreach(var ts in tilesets ) {
                    var source = ts.Attributes().First(a => a.Name == "source");
                    ImportTileSheet( Path.Combine(tmxDir,source.Value), projectDir );
                    source.Value = "../"+ Project.Paths.TileSheets +"/"+ Path.GetFileName(source.Value);
                }

                document.Save(Path.Combine( projectDir, Project.Paths.Maps, Path.GetFileName(tmxPath) ));
            }

            return size;
        }

        private static void ImportTileSheet( string tsxPath, string projectDir ) {
            var tsxDir = Path.GetDirectoryName(tsxPath);

            using( var tsxReadStream = File.OpenRead( tsxPath ) ) {
                var document = XDocument.Load( tsxReadStream );
                var images = document.Root.Elements().Where( e => e.Name == "image" );
                foreach( var img in images) {
                    var source = img.Attributes().First( a => a.Name == "source" );
                    var imageFileName = Path.GetFileName(source.Value);
                    File.Copy( Path.Combine(tsxDir, imageFileName), 
                        Path.Combine(projectDir, Project.Paths.TileSheets, imageFileName), true );

                    source.Value = imageFileName;
                }

                document.Save(Path.Combine( projectDir, Project.Paths.TileSheets, Path.GetFileName(tsxPath) ));
            }
        }
    }
}
