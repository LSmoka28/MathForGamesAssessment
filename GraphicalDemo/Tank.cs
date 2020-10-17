﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GraphicalDemo
{
    class Tank : SpriteObject
    {

        SceneObject tankObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();

        SceneObject turretObject = new SceneObject();
        SpriteObject turretSprite = new SpriteObject();

        SceneObject bulletObject = new SceneObject();
        SpriteObject bulletSprite = new SpriteObject();

        Timer timer = new Timer();

        public static float speedX = 100;
        public static float direction = 2;


        public static string bulletFile = @"ref\bulletRedSilver.png";

        Vector3 velocity = new Vector3(speedX, direction, 1);
        Vector3 position = new Vector3(GetScreenWidth() / 2, GetScreenHeight() / 2, 1);
        
     

        // create uninitialized tank
        public Tank()
        {

        }

        // load sprites and attach turret
        public Tank(string tankImageFilePath, string turretImageFilePath)
        {
            //load tank
            tankSprite.Load(tankImageFilePath);
            // flip the tank 90 deg
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // set an offset fo that it has a center
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            // load turret
            turretSprite.Load(turretImageFilePath);
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

        // unload images
        ~Tank()
        {

        }

        // load sprites and attach turret
        public void Setup(string tankImageFilePath, string turretImageFilePath)
        {
            //load tank
            tankSprite.Load(tankImageFilePath);
            // flip the tank 90 deg
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            // set an offset fo that it has a center
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            // load turret
            turretSprite.Load(turretImageFilePath);
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

        public void LoadAmmo(string bulletImageFilePath)
        {
            bulletSprite.Load(bulletImageFilePath);

            bulletSprite.SetRotate(90 * (float)(Math.PI / 180.0f));

            bulletSprite.SetPosition(0,     bulletSprite.Width / 2.0f );

            bulletObject.AddChild(bulletSprite);

            //turretObject.AddChild(bulletObject);


            bulletObject.SetPosition((GetScreenWidth() / 2.0f), (GetScreenHeight() / 2.0f));

        }

        // update tank/turrent movement
        public override void OnUpdate(float deltaTime)
        {
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(-deltaTime);
                bulletObject.Rotate(-deltaTime);


            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(deltaTime);
                bulletObject.Rotate(deltaTime);

            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {                
                Vector3 pos = new Vector3(tankObject.LocalTransfrom.m1 * (velocity.x* velocity.y), tankObject.LocalTransfrom.m2 * (velocity.x * velocity.y), 1) * deltaTime;
                tankObject.Translate(pos.x, pos.y);
                bulletObject.Translate(pos.x, pos.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 pos = new Vector3(tankObject.LocalTransfrom.m1 * (velocity.x * velocity.y), tankObject.LocalTransfrom.m2 * (velocity.x * velocity.y), 1) * -deltaTime;
                tankObject.Translate(pos.x, pos.y);
                bulletObject.Translate(pos.x, pos.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(-deltaTime);
                bulletObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(deltaTime);
                bulletObject.Rotate(deltaTime);
            }


            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {

                Vector3 pos = new Vector3(bulletObject.LocalTransfrom.m1 * 500 , bulletObject.LocalTransfrom.m2 * 500, 1) * deltaTime;
                
                
                
                bulletObject.Rotate(0);
                bulletObject.Translate(pos.x, pos.y);

            }

            if (tankObject.LocalTransfrom.m1 > GetScreenWidth())
            {
                tankObject.LocalTransfrom.m1 = 0;
            }

            tankObject.Update(deltaTime);
            bulletObject.Update(deltaTime);

        }

        public override void OnDraw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);
            
            tankObject.Draw();
            bulletObject.Draw();

            EndDrawing();
        }

        private SpriteObject m_turret;

    }
}
