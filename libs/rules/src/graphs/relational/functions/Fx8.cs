//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct PointFunctions
    {
        /// <summary>
        /// Defines a total function over an 8-bit domain
        /// </summary>
        public unsafe struct Fx8 : IFunction<Fx8,byte,byte>
        {
            readonly Ptr<byte> PSrc;

            readonly Ptr<byte> PDst;

            internal readonly Index<byte> SrcMap;

            internal uint Size;

            internal const uint Capacity = 256;

            [MethodImpl(Inline)]
            internal Fx8(MemoryAddress src, MemoryAddress dst)
            {
                Size = 0;
                PSrc = src.Pointer<byte>();
                PDst = dst.Pointer<byte>();
                SrcMap = alloc<byte>(Capacity);
            }

            [MethodImpl(Inline)]
            ref readonly byte iY(byte x)
                => ref SrcMap[x];

            [MethodImpl(Inline)]
            public byte Eval(byte x)
                => skip(cover(PDst.P, Size), iY(x));

            [MethodImpl(Inline)]
            public KeyedValue<byte,byte> Map(byte x)
                => (x, Eval(x));
        }
    }
}