//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    public readonly struct TextMarkers
    {
        [MethodImpl(Inline), Op]
        public static TextMarker define(string id, string src)
            => new TextMarker(id, src);

        /// <summary>
        /// Constructs a set of markers from a type that defines literal string values and/or static <see cref='TextMarker'/> properties
        /// </summary>
        /// <param name="provider">The type to query</param>
        [Op]
        public static TextMarkers discover(Type provider)
        {
            var fields = provider.LiteralFields(typeof(string)).Tagged<TextMarkerAttribute>().ToReadOnlySpan();
            var count = fields.Length;
            if(count == 0)
                return TextMarkers.Empty;

            var buffer = sys.alloc<TextMarker>(count);
            ref var dst = ref core.first(buffer);
            var j=0;
            for(var i=0; i<count; i++, j++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(dst,j) = define(field.Name, (string)field.GetRawConstantValue());

            }
            return new TextMarkers(buffer);
        }

        readonly Index<TextMarker> Data;

        [MethodImpl(Inline)]
        public TextMarkers(TextMarker[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<TextMarker> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref readonly TextMarker this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly TextMarker this[long index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        [MethodImpl(Inline)]
        public static implicit operator TextMarkers(TextMarker[] src)
            => new TextMarkers(src);

        public static TextMarkers Empty
            => new TextMarkers(sys.empty<TextMarker>());
    }
}