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
        // game window measurements 
        public const int screenWidth = 800;
        public const int screenHeight = 450;


        // bullet file path name
        public static string bulletFile = @"ref\bulletRedSilver.png";

        // create new rectangle and assign proper value
        public static Rectangle rect = new Rectangle
        {
            x = GetScreenWidth() / 4,
            y = GetScreenHeight() / 4,
            width = 60,
            height = 60
        };

        // simple score start count
        public static int score = 0;
        // bullet tracker
        public static int amountOfBulletsFired = 0;


        // initialize random
        public static Random random = new Random();

        // color conversion holding box color
        public static MathClasses.Vector3 colorVecBox = ColorToHSV(Color.ORANGE);
        public static Color boxColor = ColorFromHSV(colorVecBox);

        // main program method
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            
            // file name variables
            string tankFileName = @"ref\tankBlue_outline.png";
            string turretFileName = @"ref\barrelBlue.png";

            
           
                        
            InitWindow(screenWidth, screenHeight, "Tanks for Everything!");
            // set Frames-Per-Second and window size
            SetTargetFPS(60);

            // initialize classes
            Timer timer = new Timer();
            Game game = new Game();
            Tank player = new Tank();
            Bullet bullet = new Bullet();

            //set array of bullets and assign index
            Bullet[] rockets = new Bullet[10];
            for(int i = 0; i < rockets.Length; ++i)
            {
                rockets[i] = new Bullet();
                rockets[i].LoadAmmo(bulletFile);
            }
            
            // assign tank in Bullet class to player tank
            Bullet.tank = player;

            // color conversion holding 
            MathClasses.Vector3 colorVecBackground = ColorToHSV(LIGHTGRAY);
            Color backgroundColor = ColorFromHSV(colorVecBackground);
            
            // load player tank image and turret image
            player.Setup(tankFileName, turretFileName);

            // load bullet image
            bullet.LoadAmmo(bulletFile);

            //--------------------------------------------------------------------------------------
            
            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------

                float deltaTime = timer.DeltaTime;
                
                timer.Update();
                player.OnUpdate(deltaTime);
                bullet.OnUpdate(deltaTime);
                //update each rocket in the array
                foreach(Bullet rock in rockets)
                {
                    rock.OnUpdate(deltaTime);
                }

                // press "SPACEBAR" to shoot bullets out of tank barrel
                if (IsKeyPressed(KeyboardKey.KEY_SPACE))
                {                 
                    foreach(Bullet rock in rockets)
                    {                        
                        if(!rock.bulletActive)
                        {
                            // set bullet to active 
                            rock.bulletActive = true;
                           
                            // set rotate will reset position and scale values
                            rock.bulletObj.SetRotate(0.0f);

                            // set / start shooting position of bullet at turrets x and y after rotation reset
                            rock.bulletObj.SetPosition(Tank.turretObject.GlobalTransform.m7, Tank.turretObject.GlobalTransform.m8);

                            // get the rotation of the turret and fire in that direction
                            float firingAngle = (float)Math.Atan2(Tank.turretObject.GlobalTransform.m2, Tank.turretObject.GlobalTransform.m1);
                            rock.bulletObj.Rotate(-firingAngle);

                            // add 1 to "firing" count each time
                            amountOfBulletsFired ++;

                            break;
                        }  
                    }
                }


                //----------------------------------------------------------------------------------
                // Draw
                //----------------------------------------------------------------------------------

                BeginDrawing();

                ClearBackground(backgroundColor);

                // draws images to screen 
                bullet.Draw();
                foreach(Bullet rock in rockets)
                {
                    rock.Draw();
                }
                player.Draw();                
                               
                // end game controls
                DrawText("Press the 'Esc' key to close window", 10, 20, 20, RED);

                // screen text for score, deltaTime, and time since game started
                DrawText("Time Since Start: " + GetTime().ToString("0.0"), 10, 40, 20, RED);
                DrawText("DeltaTime: " + timer.DeltaTime.ToString("0.000000"), 10, 60, 20, RED);
                DrawText("Targets Hit: " + score.ToString("0"), 600, 20, 20, BLUE);
                DrawText("Bullets Fired: " + amountOfBulletsFired.ToString("0"), 600, 40, 20, BLUE);
               
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