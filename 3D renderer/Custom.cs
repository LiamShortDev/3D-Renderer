using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3D_renderer
{
    public class Custom : SceneObject
    {
        public Triangle[] triangles;
        public Quad[] quads;
        public Custom(int size, Color color, string filename) : base(size, color)
        {
            LoadObj(filename);
        }

        private void LoadObj(string filename)
        {
            List<Point3D> Vertices = new List<Point3D>();
            List<Triangle> Triangles = new List<Triangle>();
            List<Quad> Quads = new List<Quad>();
            foreach (var line in File.ReadLines(filename))
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "v":  // Vertex line
                        double x = double.Parse(parts[1], CultureInfo.InvariantCulture);
                        double y = double.Parse(parts[2], CultureInfo.InvariantCulture);
                        double z = double.Parse(parts[3], CultureInfo.InvariantCulture);
                        Vertices.Add(new Point3D(x, y, z));
                        break;

                    case "f":  // Face line
                        int[] faceIndices = new int[parts.Length - 1];
                        for (int i = 1; i < parts.Length; i++)
                        {
                            string[] vertexData = parts[i].Split('/');  // Split v/vt/vn format
                            int vertexIndex = int.Parse(vertexData[0]) - 1; // Convert to 0-based index
                            faceIndices[i - 1] = vertexIndex;
                        }
                        switch (faceIndices.Length)
                        {
                            case 3:
                                Triangles.Add(new Triangle(faceIndices[0], faceIndices[1], faceIndices[2]));
                                break;
                            case 4:
                                Quads.Add(new Quad(faceIndices[0], faceIndices[1], faceIndices[2], faceIndices[3]));
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
            triangles = Triangles.ToArray();
            quads = Quads.ToArray();
            vertices = Vertices.ToArray();
        }
    }
}
