//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class bits
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static BitCircles bitstack(ulong state)
            => BitCircles.create(state);

        /// <summary>
        /// Wraps a bitview around a generic reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The generic type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitEditor<T> editor<T>(in T src)
            where T : unmanaged
                => new BitEditor<T>(src);
    }
}