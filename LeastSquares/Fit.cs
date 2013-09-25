using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeastSquares
{
    public abstract class Fit
    {
        /// <summary>
        /// point list constructor
        /// </summary>
        /// <param name="points">points list</param>
        public Fit(IEnumerable<Point> points)
        {
            Points = points;
        }
        /// <summary>
        /// abscissae/ordinates constructor
        /// </summary>
        /// <param name="x">abscissae</param>
        /// <param name="y">ordinates</param>
        public Fit(IEnumerable<float> x, IEnumerable<float> y)
        {
            if (x.Empty() || y.Empty())
                throw new ArgumentNullException("null-x");
            if (y.Empty())
                throw new ArgumentNullException("null-y");
            if (x.Count() != y.Count())
                throw new ArgumentException("diff-count");

            Points = x.Zip(y, (unx, uny) => new Point { x = unx, y = uny });
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
                foreach (IGrouping<float, Point> g in grp)
                {
                    float currentX = g.Key;
                    float averageYforX = g.Select(p => p.y).Average();
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
        public IEnumerable<float> X { get { return UniquePoints.Select(p => p.x); } }
        public IEnumerable<float> X_Orig { get { return Points.Select(p => p.x); } }
        /// <summary>
        /// ordinates
        /// </summary>
        public IEnumerable<float> Y { get { return UniquePoints.Select(p => p.y); } }
        public IEnumerable<float> Y_Orig { get { return Points.Select(p => p.y); } }

        /// <summary>
        /// x mean
        /// </summary>
        protected float AverageX { get { return X.Average(); } }
        /// <summary>
        /// y mean
        /// </summary>
        protected float AverageY { get { return Y.Average(); } }

        /// <summary>
        /// x sum
        /// </summary>
        protected float SumX { get { return X.Sum(); } }
        /// <summary>
        /// y sum
        /// </summary>
        protected float SumY { get { return Y.Sum(); } }

        /// <summary>
        /// coefficient of determination, R squared
        /// http://en.wikipedia.org/wiki/Coefficient_of_determination
        /// </summary>
        public float R2 { get { return 1f - SSResidual / SSTotal; } }

        /// <summary>
        /// residual sum of squares, sum of squares of residuals
        /// </summary>
        public abstract float SSResidual { get; }

        /// <summary>
        /// total sum of squares (proportional to the sample variance);
        /// sum sq (yi - mean y)
        /// </summary>
        public float SSTotal { get { var meanY = Y.Select(y => y - AverageY); return meanY.DotProduct(meanY); } }
    }
}
