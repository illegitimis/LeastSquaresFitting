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
        public ExponentialOptimum(IEnumerable<float> x, IEnumerable<float> y) : base(x, y) { }
        
        public float A { get { return (float)Math.Exp(a); } }
        public float B { get { return (float)b; } }

        // COMPUTED
        float a_h { get { return sumxxy*sumylny - X.DotProduct(Y)*sumxylny; } }
        float a_l { get { return SumY * sumxxy - (float)Math.Pow (X.DotProduct(Y),2); } }
        float a { get { return a_h / a_l; } }

        float b { get { return b_h / b_l; } }
        float b_h { get { return SumY * sumxylny - X.DotProduct(Y) * sumylny; } }
        float b_l { get { return a_l; } }



        float sumylny { get { return Y.DotProduct(Y.Select(y => (float)Math.Log(y))); } }
        float sumxxy { get { return X.DotProduct(X,Y) ; } }
        float sumxylny { get { return X.DotProduct(Y, Y.Select(y => (float)Math.Log(y))); } }

        public override float SSResidual
        {
            get
            {
                var F = X.Select(x => A * (float)Math.Exp(x * B));
                var residues = Y.Zip(F, (y, f) => y - f);
                return residues.DotProduct(residues);
            }
        }
    }
}
