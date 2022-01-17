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
    class C_Tabung
    {
        protected List<Vector3> _tabung_vertices = new List<Vector3>();
        protected int _tabung_index = 0;
        protected int _vertexBufferObject_tabung;
        protected int _vertexArrayObject_tabung;
        protected Shader _shader_tabung;
        protected Matrix4 transform;
        protected int timer = 0;
        protected int count = 0;

        public C_Tabung()
        {
        }

        public void createTabungVertices()
        {
            float _positionX = 0.0f;
            float _positionY = -1.15f;
            float _positionZ = 0.0f;

            float _radiusX = 0.14f;
            float _radiusY = 0.14f;
            float _radiusZ = 0.36f;

            Vector3 tempvector;

            float _pi = 3.14159f;

            for (float u = -_pi; u <= _pi; u += _pi / 200)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 200)
                {
                    tempvector.X = _positionX + (float)Math.Cos(u) * _radiusX; // x
                    tempvector.Y = _positionY + (float)Math.Sin(u) * _radiusY; // y
                    tempvector.Z = _positionZ + v * _radiusZ; // z
                    _tabung_vertices.Add(tempvector);
                }
            }
        }

        public void setTabung()
        {
            transform = Matrix4.Identity;
            // VBO
            _vertexBufferObject_tabung = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_tabung);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _tabung_vertices.Count * Vector3.SizeInBytes,
                _tabung_vertices.ToArray(), BufferUsageHint.StaticDraw);
            // VAO
            _vertexArrayObject_tabung = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_tabung);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_tabung = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/C_ShaderSubmarine.frag");
            _shader_tabung.Use();

            scale(0.6f);
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
        }

        public void renderTabung()
        {
            _shader_tabung.Use();
            _shader_tabung.SetMatrix4("transform", transform);

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

            GL.BindVertexArray(_vertexArrayObject_tabung);
            GL.DrawArrays(PrimitiveType.Lines, 0, _tabung_vertices.Count);
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