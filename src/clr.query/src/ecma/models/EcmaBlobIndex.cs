//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(StructLayout, Pack=1)]
    public readonly struct EcmaBlobIndex : IEcmaHeapKey<EcmaBlobIndex>
    {
        public EcmaHeapKind HeapKind => EcmaHeapKind.Blob;

        public readonly uint Value;

        [MethodImpl(Inline)]
        public EcmaBlobIndex(uint src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public EcmaBlobIndex(BlobHandle src)
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
        public static implicit operator BlobHandle(EcmaBlobIndex src)
            => @as<EcmaBlobIndex,BlobHandle>(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaBlobIndex(BlobHandle src)
            => new EcmaBlobIndex(src);

        [MethodImpl(Inline)]
        public static implicit operator EcmaHeapKey(EcmaBlobIndex src)
            => new EcmaHeapKey(src.HeapKind, src.Value);
    }
}