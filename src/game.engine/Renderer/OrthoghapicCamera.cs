using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Renderer
{
    public class OrthogaphicCamera
    {
        private Vector3 _position;
        private float _rotation;
        public OrthogaphicCamera(float left, float right, float bottom, float top)
        {
            ProjectionMatrix = Math1.Ortho(left, right, bottom, top, -1.0f, 1.0f);
            ViewMatrix = Matrix4.Identity();
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;
        }

        public Matrix4 ProjectionMatrix { get; private set; }
        public Matrix4 ViewMatrix { get; private set; }
        public Matrix4 ViewProjectionMatrix { get; private set; }

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                RecalculateViewMatrix();
            }
        }
        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                RecalculateViewMatrix();
            }
        }

        private void RecalculateViewMatrix()
        {
            var transform = Math1.Translate(Matrix4.Identity(), _position)
                * Math1.Rotate(Matrix4.Identity(), Math1.Radians(_rotation), new Vector3(0, 0, 1));

            ViewMatrix = transform.Inverse();
            ViewProjectionMatrix = ProjectionMatrix * ViewMatrix;

        }
    }
}
