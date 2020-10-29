/*******************************************************************************************
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
using System;

namespace Examples
{
    public class core_basic_window
    {
        public const int screenWidth = 800;
        public const int screenHeight = 450;
        public static float speed = 50;
        public static float distance = 1;

        // bool for bullet firing
        public static bool bulletActive = false;

        public static bool[] magActive = { false, false, false, false, false, false, false, false, false, false };

        public static string bulletFile = @"ref\bulletRedSilver.png";

        // main program method
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            
            // file name variables
            string tankFileName = @"ref\tankBlue_outline.png";
            string turretFileName = @"ref\barrelBlue.png";
                        
            // set Frames-Per-Second and window size
            SetTargetFPS(60);
            InitWindow(screenWidth, screenHeight, "Tanks for Everything!");

            // initialize classes
            Timer timer = new Timer();
            Game game = new Game();
            Tank player = new Tank();
            Bullet bullet = new Bullet();

            // initialize random
            Random random = new Random();

            // assign tank in Bullet class to player tank
            Bullet.tank = player;

            // simple score start count
            int score = 0;

            // color conversion holding box color
            MathClasses.Vector3 colorVecBox = ColorToHSV(Color.ORANGE);
            Color boxColor = ColorFromHSV(colorVecBox);
            
            // color conversion holding 
            MathClasses.Vector3 colorVecBackground = ColorToHSV(LIGHTGRAY);
            Color backgroundColor = ColorFromHSV(colorVecBackground);

            // TODO: Add to git test

            //--------------------------------------------------------------------------------------
            
            // load player tank image
            player.Setup(tankFileName, turretFileName);

            // load bullet image
            bullet.LoadAmmo(bulletFile);

            // create new rectangle and assign proper value
            Rectangle rect = new Rectangle
            {
                x = GetScreenWidth() / 4,
                y = GetScreenHeight() / 4,
                width = 60,
                height = 60
            };


            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------

                float deltaTime = timer.DeltaTime;
                
                timer.Update();
                player.OnUpdate(deltaTime);
                bullet.OnUpdate(deltaTime);

                game.Update();

                // check for collision point inside rectangle
                if (bulletActive && CheckCollisionPointRec(new MathClasses.Vector2(Bullet.bulletObj.LocalTransform.m7, Bullet.bulletObj.LocalTransform.m8), rect) == true)
                {

                    rect.x = random.Next(50, GetScreenWidth() - 50);
                    rect.y = random.Next(50, GetScreenHeight() - 50);
                    score += 1;

                    bulletActive = false;

                    // console log to prove collision
                    Console.WriteLine("Collision Detected");

                }
              
                //----------------------------------------------------------------------------------
                // Draw
                //----------------------------------------------------------------------------------

                BeginDrawing();

                ClearBackground(backgroundColor);
               
                // draws images to screen 
                player.OnDraw();
                
                // draw rectangle to screen
                DrawRectangle((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height, boxColor);
                
                // end game controls
                DrawText("Press the 'Esc' key to close window", 10, 20, 20, RED);

                // visible text on screen for score, deltaTime, and time since game started
                DrawText("Time Since Start: " + GetTime().ToString("0.0"), 10, 40, 20, RED);
                DrawText("DeltaTime: " + timer.DeltaTime.ToString("0.000000"), 10, 60, 20, RED);
                DrawText("Targets Hit: " + score.ToString("0"), 10, 80, 20, RED);


                




                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------            
            game.Shutdown();                    // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }

        
    }
}