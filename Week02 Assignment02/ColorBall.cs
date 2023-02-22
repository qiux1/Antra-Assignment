public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha = 255)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }

    public int GetRed()
    {
        return red;
    }

    public void SetRed(int red)
    {
        this.red = red;
    }

    public int GetGreen()
    {
        return green;
    }

    public void SetGreen(int green)
    {
        this.green = green;
    }

    public int GetBlue()
    {
        return blue;
    }

    public void SetBlue(int blue)
    {
        this.blue = blue;
    }

    public int GetAlpha()
    {
        return alpha;
    }

    public void SetAlpha(int alpha)
    {
        this.alpha = alpha;
    }

    public double GetGrayscale()
    {
        return (red + green + blue) / 3.0;
    }
}

public class Ball
{
    private int _size;
    private Color _color;
    private int _throwCount;

    public Ball(int size, Color color)
    {
        _size = size;
        _color = color;
        _throwCount = 0;
    }

    public Ball(int size, int red, int green, int blue, int alpha = 255)
    {
        _size = size;
        _color = new Color(red, green, blue, alpha);
        _throwCount = 0;
    }

    public int GetSize()
    {
        return _size;
    }

    public void SetSize(int size)
    {
        _size = size;
    }

    public Color GetColor()
    {
        return _color;
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Pop()
    {
        _size = 0;
    }

    public void Throw()
    {
        if (_size > 0)
        {
            _throwCount++;
        }
    }

    public int GetThrowCount()
    {
        return _throwCount;
    }
}


class ColorBall
{
    static void Main(string[] args)
    {
        // Create three different colors for the balls
        Color red = new Color(255, 0, 0);
        Color green = new Color(0, 255, 0);
        Color blue = new Color(0, 0, 255);

        // Create three different balls with different colors and sizes
        Ball ball1 = new Ball(10, red);
        Ball ball2 = new Ball(15, 100, 15, 139, 255);
        Ball ball3 = new Ball(17, blue);
        Ball ball4 = new Ball(20, green);

        ball1.Pop();
        // Throw each ball multiple times
        for (int i = 0; i < 5; i++)
        {
            ball1.Throw();
            ball2.Throw();
            ball3.Throw();
            ball4.Throw();
        }
        ball4.Throw();

        // Pop one of the balls
        ball2.Pop();

        // Try to throw each ball again
        ball1.Throw();
        ball2.Throw(); // This shouldn't work, since the ball is popped
        ball3.Throw();
        ball4.Throw();

        // Print out the number of times each ball was thrown
        Console.WriteLine($"Ball 1 was thrown {ball1.GetThrowCount()} times.");
        Console.WriteLine($"Ball 2 was thrown {ball2.GetThrowCount()} times.");
        Console.WriteLine($"Ball 3 was thrown {ball3.GetThrowCount()} times.");
        Console.WriteLine($"Ball 4 was thrown {ball4.GetThrowCount()} times.");
    }
}