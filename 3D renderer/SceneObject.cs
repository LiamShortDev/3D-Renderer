using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D_renderer
{
    public class SceneObject
    {
        public int size;
        public Color color;
        public Point3D[] vertices;
        public Edge[] edges;
        public Rotation rotation;
        public Position position;
        public struct Position
        {
            public int X = 500;
            public int Y = 500;
            public int Z = 500;
            public Position(int x, int y, int z)
            {
                
                X = x;
                Y = y;
                Z = z;
            }
        }
        public struct Rotation
        {
            public double Alpha= 0;
            public double Beta = 0;
            public double Gamma = 0;
            public Rotation(double alpha, double beta, double gamma)
            {
                Alpha = alpha;
                Beta = beta;
                Gamma = gamma;
            }
        }
        public SceneObject(int size, Color color)
        {
            this.size = size;
            this.color = color;
        }
        public Point3D Rotate(Point3D point)
        {
            Point3D rotatedPoint = new Point3D(0, 0, 0);
            rotatedPoint.x = (point.x * Math.Cos(rotation.Alpha) * Math.Cos(rotation.Beta)) + (point.y * Math.Sin(rotation.Alpha) * Math.Cos(rotation.Beta)) + (point.z * Math.Sin(rotation.Beta) * -1);
            rotatedPoint.y = (point.x * ((Math.Cos(rotation.Alpha) * Math.Sin(rotation.Beta) * Math.Sin(rotation.Gamma)) - (Math.Sin(rotation.Alpha) * Math.Cos(rotation.Gamma)))) + (point.y * ((Math.Sin(rotation.Alpha) * Math.Sin(rotation.Beta) * Math.Sin(rotation.Gamma)) + (Math.Cos(rotation.Alpha) * Math.Cos(rotation.Gamma)))) + (point.z * Math.Cos(rotation.Beta) * Math.Sin(rotation.Gamma));
            rotatedPoint.z = (point.x * ((Math.Cos(rotation.Alpha) * Math.Sin(rotation.Beta) * Math.Sin(rotation.Gamma)) + (Math.Sin(rotation.Alpha) * Math.Sin(rotation.Gamma)))) + (point.y * ((Math.Sin(rotation.Alpha) * Math.Sin(rotation.Beta) * Math.Cos(rotation.Gamma)) - (Math.Cos(rotation.Alpha) * Math.Sin(rotation.Gamma)))) + (point.z * Math.Cos(rotation.Beta) * Math.Cos(rotation.Gamma));
            return rotatedPoint;
        }
    }
}
