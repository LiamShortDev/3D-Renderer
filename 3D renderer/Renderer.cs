using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _3D_renderer
{
    public struct Point3D
    {
        public double x;
        public double y;
        public double z;
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point3D Normalize()
        {
            // Calculate the length (magnitude) of the vector
            double length = Math.Sqrt(x * x + y * y + z * z);

            // Avoid division by zero
            if (length == 0)
            {
                return this; // Return the point as-is if it's a zero vector
            }

            // Normalize the vector by dividing each component by the length
            return new Point3D(x / length, y / length, z / length);
        }

        public bool IsConnectedTo(Point3D other)
        {
            // Normalize both points to make sure they are on the unit sphere
            Point3D p1 = this.Normalize();
            Point3D p2 = other.Normalize();

            double tolerance = 1.5; // Adjust tolerance as needed
            double distance = Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2) + Math.Pow(p1.z - p2.z, 2));

            // For debugging, log the distance
            Debug.WriteLine($"Distance between ({p1.x}, {p1.y}, {p1.z}) and ({p2.x}, {p2.y}, {p2.z}) = {distance}");

            return distance < tolerance; // Returns true if the distance is smaller than the tolerance
        }



    }
    public struct Edge
    {
        public int startPos;
        public int endPos;
        public Edge(int startPos, int endPos)
        {
            this.startPos = startPos;
            this.endPos = endPos;
        }
    }
    public static class Renderer
    {
        public static double focalLength = 100;
        public static void RenderObject(SceneObject obj, PaintEventArgs e)
        {
            if (obj.GetType().Name == "Custom") 
            {
                Custom custom = (Custom)obj;
                foreach (Triangle triangle in custom.triangles)
                {
                    Point3D rotated1 = custom.Rotate(custom.vertices[triangle.VertexIndex1]);
                    Point3D rotated2 = custom.Rotate(custom.vertices[triangle.VertexIndex2]);
                    Point3D rotated3 = custom.Rotate(custom.vertices[triangle.VertexIndex3]);
                    Point projected1 = projectPoint(rotated1, custom.size, custom.position.X, custom.position.Y, custom.position.Z);
                    Point projected2 = projectPoint(rotated2, custom.size, custom.position.X, custom.position.Y, custom.position.Z);
                    Point projected3 = projectPoint(rotated3, custom.size, custom.position.X, custom.position.Y, custom.position.Z);
                    drawTriangle(projected1, projected2, projected3, e, custom.color);
                }
                foreach (Quad quad in custom.quads)
                {
                    Point3D rotated1 = custom.Rotate(custom.vertices[quad.VertexIndex1]);
                    Point3D rotated2 = custom.Rotate(custom.vertices[quad.VertexIndex2]);
                    Point3D rotated3 = custom.Rotate(custom.vertices[quad.VertexIndex3]);
                    Point3D rotated4 = custom.Rotate(custom.vertices[quad.VertexIndex4]);
                    Point projected1 = projectPoint(rotated1, custom.size, custom.position.X, custom.position.Y, custom.position.Z);
                    Point projected2 = projectPoint(rotated2, custom.size, custom.position.X, custom.position.Y, custom.position.Z);
                    Point projected3 = projectPoint(rotated3, custom.size, custom.position.X, custom.position.Y, custom.position.Z);
                    Point projected4 = projectPoint(rotated4, custom.size, custom.position.X, custom.position.Y, custom.position.Z);
                    drawQuad(projected1, projected2, projected3, projected4, e, custom.color);
                }
            }
            else if (obj.edges == null)
            {
                ProcSphere sphere = (ProcSphere)obj;
                foreach (Triangle triangle in sphere.triangles)
                {
                    Point3D rotated1 = sphere.Rotate(sphere.vertices[triangle.VertexIndex1]);
                    Point3D rotated2 = sphere.Rotate(sphere.vertices[triangle.VertexIndex2]);
                    Point3D rotated3 = sphere.Rotate(sphere.vertices[triangle.VertexIndex3]);
                    Point projected1 = projectPoint(rotated1, sphere.size, sphere.position.X, sphere.position.Y, sphere.position.Z);
                    Point projected2 = projectPoint(rotated2, sphere.size, sphere.position.X, sphere.position.Y, sphere.position.Z);
                    Point projected3 = projectPoint(rotated3, sphere.size, sphere.position.X, sphere.position.Y, sphere.position.Z);
                    drawTriangle(projected1, projected2, projected3, e, sphere.color);
                }
            }
            else
            {
                foreach (Edge edge in obj.edges)
                {
                    Point3D rotatedStartPos = obj.Rotate(obj.vertices[edge.startPos]);
                    Point3D rotatedEndPos = obj.Rotate(obj.vertices[edge.endPos]);
                    Point projectedStartPos = projectPoint(rotatedStartPos, obj.size, obj.position.X, obj.position.Y, obj.position.Z);
                    Point projectedEndPos = projectPoint(rotatedEndPos, obj.size, obj.position.X, obj.position.Y, obj.position.Z);
                    drawLine(projectedStartPos, projectedEndPos, e, obj.color);
                }
            }
        }
        public static Point projectPoint(Point3D point, int size, int xOffset, int yOffset, int zOffset)
        {
            Point projectedPoint = new Point();
            projectedPoint.X = (int)(((point.x * focalLength * size) ) / (point.z + zOffset + focalLength));
            projectedPoint.X += xOffset;
            projectedPoint.Y = (int)(((point.y * focalLength * size) ) / (point.z + zOffset + focalLength));
            projectedPoint.Y += yOffset;
            return projectedPoint;
        }
        public static void drawLine(Point startPos, Point endPos, PaintEventArgs e, Color color)
        {
            using(Pen pen = new Pen(color))
            {
                e.Graphics.DrawLine(pen, startPos, endPos);
            }
        }

        public static void drawTriangle(Point vertex1, Point vertex2, Point vertex3, PaintEventArgs e, Color color)
        {
            using (Brush brush = new SolidBrush(color)) 
            {
                e.Graphics.FillPolygon(brush, new PointF[] { vertex1, vertex2, vertex3 });
            }
        }

        public static void drawQuad(Point vertex1, Point vertex2, Point vertex3, Point vertex4, PaintEventArgs e, Color color)
        {
            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillPolygon(brush, new PointF[] { vertex1, vertex2, vertex3, vertex4 });
            }
        }
    }

}
