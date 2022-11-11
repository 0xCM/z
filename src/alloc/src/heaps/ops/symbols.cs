//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Heaps
    {
        public static SymHeap symbols<E>()
            where E : unmanaged, Enum
                => load(symlits<E>());

        public static ReadOnlySeq<SymLiteralRow> symlits<E>()
            where E : unmanaged, Enum
        {
            var symbols = Symbols.index<E>().View;
            var dst = sys.alloc<SymLiteralRow>(symbols.Length);
            fill<E>(symbols, dst);
            return dst;
        }

        [Op]
        public static ReadOnlySeq<SymLiteralRow> symlits(Type src)
        {
            var fields = @readonly(src.LiteralFields());
            var dst = sys.alloc<SymLiteralRow>(fields.Length);
            fill(src, PrimalBits.kind(src), fields, dst);
            return dst;
        }

        [Op]
        public static ReadOnlySeq<SymLiteralRow> symlits(Index<Type> src)
        {
            var dst = list<SymLiteralRow>();
            var kTypes = src.Count;
            for(var i=0; i<kTypes; i++)
                dst.AddRange(symlits(src[i]));
            return dst.Array();
        }

        [Op]
        public static ReadOnlySeq<SymLiteralRow> symlits(Index<Assembly> src)
            => symlits(Enums.types(src).Ignore().OrderBy(src => src.Name));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static void fill<E>(ReadOnlySpan<Sym<E>> src, Span<SymLiteralRow> dst)
            where E : unmanaged
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst, i) = untype(symlit(skip(src,i), out _));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static ref SymLiteral<E> symlit<E>(in Sym<E> src, out SymLiteral<E> dst)
            where E : unmanaged
        {
            var type = typeof(E);
            dst.Component = typeof(E).Assembly;
            dst.DataType = PrimalBits.kind(type);
            dst.Group = src.Group;
            dst.Size = src.Size;
            dst.Description = src.Description;
            dst.Value = src.Value;
            dst.Identity = src.Identity;
            dst.Name = src.Name;
            dst.Index = (uint)src.Key.Value;
            dst.Symbol = (src.Kind, src.Expr.Format());
            dst.Type = src.Type;
            dst.Hidden = src.Hidden;
            return ref dst;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static SymLiteralRow untype<E>(in SymLiteral<E> src)
            where E : unmanaged
        {
            var dst = new SymLiteralRow();
            dst.Component = src.Component.SimpleName;
            dst.Type = src.Type;
            dst.Group = src.Group;
            dst.Size = src.Size;
            dst.Index = src.Index;
            dst.Name = src.Name;
            dst.Symbol = src.Symbol;
            dst.DataType = src.DataType;
            dst.Value = src.Value;
            dst.Base = NumericBaseKind.Base10;
            dst.Description = src.Description;
            dst.Hidden = src.Hidden;
            dst.Identity = src.Identity;
            return dst;
        }

        [Op]
        static void fill(Type src, PrimalKind kind, ReadOnlySpan<FieldInfo> fields, Span<SymLiteralRow> dst)
        {
            var count = fields.Length;
            var component = src.Assembly.GetSimpleName();
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                ref var row = ref seek(dst,i);
                var tag = f.Tag<SymbolAttribute>();
                row.Component = component;
                row.Type = src.Name;
                row.DataType = kind;
                row.Group = Symbols.group(src);
                row.Size = Sizes.measure(src);
                row.Index = (ushort)i;
                row.Name = f.Name;
                row.Value = Enums.unbox(kind, f.GetRawConstantValue());
                row.Base = NumericBaseKind.Base10;
                row.Symbol = tag.MapValueOrDefault(a => a.Symbol, f.Name);
                row.Description = tag.MapValueOrDefault(a => a.Description, EmptyString);
                row.Hidden = f.Ignored();
            }
        }

         public static SymHeap<K,byte,byte> symbols<K>(W8 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,byte,byte>();

        public static SymHeap<K,ushort,byte> symbols<K>(W16 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,ushort,byte>();

        public static SymHeap<K,ushort,ushort> symbols<K>(W16 wO, W16 wL)
            where K : unmanaged, Enum
                => symbols<K,ushort,ushort>();

        public static SymHeap<K,uint,byte> symbols<K>(W32 wO, W8 wL)
            where K : unmanaged, Enum
                => symbols<K,uint,byte>();

        public static SymHeap<K,uint,ushort> symbols<K>(W32 wO, W16 wL)
            where K : unmanaged, Enum
                => symbols<K,uint,ushort>();

        public static SymHeap<K,O,L> symbols<K,O,L>()
            where K : unmanaged, Enum
            where O : unmanaged
            where L : unmanaged
        {
            var symbols = Symbols.index<K>();
            var count = symbols.Count;
            var content = text.buffer();
            var offsets = span<O>(count);
            var lengths = span<L>(count);
            var entries = span<HeapEntry<K,O,L>>(count);
            var offset = 0u;
            for(var i=0; i<symbols.Count; i++)
            {
                var expr = symbols[i].Expr.Data;
                var length = (uint)expr.Length;
                seek(entries,i) = new HeapEntry<K,O,L>(symbols[i].Kind, @as<uint,O>(offset), @as<uint,L>(length));
                content.Append(expr);
                offset += length;
            }
            return new SymHeap<K,O,L>(entries,content.Emit());
        }
    }
}