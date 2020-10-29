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
        // TODO: Fix firirng direction of bullet 

        // new SceneObject for tank parent and a child tank SpriteObject
        public static SceneObject bulletObj = new SceneObject();
        SpriteObject bulletSpr = new SpriteObject();

        // timer instance to check deltaTime
        public static Timer timer = new Timer();

        // Tank instacne to assign a bullet to
        public static Tank tank = new Tank();

        // Vector3 of velocity
        public static float speed = 300;
        public static float distance = 2;
        Vector3 velocityOfBullet = new Vector3(speed, distance, 1);

        public static SceneObject[] bullets = new SceneObject[10];
        SpriteObject[] bulletsSprites = new SpriteObject[10];


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

        public override void OnUpdate(float deltaTime)
        {
            // press "SPACEBAR" to shoot bullets out of tank barrel
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                //shoot bullet
                //set bullet firing to true after hitting space if false
                if (!core_basic_window.bulletActive)
                {
                     core_basic_window.bulletActive = true;
                }

                // set rotate will reset your position and scale values
                bulletObj.SetRotate(0.0f);
           
                // set / start shooting position of bullet at turrets x and y after rotation reset
                bulletObj.SetPosition(Tank.turretObject.GlobalTransform.m7, Tank.turretObject.GlobalTransform.m8);

                // get the rotation of the tank and fire in that direction
                float firingAngle = (float)Math.Atan2(Tank.turretObject.GlobalTransform.m2, Tank.turretObject.GlobalTransform.m1);
                bulletObj.Rotate(-firingAngle);
                
            }
            // fire bullet if true/ after space bar is hit
            if (core_basic_window.bulletActive)
            {
                Vector3 pos = new Vector3(bulletObj.LocalTransform.m1 * (velocityOfBullet.x * velocityOfBullet.y), bulletObj.LocalTransform.m2 * (velocityOfBullet.x * velocityOfBullet.y), 1) * (deltaTime);

                bulletObj.Translate(pos.x, pos.y);

                // remove bullet if collidied with edge of window
                if (bulletObj.LocalTransform.m7 >= GetScreenWidth() || bulletObj.LocalTransform.m8 >= GetScreenHeight())
                {
                    core_basic_window.bulletActive = false;

                }
                if (bulletObj.LocalTransform.m7 <= 0 || bulletObj.LocalTransform.m8 <= 0)
                {
                    core_basic_window.bulletActive = false;
                }

                bulletObj.Draw();
            }

            if (IsKeyPressed(KeyboardKey.KEY_J))
            {
                for (int i = 0; i < 10; i++)
                {

                    foreach(SpriteObject ammo in bulletsSprites)
                    {
                        bulletsSprites[i] = ammo;

                        ammo.Load(core_basic_window.bulletFile);

                        ammo.SetRotate(-90 * (float)(Math.PI / 180.0f));

                        ammo.SetPosition(bulletSpr.Width / 2.0f, 0);
                    }


                    if (!core_basic_window.magActive[i])
                    {
                        int magSlot = i;

                        bullets[magSlot].Rotate(0);

                        Vector3 pos = new Vector3(bullets[magSlot].LocalTransform.m1 * (velocityOfBullet.x * velocityOfBullet.y), bullets[magSlot].LocalTransform.m2 * (velocityOfBullet.x * velocityOfBullet.y), 1) * (deltaTime);

                        bullets[magSlot].Translate(pos.x, pos.y);

                        bullets[magSlot].Draw();


                        if (bullets[magSlot].LocalTransform.m7 >= GetScreenWidth() || bullets[magSlot].LocalTransform.m8 >= GetScreenHeight())
                        {
                            core_basic_window.magActive[i] = false;

                        }
                        if (bullets[magSlot].LocalTransform.m7 <= 0 || bullets[magSlot].LocalTransform.m8 <= 0)
                        {
                            core_basic_window.magActive[i] = false;
                        }
                    }
                }
                

            }




        }

        // draws bullet loaded
        public override void OnDraw()
        {            
            bulletObj.Draw();
        }
    }
}
