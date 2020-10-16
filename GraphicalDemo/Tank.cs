using System;
using System.Collections.Generic;
using System.Text;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GraphicalDemo
{
    class Tank : SpriteObject
    {

        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();


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
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransfrom.m1, tankObject.LocalTransfrom.m2, 1) * deltaTime * 100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransfrom.m1, tankObject.LocalTransfrom.m2, 1) * deltaTime * -100;
                tankObject.Translate(facing.x, facing.y);
            }
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(deltaTime);
            }

            tankObject.Update(deltaTime);
        }

        private SpriteObject m_turret;

    }
}
