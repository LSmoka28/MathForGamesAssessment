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
        // private variable for use calculating deltaTime
        private double prevTimeSinceStart = 0.0f;
        private double currentTime = 0.0f;

        private float _deltaTime;

        // return value of deltTime
        public float DeltaTime
        {
            get
            {
                return _deltaTime;
            }
        }

        // update method to calculate deltaTimer
        public void Update()
        {
            currentTime = GetTime();
            _deltaTime = (float)(currentTime - prevTimeSinceStart);
            prevTimeSinceStart = currentTime;
        }
    }
}
