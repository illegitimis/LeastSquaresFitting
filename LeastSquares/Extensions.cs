

//namespace LeastSquares
//{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    /// <summary>
    /// Linq extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// dot vector product
        /// </summary>
        /// <param name="a">input</param>
        /// <param name="b">input</param>
        /// <returns>dot product of 2 inputs</returns>
        public static float DotProduct(this IEnumerable<float> a, IEnumerable<float> b)
        {
            return a.Zip(b, (d1, d2) => d1 * d2).Sum();
        }

        public static float DotProduct(this IEnumerable<float> a, IEnumerable<float> b, IEnumerable<float> c)
        {
            return a.MyZip(b,c, (d1, d2, d3) => d1 * d2 * d3).Sum();
        }

        /// <summary>
        /// is empty enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool Empty<T>(this IEnumerable<T> a)
        {
            return a == null || a.Count() == 0;
        }

        /// <summary>
        ///  Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <remarks>Exceptions: System.ArgumentNullException: first or second is null.</remarks>
        /// <typeparam name="TFirst">The first input sequence</typeparam>
        /// <typeparam name="TSecond">The second input sequence</typeparam>
        /// <typeparam name="TResult">A function that specifies how to combine the corresponding elements of the two sequences.</typeparam>
        /// <param name="first">The type of the elements of the first input sequence.</param>
        /// <param name="second">The type of the elements of the second input sequence</param>
        /// <param name="resultSelector">The type of the elements of the result sequence</param>
        /// <returns>An System.Collections.Generic.IEnumerable<T> that contains elements of the two input sequences, combined by resultSelector.</returns>
        
        public static IEnumerable<TResult> MyZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            IList<TResult> results = new List<TResult>(first.Count());
            var fe = first.GetEnumerator();
            var se = second.GetEnumerator();
            while (se.MoveNext() && fe.MoveNext())
            {
                results.Add( resultSelector(fe.Current, se.Current) );                
            }
            return results;
        }

        public static IEnumerable<TResult> MyZip<TFirst, TSecond, TThird, TResult>(
            this IEnumerable<TFirst> first
            , 
            IEnumerable<TSecond> second
            ,
            IEnumerable<TThird> third
            , 
            Func<TFirst, TSecond, TThird, TResult> resultSelector
            )
        {
            IList<TResult> results = new List<TResult>(first.Count());
            var fe = first.GetEnumerator();
            var se = second.GetEnumerator();
            var te = third.GetEnumerator();
            //
            while (se.MoveNext() && fe.MoveNext() && te.MoveNext())
            {
                results.Add(resultSelector(fe.Current, se.Current, te.Current));
            }
            return results;
        }
    }
//}
