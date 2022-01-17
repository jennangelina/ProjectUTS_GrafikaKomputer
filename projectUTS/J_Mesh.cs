using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectUTS
{
    class J_Mesh
    {
        protected List<Vector3> vertices = new List<Vector3>();
        protected List<Vector3> textureVertices = new List<Vector3>();
        protected List<Vector3> normals = new List<Vector3>();
        protected List<uint> vertexIndices = new List<uint>(); 
        protected int _vertexBufferObject;
        protected int _elementBufferObject;
        protected int _vertexArrayObject;
        protected Shader _shader;
        protected Matrix4 transform;
        protected int count = 0;
        protected int timer = 0;
        protected int countMini = 0;
        protected int timerMini = 0;
        protected int countBalok = 0;
        protected int timerBalok = 0;

        public J_Mesh()
        {
        }

        public void createBox(float _x, float _y, float _z, float _l)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _boxLength = _l;

            Vector3 temp_vector;

            // titik 1
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxLength / 2.0f; // y
            temp_vector.Z = _positionZ - _boxLength / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 2
            temp_vector.X = _positionX + _boxLength / 2.0f; 
            temp_vector.Y = _positionY + _boxLength / 2.0f; 
            temp_vector.Z = _positionZ - _boxLength / 2.0f;

            vertices.Add(temp_vector);

            // titik 3
            temp_vector.X = _positionX - _boxLength / 2.0f; 
            temp_vector.Y = _positionY - _boxLength / 2.0f; 
            temp_vector.Z = _positionZ - _boxLength / 2.0f;
            vertices.Add(temp_vector);

            // titik 4
            temp_vector.X = _positionX + _boxLength / 2.0f; 
            temp_vector.Y = _positionY - _boxLength / 2.0f; 
            temp_vector.Z = _positionZ - _boxLength / 2.0f; 

            vertices.Add(temp_vector);

            // titik 5
            temp_vector.X = _positionX - _boxLength / 2.0f; 
            temp_vector.Y = _positionY + _boxLength / 2.0f; 
            temp_vector.Z = _positionZ + _boxLength / 2.0f; 

            vertices.Add(temp_vector);

            // titik 6
            temp_vector.X = _positionX + _boxLength / 2.0f; 
            temp_vector.Y = _positionY + _boxLength / 2.0f; 
            temp_vector.Z = _positionZ + _boxLength / 2.0f;
            vertices.Add(temp_vector);
            // titik 7
            temp_vector.X = _positionX - _boxLength / 2.0f; 
            temp_vector.Y = _positionY - _boxLength / 2.0f; 
            temp_vector.Z = _positionZ + _boxLength / 2.0f; 
            vertices.Add(temp_vector);
            // titik 8
            temp_vector.X = _positionX + _boxLength / 2.0f;
            temp_vector.Y = _positionY - _boxLength / 2.0f; 
            temp_vector.Z = _positionZ + _boxLength / 2.0f; 
            vertices.Add(temp_vector);

            vertexIndices = new List<uint>
            {
                0,1,2, //segitiga depan 1
                1,2,3, //segitiga depan 2
                0,4,5, //segitiga atas 1
                0,1,5, //segitiga atas 2
                1,3,5, //segitiga kanan 1
                3,5,7, //segitiga kanan 2
                0,2,4, //segitiga kiri 1
                2,4,6, //segitiga kiri2
                4,5,6, //segitiga belakang 1
                5,6,7, //segitiga belakang 2
                3,6,2, //segitiga bawah 1
                6,7,3  //segitiga bawah 2
            };
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

            _shader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/shaders/J_ShaderBox.frag");
            _shader.Use();

            scale(0.5f);
        }

        public void setupElement()
        {
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer,
            vertexIndices.Count * sizeof(uint), vertexIndices.ToArray(), BufferUsageHint.StaticDraw);
        }

        public void render()
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);

            if (timer == 10)
            {
                if (count <= 2)
                {
                    transform = transform * Matrix4.CreateScale(2.0f);
                }
                timer = 0;
                count++;
            }
            else
            {
                timer++;
            }
            if (timer == 10)
            {
                if (count <= 1)
                {
                    transform = transform * Matrix4.CreateTranslation(0.0f, -0.124f, 0.0f);
                }
                timer = 0;
                count++;
            }
            else
            {
                timer++;
            }

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.TriangleFan, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void setupMiniObject()
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

            _shader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/shaders/J_ShaderMini.frag");
            _shader.Use();

            scale(0.5f);
        }

        public void rendermini()
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);

            if (timerMini == 2)
            {
                if (countMini <= 10)
                {
                    transform = transform * Matrix4.CreateTranslation(0.0f, -0.1f, 0.0f);
                }
                timerMini = 0;
                countMini++;
            }
            else
            {
                timerMini++;
            }

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.TriangleFan, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void setupBalok()
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

            _shader = new Shader("C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/shaders/shader.vert",
                "C:/Users/JENNIFER ANGELINA/source/repos/projectUTS/projectUTS/shaders/J_ShaderTube.frag");
            _shader.Use();

            scale(0.5f);
        }

        public void renderBalok()
        {
            _shader.Use();
            _shader.SetMatrix4("transform", transform);

            if (timerBalok == 2)
            {
                if (countBalok <= 11)
                {
                    transform = transform * Matrix4.CreateTranslation(0.0f, -0.1f, 0.0f);
                }
                timerBalok = 0;
                countBalok++;
            }
            else
            {
                timerBalok++;
            }

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.TriangleFan, vertexIndices.Count, DrawElementsType.UnsignedInt, 0);
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

        public void scale(float x)
        {
            transform = transform * Matrix4.CreateScale(x);
        }

        public void createBalok(float _x, float _y, float _z)
        {
            float _positionX = _x;
            float _positionY = _y;
            float _positionZ = _z;

            float _boxLength = 0.1f;
            float _boxWidth = 0.1f;
            float _boxHeight = 0.3f;

            Vector3 temp_vector;

            // titik 1
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 2
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 3
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 4
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ - _boxWidth / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 5
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z

            vertices.Add(temp_vector);

            // titik 6
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY + _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z
            vertices.Add(temp_vector);
            // titik 7
            temp_vector.X = _positionX - _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z
            vertices.Add(temp_vector);
            // titik 8
            temp_vector.X = _positionX + _boxLength / 2.0f; // x
            temp_vector.Y = _positionY - _boxHeight / 2.0f; // y
            temp_vector.Z = _positionZ + _boxWidth / 2.0f; // z
            vertices.Add(temp_vector);

            vertexIndices = new List<uint>
            {
                0,1,2, //segitiga depan 1
                1,2,3, //segitiga depan 2
                0,4,5, //segitiga atas 1
                0,1,5, //segitiga atas 2
                1,3,5, //segitiga kanan 1
                3,5,7, //segitiga kanan 2
                0,2,4, //segitiga kiri 1
                2,4,6, //segitiga kiri2
                4,5,6, //segitiga belakang 1
                5,6,7, //segitiga belakang 2
                3,6,2, //segitiga bawah 1
                6,7,3  //segitiga bawah 2
            };
        }
    }
}
