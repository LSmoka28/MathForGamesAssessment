using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Examples;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;


namespace GraphicalDemo
{
    class Game
    {
        // stop update/ stopwatch
        public void Shutdown()
        {
            CloseWindow();
        }

        // checks for keyboard input to close game
        public void Update()
        {
            

        }

        // draws current framerate
        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.LIGHTGRAY);
                        
            EndDrawing();
        }
    }
}
