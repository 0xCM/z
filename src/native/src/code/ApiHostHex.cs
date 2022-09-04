//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public readonly struct ApiHostHex
    {
        public readonly _ApiHostUri Host;

        public readonly MemoryBlocks Hex;

        [MethodImpl(Inline)]
        public ApiHostHex(_ApiHostUri uri, MemoryBlocks hex)
        {
            Host = uri;
            Hex = hex;
        }

        [MethodImpl(Inline)]
        public static implicit operator ApiHostHex((_ApiHostUri uri, MemoryBlocks hex) src)
            => new ApiHostHex(src.uri, src.hex);
    }
}