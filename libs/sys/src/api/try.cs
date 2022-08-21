//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Task<T> @try<T>(Func<T> f, Action<Exception> fail)
        {
            try
            {
                return Task.Run(f);
            }
            catch(Exception e)
            {
                fail(e);
                return new Task<T>(() => default(T));
            }
        }
    }
}