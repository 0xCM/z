//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct NativeTypeSeq : IEnumerable<NativeType>
    {
        readonly ByteBlock32 Storage;

        static N16 N => default;

        public byte MaxCount
        {
            [MethodImpl(Inline)]
            get => (byte)N.NatValue;
        }

        public byte Count
        {
            [MethodImpl(Inline)]
            get => NativeSigs.nonempty(this);
        }

        public Span<NativeType> Edit
        {
            [MethodImpl(Inline), UnscopedRef]
            get => recover<NativeType>(sys.bytes(this));
        }

        public ReadOnlySpan<NativeType> View
        {
            [MethodImpl(Inline), UnscopedRef]
            get => recover<NativeType>(sys.bytes(this));
        }

        public ref NativeType this[uint i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Edit,i);
        }

        public ref NativeType this[int i]
        {
            [MethodImpl(Inline), UnscopedRef]
            get => ref seek(Edit,i);
        }

        public IEnumerator<NativeType> GetEnumerator()
            => throw new NotImplementedException();

        IEnumerator IEnumerable.GetEnumerator()
            => throw new NotImplementedException();
    }
}