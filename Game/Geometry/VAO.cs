using static OpenGL.GL;

namespace Geometry
{
    class VAO
    {
        protected Shape[] shapes;
        protected uint vao;
        protected uint[] vbo;

        public VAO(Shape[] shapes)
        {
            this.shapes = shapes;
            GenerateVAO();
        }

        public VAO(Shape shape)
        {
            this.shapes = new Shape[] { shape };
            GenerateVAO();
        }

        private void GenerateVAO()
        {
            vao = CreateVAO();
            vbo = glGenBuffers(shapes.Length);

            for (int i = 0; i < shapes.Length; i++)
            {
                AssignVerticesToVBO(vbo[i], shapes[i].Flatten());
                shapes[i].Moved += RegenerateVAO;
            }
        }

        private void RegenerateVAO()
        {
            ClearData();

            vao = CreateVAO();
            vbo = glGenBuffers(shapes.Length);

            for (int i = 0; i < shapes.Length; i++)
            {
                AssignVerticesToVBO(vbo[i], shapes[i].Flatten());
            }
        }

        private void ClearData()
        {
            foreach(uint v in vbo)
            {
                glDeleteBuffer(v);
            }

            glDeleteVertexArray(vao);
        }

        private static unsafe uint CreateVAO()
        {
            var vao = glGenVertexArray();
            return vao;
        }

        private unsafe void AssignVerticesToVBO(uint vbo, float[] vertices)
        {
            glBindBuffer(GL_ARRAY_BUFFER, vbo);

            fixed (float* v = &vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
            }

            glBindBuffer(GL_ARRAY_BUFFER, 0);
        }

        public unsafe void Draw()
        {
            for (int i = 0; i < vbo.Length; i++)
            {
                glBindVertexArray(vao);

                glBindBuffer(GL_ARRAY_BUFFER, vbo[i]);
                glVertexAttribPointer(0, Config.VertexStride, GL_FLOAT, false, Config.VertexStride * sizeof(float), NULL);
                glEnableVertexAttribArray(0);
                glDrawArrays(GL_TRIANGLE_FAN, 0, shapes[i].Vertices.Length);

                glBindVertexArray(0);
            }
        }

        public void Move()
        {

        }
    }
}
