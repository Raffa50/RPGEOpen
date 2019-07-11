using RpgeOpen.Core.Interfaces;
using IronPython.Hosting;
using System;
using RpgeOpen.Shared;
using System.Reflection;
using Microsoft.Scripting.Hosting;

namespace RpgeOpen.Core.Binder.Python2
{
    public sealed class PythonBinder : ScriptBinder
    {
        private readonly CompiledCode PyProgram;
        private readonly ScriptScope PyScope;
        public bool Initialized { get; private set; }

        public PythonBinder()
        {
            var PyEngine = Python.CreateEngine();
            var pyPaths = PyEngine.GetSearchPaths();
            pyPaths.Add(AppContext.BaseDirectory);
            PyEngine.SetSearchPaths(pyPaths);
            var pySrc = PyEngine.CreateScriptSourceFromFile($"Content/{Constants.Paths.Scripts}/SplashScene.py");
            PyProgram = pySrc.Compile();

            PyScope = PyEngine.CreateScope();
            PyEngine.Runtime.LoadAssembly(Assembly.GetAssembly(typeof(IRpgGame)));
        }

        public void Dispose()
        {
        }

        public void Initialize(IRpgGame game)
        {
            if (Initialized)
                return;
            PyScope.SetVariable("AudioManager", game.AudioManager);
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
