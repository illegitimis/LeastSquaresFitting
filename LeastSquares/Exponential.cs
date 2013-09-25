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
        public Exponential(IEnumerable<float> x, IEnumerable<float> y) : base(x, y) { }

        public float A { get { return (float)Math.Exp(a); } }
        public float B { get { return (float)b; } }

        // COMPUTED
        float a_h { get { return sumlny * X.DotProduct(X) - SumX * sumxlny; } }
        float a_l { get { return CountUnique * X.DotProduct(X) - SumX * SumX; } }
        float a { get { return a_h / a_l; } }

        float b { get { return b_h/b_l; } }
        float b_h { get { return CountUnique * sumxlny - SumX * sumlny; } }
        float b_l { get { return a_l; } }

        float sumlny { get { return Y.Select(y=>(float)Math.Log(y)).Sum(); } }
        float sumxlny { get { return X.DotProduct(Y.Select(y => (float)Math.Log(y))); } }



        public override float SSResidual
        {
            get
            {
                var F = X.Select(x => A * (float)Math.Exp(x*B));
                var residues = Y.Zip(F, (y, f) => y - f);
                return residues.DotProduct(residues);
            }
        }
    }
}
