
/// <summary>
/// any given point
/// </summary>
using System;
public class Point
{
    public double x { get; set; }
    public double y { get; set; }

    public Point(double x = 0, double y = 0) { this.x = x; this.y = y; }
}

public class Point<T> 
  where T : struct, IComparable, IFormattable, IConvertible
  //, IComparable<double>, IEquatable<double>, IComparable<float>, IEquatable<float>
{
  public T x { get; set; }
  public T y { get; set; }

  public Point (T x = default(T), T y = default(T)) { this.x = x; this.y = y; }
}
