﻿using System;

namespace Game.Engine
{
    public interface ISystem
    {
        void Update(TimeSpan gameTime);
    }
}