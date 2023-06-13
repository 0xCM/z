//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = CharBlock;

    public ref struct CharBlock<N>
        where N : unmanaged, ITypeNat
    {
        readonly Span<char> Buffer;

        [MethodImpl(Inline)]
        public CharBlock()
        {
            Buffer = new char[nat32i<N>()];            
        }

        [MethodImpl(Inline)]
        internal CharBlock(Span<char> buffer)
        {
            Buffer = buffer;
        }

        [MethodImpl(Inline)]
        public CharBlock(ReadOnlySpan<char> src)
        {
            Buffer = new char[nat32i<N>()];
            var n =  nat32u<N>();
            var k = src.Length;
            for(var i=0; i<n && i<k; i++, k++)
                seek(Buffer,i) = skip(src,i);            
            sys.copy(src, Buffer);
        }

        public uint Capacity
        {
            [MethodImpl(Inline)]
            get => nat32u<N>();
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => api.length(this);
        }

        public Span<char> Data
        {
            [MethodImpl(Inline)]
            get => Buffer;
        }

        /// <summary>
        /// If the block contains no null-terminators, returns a readonly view of the data source; otherwise
        /// returns the content preceding the first null-terminator
        /// </summary>
        public ReadOnlySpan<char> String
        {
            [MethodImpl(Inline)]
            get => text.@string(Data);
        }

        /// <summary>
        /// Specifies a reference to the leading cell
        /// </summary>
        public ref char First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public ref char this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public ref char this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CharBlock<N>(string src)
            => api.init(src, out CharBlock<N> dst);
 
        [MethodImpl(Inline)]
        public static implicit operator CharBlock<N>(ReadOnlySpan<char> src)
            => api.init(src, out CharBlock<N> dst);
    }
}