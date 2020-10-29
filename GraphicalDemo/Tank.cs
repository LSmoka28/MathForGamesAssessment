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
    class Tank : SpriteObject
    {
        // new SceneObject for tank parent and a child tank SpriteObject
        public static SceneObject tankObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();

        // new SceneObject to turret parent and a child turret SpriteObject
        public static SceneObject turretObject = new SceneObject();
        public static SpriteObject turretSprite = new SpriteObject();

        // Vector3 of velocity
        public static float speed = 100;
        public static float distance = 2;
        Vector3 velocity = new Vector3(speed, distance, 1);

        // create uninitialized tank
        public Tank()
        {
            // left blank intentionally
        }
        
        // unload images
        ~Tank()
        {
            // left blank intentionally
        }

        // load sprites and attach turret
        public void Setup(string tankImageFilePath, string turretImageFilePath)
        {
            //load tank
            tankSprite.Load(tankImageFilePath);
            // flip the tank 90 deg
            tankSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            // set an offset fo that it has a center
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            // load turret
            turretSprite.Load(turretImageFilePath);
            // rotate 90 deg
            turretSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            // set offset for center point
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);

            //set hierarchy
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);

            // set position of object to center of window
            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        }


        // update tank/turrent movement
        public override void OnUpdate(float deltaTime)
        {

            // rotate object counter clockwise
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(deltaTime * 2);
            }
            // rotates object clockwise
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(-deltaTime *2);               
            }
            // moves object forward
            if (IsKeyDown(KeyboardKey.KEY_W))
            {                
                Vector3 pos = new Vector3(tankObject.LocalTransform.m1 * (velocity.x * velocity.y), tankObject.LocalTransform.m2 * (velocity.x * velocity.y), 1) * deltaTime;
                tankObject.Translate(pos.x, pos.y);               
            }
            // moves object backwards
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 pos = new Vector3(tankObject.LocalTransform.m1 * (velocity.x * velocity.y), tankObject.LocalTransform.m2 * (velocity.x * velocity.y), 1) * -deltaTime;
                tankObject.Translate(pos.x, pos.y);               
            }
            // rotates turret counter clockwise
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(deltaTime * 2);
            }
            // rotates turret clockwise
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(-deltaTime * 2);
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

            // update object
            tankObject.Update(deltaTime);            
        }

        // draw object to screen
        public override void OnDraw()
        {
            tankObject.Draw();
        }        
    }
}
