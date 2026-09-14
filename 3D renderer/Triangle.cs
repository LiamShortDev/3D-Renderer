using System;

namespace _3D_renderer
{
    public class Triangle
    {
        // Indices of the vertices that form the triangle
        public int VertexIndex1 { get; private set; }
        public int VertexIndex2 { get; private set; }
        public int VertexIndex3 { get; private set; }
        // Constructor to initialize the triangle with three vertex indices
        public Triangle(int vertexIndex1, int vertexIndex2, int vertexIndex3)
        {
            VertexIndex1 = vertexIndex1;
            VertexIndex2 = vertexIndex2;
            VertexIndex3 = vertexIndex3;
        }

        // Optional: Override ToString for debugging purposes
        public override string ToString()
        {
            return $"Triangle({VertexIndex1}, {VertexIndex2}, {VertexIndex3})";
        }
    }
}