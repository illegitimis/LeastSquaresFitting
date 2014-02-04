namespace LeastSquares
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  To fit a functional form y=Ae^(Bx), take the logarithm of both sides lny=lnA+Bx. 
    ///  This fit gives greater weights to small y values !
    /// </summary>
    public class Exponential : Fit
    {
        /// <summary>
        /// point list constructor
        /// </summary>
        /// <param name="points">points list</param>
        public Exponential(IEnumerable<Point> points) : base(points) { }
        /// <summary>
        /// abscissae/ordinates constructor
        /// </summary>
        /// <param name="x">abscissae</param>
        /// <param name="y">ordinates</param>
        public Exponential(IEnumerable<double> x, IEnumerable<double> y) : base(x, y) { }
        public Exponential(IEnumerable<double[]> ar2double) : base (ar2double) {}

        public double A { get { return (double)Math.Exp(a); } }
        public double B { get { return (double)b; } }

        // COMPUTED
        double a_h { get { return sumlny * X.DotProduct(X) - SumX * sumxlny; } }
        double a_l { get { return CountUnique * X.DotProduct(X) - SumX * SumX; } }
        double a { get { return a_h / a_l; } }

        double b { get { return b_h/b_l; } }
        double b_h { get { return CountUnique * sumxlny - SumX * sumlny; } }
        double b_l { get { return a_l; } }

        double sumlny { get { return Y.Select(y=>(double)Math.Log(y)).Sum(); } }
        double sumxlny { get { return X.DotProduct(Y.Select(y => (double)Math.Log(y))); } }

        public override double SSResidual
        {
            get
            {
                var F = X.Select(x => A * (double)Math.Exp(x*B));
                var residues = Y.Zip(F, (y, f) => y - f);
                return residues.DotProduct(residues);
            }
        }

        public override string ToString ( )
        {
          return string.Format("(EX) A:{0} B:{1} R^2:{2:F02}", A, B, R2);
        }
    }
}
