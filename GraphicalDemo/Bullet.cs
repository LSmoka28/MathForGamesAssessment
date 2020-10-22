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

            //turretObject.AddChild(bulletObject);


            bulletObj.SetPosition((GetScreenWidth() / 2.0f), (GetScreenHeight() / 2.0f));


            // load each sprite into array
            foreach (SceneObject bullet in bulletObjects)
            {

            }

        }



        public override void OnUpdate(float deltaTime)
        {
            // press "SPACEBAR" to shoot bullets out of tank barrel - program class or bullet class?
            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                // try to shoot bullet, no array
                if (!core_basic_window.bulletInChamber)
                {

                    Vector3 posi = new Vector3(bulletObj.LocalTransfrom.m1 * 100, bulletObj.LocalTransfrom.m2 * 100, 1) * (deltaTime);
                    
                    bulletObj.Translate(++posi.x, ++posi.y);


                    core_basic_window.bulletInChamber = true;
                }

                //// shooting with an array - work in progress 
                //for (int i = 0; i < 5; i++)
                //{
                //    int shootingBullet = i;

                //    Vector3 pos = new Vector3(bulletObjects[shootingBullet].LocalTransfrom.m1 * 500, bulletObjects[shootingBullet].LocalTransfrom.m2 * 500, 1) * deltaTime;

                //    if (!core_basic_window.bulletActive[i])
                //    {



                //        core_basic_window.bulletObjects[shootingBullet].Rotate(0);
                //        core_basic_window.bulletObjects[shootingBullet].Translate(pos.x, pos.y);
                //    }

                //}

            }
            if (core_basic_window.bulletInChamber)
            {

                bulletObj.Draw();

            }

        }


        // draws object loaded
        public override void OnDraw()
        {
            
            bulletObj.Draw();
        }

    }
}
