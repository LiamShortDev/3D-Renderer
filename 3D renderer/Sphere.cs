using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _3D_renderer
{
    public class Sphere : SceneObject
    {
        public Sphere(int size, Color color) : base(size, color)
        {
            vertices = generateSphericalVertices();
            edges = generateEdges(vertices).ToArray();
        }
        public double GoldenRatioAngle = Math.PI * (3 - Math.Sqrt(5));
        public const int N = 200;
        private Point3D[] generateSphericalVertices()
        {
            Point3D[] vertices = new Point3D[N];

            for (int i = 0; i < N; i++)
            {
                double theta = GoldenRatioAngle * i;  // Azimuthal angle
                double y = 1 - (2.0 * i) / (N - 1);  // Uniform vertical distribution
                double r = Math.Sqrt(1 - y * y);  // Correct radius for the x-z plane

                double x = r * Math.Cos(theta);
                double z = r * Math.Sin(theta);

                vertices[i] = new Point3D(x, y, z);
            }
            return vertices;
        }


        private List<Edge> generateEdges(Point3D[] vertices)
        {
            int k = 6;
            List<Edge> edges = new List<Edge>();
            KDTree tree = new KDTree(vertices.ToList());
            int i = 0;
            foreach(Point3D p in vertices)
            {
                List<Point3D> kNearest = tree.FindKNearest(p, k);
                if (kNearest != null)
                {
                    foreach (Point3D nearPoint in kNearest)
                    {
                        edges.Add(new Edge(i, Array.FindIndex(vertices, v => v.Equals(nearPoint))));
                    }
                }
                i++;
            }
            return edges;
        }
    }

    public class KDTreeNode
    {
        public Point3D Point { get; }
        public KDTreeNode Left { get; set; }
        public KDTreeNode Right { get; set; }
        public int Axis { get; }

        public KDTreeNode(Point3D point, int axis)
        {
            Point = point;
            Axis = axis;
        }
    }

    public class KDTree
    {
        private KDTreeNode root;

        public KDTree(List<Point3D> points)
        {
            root = ConstructTree(points, depth: 0);
        }

        private KDTreeNode ConstructTree(List<Point3D> points, int depth)
        {
            if (points.Count == 0)
            {
                return null;
            }

            int axis = depth % 3; // x -> y -> z
            points = points.OrderBy(p => axis == 0 ? p.x : axis == 1 ? p.y : p.z).ToList();

            int median = points.Count / 2;
            KDTreeNode node = new KDTreeNode(points[median], axis);

            node.Left = ConstructTree(points.Take(median).ToList(), depth + 1);
            node.Right = ConstructTree(points.Skip(median + 1).ToList(), depth + 1);

            return node;
        }
        public List<Point3D> FindKNearest(Point3D target, int k)
        {
            if (root == null) return new List<Point3D>(); // Ensure tree is not empty

            SortedDictionary<double, List<Point3D>> bestPoints = new SortedDictionary<double, List<Point3D>>();

            FindKNearest(root, target, k, bestPoints);

            // ✅ Flatten the list to return `List<Point3D>` instead of `List<List<Point3D>>`
            return bestPoints.SelectMany(pair => pair.Value).ToList();
        }


        public double DistanceSquared(Point3D a, Point3D b)
        {
            return Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2) + Math.Pow(a.z - b.z, 2);
        }
        private void FindKNearest(KDTreeNode node, Point3D target, int k, SortedDictionary<double, List<Point3D>> bestPoints)
        {
            if (node == null) return;

            double dist = DistanceSquared(target, node.Point);

            // ✅ Store points with the same distance in a List
            if (!bestPoints.ContainsKey(dist))
            {
                bestPoints[dist] = new List<Point3D>();
            }
            bestPoints[dist].Add(node.Point);

            // ✅ Keep only the k-nearest points
            while (bestPoints.Count > k)
            {
                bestPoints.Remove(bestPoints.Keys.Last()); // Removes the farthest point
            }

            int axis = node.Axis;
            double diff = axis == 0 ? target.x - node.Point.x :
                          axis == 1 ? target.y - node.Point.y :
                                      target.z - node.Point.z;

            KDTreeNode first = (diff < 0) ? node.Left : node.Right;
            KDTreeNode second = (diff < 0) ? node.Right : node.Left;

            FindKNearest(first, target, k, bestPoints);

            if (bestPoints.Count < k || diff * diff < bestPoints.Keys.Last())
            {
                FindKNearest(second, target, k, bestPoints);
            }
        }


    }
}
