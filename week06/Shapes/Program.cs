using System;


//computes area of different shapes
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");
        Console.WriteLine();
        // Create instances of different shapes
        Shape myCircle = new Circle("GREEN", 3.0);
        Shape myRectangle = new Rectangle("BLUE", 4.0, 6.0);
        Shape mySquare = new Square("RED", 4);

        // Display the area and color of each shape
        Console.WriteLine($"Circle: Color = {myCircle.GetColor()}, Area = {myCircle.GetArea()}");
        Console.WriteLine($"Rectangle: Color = {myRectangle.GetColor()}, Area = {myRectangle.GetArea()}");
        Console.WriteLine($"Square: Color = {mySquare.GetColor()}, Area = {mySquare.GetArea()}");   

        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Red", 4);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        shapes.Add(rectangle);

        Circle circle = new Circle("Green", 3);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"Shape Color: {color}, Area: {area}");
        }

    }
}