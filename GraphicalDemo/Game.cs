using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;


namespace GraphicalDemo
{
    class Game
    {
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        // stop update/ stopwatch
        public void Shutdown()
        {

        }

        // update for getting current framerate
        public void Update()
        {
                      
        }

        // draws current framerate
        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);
            
            tankObject.Draw();

            EndDrawing();
        }
    }
}
