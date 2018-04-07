using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace GameCoreLibrary
{
    public class Pos
    {
        public Pos(double x, double y)
        {
            X = x;
            Y = y;
        }

        double X { get;}
        double Y { get; }

        public double DistTo(Pos another)
        {
            var diffX = X - another.X;
            var diffY = Y - another.Y;
            return Math.Sqrt((diffY * diffY) + (diffX * diffX));
        }

        
        public static Pos operator *(Pos a, int k)
        {
            return new Pos(a.X * k, a.Y * k);
        }

        public static Pos operator -(Pos a)
        {
            return new Pos(-a.X, -a.Y);
        }

        public static Pos operator -(Pos a, Pos b)
        {
            return new Pos(a.X - b.X, a.Y - b.Y);
        }

        public static Pos operator /(Pos a, int k)
        {
            return new Pos(a.X / k, a.Y / k);
        }

        
        public static Pos operator *(int k, Pos a)
        {
            return new Pos(a.X * k, a.Y * k);
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }


        public Pos MoveTowards(Pos target, double distance)
        {
            var d = target - this;
            var difLen = d.Length();
            if (difLen < distance) return target;
            var k = distance / difLen;
            return new Pos(X + k * d.X, Y + k * d.Y);
        }
    }
}