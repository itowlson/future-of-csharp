using System;
using System.Collections.Generic;
using System.Console;
using System.Linq;
using System.Math;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFutureFeatures
{
    public struct Point(double x, double y)
    {
        public double X { get; } = x;
        public double Y { get; } = y;

        public static Point Origin { get; } = new Point(0, 0);

        public Point Add(Vector delta) => new Point(X + delta.X, Y + delta.Y);
        public static Point operator +(Point pt, Vector delta) => pt.Add(delta);

        public Point Subtract(Vector delta) => Add(-delta);
        public static Point operator -(Point pt, Vector delta) => pt.Subtract(delta);

        public Vector Subtract(Point other) => new Vector(X - other.X, Y - other.Y);
        public static Vector operator -(Point pt1, Point pt2) => pt1.Subtract(pt2);

        public double Distance(Point other) => (this - other).Length;

        public void Print() => WriteLine("({0}, {1})", X, Y);
    }

    public struct Vector(double x, double y)
    {
        public double X { get; } = x;
        public double Y { get; } = y;

        public Vector Add(Vector delta) => new Vector(X + delta.X, Y + delta.Y);
        public static Vector operator +(Vector v1, Vector v2) => v1.Add(v2);

        public Vector Times(double scale) => new Vector(X * scale, Y * scale);
        public static Vector operator *(Vector vector, double scale) => vector.Times(scale);

        public static Vector operator -(Vector vector) => vector * -1;

        public double Length => Sqrt(X * X + Y * Y);

        public double Dot(Vector other) => X * other.X + Y * other.Y;
        public double Angle(Vector other) => Acos(this.Dot(other) / (this.Length * other.Length));
    }
}
