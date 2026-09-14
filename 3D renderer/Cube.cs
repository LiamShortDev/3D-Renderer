using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_renderer
{
    public class Cube : SceneObject
    {
        public Cube(int size, Color color) : base(size, color)
        {
            edges = new Edge[]
            {
                new Edge(0, 1),
                new Edge(0, 2),
                new Edge(0, 3),
                new Edge(7, 4),
                new Edge(7, 5),
                new Edge(7, 6),
                new Edge(5, 2),
                new Edge(5, 1),
                new Edge(2, 6),
                new Edge(3, 4),
                new Edge(4, 1),
                new Edge(6, 3),
            };

            vertices = new Point3D[]
            {
                new Point3D(-1, -1, -1),
                new Point3D(-1, -1, 1),
                new Point3D(1, -1, -1),
                new Point3D(-1, 1, -1),
                new Point3D(-1, 1, 1),
                new Point3D(1, -1, 1),
                new Point3D(1, 1, -1),
                new Point3D(1, 1, 1),
            };
        }
    }
}
