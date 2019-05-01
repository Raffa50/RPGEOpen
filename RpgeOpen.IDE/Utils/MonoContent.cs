using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgeOpen.IDE.Models;
using RpgeOpen.Models;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.IDE.Utils
{
    internal static class MonoContent
    {
        private static string monoContentBuildPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "MSBuild/MonoGame/v3.0/Tools/MGCB.exe");

        /// <summary>
        /// Compiles the Mono Content resources from projec's resources
        /// </summary>
        /// <param name="project"></param>
        /// <param name="target"></param>
        /// <param name="outputPath"></param>
        public static void Deploy(CurrentProject project, TargetConsoleType target, string outputPath) {
            CreateMgcb(project, target, outputPath);
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = project.Directory,
                FileName = monoContentBuildPath,
                Arguments = "",
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
            using( var w = File.CreateText( Path.Combine( project.Directory, "Content.mgcb" ) ) ) {
                w.Write("/outputDir:"); w.WriteLine(outputPath);
                w.WriteLine("/platform:DesktopGL"); //TODO

                w.WriteLine("/config:");
                w.WriteLine("/profile:Reach");
                w.WriteLine("/compress:False");

                //import audios
                w.WriteLine("/importer:Mp3Importer");
                w.WriteLine( "/processor:SongProcessor" );
                w.WriteLine("/processorParam:Quality=Best");

                var bgmDir = new DirectoryInfo(Path.Combine(project.Directory, Project.Paths.AudioBgm));
                foreach( var audio in bgmDir.GetFiles()) {
                    w.WriteLine($"/build:{Project.Paths.AudioBgm}/{audio.Name}");
                }

                w.WriteLine("/importer:TextureImporter");
                w.WriteLine("/processor:TextureProcessor");
                w.WriteLine("/processorParam:ColorKeyColor=255,0,255,255");

                //build Characters
                var charsDir= new DirectoryInfo( Path.Combine(project.Directory, Project.Paths.Characters) );
                foreach( var img in charsDir.GetFiles() ) {
                    w.WriteLine($"/build:{Project.Paths.Characters}/{img.Name}");
                }
                //build TileSheets
                var tilesDir= new DirectoryInfo(Path.Combine(project.Directory, Project.Paths.TileSheets));
                foreach( var img in tilesDir.GetFiles()) {
                    if(img.Extension.Contains("png") || img.Extension.Contains("jpg") || img.Extension.Contains("jpeg") || img.Extension.Contains("bmp"))
                        w.WriteLine($"/build:{Project.Paths.TileSheets}/{img.Name}");
                    else
                        w.WriteLine($"/copy:{Project.Paths.TileSheets}/{img.Name}");
                }
                //copy Maps
                var mapsDir= new DirectoryInfo(Path.Combine(project.Directory, Project.Paths.Maps));
                foreach( var map in mapsDir.GetFiles() ) {
                    w.WriteLine($"/copy:{Project.Paths.TileSheets}/{map.Name}");
                }
            }
        }
    }
}
