using System;
namespace Geometry
{
    class Triangle : Shape
    {
        public Triangle(Point[] vertices)
        {
            if (vertices.Length != 3)
            {
                throw new ArgumentException("Triangle has to have 3 vertices", nameof(vertices));
            }

            this.vertices = vertices;
        }
    }
}


