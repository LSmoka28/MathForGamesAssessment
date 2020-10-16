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

        Stopwatch stopwatch = new Stopwatch();

        Tank player = new Tank();
        Timer timer2 = new Timer();


        private double currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;






        // starts stopwatch - ignore this method, old way of loading
        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            //load tank
            tankSprite.Load(@"C:\Users\larry\OneDrive\Desktop\MathForGames\MathAssessment\topdowntanks\PNG\Tanks\tankBlue_outline.png");
            // flip the tank 90 deg
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // set an offset fo that it has a center
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            // load turret
            turretSprite.Load(@"C:\Users\larry\OneDrive\Desktop\MathForGames\MathAssessment\topdowntanks\PNG\Tanks\barrelBlue.png");
            // rotate 90 deg
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // set offset for center point
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);

            //set hierarchy
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);

            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        }

        // stop update/ stopwatch
        public void Shutdown()
        {

        }

        // update for getting current framerate
        public void Update()
        {
            deltaTime = timer2.DeltaTime;

            currentTime = GetTime();
            //deltaTime = (currentTime - lastTime) / 1000.0f;

            timer += deltaTime;
            if(timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            
        }

        // draws current framerate
        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            tankObject.Draw();

            EndDrawing();
        }
    }
}
