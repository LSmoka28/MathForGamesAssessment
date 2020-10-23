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
        public static SceneObject bulletObj = new SceneObject();
        public static SpriteObject bulletSpr = new SpriteObject();


        public static SceneObject[] bulletObjects = new SceneObject[5];
        public static SpriteObject[] bulletSprites = new SpriteObject[5];

        public static Timer timer = new Timer();

        public static Tank tank = new Tank();

        public static float speed = 100;
        public static float direction = 2;
        Vector3 velocity = new Vector3(speed, direction, 1);

        

        public Bullet()
        {

        }
       
        // load bullet image and assign parent/child relationship
        public void LoadAmmo(string bulletImageFilePath)
        {
            bulletSpr.Load(bulletImageFilePath);

            bulletSpr.SetRotate(90 * (float)(Math.PI / 180.0f));

            bulletSpr.SetPosition(0, bulletSpr.Width / 2.0f);

            bulletObj.AddChild(bulletSpr);

            
            //// load each sprite into array
            //foreach (SpriteObject bullet in bulletSprites)
            //{


            //    bullet.Load(bulletImageFilePath);

            //    bullet.SetRotate(90 * (float)(Math.PI / 180.0f));

            //    bullet.SetPosition(0, bulletSpr.Width / 2.0f);

            //    bullet.AddChild(bulletSpr);
            //}

        }



        public override void OnUpdate(float deltaTime)
        {
            // press "SPACEBAR" to shoot bullets out of tank barrel - program class or bullet class?
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                // try to shoot bullet, no array
                if (!core_basic_window.bulletInChamber)
                {                     
                    core_basic_window.bulletInChamber = true;
                }

                bulletObj.SetPosition(Tank.tankObject.LocalTransform.m7, Tank.tankObject.LocalTransform.m8);
                bulletObj.Rotate(0);


                //// shooting with an array - work in progress 
                //for (int i = 0; i < 5; i++)
                //{
                //    int shootingBullet = i;

                //    Vector3 pos = new Vector3(bulletObjects[shootingBullet].LocalTransform.m1 * 500, bulletObjects[shootingBullet].LocalTransform.m2 * 500, 1) * deltaTime;

                //    if (!core_basic_window.bulletActive[i])
                //    {



                //        core_basic_window.bulletObjects[shootingBullet].SetPosition(Tank.tankObject.LocalTransform.m7, Tank.tankObject.LocalTransform.m8);
                //        core_basic_window.bulletActive[0] = true;

                //    }

                //}

            }
            if (core_basic_window.bulletInChamber)
            {

                //tank.OnUpdate(timer.DeltaTime);
                //bulletObj.SetPosition(tank.LocalTransfrom.m1, tank.LocalTransfrom.m2);
                //bulletObj.UpdateTransform();

                Vector3 posi = new Vector3(bulletObj.LocalTransform.m1 * 500, bulletObj.LocalTransform.m2 * 500, 1) * (deltaTime);

                bulletObj.Translate(posi.x, posi.y);

                if (bulletObj.LocalTransform.m7 >= GetScreenWidth() || bulletObj.LocalTransform.m8 >= GetScreenHeight())
                {
                    core_basic_window.bulletInChamber = false;
                    
                }
                if(bulletObj.LocalTransform.m7 <= 0 || bulletObj.LocalTransform.m8 <= 0 )
                {
                    core_basic_window.bulletInChamber = false;
                }

                bulletObj.Rotate(0);
                bulletObj.Draw();
            }

            // rotate player counter clockwise
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                bulletObj.Rotate(-deltaTime);


            }
            // rotates player clockwise
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                bulletObj.Rotate(deltaTime);

            }
            // rotates turret counter clockwise
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                bulletObj.Rotate(-deltaTime);


            }
            // rotates turret clockwise
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                bulletObj.Rotate(deltaTime);

            }

        }


        // draws object loaded
        public override void OnDraw()
        {
            
            bulletObj.Draw();
        }

    }
}
