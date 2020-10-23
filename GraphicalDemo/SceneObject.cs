using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MathClasses;
using Raylib_cs;

namespace GraphicalDemo
{
    public class SceneObject
    {
        // set parent to none when first declared
        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();

        // custom Matric class holding position
        protected Matrix3 localTransform = new Matrix3();
        protected Matrix3 globalTransform = new Matrix3();
        
        // matrix3 local
        public Matrix3 LocalTransform
        {
            get { return localTransform; }
        }

        // matrix3 global
        public Matrix3 GlobalTransform
        {
            get { return globalTransform; }
        }

        // returns parent
        public SceneObject Parent
        {
            get { return parent; }
        }

        // blank SceneObject 
        public SceneObject()
        {
        }

        // returns amount children an object has
        public int GetChildCount()
        {
            return children.Count;
        }

        // access Child by index number
        public SceneObject GetChild (int index)
        {
            return children[index];
        }

        // add Child to Parent 
        public void AddChild(SceneObject child)
        {
            // makes sure the parent is empty
            Debug.Assert(child.parent == null);
            // assigns as parent
            child.parent = this;
            // add new child
            children.Add(child);
        }

        // remove Child from Parent
        public void RemoveChild(SceneObject child)
        {
            if(children.Remove(child) == true)
            {
                child.parent = null;
            }
        }

        //Destructor
        ~SceneObject()
        {
            if(parent != null)
            {
                parent.RemoveChild(this);
            }

            foreach (SceneObject obj in children)
            {
                obj.parent = null;
            }
        }

        // on update method,  implement specific behaviours
        public virtual void OnUpdate(float deltaTime)
        {
            
        }

        // draw method, implement specific drawing behaviours
        public virtual void OnDraw()
        {

        }

        // update method
        public void Update(float deltaTime)
        {
            // run behaviour
            OnUpdate(deltaTime);

            // update children
            foreach (SceneObject child in children)
            {
                child.Update(deltaTime);
            }
        }

        // draw method 
        public void Draw()
        {
            // run OnDraw behaviour
            OnDraw();

            // draw children
            foreach (SceneObject child in children)
            {
                child.Draw();
            }
        }

        // update global transform and mulitply by local to move, set equal if not moved
        public void UpdateTransform()
        {
            if(parent != null)
            {
                globalTransform = parent.globalTransform * localTransform;
            }
            else
            {
                globalTransform = localTransform;
            }

            foreach (SceneObject child in children)
            {
                child.UpdateTransform();
            }
        }

        #region TransformChanges
        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }

        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }

        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }

        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateTransform();
        }

        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }

        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }
        #endregion
    }
}
