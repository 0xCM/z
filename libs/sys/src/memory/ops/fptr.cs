//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.InteropServices.Marshal;

    unsafe partial struct memory
    {
        /// <summary>
        /// Given an untyped delegate, yields a funcion pointer invocable from unmanaged code
        /// </summary>
        /// <param name="src">The source delegate</param>
        /// <typeparam name="D">The delegate type</typeparam>
        [MethodImpl(Inline), Op]
        public static unsafe FPtr fptr(Delegate src)
            => new FPtr(GetFunctionPointerForDelegate(src).ToPointer());

        /// <summary>
        /// Given a delegate, yields a funcion pointer invocable from unmanaged code
        /// </summary>
        /// <param name="src">The source delegate</param>
        /// <typeparam name="D">The delegate type</typeparam>
        [MethodImpl(Inline)]
        public static unsafe FPtr<D> fptr<D>(D src)
            where D : Delegate
                => new FPtr<D>(GetFunctionPointerForDelegate<D>(src).ToPointer());
    }
}