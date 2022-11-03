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
        [Parser]
        public static bool parse(string src, out HexArray dst)
        {
            dst = HexArray.Empty;
            var l = text.index(src, Chars.LBracket);
            var r = text.index(src, Chars.RBracket);
            var i0 = 0;
            var i1 = 0;
            if(l < 0 || r < 0 || r <= l)
            {
                i0 = 0;
                i1 = src.Length - 1;
            }
            else
            {
                i0 = l + 1;
                i1 = r - 1;
            }

            var data =  text.segment(src, i0, i1);
            var cells = data.SplitClean(Chars.Comma).ToReadOnlySpan();
            var count = cells.Length;
            var buffer = alloc<byte>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref skip(cells,i);
                if(!Hex.parse8u(cell, out seek(target,i)))
                    return false;
            }
            dst = buffer;
            return true;
        }


        [MethodImpl(Inline), Op]
        public static HexArray from(byte[] src)
            => new HexArray(src);

        [MethodImpl(Inline), Op]
        public static HexArray16 from(ReadOnlySpan<byte> src, N16 n)
        {
            var size = src.Length;
            if(size <= 16)
                return @as<HexArray16>(first(src));
            else
            {
                var dst = HexArray16.Empty;
                store(src, ref dst);
                return dst;
            }
        }        

        [MethodImpl(Inline), Op]
        public static ref HexArray16 store(ReadOnlySpan<byte> src, ref HexArray16 dst)
        {
            ref var target = ref @as<HexArray16,byte>(dst);
            var count = min(src.Length, 16);
            for(var i=0; i<count; i++)
                seek(target,i) = skip(src,i);
            return ref dst;
        }

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