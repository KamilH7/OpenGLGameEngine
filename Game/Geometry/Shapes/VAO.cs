using static OpenGL.GL;

namespace Geometry
{
    class VAO
    {
        protected Shape[] shape;
        protected uint vao;
        protected uint[] vbo;

        public VAO(Shape[] shape)
        {
            this.shape = shape;
            GenerateVAO();
        }

        protected static unsafe uint CreateVAO()
        {
            var vao = glGenVertexArray();
            return vao;
        }

        protected void GenerateVAO()
        {
            vao = CreateVAO();
            vbo = glGenBuffers(shape.Length);

            for (int i = 0; i < shape.Length; i++)
            {
                AssignVerticesToVBO(vbo[i], shape[i].Flatten());
            }
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
            for(int i =0; i< vbo.Length; i++) {

                glBindVertexArray(vao);

                glBindBuffer(GL_ARRAY_BUFFER, vbo[i]);
                glVertexAttribPointer(0, 3, GL_FLOAT, false, shape[i].Vertices.Length * sizeof(float), NULL);
                glEnableVertexAttribArray(0);
                glDrawArrays(GL_TRIANGLE_STRIP, 0, shape[i].Vertices.Length);

                glBindVertexArray(0);
            }
        }
        public void Move()
        {

        }

        public void SetPosition()
        {

        }
    }
}
