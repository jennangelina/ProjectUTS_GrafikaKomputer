using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Mathematics;

namespace projectUTS
{
    class J_Bezier
    {
        protected List<Vector3> vertices = new List<Vector3>();
        protected List<Vector3> temp_vertices = new List<Vector3>();
        protected List<uint> vertexIndices = new List<uint>();
        protected int _vertexBufferObject;
        protected int _vertexArrayObject;
        public List<J_Bezier> child = new List<J_Bezier>();
        protected Shader _shader;
        protected Matrix4 transform;
        protected int count = 0;
        protected int timer = 0;

        public J_Bezier()
        {
        }

        public void createBezier(float rx, float ry, float rz)
        {
            int i = 0;

            Vector3 temp_vector;
            temp_vector.X = temp_vertices[i].X;
            temp_vector.Y = temp_vertices[i].Y;
            temp_vector.Z = temp_vertices[i].Z;
            vertices.Add(temp_vector);
            i++;

            for (float t = 0; t < 1.0f; t += 0.01f)
            {
                Vector3 p;
                p.X = 0;
                p.Y = 0;
                p.Z = 0;
                int[] pascal = new int[temp_vertices.Count + 1];
                int rows = temp_vertices.Count - 1;
                int angka = 1;
                for (int j = 0; j <= rows; j++)
                {
                    pascal[j] = angka;
                    angka = angka * (rows - j) / (j + 1);
                }
                for (int j = 0; j < temp_vertices.Count; j++)
                {
                    float a = pascal[j] * (float)Math.Pow((1 - t), (temp_vertices.Count - (j + 1))) * (float)Math.Pow(t, j);
                    p.X += a * temp_vertices[j].X; 
                    p.Y += a * temp_vertices[j].Y;
                    p.Z += a * temp_vertices[j].Z;
                }

                float _radiusX = rx;
                float _radiusY = ry;
                float _radiusZ = rz;
                float _pi = 3.14159f;
                float _cx = _radiusX;
                float _cy = _radiusY;

                for (float u = -_pi; u <= _pi; u += _pi / 200)
                {
                    for (float v = -_pi / 2; v < _pi / 2; v += _pi / 200)
                    {
                        temp_vector.X = p.X + (float)Math.Cos(u) * _radiusX; 
                        temp_vector.Y = p.Y + (float)Math.Sin(u) * _radiusY;
                        temp_vector.Z = p.Z + v * _radiusZ;
                        vertices.Add(temp_vector);
                    }
                }
                i++;
            }
        }

        public void setupObject()
        {
            transform = Matrix4.Identity;
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes, vertices.ToArray(),BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            _shader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/J_ShaderTube.frag"); 
            _shader.Use();
        }
        public void render()
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.LineStrip,
               0, vertices.Count);
            foreach (var meshobj in child)
            {
                meshobj.render();
            }
        }
        public void addPoint(float x, float y, float z)
        {
            temp_vertices.Add(new Vector3(x, y, z));
        }

        public void scale(float x)
        {
            transform = transform * Matrix4.CreateScale(x);
            foreach (var meshobj in child)
            {
                meshobj.scale(x);
            }
        }

        public void translate()
        {
            transform = transform * Matrix4.CreateTranslation(0.0f, 0.1f, 0.0f);
            foreach (var meshobj in child)
            {
                meshobj.translate();
            }
        }

        public void rotate(float _x, float _y, float _z)
        {
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_x));
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_y));
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_z));
        }
    }
}