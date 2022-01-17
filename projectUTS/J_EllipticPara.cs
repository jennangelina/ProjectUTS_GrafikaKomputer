using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectUTS
{
    class J_EllipticPara
    {
        protected List<Vector3> vertices = new List<Vector3>();
        protected List<Vector3> textureVertices = new List<Vector3>();
        protected List<Vector3> normals = new List<Vector3>();
        protected int _vertexBufferObject;
        protected int _vertexArrayObject;
        protected Shader _shader;
        protected Matrix4 transform;
        protected int count = 0;
        protected int timer = 0;

        public J_EllipticPara()
        {
        }

        public void createElipticParaboloid(float _x, float _y, float _z)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _radiusX = 0.1f;
            float _radiusY = 0.1f;
            float _radiusZ = 0.18f;

            Vector3 temp_vector;

            float _pi = 3.14159f;

            for (float u = -_pi; u < _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    temp_vector.X = v * (float)Math.Cos(u) * _radiusX + _positionX;
                    temp_vector.Y = v * (float)Math.Sin(u) * _radiusY + _positionY;
                    temp_vector.Z = v * v * _radiusZ + _positionZ;

                    vertices.Add(temp_vector);
                }
            }
        }

        public void setupObject()
        {
            transform = Matrix4.Identity;

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, vertices.Count * Vector3.SizeInBytes,
                vertices.ToArray(), BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.EnableVertexAttribArray(0);

            _shader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/J_ShaderCone.frag");
            _shader.Use();

            scale(0.5f);
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
        }

        public void render()
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);

            if (timer == 2)
            {
                if (count <= 23)
                {
                    transform = transform * Matrix4.CreateTranslation(0.0f, -0.1f, 0.0f);
                }
                timer = 0;
                count++;
            }
            else
            {
                timer++;
            }

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, vertices.Count);
        }

        public void rotate(float _x, float _y, float _z)
        {
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_x));
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_y));
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_z));
        }

        public void translate(float _x, float _y, float _z)
        {
            transform = transform * Matrix4.CreateTranslation(_x, _y, _z);
        }

        public void translate_rev()
        {
            transform = transform * Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);
        }

        public void scale()
        {
            transform = transform * Matrix4.CreateScale(0.01f);
        }

        public void scale(float x)
        {
            transform = transform * Matrix4.CreateScale(x);
        }
    }
}
