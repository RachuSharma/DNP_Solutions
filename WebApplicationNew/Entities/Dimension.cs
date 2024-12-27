namespace WebApplicationSecound.Entities;

public class Dimension
{
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public int CubicMeters => Length * Width * Height;

    public override string ToString()
    {
        return $"{Length} x {Width} x {Height}";
    }
}