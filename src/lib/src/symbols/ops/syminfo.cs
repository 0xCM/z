//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Symbols
    {
        [Op]
        public static Index<SymInfo> syminfo(ReadOnlySpan<Type> src)
        {
            var dst = list<SymInfo>();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(src,i);
                var symbols = untyped(type);
                var size = Sizes.measure(type);
                for(var j=0u; j<symbols.Length; j++)
                {
                    ref readonly var symbol = ref symbols[j];
                    var record = new SymInfo();
                    var tag = type.Tag<SymSourceAttribute>();
                    var group = tag.MapValueOrDefault(x => x.SymGroup, EmptyString);
                    var @base = tag.MapValueOrDefault(t => t.NumericBase, NumericBaseKind.Base10);
                    record.Index = j;
                    record.Type = type.Name;
                    record.Group = group;
                    record.Size = size;
                    record.Value = (symbol.Value,@base);
                    record.Name = symbol.Name;
                    record.Expr = symbol.Expr;
                    record.Description = symbol.Description;
                    dst.Add(record);
                }
            }
            return dst.ToArray();
        }

        [Op]
        public static Index<SymInfo> syminfo<K>(ReadOnlySpan<Type> src)
            where K : unmanaged
        {
            var dst = list<SymInfo>();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(src,i);
                var symbols = untyped(type);
                var size = Sizes.measure(type);
                for(var j=0u; j<symbols.Length; j++)
                {
                    ref readonly var symbol = ref symbols[j];
                    var record = new SymInfo();
                    var tag = type.Tag<SymSourceAttribute>();
                    var @base = tag.MapValueOrDefault(t => t.NumericBase, NumericBaseKind.Base10);
                    var group = tag.MapValueOrDefault(x => x.SymGroup, EmptyString);
                    record.Index = j;
                    record.Type = type.Name;
                    record.Group = group;
                    record.Size = size;
                    record.Value = (symbol.Value,@base);
                    record.Name = symbol.Name;
                    record.Expr = symbol.Expr;
                    record.Description = symbol.Description;
                    dst.Add(record);
                }
            }
            return dst.ToArray();
        }

        [Op]
        public static Index<SymInfo> syminfo(Type src)
        {
            var symbols = Symbols.untyped(src);
            var count = symbols.Length;
            var tag = src.Tag<SymSourceAttribute>();
            var @base = tag.MapValueOrDefault(t => t.NumericBase, NumericBaseKind.Base10);
            var group = tag.MapValueOrDefault(x => x.SymGroup, EmptyString);
            var buffer = alloc<SymInfo>(count);
            var size = Sizes.measure(src);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref symbols[i];
                ref var dst = ref seek(buffer,i);
                dst.Index = i;
                dst.Type = src.Name;
                dst.Group = group;
                dst.Size = size;
                dst.Value = (symbol.Value, @base);
                dst.Name =  symbol.Name;
                dst.Expr = symbol.Expr;
                dst.Description = symbol.Description;
            }
            return buffer;
        }

        public static Index<SymInfo> syminfo<E>()
            where E : unmanaged, Enum
                => syminfo(typeof(E));
    }
}