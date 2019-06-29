using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models
{
    public struct Size
    {
        [JsonProperty]
        public int Width { get; private set; }
        [JsonProperty]
        public int Height { get; private set; }

        public Size( int Width, int Height ) {
            this.Width = Width;
            this.Height = Height;
        }
    }
}
