using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models
{
    /// <summary>
    /// Map passability
    /// </summary>
    [Flags]
    public enum PassabilityType
    {
        Allow = 0x0,
        Deny = 0x1,
        Top = 0x2,
        Left = 0x3,
        Right = 0x4,
        Bottom = 0x5
    }
}
