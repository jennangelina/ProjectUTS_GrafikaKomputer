using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;

namespace projectUTS
{
    class C_Elliptic
    {
        protected List<Vector3> _elliptic_vertices = new List<Vector3>();
        protected int _elliptic_index = 0;
        private int _vertexBufferObject_elliptic;
        private int _vertexArrayObject_elliptic;
        private Shader _shader_elliptic;
        protected Matrix4 transform;
        protected int timer = 0;
        protected int count = 0;

        public C_Elliptic()
        {
        }

        public void createEllipticVertices()
        {
            float _positionX = -0.0f; 
            float _positionY = 1.15f; 
            float _positionZ = -0.83f; 

            float _radiusX = 0.08f;
            float _radiusY = 0.09f;
            float _radiusZ = 0.11f;

            Vector3 tempvector;
            float _pi = 3.14159f;

            for (float u = -_pi; u < _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    tempvector.X = v * (float)Math.Cos(u) * _radiusX + _positionX;
                    tempvector.Y = v * (float)Math.Sin(u) * _radiusY + _positionY;
                    tempvector.Z = v * v * _radiusZ + _positionZ;
                    _elliptic_vertices.Add(tempvector);
                }
            }
        }

        public void setElliptic()
        {
            transform = Matrix4.Identity;
            // VBO
            _vertexBufferObject_elliptic = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_elliptic);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _elliptic_vertices.Count * Vector3.SizeInBytes,
                _elliptic_vertices.ToArray(), BufferUsageHint.StaticDraw);
            // VAO
            _vertexArrayObject_elliptic = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_elliptic);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_elliptic = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/C_ShaderSubmarine.frag");
            _shader_elliptic.Use();

            scale(0.6f);

            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f));
        }

        public void renderElliptic()
        {
            _shader_elliptic.Use();
            _shader_elliptic.SetMatrix4("transform", transform);

            if (timer == 10)
            {
                if (count > 12 && count < 23)
                {
                    transform = transform * Matrix4.CreateTranslation(-0.1f, 0.0f, 0.0f);
                }
                else if (count > 23 && count < 33)
                {
                    transform = transform * Matrix4.CreateTranslation(0.1f, 0.0f, 0.0f);
                }
                if (count == 33)
                {
                    count = 0;
                }
                timer = 0;
                count++;
            }
            else
            {
                timer++;
            }

            GL.BindVertexArray(_vertexArrayObject_elliptic);
            GL.DrawArrays(PrimitiveType.Lines, 0, _elliptic_vertices.Count);
        }

        public void rotate(float _x, float _y, float _z)
        {
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_x));
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_y));
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_z));
        }

        public void translate()
        {
            transform = transform * Matrix4.CreateTranslation(0.0f, -0.1f, 0.0f);
        }

        public void scale(float x)
        {
            transform = transform * Matrix4.CreateScale(x);
        }
    }
}