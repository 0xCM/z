//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    [ApiHost]
    public readonly struct HexArray
    {
        [MethodImpl(Inline)]
        public static HexArray cover(byte[] src)
            => new HexArray(src);

        public static HexArray from(ReadOnlySpan<byte> src)
            => cover(src.ToArray());

        public static HexArray alloc(uint n)
            => new HexArray(new byte[n]);

        public static HexArray from(byte src)
            => cover(new byte[]{src});

        public static HexArray from(ushort src)
            => cover(bytes(src).ToArray());

        public static HexArray from(uint src)
            => cover(bytes(src).ToArray());

        public static HexArray from(ulong src)
            => cover(bytes(src).ToArray());

        readonly Index<byte> Data;

        [MethodImpl(Inline)]
        public HexArray(byte[] data)
        {
            Data = data;
        }

        public HexArray Clear()
        {
            Data.Clear();
            return this;
        }

        [MethodImpl(Inline)]
        public uint Write(ReadOnlySpan<byte> src, uint offset)
        {
            var j = 0u;
            var count = Count;
            var terms = src.Length;
            for(var i=offset; i<count && j<terms; i++)
                this[i] = skip(src,j++);

            return j;
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref byte this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref byte this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public string Format(bool enclose)
        {
            var content = HexFormatter.array(Data.View);
            return enclose ? text.bracket(content) : content;
        }

        public string Format(Fence<char> fence)
        {
            var content = HexFormatter.array(Data.View);
            return string.Format("{0}{1}{2}", fence.Left, content, fence.Right);
        }

        public string Format()
            => Format(true);

        public override string ToString()
            => Format(true);

        [MethodImpl(Inline)]
        public static implicit operator HexArray(byte[] src)
            => new HexArray(src);

        public static HexArray Empty
        {
            [MethodImpl(Inline)]
            get => Array.Empty<byte>();
        }
    }
}