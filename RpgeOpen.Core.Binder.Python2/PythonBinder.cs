using RpgeOpen.Core.Interfaces;
using IronPython.Hosting;
using System;
using RpgeOpen.Shared;
using System.Reflection;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace RpgeOpen.Core.Binder.Python2
{
    public sealed class PythonBinder : IScriptBinder
    {
        private static readonly string EntryPoint = $"Content/{Constants.Paths.Scripts}/main.py";
        private readonly CompiledCode PyProgram;
        private readonly ScriptScope PyScope;
        public bool Initialized { get; private set; }
        private readonly ScriptEngine PyEngine;

        public PythonBinder()
        {
            PyEngine = Python.CreateEngine();
            var pyPaths = PyEngine.GetSearchPaths();
            //pyPaths.Add(AppContext.BaseDirectory);
            pyPaths.Add(Path.Combine(AppContext.BaseDirectory, "Content", Constants.Paths.Scripts));
            PyEngine.SetSearchPaths(pyPaths);

            PyEngine.Runtime.LoadAssembly(
                Assembly.GetAssembly(typeof(IRpgGame))
            );
            PyEngine.Runtime.LoadAssembly(
                Assembly.LoadFile(Path.Combine(AppContext.BaseDirectory, "MonoGame.Framework.dll"))
            );

            if (!File.Exists(EntryPoint))
                throw new FileNotFoundException("The entrypoint was not found", EntryPoint);
            var pySrc = PyEngine.CreateScriptSourceFromFile(EntryPoint);
            PyProgram = pySrc.Compile();

            PyScope = PyEngine.CreateModule("RpgeOpen.Runtime");
        }

        public void Dispose()
        {
        }

        public void Initialize(IRpgGame game)
        {
            if (Initialized)
                return;

            PyScope.SetVariable("ContentManager", game.ContentManager);
            PyScope.SetVariable("SceneManager", game.SceneManager);
            PyScope.SetVariable("AudioManager", game.AudioManager);
            PyScope.SetVariable("RpgeGame", game);
            PyProgram.Execute(PyScope);

            Initialized = true;
        }

        public dynamic GetVariable(string name)
        {
            if (!Initialized)
                throw new InvalidOperationException("Not initialzied");
            return PyScope.GetVariable(name);
        }
    }
}
