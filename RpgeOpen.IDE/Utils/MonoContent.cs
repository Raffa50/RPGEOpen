using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgeOpen.IDE.Models;
using RpgeOpen.Models;
using RpgeOpen.Shared;

namespace RpgeOpen.IDE.Utils
{
    internal static class MonoContent
    {
        private const string mgcbFile = "Content.mgcb";
        private static readonly string monoContentBuildPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "MSBuild/MonoGame/v3.0/Tools/MGCB.exe");

        /// <summary>
        /// Compiles the Mono Content resources from projec's resources
        /// </summary>
        /// <param name="project"></param>
        /// <param name="target"></param>
        /// <param name="outputPath"></param>
        public static void Deploy(CurrentProject project, TargetConsoleType target, string outputPath) {
            if (File.Exists(outputPath))
                File.Delete(outputPath);
            Directory.CreateDirectory(outputPath);
            CreateMgcb(project, target, outputPath);
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = project.Directory,
                FileName = monoContentBuildPath,
                Arguments = mgcbFile,
            };
            Process.Start(startInfo).WaitForExit();
        }

        /// <summary>
        /// Generate mgcb from project's resources
        /// </summary>
        /// <param name="project"></param>
        /// <param name="target"></param>
        /// <param name="outputPath"></param>
        private static void CreateMgcb(CurrentProject project, TargetConsoleType target, string outputPath) {
            using( var w = File.CreateText( Path.Combine( project.Directory, mgcbFile) ) ) {
                string tempDirPath = Path.Combine(Path.GetTempPath(), project.Project.Name);
                Directory.CreateDirectory(tempDirPath);

                w.WriteLine("/outputDir:"+outputPath);
                w.WriteLine("/intermediateDir:"+tempDirPath);
                w.WriteLine("/platform:DesktopGL"); //TODO

                w.WriteLine("/config:");
                w.WriteLine("/profile:Reach");
                w.WriteLine("/compress:False");

                //import fonts
                w.WriteLine("/importer:FontDescriptionImporter");
                w.WriteLine("/processor:FontDescriptionProcessor");
                w.WriteLine("/processorParam:PremultiplyAlpha=True");
                w.WriteLine("/processorParam:TextureFormat=Compressed");

                var fontDir = new DirectoryInfo(Path.Combine(project.Directory, Constants.Paths.Fonts));
                foreach(var font in fontDir.GetFiles().Where(f => f.Extension == ".spritefont"))
                    w.WriteLine($"/build:{Constants.Paths.Fonts}/{font.Name}");
                
                //import audios
                w.WriteLine("/importer:Mp3Importer");
                w.WriteLine( "/processor:SongProcessor" );
                w.WriteLine("/processorParam:Quality=Best");

                var bgmDir = new DirectoryInfo(Path.Combine(project.Directory, Constants.Paths.AudioBgm));
                foreach( var audio in bgmDir.GetFiles())
                    w.WriteLine($"/build:{Constants.Paths.AudioBgm}/{audio.Name}");

                w.WriteLine("/importer:TextureImporter");
                w.WriteLine("/processor:TextureProcessor");
                w.WriteLine("/processorParam:ColorKeyColor=255,0,255,255");

                //build Characters
                var charsDir= new DirectoryInfo( Path.Combine(project.Directory, Constants.Paths.Characters) );
                foreach( var img in charsDir.GetFiles().Where(f => Constants.Extensions.Images.Contains(f.Extension)) )
                    w.WriteLine($"/build:{Constants.Paths.Characters}/{img.Name}");

                //build backgrounds
                var bgDir = new DirectoryInfo(Path.Combine(project.Directory, Constants.Paths.Backgrounds));
                foreach (var img in bgDir.GetFiles().Where(f => Constants.Extensions.Images.Contains(f.Extension)))
                    w.WriteLine($"/build:{Constants.Paths.Backgrounds}/{img.Name}");

                //build TileSheets
                var tilesDir= new DirectoryInfo(Path.Combine(project.Directory, Constants.Paths.TileSheets));
                foreach( var img in tilesDir.GetFiles()) {
                    if(Constants.Extensions.Images.Contains(img.Extension))
                        w.WriteLine($"/build:{Constants.Paths.TileSheets}/{img.Name}");
                    else if(img.Extension == ".tsx")
                        w.WriteLine($"/copy:{Constants.Paths.TileSheets}/{img.Name}");
                }

                //copy Maps
                var mapsDir= new DirectoryInfo(Path.Combine(project.Directory, Constants.Paths.Maps));
                foreach( var map in mapsDir.GetFiles().Where(f => f.Extension == ".tmx") )
                    w.WriteLine($"/copy:{Constants.Paths.Maps}/{map.Name}");

                //copy Scripts
                var scriptsDir = new DirectoryInfo(Path.Combine(project.Directory, Constants.Paths.Scripts));
                foreach( var script in scriptsDir.GetFiles().Where(f => f.Extension == ".py") )
                    w.WriteLine($"/copy:{Constants.Paths.Scripts}/{script.Name}");

                w.WriteLine($"/copy:{project.FileName}.rpgeo;game.rpgeo");
            }
        }
    }
}
