﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using MonoGame.Extended.Screens;

using RpgeOpen.Core.Interfaces;
using RpgeOpen.Models.Entities;

namespace RpgeOpen.Core
{
    public abstract class AbstractScreen : Screen
    {
        protected AbstractScreen(IRpgGame game){
            Game = game;
        }

        private IRpgGame Game { get; }
        public ContentManager Content => Game.Content;
        public GraphicsDevice GraphicsDevice => Game.GraphicsDevice;
        public Camera2D Camera => Game.Camera;
        public Project GameData => Game.GameData;
    }
}