﻿/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib-cs 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example was lightly modified to provide additional 'using' directives to make
*   common math types and utilities readily available, though they are not using in this sample.
*
*   Copyright (c) 2019-2020 Academy of Interactive Entertainment (@aie_usa)
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using MathClasses; // my mathematics types
using Raylib_cs;
using GraphicalDemo;
using System.Numerics;

namespace Examples
{
    public class core_basic_window
    {

        public const int screenWidth = 800;
        public const int screenHeight = 450;
        public static float speedX = 50;
        public static float direction = 1;


        // bool of active bullets - no more than 5 on the screen at a time
        public static bool[] bulletActive = { false, false, false, false, false };

        public static bool bulletInChamber = false;


        // attempt to create array of bullets
        public static SceneObject[] bulletObjects = new SceneObject[5];
        public static SpriteObject[] bulletSprites = new SpriteObject[5];


        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------

            // TODO: Add bullet array and fix loading of bullet

            // file name variables
            string tankFileName = @"ref\tankBlue_outline.png";
            string turretFileName = @"ref\barrelBlue.png";
            string bulletFile = @"ref\bulletRedSilver.png";
            
            // set Frames-Per-Seconda and window size
            SetTargetFPS(60);
            InitWindow(screenWidth, screenHeight, "Tanks for Everything!");


            Timer timer = new Timer();
            Game game = new Game();
            Tank player = new Tank();
            Bullet bullet = new Bullet();

            Bullet.tank = player;

            

            SceneObject bulletObject = new SceneObject();
            SpriteObject bulletSprite = new SpriteObject();

                       
            //--------------------------------------------------------------------------------------
            
            // load player tank image
            player.Setup(tankFileName, turretFileName);

            // load bullet image
            bullet.LoadAmmo(bulletFile);


            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                float deltaTime = timer.DeltaTime;

                //----------------------------------------------------------------------------------
                // TODO: Update your variables here

                timer.Update();
                player.OnUpdate(deltaTime);
                bullet.OnUpdate(deltaTime);

                //----------------------------------------------------------------------------------
                // Draw
                //----------------------------------------------------------------------------------

                BeginDrawing();

                ClearBackground(Color.LIGHTGRAY);

               

                // draws images to screen 
                player.OnDraw();

                

                DrawText("Time Since Start: " + GetTime().ToString("0.0"), 25, 25, 20, RED);
                DrawText("DeltaTime: " + timer.DeltaTime.ToString("0.000000"), 25, 50, 20, RED);
                
               

                Rectangle rect = new Rectangle();
                rect.x = GetScreenWidth() / 4;
                rect.y = GetScreenHeight() / 4;
                rect.width = 50;
                rect.height = 50;

                DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, BLUE);
                
                if(bulletInChamber && CheckCollisionPointRec(new MathClasses.Vector2(Bullet.bulletObj.LocalTransform.m7, Bullet.bulletObj.LocalTransform.m8), rect)==true)
                {
                    DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, GREEN);
                    bulletInChamber = false;
                    //DrawText("Collision worked", 25, 25, 20, RED);
                    System.Console.WriteLine("Collision Worked");
                }





                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            game.Shutdown();
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }

        
    }
}