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
        // TODO: Add bullet array and fix loading of bullet

        // new SceneObject for tank parent and a child tank SpriteObject
        public static SceneObject bulletObj = new SceneObject();
        SpriteObject bulletSpr = new SpriteObject();

        // attempt to hold array bullets
        public static SceneObject[] bulletObjects = new SceneObject[5];
        public static SpriteObject[] bulletSprites = new SpriteObject[5];

        // timer instance to check deltaTime
        public static Timer timer = new Timer();

        // Tank instacne to assign a bullet to
        public static Tank tank = new Tank();

        // Vector3 of velocity
        public static float speed = 300;
        public static float direction = 2;
        Vector3 velocityOfBullet = new Vector3(speed, direction, 1);


        // create uninitialized tank
        public Bullet()
        {
            // left blank intentionally
        }

        // load bullet image and assign parent/child relationship
        public void LoadAmmo(string bulletImageFilePath)
        {
            // load file path specified
            bulletSpr.Load(bulletImageFilePath);
            // rotate to match correct facing direction of tank
            bulletSpr.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // set pivot point
            bulletSpr.SetPosition(bulletSpr.Width /2.0f, 0);

            // set hierarchy
            bulletObj.AddChild(bulletSpr);
          
        }

        public override void OnUpdate(float deltaTime)
        {
            // press "SPACEBAR" to shoot bullets out of tank barrel
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {

                //shoot bullet
                //set bullet firing to true after hitting space if false
                if (!core_basic_window.bulletFiring)
                {
                     core_basic_window.bulletFiring = true;
                }

                // set / start shooting position of bullet at turrets x and y
                bulletObj.SetPosition(Tank.turretObject.GlobalTransform.m7, Tank.turretObject.GlobalTransform.m8);
                
                
            }

            // fire bullet when true/ after space bar is hit
            if (core_basic_window.bulletFiring)
            {
                Vector3 pos = new Vector3(bulletObj.LocalTransform.m1 * (velocityOfBullet.x * velocityOfBullet.y), bulletObj.LocalTransform.m2 * (velocityOfBullet.x * velocityOfBullet.y), 1) * (deltaTime);

                bulletObj.Translate(pos.x, pos.y);

                if (bulletObj.LocalTransform.m7 >= GetScreenWidth() || bulletObj.LocalTransform.m8 >= GetScreenHeight())
                {
                    core_basic_window.bulletFiring = false;

                }
                if (bulletObj.LocalTransform.m7 <= 0 || bulletObj.LocalTransform.m8 <= 0)
                {
                    core_basic_window.bulletFiring = false;
                }

                bulletObj.Draw();
            }

            // 1 2 4 5 rotate storage
            
        }

        // draws bullet loaded
        public override void OnDraw()
        {            
            bulletObj.Draw();
        }
    }
}
