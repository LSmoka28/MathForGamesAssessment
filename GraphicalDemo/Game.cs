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

        // draws current framerate
        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.LIGHTGRAY);
                        
            EndDrawing();
        }
    }
}
