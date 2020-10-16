using System;
using System.Collections.Generic;
using System.Text;
using MathClasses;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GraphicalDemo
{
    // inherits from SceneObject class
    public class SpriteObject : SceneObject
    {
        // add member variable for Texture
        Texture2D texture = new Texture2D();
        Image image = new Image();

        // gets width of texture
        public float Width
        {
            get { return texture.width; }
        }

        // gets height of texture
        public float Height
        {
            get { return texture.height; }
        }
        // blank sprite
        public SpriteObject()
        {
        }

        // loads an image from file
        public void Load(string filename)
        {
            Image img = LoadImage(filename);
            texture = LoadTextureFromImage(img);
        }

        // custom draw method when loading image
        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(globalTransform.m2, globalTransform.m1);

            DrawTextureEx(
                texture, 
                new System.Numerics.Vector2(globalTransform.m7, globalTransform.m8),
                rotation * (float)(180.0f / Math.PI),
                1, Color.WHITE);



            base.OnDraw();
        }

    }
}
