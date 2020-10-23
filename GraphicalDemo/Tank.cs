﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Examples;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GraphicalDemo
{
    class Tank : SpriteObject
    {

        public static SceneObject tankObject = new SceneObject();
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


        // update tank/turrent movement
        public override void OnUpdate(float deltaTime)
        {

            // rotate player counter clockwise
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(-deltaTime);
                


            }
            // rotates player clockwise
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(deltaTime);
                

            }
            // moves player forward
            if (IsKeyDown(KeyboardKey.KEY_W))
            {                
                Vector3 pos = new Vector3(tankObject.LocalTransform.m1 * (velocity.x * velocity.y), tankObject.LocalTransform.m2 * (velocity.x * velocity.y), 1) * deltaTime;
                tankObject.Translate(pos.x, pos.y);
                
            }
            // moves player backwards
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 pos = new Vector3(tankObject.LocalTransform.m1 * (velocity.x * velocity.y), tankObject.LocalTransform.m2 * (velocity.x * velocity.y), 1) * -deltaTime;
                tankObject.Translate(pos.x, pos.y);
                
            }
            // rotates turret counter clockwise
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(-deltaTime);


            }
            // rotates turret clockwise
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(deltaTime);

            }

            // resets tank position to correct opposite side of player exited window
            if(tankObject.LocalTransform.m7 > GetScreenWidth())
            {
                tankObject.SetPosition(0, GetScreenHeight() / 2);
            }
            if (tankObject.LocalTransform.m8 > GetScreenHeight())
            {
                tankObject.SetPosition(GetScreenWidth() / 2, 0);
            }
            if (tankObject.LocalTransform.m7 < 0)
            {
                tankObject.SetPosition(GetScreenWidth(), GetScreenHeight() / 2);
            }
            if (tankObject.LocalTransform.m8 < 0)
            {
                tankObject.SetPosition(GetScreenWidth() / 2, GetScreenHeight());
            }

            tankObject.Update(deltaTime);
            

        }

        public override void OnDraw()
        {
            tankObject.Draw();
        }

        private SpriteObject m_turret;

    }
}
