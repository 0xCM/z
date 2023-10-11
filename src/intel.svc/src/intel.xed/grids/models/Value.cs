//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedGrids
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly record struct Value : IValue<ByteBlock3>
    {
        [MethodImpl(Inline)]
        public static Value untype<T>(T src)
            where T : unmanaged, IValue<T>
                => new (sys.bw32(src.Value));

        readonly ByteBlock4 Storage;

        [MethodImpl(Inline)]
        public Value(uint data)
        {
            Storage = data;
        }

        ByteBlock3 IValue<ByteBlock3>.Value
            => Storage.Cell<ByteBlock3>(0);

        public static Value Empty => default;
    }
}
