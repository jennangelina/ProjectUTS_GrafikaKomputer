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
    class C_Balok
    {
        protected List<Vector3> _balok_vertices = new List<Vector3>();
        private int _vertexBufferObject_balok;
        private int _vertexArrayObject_balok;
        protected int _elementBufferObject_balok;
        private Shader _shader_balok;
        protected List<uint> vertexIndices = new List<uint>(); 
        protected Matrix4 transform;
        protected int timer = 0;
        protected int count = 0;

        public C_Balok()
        {
        }

        public void createBalok(float _x, float _y, float _z, float _l, float _w, float _h)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _boxLength = _l;
            float _boxWidth = _w;
            float _boxHeight = _h;

            Vector3 temp_vector;

            // titik 1
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            _balok_vertices.Add(temp_vector);

            // titik 2
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            _balok_vertices.Add(temp_vector);

            // titik 3
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            _balok_vertices.Add(temp_vector);

            // titik 4
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            _balok_vertices.Add(temp_vector);

            // titik 5
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z

            _balok_vertices.Add(temp_vector);

            // titik 6
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z
            _balok_vertices.Add(temp_vector);
            // titik 7
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z
            _balok_vertices.Add(temp_vector);
            // titik 8
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z
            _balok_vertices.Add(temp_vector);

            vertexIndices = new List<uint>
            {
                //segitiga depan 1
                0,1,2,
                //segitiga depan 2
                1,2,3,
                //segitiga atas 1
                0,4,5,
                //segitiga atas 2
                0,1,5,
                //segitiga kanan 1
                1,3,5,
                //segitiga kanan 2
                3,5,7,
                //segitiga kiri 1
                0,2,4,
                //segitiga kiri2
                2,4,6,
                //segitiga belakang 1
                4,5,6,
                //segitiga belakang 2
                5,6,7,
                //segitiga bawah 1
                3,6,2,
                //segitiga bawah 2
                6,7,3
            };
        }

        public void setBalok()
        {
            transform = Matrix4.Identity;
            // Tabung
            // VBO
            _vertexBufferObject_balok = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_balok);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _balok_vertices.Count * Vector3.SizeInBytes,
                _balok_vertices.ToArray(), BufferUsageHint.StaticDraw);
            // VAO
            _vertexArrayObject_balok = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_balok);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _elementBufferObject_balok = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject_balok);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
            vertexIndices.Count * sizeof(uint), vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
            // Shader
            _shader_balok = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/C_shaderBalok.frag");
            _shader_balok.Use();
            scale(0.6f);
        }

        public void setBaling()
        {
            transform = Matrix4.Identity;
            // Tabung
            // VBO
            _vertexBufferObject_balok = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_balok);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _balok_vertices.Count * Vector3.SizeInBytes,
                _balok_vertices.ToArray(), BufferUsageHint.StaticDraw);
            // VAO
            _vertexArrayObject_balok = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_balok);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _elementBufferObject_balok = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject_balok);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
            vertexIndices.Count * sizeof(uint), vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
            //baling
            _shader_balok = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/C_shaderBaling.frag");
            _shader_balok.Use();
            scale(0.5f);
        }

        public void renderBalok()
        {           
            _shader_balok.Use();
            _shader_balok.SetMatrix4("transform", transform);

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

            GL.BindVertexArray(_vertexArrayObject_balok);
            GL.DrawElements(PrimitiveType.TriangleFan, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void renderBaling()
        {
            _shader_balok.Use();
            _shader_balok.SetMatrix4("transform", transform);

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

            GL.BindVertexArray(_vertexArrayObject_balok);
            GL.DrawElements(PrimitiveType.TriangleFan, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void renderGround()
        {
            _shader_balok.Use();
            _shader_balok.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject_balok);
            GL.DrawElements(PrimitiveType.TriangleFan, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void renderAlas()
        {
            _shader_balok.Use();
            _shader_balok.SetMatrix4("transform", transform);
            GL.BindVertexArray(_vertexArrayObject_balok);
            GL.DrawElements(PrimitiveType.TriangleFan, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
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

        public void rotateBaling()
        {
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.7f));
        }

        public void scale(float x)
        {
            transform = transform * Matrix4.CreateScale(x);
        }
    }
}

