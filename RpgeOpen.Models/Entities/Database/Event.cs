using RpgeOpen.Models.Interfaces;
using RpgeOpen.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgeOpen.Models.Entities.Database
{
    public class Event : IEvent
    {
        public string Id { get; }
        public int X { get; }
        public int Y { get; }

        internal Event(string id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}
