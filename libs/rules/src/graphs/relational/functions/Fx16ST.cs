//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct PointFunctions
    {
        /// <summary>
        /// Defines a total function over a 16-bit domain
        /// </summary>
        public unsafe struct Fx16<S,T> : IFunction<Fx16<S,T>,S,T>
            where S : unmanaged
            where T : unmanaged
        {
            readonly Ptr<S> PSrc;

            readonly Ptr<T> PDst;

            internal readonly Index<ushort> SrcMap;

            internal uint Size;

            internal const uint Capacity = ushort.MaxValue + 1;

            [MethodImpl(Inline)]
            internal Fx16(MemoryAddress src, MemoryAddress dst)
            {
                Size = 0;
                PSrc = src.Pointer<S>();
                PDst = dst.Pointer<T>();
                SrcMap = alloc<ushort>(Capacity);
            }

            [MethodImpl(Inline)]
            ref readonly ushort iY(ushort x)
                => ref SrcMap[x];

            [MethodImpl(Inline)]
            public T Eval(S x)
                => skip(cover(PDst.P, Size), iY(u16(x)));

            [MethodImpl(Inline)]
            public KeyedValue<S,T> Map(S x)
                => (x, Eval(x));
        }
    }
}