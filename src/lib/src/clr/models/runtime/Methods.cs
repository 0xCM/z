//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Domain(typeof(MethodInfo))]
    public readonly struct Methods : IIndex<MethodInfo>
    {
        readonly Index<MethodInfo> Data;

        [MethodImpl(Inline)]
        public Methods(MethodInfo[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public MethodInfo[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Span<MethodInfo> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<MethodInfo> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref MethodInfo this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref MethodInfo this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator Methods(MethodInfo[] src)
            => new Methods(src);

        [MethodImpl(Inline)]
        public static implicit operator MethodInfo[](Methods src)
            => src.Data;
    }
}