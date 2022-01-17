using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;

namespace projectUTS
{
    class F_Fountain
    {
        // Fountain 1
        List<Vector3> _fountain_1_vertices = new List<Vector3>();
        int _vertexBufferObject_fountain_1;
        int _vertexArrayObject_fountain_1;
        int _fountain_1_index = 0;
        int counter_fountain_1 = 0;
        int putaran_fountain_1 = 1;
        Shader _shader_fountain_1;
        Matrix4 transform_fountain_1;


        // Fountain 2
        List<Vector3> _fountain_2_vertices = new List<Vector3>();
        int _vertexBufferObject_fountain_2;
        int _vertexArrayObject_fountain_2;
        int _fountain_2_index = 0;
        Shader _shader_fountain_2;
        Matrix4 transform_fountain_2;

        // Fountain 3
        List<Vector3> _fountain_3_vertices = new List<Vector3>();
        int _vertexBufferObject_fountain_3;
        int _vertexArrayObject_fountain_3;
        int _fountain_3_index = 0;
        Shader _shader_fountain_3;
        Matrix4 transform_fountain_3;

        public void createfountain1(float _x, float _y, float _z)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _radius = 0.75f;

            float _pi = 3.14159f;

            for (float u = -_pi; u < _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    _fountain_1_vertices.Add(new Vector3(v * (float)Math.Cos(u) * _radius + _positionX,
                                             v * (float)Math.Sin(u) * _radius + _positionY,
                                              v * v + _positionZ));
                    _fountain_1_index++;
                }
            }
        }

        public void createfountain2(float _x, float _y, float _z)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _radius = 0.75f;

            float _pi = 3.14159f;

            for (float u = -_pi; u < _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    _fountain_2_vertices.Add(new Vector3(v * (float)Math.Cos(u) * _radius + _positionX,
                                             v * (float)Math.Sin(u) * _radius + _positionY,
                                              v * v + _positionZ));
                    _fountain_2_index++;
                }
            }
        }

        public void createfountain3(float _x, float _y, float _z)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _radius = 0.75f;

            float _pi = 3.14159f;

            for (float u = -_pi; u < _pi; u += _pi / 30)
            {
                for (float v = -_pi / 2; v < _pi / 2; v += _pi / 30)
                {
                    _fountain_3_vertices.Add(new Vector3(v * (float)Math.Cos(u) * _radius + _positionX,
                                             v * (float)Math.Sin(u) * _radius + _positionY,
                                              v * v + _positionZ));
                    _fountain_3_index++;
                }
            }
        }

        public void rotate(float _x, float _y, float _z)
        {
            // untuk berputar x y z ---------------------------------------------------------------------------------------------
            //sumbu X
            transform_fountain_1 = transform_fountain_1 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_x));
            transform_fountain_1 = transform_fountain_1 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_y));
            transform_fountain_1 = transform_fountain_1 * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_z));

            transform_fountain_2 = transform_fountain_2 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_x));
            transform_fountain_2 = transform_fountain_2 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_y));
            transform_fountain_2 = transform_fountain_2 * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_z));

            transform_fountain_3 = transform_fountain_3 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(_x));
            transform_fountain_3 = transform_fountain_3 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(_y));
            transform_fountain_3 = transform_fountain_3 * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(_z));
        }

        public void scale()
        {
            // untuk besar atau kecil gambar ----------------------------------------------------------------------
            transform_fountain_1 = transform_fountain_1 * Matrix4.CreateScale(0.1f);
            transform_fountain_2 = transform_fountain_2 * Matrix4.CreateScale(0.1f);
            transform_fountain_3 = transform_fountain_3 * Matrix4.CreateScale(0.1f);
        }

        public void OnLoad()
        {
            transform_fountain_1 = Matrix4.Identity;
            transform_fountain_2 = Matrix4.Identity;
            transform_fountain_3 = Matrix4.Identity;

            // Fountain 1
            // VBO
            _vertexBufferObject_fountain_1 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_fountain_1);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _fountain_1_vertices.Count * Vector3.SizeInBytes,
                _fountain_1_vertices.ToArray(), BufferUsageHint.StaticDraw);

            // VAO
            _vertexArrayObject_fountain_1 = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_fountain_1);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_fountain_1 = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/F_ShaderBawah.frag");
            _shader_fountain_1.Use();

            // Fountain 2
            // VBO
            _vertexBufferObject_fountain_2 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_fountain_2);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _fountain_2_vertices.Count * Vector3.SizeInBytes,
                _fountain_2_vertices.ToArray(), BufferUsageHint.StaticDraw);

            // VAO
            _vertexArrayObject_fountain_2 = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_fountain_2);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_fountain_2 = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/F_ShaderTengah.frag"); 
            _shader_fountain_2.Use();

            // Fountain 3
            // VBO
            _vertexBufferObject_fountain_3 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject_fountain_3);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, _fountain_3_vertices.Count * Vector3.SizeInBytes,
                _fountain_3_vertices.ToArray(), BufferUsageHint.StaticDraw);

            // VAO
            _vertexArrayObject_fountain_3 = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject_fountain_3);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            // Shader
            _shader_fountain_3 = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/Shaders/F_ShaderAtas.frag"); 
            _shader_fountain_3.Use();

            transform_fountain_1 = transform_fountain_1 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            transform_fountain_2 = transform_fountain_2 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            transform_fountain_3 = transform_fountain_3 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));

            scale();
        }

        public void RenderFrame()
        {
            rotate(0.0f, 0.7f, 0.0f);

            if (counter_fountain_1 == 10)
            {
                if (putaran_fountain_1 <= 1)
                {
                    transform_fountain_2 = transform_fountain_2 * Matrix4.CreateTranslation(0.0f, 0.24f, 0.0f);
                    transform_fountain_3 = transform_fountain_3 * Matrix4.CreateTranslation(0.0f, 0.24f, 0.0f);
                }
                else if (putaran_fountain_1 > 1 && putaran_fountain_1 <= 2)
                {
                    transform_fountain_3 = transform_fountain_3 * Matrix4.CreateTranslation(0.0f, 0.24f, 0.0f);
                }
                else if (putaran_fountain_1 > 2 && putaran_fountain_1 <= 3)
                {
                    transform_fountain_3 = transform_fountain_3 * Matrix4.CreateTranslation(0.0f, -0.24f, 0.0f);
                }
                else if (putaran_fountain_1 > 3 && putaran_fountain_1 <= 4)
                {
                    transform_fountain_2 = transform_fountain_2 * Matrix4.CreateTranslation(0.0f, -0.24f, 0.0f);
                    transform_fountain_3 = transform_fountain_3 * Matrix4.CreateTranslation(0.0f, -0.24f, 0.0f);
                }
                if (putaran_fountain_1 == 4)
                {
                    putaran_fountain_1 = 0;
                }
                counter_fountain_1 = 0;
                putaran_fountain_1++;
            }
            else
            {
                counter_fountain_1++;
            }

            // shader fountain 1
            _shader_fountain_1.Use();
            _shader_fountain_1.SetMatrix4("transform", transform_fountain_1); // transformasi atau rotate
            GL.BindVertexArray(_vertexArrayObject_fountain_1);
            GL.DrawArrays(PrimitiveType.Lines, 0, _fountain_1_index);

            // shader fountain 1
            _shader_fountain_2.Use();
            _shader_fountain_2.SetMatrix4("transform", transform_fountain_2); // transformasi atau rotate
            GL.BindVertexArray(_vertexArrayObject_fountain_2);
            GL.DrawArrays(PrimitiveType.Lines, 0, _fountain_2_index);

            // shader fountain 3
            _shader_fountain_3.Use();
            _shader_fountain_3.SetMatrix4("transform", transform_fountain_3); // transformasi atau rotate
            GL.BindVertexArray(_vertexArrayObject_fountain_3);
            GL.DrawArrays(PrimitiveType.Lines, 0, _fountain_3_index);
        }
    }
}
