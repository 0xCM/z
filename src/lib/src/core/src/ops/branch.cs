// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Executes one of two functions depending on the evaluation criterion
        /// </summary>
        /// <param name="x">The value to supply to the predicate and one of the handlers</param>
        /// <param name="bool">The predicate to evalue to determine which function will map the value</param>
        /// <param name="true">The function to evaluate when the criterion is true</param>
        /// <param name="false">The function to evaluate when the criterion is false</param>
        /// <typeparam name="X">The function input type</typeparam>
        /// <typeparam name="Y">The function output type</typeparam>
        [MethodImpl(Inline)]
        public static Y branch<X,Y>(X x, Func<X,bool> @bool, Func<X,Y> @true, Func<X,Y> @false)
            where X : struct
                => @bool(x) ? @true(x) : @false(x);

        /// <summary>
        /// Executes one action if a condition is true and another should it be false
        /// </summary>
        /// <param name="condition">Specifies whether some condition is true</param>
        /// <param name="true">The action to invoke when condition is true</param>
        /// <param name="false">The action to invoke when condition is false</param>
        [MethodImpl(Inline), Op]
        public static void branch(bool condition, Action @true, Action @false)
        {
            if (condition)
                @true();
            else
                @false();
        }
    }
}