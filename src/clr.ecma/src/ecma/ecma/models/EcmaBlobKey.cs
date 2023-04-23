//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(StructLayout, Pack=1)]
    public readonly struct EcmaBlobKey : IEcmaHeapKey<EcmaBlobKey>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.Blob;

        public readonly uint Value;

        [MethodImpl(Inline)]
        public EcmaBlobKey(uint src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public EcmaBlobKey(BlobHandle src)
        {
            Value = u32(src);
        }

        uint IEcmaHeapKey.Value
            => Value;

        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BlobHandle(EcmaBlobKey src)
            => @as<EcmaBlobKey,BlobHandle>(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaBlobKey(BlobHandle src)
            => new EcmaBlobKey(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(EcmaBlobKey src)
            => new EcmaHeapKey(src.HeapKind, src.Value);
    }
}