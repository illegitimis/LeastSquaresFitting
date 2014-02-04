using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeastSquares
{
    /// <summary>
    /// in order to weight the points equally, it is often better to minimize the function sum_(i=1)^ny_i(lny_i-a-bx_i)^2. 
    /// </summary>
    public class ExponentialOptimum : Fit
    {
         /// <summary>
        /// point list constructor
        /// </summary>
        /// <param name="points">points list</param>
        public ExponentialOptimum(IEnumerable<Point> points) : base(points) { }
        /// <summary>
        /// abscissae/ordinates constructor
        /// </summary>
        /// <param name="x">abscissae</param>
        /// <param name="y">ordinates</param>
        public ExponentialOptimum(IEnumerable<double> x, IEnumerable<double> y) : base(x, y) { }
        public ExponentialOptimum(IEnumerable<double[]> ar2double) : base (ar2double) {}

        public double A { get { return (double)Math.Exp(a); } }
        public double B { get { return (double)b; } }

        // COMPUTED
        double a_h { get { return sumxxy*sumylny - X.DotProduct(Y)*sumxylny; } }
        double a_l { get { return SumY * sumxxy - (double)Math.Pow (X.DotProduct(Y),2); } }
        double a { get { return a_h / a_l; } }

        double b { get { return b_h / b_l; } }
        double b_h { get { return SumY * sumxylny - X.DotProduct(Y) * sumylny; } }
        double b_l { get { return a_l; } }



        double sumylny { get { return Y.DotProduct(Y.Select(y => (double)Math.Log(y))); } }
        double sumxxy { get { return X.DotProduct(X,Y) ; } }
        double sumxylny { get { return X.DotProduct(Y, Y.Select(y => (double)Math.Log(y))); } }

        public override double SSResidual
        {
            get
            {
                var F = X.Select(x => A * (double)Math.Exp(x * B));
                var residues = Y.Zip(F, (y, f) => y - f);
                return residues.DotProduct(residues);
            }
        }

        public override string ToString ( )
        {
          return string.Format("(EO) A:{0} B:{1} R^2:{2:F02}", A, B, R2);
        }
    }
}
