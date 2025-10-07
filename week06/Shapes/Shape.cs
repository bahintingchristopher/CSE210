using System;


//Base class for different shapes
class Shape
{
    // Field for color with a default value
    private string _color = "red";

    // Constructor to initialize the shape with a specific color
    public Shape(string color)
    {
        _color = color;
    }

    // Method to get the color of the shape
    public string GetColor()
    {
        return _color;
    }

    // Method to set the color of the shape
    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method to compute the area, to be overridden by derived classes
    public virtual double GetArea()
    {
        return 0.0;
    }
}


