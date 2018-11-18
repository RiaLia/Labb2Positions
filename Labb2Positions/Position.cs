using System;
namespace Labb2Positions
{
    public class Position
    {
        int _x = 0;
        int _y = 0;
        public int X
        {
            get => _x;
            set => _x = Math.Abs(value);
        }
        public int Y
        {
            get => _y;
            set => _y = Math.Abs(value);
        }


        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {

            double distance = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            return distance;
        }

        public bool Equals(Position p)
        {
            if (X == p.X && Y == p.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Position Clone()
        {

            Position clonedPosition = new Position(X, Y);
            return clonedPosition;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static bool operator >(Position p1, Position p2)
        {

            if (p1.Length() > p2.Length())
            {
                return true;
            }
            else if (Math.Abs(p1.Length() - p2.Length()) < 0.001)
            {
                if (p1.X > p2.X)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }
            else if (Math.Abs(p1.Length() - p2.Length()) < 0.001)
            {
                if (p1.X < p2.X)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static Position operator +(Position p1, Position p2)
        {
            var x = p1.X + p2.X;
            var y = p1.Y + p2.Y;

            Position newPosition = new Position(x, y);
            return newPosition;

        }

        public static Position operator -(Position p1, Position p2)
        {
            var x = p1.X - p2.X;
            var y = p1.Y - p2.Y;

            Position newPosition = new Position(x, y);
            return newPosition;
        }

        public static double operator %(Position p1, Position p2)
        {
            double distance = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return distance;
        }


    }
}


