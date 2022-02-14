using System;

namespace CHAPTER8
{
    class Program
    {
        static void Main(string[] args)
        {
            //var raster = new RasterRenderer();
            var vector = new VectorRenderer();
            var circle = new Circle(vector, 5);
            circle.Draw(); // Drawing a circle of radius 5
            circle.Resize(2);
            circle.Draw(); // Drawing a circle of radius 10
        }
    }
    public interface IRenderer
    {
        void RenderCircle(float radius);
        // RenderSquare, RenderTriangle, etc.
    }
    public abstract class Shape
    {
        protected IRenderer renderer;
        // a bridge between the shape that's being drawn and
        // the component which actually draws it
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }
        public abstract void Draw();
        public abstract void Resize(float factor);
    }
    public class Circle : Shape
    {
        private float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }
        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }
        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }
    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }
}
