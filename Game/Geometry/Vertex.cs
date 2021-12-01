using System.Drawing;
using System;

namespace Geometry
{
    class Vertex
    {
        //x,y,z,w,r,g,b,a
        private float[] data;

        public float X => data[0];
        public float Y => data[1];
        public float Z => data[2];
        public float W => data[3];
        public float R => data[4];
        public float G => data[5];
        public float B => data[6];
        public float A => data[7];

        public Vertex(float[] data)
        {
            this.data = data;
        }

        public void SetPosition(float x, float y, float z)
        {
            data[0] = x;
            data[1] = y;
            data[2] = z;
        }

        public void SetPosition(float x, float y, float z, float w)
        {
            data[0] = x;
            data[1] = y;
            data[2] = z;
            data[3] = w;
        }

        public void SetColor(Color color)
        {
            data[4] = color.R;
            data[5] = color.G;
            data[6] = color.B;
            data[7] = color.A;
        }

        public void SetData(float[] data)
        {
            if (data.Length == 8)
                this.data = data;
            else
                Console.WriteLine("Cant write - wrong data size");
        }
    }
}

