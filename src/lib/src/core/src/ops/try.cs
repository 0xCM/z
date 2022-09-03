//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Evaluates a function within a try block and returns the value of the computation if
        /// successful; otherwise, returns None and invokes an error handler if supplied
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="f">The function to evaluate</param>
        [MethodImpl(Inline)]
        public static Option<T> @try<T>(Func<T> f, Action<Exception> handler = null)
            => Option.Try(f,handler ?? OnTryFail);

        /// <summary>
        /// Evaluates a function within a try block and returns the value of the computation if
        /// successful; otherwise, returns None together with the reported exception
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <typeparam name="T">The function result type, if successful</typeparam>
        [MethodImpl(Inline)]
        public static Option<T> @try<T>(Func<Option<T>> f, Action<Exception> handler = null)
            => Option.Try(f,handler ?? OnTryFail);

        /// <summary>
        /// Invokes an action within a try block and, upon error, calls the handler if specified.
        /// If no handler is specified, the exception message is emitted to stderr
        /// </summary>
        /// <param name="f">The action to invoke</param>
        /// <param name="onerror">The error handler to call, if specified</param>
        [MethodImpl(Inline)]
        public static void @try(Action f, Action<Exception> handler = null)
            => Option.Try(f,handler ?? OnTryFail);

        /// <summary>
        /// Evaluates a function within a try block and returns the value of the computation if successful.
        /// Otherwise, returns None together with the reported exception
        /// </summary>
        /// <typeparam name="X">The input type</typeparam>
        /// <typeparam name="Y">The output type</typeparam>
        /// <param name="x">The input value</param>
        /// <param name="f">The function to evaluate</param>
        [MethodImpl(Inline)]
        public static Option<Y> @try<X,Y>(X x, Func<X,Y> f, Action<X,Exception> handler = null)
            => Option.Try(x, f, handler ?? OnTryFail<X>);

        [MethodImpl(Inline)]
        static void OnTryFail(Exception e)
            => Console.WriteLine(e.ToString()); //term.error(e);

        [MethodImpl(Inline)]
        static void OnTryFail<X>(X x, Exception e)
            => Console.WriteLine(e.ToString()); //term.error(e);
    }
}