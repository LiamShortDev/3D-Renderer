using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_renderer
{
    public class ProcSphere : SceneObject
    {
        public int horizontalLines = 100; // Number of horizontal lines (latitude)
        public int verticalLines = 100;   // Number of vertical lines (longitude)
        public Triangle[] triangles;

        public ProcSphere(int size, Color color) : base(size, color)
        {
            GenerateSphere();
        }

        // Generate the vertices and edges for the sphere
        private void GenerateSphere()
        {
            List<Point3D> vertexList = new List<Point3D>();
            List<Triangle> triangleList = new List<Triangle>();

            // Generate vertices
            for (int m = 0; m < horizontalLines; m++)
            {
                for (int n = 0; n < verticalLines; n++)
                {
                    double x = Math.Sin(Math.PI * m / horizontalLines) * Math.Cos(2 * Math.PI * n / verticalLines);
                    double y = Math.Sin(Math.PI * m / horizontalLines) * Math.Sin(2 * Math.PI * n / verticalLines);
                    double z = Math.Cos(Math.PI * m / horizontalLines);
                    vertexList.Add(new Point3D(x * size, y * size, z * size));
                }
            }

            vertices = vertexList.ToArray();

            // Generate triangles
            for (int m = 0; m < horizontalLines - 1; m++)
            {
                for (int n = 0; n < verticalLines; n++)
                {
                    int current = m * verticalLines + n;
                    int next = m * verticalLines + ((n + 1) % verticalLines);
                    int below = ((m + 1) % horizontalLines) * verticalLines + n;
                    int belowNext = ((m + 1) % horizontalLines) * verticalLines + ((n + 1) % verticalLines);

                    // Create two triangles for each quad
                    triangleList.Add(new Triangle(current, next, below));
                    triangleList.Add(new Triangle(next, belowNext, below));
                }
            }

            triangles = triangleList.ToArray();
        }
    }
}
