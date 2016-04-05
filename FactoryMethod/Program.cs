using System;

namespace FactoryMethod
{

    public interface IShape
    {
        void Draw();
    }

    public abstract class Shape : IShape
    {
        public override string ToString()
        {
            return $"Shape Name: {GetType().Name}\n";
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing {GetType().Name}\n");
        }
    }

    public class Circle : Shape
    {
    }

    public class Rectangle : Shape
    {
    }

    public class Square : Shape
    {
    }

    // Null Object Pattern
    public class NullShape : Shape
    {
    }

    public enum ShapeType
    {
        Circle,
        Rectangle,
        Square,
        Null
    }

    public interface IShapeFactory
    {
        IShape CreateShape(ShapeType shapeType);
        T CreateShape<T>() where T : IShape, new();
    }

    public class ShapeFactory : IShapeFactory
    {
        public IShape CreateShape(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Circle:
                    return new Circle();
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Square:
                    return new Square();
                default:
                    return new NullShape();
            }
        }

        public T CreateShape<T>() where T : IShape, new()
        {
            return new T();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using Generic Method");
            IShapeFactory shapeFactory = new ShapeFactory();

            var shapes = new IShape[6];

            shapes[0] = shapeFactory.CreateShape<Circle>();
            shapes[1] = shapeFactory.CreateShape<Rectangle>();
            shapes[2] = shapeFactory.CreateShape<NullShape>();
            shapes[3] = shapeFactory.CreateShape<Square>();
            shapes[4] = shapeFactory.CreateShape<NullShape>();
            shapes[5] = shapeFactory.CreateShape<Circle>();

            foreach (var shape in shapes)
            {
                shape.Draw();
            }


            Console.WriteLine("Using Non-Generic Method");
            IShapeFactory shapeFactoryNonGeneric = new ShapeFactory();

            var shapes2 = new IShape[6];

            shapes2[0] = shapeFactoryNonGeneric.CreateShape(ShapeType.Circle);
            shapes2[1] = shapeFactoryNonGeneric.CreateShape(ShapeType.Null);
            shapes2[2] = shapeFactoryNonGeneric.CreateShape(ShapeType.Rectangle);
            shapes2[3] = shapeFactoryNonGeneric.CreateShape(ShapeType.Square);
            shapes2[4] = shapeFactoryNonGeneric.CreateShape(ShapeType.Circle);
            shapes2[5] = shapeFactoryNonGeneric.CreateShape(ShapeType.Null);

            foreach (var shape in shapes2)
            {
                shape.Draw();
            }

        }
    }
}
