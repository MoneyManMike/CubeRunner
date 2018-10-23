﻿using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace CameraLibrary
{
    public class Camera
    {
        private Vector2 position;
        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                TranslationMatrix = Matrix.CreateTranslation(new Vector3(-Position, 0));
            }
        }

        private float rotation;
        public float Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
                RotationMatrix = Matrix.CreateRotationZ(rotation);
            }
        }
        private float zoom;
        public float Zoom
        {
            get => zoom;
            set
            {
                zoom = value;
                ScaleMatrix = Matrix.CreateScale(new Vector3(Zoom, Zoom, 0));
            }
        }
        private Vector2 cameraOffset;
        public Vector2 CameraOffset
        {
            get => cameraOffset;
            set
            {
                cameraOffset = value;
                OffsetMatrix = Matrix.CreateTranslation(new Vector3(CameraOffset, 0));
            }
        }

        public Matrix TranslationMatrix { get; protected set; }
        public Matrix RotationMatrix { get; protected set; }
        public Matrix ScaleMatrix { get; protected set; }
        public Matrix OffsetMatrix { get; protected set; }

        public Matrix Transform => TranslationMatrix * RotationMatrix * ScaleMatrix * OffsetMatrix;       

        public Camera(Vector2 position, float zoom, float rotation, Rectangle screenBounds)
        {
            Position = position;
            Zoom = 1f;
            Rotation = rotation;
            CameraOffset = new Vector2(screenBounds.Width / 2f, screenBounds.Height / 2f);
        }

        public void Reset()
        {
            Zoom = 1f;
            Position = CameraOffset;
            Rotation = 0f;
        }

        public virtual void Update(GameTime gt)
        {

        }
    }
}