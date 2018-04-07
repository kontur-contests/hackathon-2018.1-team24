using System;

namespace GameCoreLibrary
{
    public class Pos
    {
        public Pos(float x, float y)
        {
            X = x;
            Y = y;
        }

        float X { get;}
        float Y { get; }

        public double DistTo(Pos another)
        {
            var diffX = X - another.X;
            var diffY = Y - another.Y;
            return Math.Sqrt((diffY * diffY) + (diffX * diffX));
        }
    }
}