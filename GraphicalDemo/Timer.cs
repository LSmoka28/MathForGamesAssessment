using System;
using System.Collections.Generic;
using System.Text;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GraphicalDemo
{
    class Timer
    {
        private double prevTimeSinceStart = 0.0f;
        public double currentTime = 0.0f;

        private float _deltaTime;
        public float DeltaTime
        {
            get
            {
                return _deltaTime;
            }
        }

        public void Update()
        {
            currentTime = GetTime();
            _deltaTime = (float)(currentTime - prevTimeSinceStart);
            prevTimeSinceStart = currentTime;
        }
    }
}
