using System;

namespace InnerFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewCartesianPoint(2, 3);
        }
    }
    public class Point
    {
        // typical members here
        private double x, y;
        // note the constructor is again private
        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y); // using a private constructor
            }
            // similar for NewPolarPoint()
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
            // other members omitted
        }
    }
}
