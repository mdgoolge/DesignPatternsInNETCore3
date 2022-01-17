using System;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static Task Main(string[] args)
        {
            var point = Point.NewPolarPoint(5, Math.PI / 4);
            return Task.CompletedTask;
        }
    }
    public class Point
    {
        private double x, y;
        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        // other members omitted
    }

    
}
