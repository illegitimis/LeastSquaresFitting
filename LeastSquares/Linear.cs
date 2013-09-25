namespace LeastSquares
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Linear Interpolation using the least squares method
    /// <remarks>http://mathworld.wolfram.com/LeastSquaresFitting.html</remarks> 
    /// </summary>
    public class Linear : Fit
    {
        /// <summary>
        /// point list constructor
        /// </summary>
        /// <param name="points">points list</param>
        public Linear(IEnumerable<Point> points) : base(points) { }
        /// <summary>
        /// abscissae/ordinates constructor
        /// </summary>
        /// <param name="x">abscissae</param>
        /// <param name="y">ordinates</param>
        public Linear(IEnumerable<float> x, IEnumerable<float> y) : base(x, y) { }

        /// <summary>
        /// the computed slope, aka regression coefficient
        /// </summary>
        public float Slope { get { return ssxy / ssxx; } }

        // dotvector(x,y)-n*avgx*avgy
        float ssxy { get { return X.DotProduct(Y) - CountUnique * AverageX * AverageY; } }
        //sum squares x - n * square avgx
        float ssxx { get { return X.DotProduct(X) - CountUnique * AverageX * AverageX; } }

        /// <summary>
        /// computed  intercept
        /// </summary>
        public float Intercept { get { return AverageY - Slope * AverageX; } }

        public override string ToString()
        {
            return string.Format("slope:{0:F02} intercept:{1:F02} R^2{2:F02}", Slope, Intercept, R2);
        }

        public override float SSResidual
        {
            get 
            { 
                var F = X.Select(x => Slope * x + Intercept);
                var residues = Y.Zip(F, (y, f) => y - f);
                return residues.DotProduct(residues); 
            }
        }
    }
}









