using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models
{
    [Serializable]
    public struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Size( int width, int height ) {
            Width = width;
            Height = height;
        }
    }
}
