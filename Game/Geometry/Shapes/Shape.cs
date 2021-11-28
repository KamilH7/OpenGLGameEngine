﻿namespace Geometry
{
    class Shape
    {
        protected Point[] vertices;
        public Point[] Vertices => vertices;

        public virtual void Move(float x, float y, float z)
        {
            foreach (Point point in vertices)
            {
                point.SetPosition(point.X + x, point.Y + y, point.Z + z);
            }
        }

        public virtual void SetPosition(float x, float y, float z)
        {
            float sumX = 0, sumY = 0, sumZ = 0;
            int numOfPoints = vertices.Length;

            foreach (Point point in vertices)
            {
                sumX += point.X;
                sumY += point.Y;
                sumZ += point.Z;
            }

            Point middlePoint = new Point(sumX / numOfPoints, sumY / numOfPoints, sumZ / numOfPoints);

            foreach (Point point in vertices)
            {
                point.SetPosition(point.X - middlePoint.X, point.Y - middlePoint.Y, point.Z - middlePoint.Z);
            }

            middlePoint.SetPosition(middlePoint.X + x, middlePoint.Y + y, middlePoint.Z + z);

            foreach (Point point in vertices)
            {
                point.SetPosition(point.X + middlePoint.X, point.Y + middlePoint.Y, point.Z + middlePoint.Z);
            }
        }

        public float[] Flatten()
        {
            float[] flatArray = new float[vertices.Length * 3];

            for (int i = 0; i < flatArray.Length; i++)
            {
                flatArray[i] = GetValue(i);
            }

            return flatArray;
        }

        private float GetValue(int index)
        {
            int vertNumber = index / 3;
            int coordinateNumber = index % 3;

            switch (coordinateNumber)
            {
                case (0): { return vertices[vertNumber].X; }
                case (1): { return vertices[vertNumber].Y; }
                case (2): { return vertices[vertNumber].Z; }
            }

            return 0;
        }
    }
}