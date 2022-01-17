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
    class C_Awan
    {
        protected Matrix4 transform;
        protected int timer = 0;
        protected int count = 0;
        // elipsoid awan
        protected List<Vector3> _elAwan_vertices = new List<Vector3>();
        protected int _elAwan_index = 0;
        private int _vertexBufferObject_elAwan;
        private int _vertexArrayObject_elAwan;
        private Shader _shader_elAwan;

        public C_Awan()
        {
        }

        public void createElAwanVertices(float _x, float _y, float _z, float _l, float _w, float _h)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _radiusX = _l;
            float _radiusY = _w;
            float _radiusZ = _h;
            Vector3 tempvector;
            float _pi = 3.14159f;

            for (float u = -_pi; u <= _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    tempvector.X = _positionX + _radiusX * (float)Math.Cos(v) * (float)Math.Cos(u); // x
                    tempvector.Y = _positionY + _radiusY * (float)Math.Cos(v) * (float)Math.Sin(u); // y
                    tempvector.Z = _positionZ + _radiusZ * (float)Math.Sin(v); // z
                    _elAwan_vertices.Add(tempvector);
                }
            }
        }

        public void setAwan()
        {
            transform = Matrix4.Identity;

            //ellipsoid awan
            // VBO
            _vertexBufferObject_elAwan = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_elAwan);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _elAwan_vertices.Count * Vector3.SizeInBytes,
                _elAwan_vertices.ToArray(), BufferUsageHint.StaticDraw);
            // VAO
            _vertexArrayObject_elAwan = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_elAwan);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_elAwan = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/C_ShaderAwan.frag");
            _shader_elAwan.Use();

            scale(0.6f);
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
        }

        public void renderAwan()
        {
            //ellipsoid awan
            _shader_elAwan.Use();
            _shader_elAwan.SetMatrix4("transform", transform);

            GL.BindVertexArray(_vertexArrayObject_elAwan);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, _elAwan_vertices.Count);

            if (timer == 10)
            {
                if (count > 1 && count < 6)
                {
                    transform = transform * Matrix4.CreateTranslation(0.02f, 0.0f, 0.0f);
                }
                else if (count > 5 && count < 10)
                {
                    transform = transform * Matrix4.CreateTranslation(-0.02f, 0.0f, 0.0f);
                }
                if (count == 10)
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