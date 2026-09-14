using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_renderer
{
    public class Quad
    {
        // Indices of the vertices that form the quad
        public int VertexIndex1 { get; private set; }
        public int VertexIndex2 { get; private set; }
        public int VertexIndex3 { get; private set; }
        public int VertexIndex4 { get; private set; }
        // Constructor to initialize the quad with four vertex indices
        public Quad(int vertexIndex1, int vertexIndex2, int vertexIndex3, int vertexIndex4)
        {
            VertexIndex1 = vertexIndex1;
            VertexIndex2 = vertexIndex2;
            VertexIndex3 = vertexIndex3;
            VertexIndex4 = vertexIndex4;
        }

        // Optional: Override ToString for debugging purposes
        public override string ToString()
        {
            return $"Quad({VertexIndex1}, {VertexIndex2}, {VertexIndex3}, {VertexIndex4})";
        }
    }
}
