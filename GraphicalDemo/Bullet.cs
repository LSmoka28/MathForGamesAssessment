using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Examples;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;


namespace GraphicalDemo
{  
    class Bullet : SpriteObject
    {


        // new SceneObject for tank parent and a child tank SpriteObject
        public SceneObject bulletObj = new SceneObject();
        SpriteObject bulletSpr = new SpriteObject();

        // timer instance to check deltaTime
        public static Timer timer = new Timer();

        // Tank instacne to assign a bullet to
        public static Tank tank = new Tank();

        // Vector3 of velocity
        public static float speed = 300;
        public static float distance = 2;
        Vector3 velocityOfBullet = new Vector3(speed, distance, 1);

        // used to draw bullet if true
        public bool bulletActive = false;

        // create uninitialized bullet
        public Bullet()
        {
            // left blank intentionally
        }

        // load bullet image and assign parent/child relationship
        public void LoadAmmo(string bulletImageFilePath)
        {
            //load file path specified
            bulletSpr.Load(bulletImageFilePath);
            //rotate to match correct facing direction of tank
            bulletSpr.SetRotate(-90 * (float)(Math.PI / 180.0f));
            //set pivot point
            bulletSpr.SetPosition(bulletSpr.Width / 2.0f, 0);
            //set hierarchy
            bulletObj.AddChild(bulletSpr);

        }

        // check for these on bullet update 
        public override void OnUpdate(float deltaTime)
        {
            // fire bullet if true/ after space bar is hit
            if (bulletActive)
            {
                Vector3 pos = new Vector3(bulletObj.LocalTransform.m1 * (velocityOfBullet.x * velocityOfBullet.y), bulletObj.LocalTransform.m2 * (velocityOfBullet.x * velocityOfBullet.y), 1) * (deltaTime);

                bulletObj.Translate(pos.x, pos.y);

                // remove bullet if collidied with edge of window
                if (bulletObj.LocalTransform.m7 >= GetScreenWidth() || bulletObj.LocalTransform.m8 >= GetScreenHeight())
                {
                    bulletActive = false;

                }
                if (bulletObj.LocalTransform.m7 <= 0 || bulletObj.LocalTransform.m8 <= 0)
                {
                    bulletActive = false;
                }
            }

            // check collsion with rectangle object 
            if (bulletActive && CheckCollisionPointRec(new Vector2(bulletObj.LocalTransform.m7, bulletObj.LocalTransform.m8), core_basic_window.rect) == true)
            {

                core_basic_window.rect.x = core_basic_window.random.Next(50, GetScreenWidth() - 50);
                core_basic_window.rect.y = core_basic_window.random.Next(50, GetScreenHeight() - 50);
                core_basic_window.score += 1;

                bulletActive = false;

                // console log to prove collision
                Console.WriteLine("Collision Detected");
              
            }
            // draw rectangle to screen
            DrawRectangle((int)core_basic_window.rect.x, (int)core_basic_window.rect.y, (int)core_basic_window.rect.width, (int)core_basic_window.rect.height, core_basic_window.boxColor);
        }

        // draws bullet loaded
        public override void OnDraw()
        {
            if (bulletActive)
            {
                bulletObj.Draw();
            }
        }
    }
}
