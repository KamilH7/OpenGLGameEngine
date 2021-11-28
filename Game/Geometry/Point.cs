namespace Geometry
{
    class Point
    {
        private float x, y, z;

        public float X => x;
        public float Y => y;
        public float Z => z;


        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetPosition(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}

