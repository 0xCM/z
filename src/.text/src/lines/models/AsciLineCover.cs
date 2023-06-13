//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public ref struct AsciLineCover
    {
        [MethodImpl(Inline), Op]
        public static void unicode(in AsciLineCover src, uint line, Span<char> buffer, out UnicodeLine dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(buffer, i) = (char)skip(src.Codes,i);
            dst = new UnicodeLine(line, text.format(buffer));
        }

        /// <summary>
        /// The line content
        /// </summary>
        readonly ReadOnlySpan<byte> Data;

        [MethodImpl(Inline)]
        public AsciLineCover(ReadOnlySpan<AsciSymbol> src)
        {
            Data = recover<AsciSymbol,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLineCover(ReadOnlySpan<AsciCode> src)
        {
            Data = recover<AsciCode,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLineCover(ReadOnlySpan<byte> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public AsciLineCover(Span<byte> src)
        {
            Data = src;
        }

        public ReadOnlySpan<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciCode>(Data);
        }

        public ReadOnlySpan<AsciSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciSymbol>(Data);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public int RenderLength
        {
            [MethodImpl(Inline)]
            get => Data.Length + LineNumber.RenderLength;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public ref readonly AsciSymbol this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref @as<byte,AsciSymbol>(skip(Data,index));
        }

        public ref readonly AsciSymbol this[int index]
        {
            [MethodImpl(Inline)]
            get => ref @as<byte,AsciSymbol>(skip(Data,index));
        }

        [MethodImpl(Inline)]
        public uint Render(Span<char> dst)
        {
            var i=0u;
        {
            var i0 = i;
            if(IsNonEmpty)
                text.render(Codes, ref i, dst);
            return i - i0;
        }
        }

        public string Format()
        {
            Span<char> buffer = stackalloc char[RenderLength];
            var i=0u;
            text.render(Codes, ref i, buffer);
            return sys.@string(buffer);
        }

        public static AsciLineCover Empty
        {
            [MethodImpl(Inline)]
            get => new AsciLineCover(default(ReadOnlySpan<byte>));
        }
    }
}