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
        SceneObject bulletObj = new SceneObject();
        SpriteObject bulletSpr = new SpriteObject();

        SceneObject[] bulletObjects = new SceneObject[5];
        SpriteObject[] bulletSprites = new SpriteObject[5];



        
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
            
        }

        // draws object loaded
        public override void OnDraw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            bulletObj.Draw();
            

            EndDrawing();
        }

    }
}
