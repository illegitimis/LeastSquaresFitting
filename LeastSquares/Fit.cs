

namespace LeastSquares
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public abstract class Fit
  {
    /// <summary>
    /// point list constructor
    /// </summary>
    /// <param name="points">points list</param>
    public Fit (IEnumerable<Point> points)
    {
      Points = points;
    }
    /// <summary>
    /// abscissae/ordinates constructor
    /// </summary>
    /// <param name="x">abscissae</param>
    /// <param name="y">ordinates</param>
    public Fit (IEnumerable<double> x, IEnumerable<double> y)
    {
      if (x.Empty() || y.Empty())
        throw new ArgumentNullException("null-x");
      if (y.Empty())
        throw new ArgumentNullException("null-y");
      if (x.Count() != y.Count())
        throw new ArgumentException("diff-count");

      Points = x.Zip(y, (unx, uny) => new Point { x = unx, y = uny });
    }

    protected IEnumerable<Point> build (IEnumerable<double[]> ar2double)
    {
      foreach (double[] ar2 in ar2double)
      {
        yield return new Point(ar2[0], ar2[1]);
      }
    }

    /// <summary>
    /// double array constructor
    /// </summary>
    /// <param name="points">points list</param>
    public Fit (IEnumerable<double[]> ar2double)
    {
      Points = build(ar2double);
    }

    protected IEnumerable<Point> Points;
    /// <summary>
    /// original points count
    /// </summary>
    public int Count { get { return Points.Count(); } }

    /// <summary>
    /// group points with equal x value, average group y value
    /// </summary>
    protected IEnumerable<Point> UniquePoints
    {
      get
      {
        var grp = Points.GroupBy((p) => { return p.x; });
        foreach (IGrouping<double, Point> g in grp)
        {
          double currentX = g.Key;
          double averageYforX = g.Select(p => p.y).Average();
          yield return new Point() { x = currentX, y = averageYforX };
        }
      }
    }
    /// <summary>
    /// count of point set used for interpolation
    /// </summary>
    public int CountUnique { get { return UniquePoints.Count(); } }
    /// <summary>
    /// abscissae
    /// </summary>
    public IEnumerable<double> X { get { return UniquePoints.Select(p => p.x); } }
    public IEnumerable<double> X_Orig { get { return Points.Select(p => p.x); } }
    /// <summary>
    /// ordinates
    /// </summary>
    public IEnumerable<double> Y { get { return UniquePoints.Select(p => p.y); } }
    public IEnumerable<double> Y_Orig { get { return Points.Select(p => p.y); } }

    /// <summary>
    /// x mean
    /// </summary>
    protected double AverageX { get { return X.Average(); } }
    /// <summary>
    /// y mean
    /// </summary>
    protected double AverageY { get { return Y.Average(); } }

    /// <summary>
    /// x sum
    /// </summary>
    protected double SumX { get { return X.Sum(); } }
    /// <summary>
    /// y sum
    /// </summary>
    protected double SumY { get { return Y.Sum(); } }

    /// <summary>
    /// coefficient of determination, R squared
    /// http://en.wikipedia.org/wiki/Coefficient_of_determination
    /// </summary>
    public double R2 { get { return 1f - SSResidual / SSTotal; } }

    /// <summary>
    /// residual sum of squares, sum of squares of residuals
    /// </summary>
    public abstract double SSResidual { get; }

    /// <summary>
    /// total sum of squares (proportional to the sample variance);
    /// sum sq (yi - mean y)
    /// </summary>
    public double SSTotal { get { var meanY = Y.Select(y => y - AverageY); return meanY.DotProduct(meanY); } }
  }
}
