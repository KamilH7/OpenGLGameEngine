using System;
namespace Geometry
{
    class Square : Shape
    {
        public Square(Point[] vertices)
        {
            if (vertices.Length != 4)
            {
                throw new ArgumentException("Square has to have 4 vertices", nameof(vertices));
            }

            this.vertices = vertices;
        }

    }
}
