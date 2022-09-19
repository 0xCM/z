//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    [ApiHost]
    public readonly struct CharMaps
    {
        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static CharMapEntry<T> entry<T>(Hex16 src, T dst)
            where T : unmanaged, IComparable<T>, IEquatable<T>
                => new CharMapEntry<T>(src, dst);

        public static CharMapEditor<T> editor<T>()
            where T : unmanaged
                => new CharMapEditor<T>(alloc<T>(ushort.MaxValue));

        [MethodImpl(Inline), Op]
        public static uint render(Paired<Hex16,char> src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            Hex.render(LowerCase, src.Left, ref i, dst);
            seek(dst,i++) = Chars.Colon;
            seek(dst,i++) = src.Right;
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render(CharMapEntry<char> src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            Hex.render(LowerCase, src.Source, ref i, dst);
            seek(dst,i++) = Chars.Colon;
            seek(dst,i++) = src.Target;
            return i-i0;
        }

        // [Op]
        // public static string format(Paired<Hex16,char> src)
        // {
        //     Span<char> dst = stackalloc char[16];
        //     var i=0u;
        //     var count = render(src,ref i, dst);
        //     return text.format(slice(dst,0,count));
        // }

        [Op]
        public static string format(CharMapEntry<char> src)
        {
            Span<char> dst = stackalloc char[16];
            var i=0u;
            var count = render(src,ref i, dst);
            return text.format(slice(dst,0,count));
        }

        public static CharMapEditor<AsciCode> editor(AsciPoints src)
        {
            var editor = editor<AsciCode>();
            init(editor);
            return editor;
        }

        public static CharMap<char> create(UnicodePoints src, AsciPoints dst)
            => CharMaps.editor(src, dst).Seal();

        public static CharMapEditor<char> editor(UnicodePoints src, AsciPoints dst)
        {
            var editor = editor<char>();
            init(editor);
            return editor;
        }

        [MethodImpl(Inline), Op]
        public static void init(in CharMapEditor<char> editor)
        {
            for(char i=(char)0; i<128; i++)
                editor[i] = i;
        }

        [MethodImpl(Inline), Op]
        public static void init(in CharMapEditor<AsciCode> editor)
        {
            for(char i= (char)0; i<128; i++)
                editor[i] = (AsciCode)i;
        }

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static ushort assign<T>(in CharMapEditor<T> editor, ushort offset, ReadOnlySpan<T> src)
            where T : unmanaged
        {
            var j = z16;
            for(var i= offset; i<src.Length; i++)
                editor[(char)i] = skip(src,j++);
            return j;
        }

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static uint apply<T>(in CharMap<T> map, ReadOnlySpan<char> src, Span<T> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = map[skip(src,i)];
            return count;
        }

        [MethodImpl(Inline), Op, Closures(UInt8x16k)]
        public static ref T apply<T>(in CharMap<T> map, char c, ref T dst)
            where T : unmanaged
        {
            dst = map[c];
            return ref dst;
        }

        [Op, Closures(UInt8x16k)]
        public static ReadOnlySpan<char> unmapped<T>(in CharMap<T> map, ReadOnlySpan<char> src)
            where T : unmanaged
        {
            var dst = hashset<char>();
            unmapped(map,src,dst);
            return dst.Array();
        }

        /// <summary>
        /// Queries the source for unmapped characters and emits the result to a caller-supplied target
        /// </summary>
        /// <param name="map">The context map</param>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        /// <typeparam name="T">The map cell type</typeparam>
        [Op, Closures(UInt8x16k)]
        public static void unmapped<T>(in CharMap<T> map, ReadOnlySpan<char> src, HashSet<char> dst)
            where T : unmanaged
        {
            var count = src.Length;
            for(var i = 0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(!map.IsMapped(c))
                    dst.Add(c);
            }
        }

        /// <summary>
        /// Writes a specified character map to a file and returns the number of entries emitted
        /// </summary>
        /// <param name="map">The source map</param>
        /// <param name="dst">The target file</param>
        /// <typeparam name="T">The map cell type</typeparam>
        public static ushort emit<T>(in CharMap<T> map, StreamWriter dst)
            where T : unmanaged
        {
            var src = map.View;
            var count = src.Length;
            var counter = z16;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref c16(skip(src,i));
                if(c != 0)
                {
                    // Symbolize whitespace characters via their identifiers
                    if(SymbolicQuery.whitespace(c))
                        dst.WriteLine(string.Format("{0}:({1})", (Hex16)i, ((AsciCode)c)));
                    else
                        dst.WriteLine(format(entry((Hex16)i,c)));
                    counter++;
                }
            }
            return counter;
        }
    }
}