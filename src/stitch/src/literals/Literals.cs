//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Literals
    {
        const NumericKind Closure = UnsignedInts;

        public static Index<ClrLiteralInfo> runtimelits(Index<LiteralProvider> src)
        {
            var providers = src.Select(provider => (Provider: provider, Fields: provider.Type.LiteralFields().Index()));
            var count = providers.Storage.Select(x => x.Fields.Count).Sum();
            var dst = sys.alloc<ClrLiteralInfo>(count);
            var k=0u;
            for(var i=0; i<providers.Count; i++)
            {
                ref readonly var provided = ref providers[i];
                var provider = provided.Provider;
                var fields = provided.Fields;
                for(var j=0; j<fields.Count; j++, k++)
                {
                    ref readonly var field = ref fields[j];
                    var datatype = field.FieldType;
                    var host = field.DeclaringType;
                    var lk = ClrLiteralKind.None;
                    if(datatype.IsEnum)
                        lk = (ClrLiteralKind)Enums.@base(datatype);
                    else
                        lk = (ClrLiteralKind)PrimalBits.kind(datatype);
                    seek(dst,k) = new (host.Assembly.PartName(), provider.Group, ClrLiterals.name(host), ClrLiterals.name(field), field.GetRawConstantValue(), lk);
                }
            }
            return dst;
        }


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Literal<T> literal<T>(string name, T value)
            => new Literal<T>(name, value);

        [Op]
        public static RuntimeLiteralValue<object> value(in ClrLiteralInfo src)
            => new RuntimeLiteralValue<object>(src.Value);

        public static string format(in ClrLiteralInfo src)
            => string.Format("{0,-16} | {1,-16} | {2,-12} | {3}", src.Type, src.Name, src.Kind, value(src));

        public static string format<T>(in RuntimeLiteralValue<T> src)
            where T : IEquatable<T>
        {
            var data = src.Data.ToString();
            var content = data switch
            {
                RP.WinEol => "<weol>",
                RP.LinuxEol => "<leol>",
                RP.AsciNull => "<ascinull>",
                _ => data
            };
            return text.ticks(content);
        }

        public static string format<T>(LiteralSeq<T> src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = text.buffer();
            var w = sys.width<T>();
            var count = src.Count;
            var offset = 0u;
            dst.AppendLine(string.Format("LiteralSeq<{0}> {1} = new ({1}, new {0}[{2}]", typeof(T).Name, src.Name, src.Count));
            dst.AppendLine("{");
            offset +=4;
            for(var i=0; i<count; i++)
                dst.IndentLine(offset, src[i].Format());
            offset -=4;
            dst.IndentLine(offset, "})");
            return dst.Emit();
        }

        public static LiteralSeq<T> seq<T>(string name, ReadOnlySpan<string> names, ReadOnlySpan<T> values)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(names, values));

        public static LiteralSeq<T> seq<T>(string name, ReadOnlySpan<T> src)
            where T : IEquatable<T>, IComparable<T>
                => new LiteralSeq<T>(name, literals(src));

        public static LiteralSeq<E> seq<E>(string name, LiteralNameSource ns)
            where E : unmanaged, Enum, IComparable<E>, IEquatable<E>
        {
            var src = Symbols.index<E>();
            var count = src.Count;
            var dst = sys.alloc<Literal<E>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = literal<E>(Literals.name(src[i], ns), src[i].Kind);
            return new LiteralSeq<E>(name, dst);
        }

        static Index<Literal<T>> literals<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            var dst = sys.alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new (skip(src,i).ToString(), skip(src,i));
            return dst;
        }

        static Index<Literal<T>> literals<T>(ReadOnlySpan<string> names, ReadOnlySpan<T> values)
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = sys.alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new (skip(names,i), skip(values,i));
            return literals;
        }

        static string name<E>(Sym<E> sym, LiteralNameSource src)
            where E : unmanaged
            => src switch{
                LiteralNameSource.Expression => sym.Expr.Text,
                LiteralNameSource.Identifier => sym.Name,
                _ => sym.Name
            };
    }
}