using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;

namespace projectUTS
{
    class C_Ellipsoid
    {
        protected List<Vector3> _ellipsoid_vertices = new List<Vector3>();
        protected int _ellipsoid_index = 0;
        private int _vertexBufferObject_ellipsoid;
        private int _vertexArrayObject_ellipsoid;
        private Shader _shader_ellipsoid;
        protected Matrix4 transform;
        protected int timer = 0;
        protected int count = 0;

        public C_Ellipsoid()
        {
        }

        public void createEllipsoidVertices()
        {
            float _positionX = 0.55f;
            float _positionY = -1.15f;
            float _positionZ = 0.0f;

            float _radiusX = 0.14f;
            float _radiusY = 0.14f;
            float _radiusZ = 0.14f;
            Vector3 tempvector;
            float _pi = 3.14159f;

            for (float u = -_pi / 2; u <= _pi / 2; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    tempvector.X = _positionX + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u); // x
                    tempvector.Y = _positionY + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); // y
                    tempvector.Z = _positionZ + _radiusZ * (float)Math.Sin(v); // z
                    _ellipsoid_vertices.Add(tempvector);
                }
            }
        }

        public void createGroundVertices(float _x, float _y, float _z, float _rx, float _ry, float _rz)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _radiusX = _rx;
            float _radiusY = _ry;
            float _radiusZ = _rz;
            Vector3 tempvector;
            float _pi = 3.14159f;

            for (float u = -_pi; u <= _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    tempvector.X = _positionX + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u); // x
                    tempvector.Y = _positionY + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); // y
                    tempvector.Z = _positionZ + _radiusZ * (float)Math.Sin(v); // z
                    _ellipsoid_vertices.Add(tempvector);
                }
            }
        }

        public void setEllipsoid()
        {
            transform = Matrix4.Identity;
            // VBO
            _vertexBufferObject_ellipsoid = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_ellipsoid);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _ellipsoid_vertices.Count * Vector3.SizeInBytes,
                _ellipsoid_vertices.ToArray(), BufferUsageHint.StaticDraw);
            // VAO
            _vertexArrayObject_ellipsoid = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_ellipsoid);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_ellipsoid = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/C_ShaderSubmarine.frag");
            _shader_ellipsoid.Use();

            scale(0.6f);
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(180f));
        }

        public void renderEllipsoid()
        {
            _shader_ellipsoid.Use();
            _shader_ellipsoid.SetMatrix4("transform", transform);

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

            GL.BindVertexArray(_vertexArrayObject_ellipsoid);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, _ellipsoid_vertices.Count);
        }

        public void setGround()
        {
            transform = Matrix4.Identity;
            // VBO
            _vertexBufferObject_ellipsoid = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_ellipsoid);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _ellipsoid_vertices.Count * Vector3.SizeInBytes,
                _ellipsoid_vertices.ToArray(), BufferUsageHint.StaticDraw);
            // VAO
            _vertexArrayObject_ellipsoid = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_ellipsoid);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_ellipsoid = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shaderGround.frag");
            _shader_ellipsoid.Use();

            scale(0.6f);
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(180f));
        }

        public void renderGround()
        {
            _shader_ellipsoid.Use();
            _shader_ellipsoid.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject_ellipsoid);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, _ellipsoid_vertices.Count);
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