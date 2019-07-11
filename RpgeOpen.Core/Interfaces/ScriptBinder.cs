using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgeOpen.Core.Interfaces
{
    public interface ScriptBinder : IDisposable
    {
        void Initialize(IRpgGame game);
        dynamic GetVariable(string name);
    }
}
