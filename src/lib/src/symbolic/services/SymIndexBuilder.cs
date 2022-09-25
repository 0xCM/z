//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using PK = PrimalKind;

    [ApiHost]
    struct SymIndexBuilder
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        internal static Symbols<E> create<E>()
            where E : unmanaged
        {
            var src = discover<E>();
            var count = src.Length;
            var buffer = alloc<Sym<E>>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new Sym<E>(i, skip(src,i));
            return new Symbols<E>(buffer, luString<E>(buffer), luValue<E>(buffer));
        }

        [Op]
        internal static Index<SymIndex> create(Type[] src)
        {
            var count = src.Length;
            var dst = alloc<SymIndex>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = create(skip(src,i));
            return dst;
        }

        [Op]
        internal static SymIndex create(Type t)
        {
            var src = discover(t);
            var count = src.Length;
            var symbols = alloc<Sym>(count);
            ref var dst = ref first(symbols);
            for(var i=0u; i<count; i++)
            {
                ref readonly var lit = ref skip(src,i);
                seek(dst,i) = new Sym(lit.Identity, lit.Group, lit.Index, lit.Type, lit.Value, lit.Name, lit.Symbol.Text, lit.Description, lit.Hidden, lit.FieldValue, lit.Size);
            }

            return new SymIndex(symbols, luString(symbols), luValue(symbols));
        }

        [Op, Closures(Closure)]
        static Sym untype<T>(Sym<T> src)
            where T : unmanaged
                => new Sym(src.Identity, src.Group, src.Key, src.Type, bw64(src.Kind), src.Name, src.Expr.Text, src.Description, src.Hidden, src.Kind, src.Size);

        public static SymIndex untype<E>(Sym<E>[] src)
            where E : unmanaged
        {
            var symbols = src.Select(x => untype(x));
            return new SymIndex(symbols, luString(symbols), luValue(symbols));
        }

        [Op]
        static SymIdentity identity(FieldInfo field, ushort index, SymExpr expr)
            => string.Format("{0:D3}:{1}:{2}::{3}.{4}({5})",
                    index,
                    text.bracket((EcmaToken)field),
                    field.DeclaringType.Assembly.GetSimpleName(),
                    field.DeclaringType.FullName,
                    field.Name,
                    expr);

        [Op, Closures(Closure)]
        static Dictionary<string,Sym<K>> luString<K>(Index<Sym<K>> src)
            where K : unmanaged
        {
            var count = src.Length;
            var view = src.View;
            var dst = dict<string,Sym<K>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(view,i);
                dst.TryAdd(symbol.Expr.Text, symbol);
            }

            return dst;
        }

        [Op, Closures(Closure)]
        static Dictionary<SymVal,Sym<K>> luValue<K>(Index<Sym<K>> src)
            where K : unmanaged
        {
            var count = src.Length;
            var view = src.View;
            var dst = dict<SymVal,Sym<K>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(view,i);
                dst.TryAdd(symbol.Value, symbol);
            }

            return dst;
        }

        [Op, Closures(Closure)]
        static Dictionary<string,Sym> luString(Index<Sym> src)
        {
            var count = src.Length;
            var view = src.View;
            var dst = dict<string,Sym>();
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(view,i);
                dst.TryAdd(symbol.Expr.Text, symbol);
            }

            return dst;
        }

        [Op, Closures(Closure)]
        static Dictionary<SymVal,Sym> luValue(Index<Sym> src)
        {
            var count = src.Length;
            var view = src.View;
            var dst = dict<SymVal,Sym>();
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(view,i);
                dst.TryAdd(symbol.Value, symbol);
            }

            return dst;
        }

        [Op]
        static ulong @ulong(PrimalKind kind, object src)
            => kind switch {
                PK.U8 => (ulong)(byte)src,
                PK.I8 => (ulong)(sbyte)src,
                PK.U16 => (ulong)(ushort)src,
                PK.I16 => (ulong)(short)src,
                PK.U32 => (ulong)(uint)src,
                PK.I32 => (ulong)(int)src,
                PK.I64 => (ulong)(long)src,
                PK.U64 => (ulong)src,
                _ => 0ul,
            };

        [Op, Closures(Closure)]
        static Span<SymLiteral<E>> discover<E>()
            where E : unmanaged
        {
            var src = typeof(E);
            ClrAssemblyName component = src.Assembly;
            var fields = src.LiteralFields().ToReadOnlySpan();
            var count = fields.Length;
            var dst = span<SymLiteral<E>>(count);
            var kind = PrimalBits.kind(src);
            var group = Symbols.group(typeof(E));
            var size = Sizes.measure(src);
            var counter = 0u;
            for(var i=z16; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                var tag = f.Tag<SymbolAttribute>();
                ref var row = ref seek(dst,i);
                var expr = tag ? tag.Value.Symbol : f.Name;
                var litval = (E)f.GetRawConstantValue();
                row.Component = component;
                row.Type = src.Name;
                row.DataType = kind;
                row.Group = group;
                row.Size = size;
                row.Index = i;
                row.Name = f.Name;
                row.Symbol = (litval,expr);
                row.Value = @ulong(kind, litval);
                row.Description = tag.MapValueOrDefault(a => a.Description, EmptyString);
                row.Identity = identity(f, i, expr);
                row.Hidden = f.Ignored();
            }

            return dst;
        }

        [Op, Closures(Closure)]
        static Span<SymLiteral> discover(Type src)
        {
            ClrAssemblyName component = src.Assembly;
            var tag = src.Tag<SymSourceAttribute>();
            var fields = src.LiteralFields().ToReadOnlySpan();
            var count = fields.Length;
            var dst = span<SymLiteral>(count);
            var kind = PrimalBits.kind(src);
            var group = Symbols.group(src);
            var size = Sizes.measure(src);
            var @base = tag.MapValueOrDefault(t => t.NumericBase, NumericBaseKind.Base10);
            var counter = 0u;
            for(var i=z16; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                var symtag = f.Tag<SymbolAttribute>();
                ref var row = ref seek(dst,i);
                var expr = symtag ? symtag.Value.Symbol : f.Name;
                var litval = f.GetRawConstantValue();
                row.Component = src.Assembly.GetSimpleName();
                row.Type = src.Name;
                row.DataType = kind;
                row.Group = group;
                row.Size = size;
                row.Base = @base;
                row.Index = i;
                row.Name = f.Name;
                row.Symbol = expr;
                row.Value = @ulong(kind, litval);
                row.Description = symtag.MapValueOrDefault(a => a.Description, EmptyString);
                row.Identity = identity(f, i, expr);
                row.Hidden = f.Ignored();
                row.FieldValue = litval;
            }

            return dst;
        }
    }
}