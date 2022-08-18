//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Symbols
    {
        public static SymSet set(Type src)
        {
            var specs = Symbols.syminfo(src);
            var tag = src.Tag<SymSourceAttribute>();
            var count = specs.Count;
            var size = Sizes.measure(src);
            var flags = src.Tag<FlagsAttribute>().IsSome();
            var @base = tag.MapValueOrDefault(x => x.NumericBase, NumericBaseKind.Base10);
            var type = Enums.@base(src);
            var group = tag.MapValueOrDefault(x => x.SymGroup, EmptyString);
            var dst = new SymSet(count, src.Name, type, size, @base, flags, group);
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref specs[i];
                dst.Symbols[i] = spec.Expr;
                dst.Names[i] = spec.Name;
                dst.Values[i] = spec.Value;
                dst.Descriptions[i] = spec.Description;
                dst.Positions[i] = spec.Index;
            }
            return dst;
        }

        public static SymSet set(Identifier name, ClrEnumKind type, DataSize size, ReadOnlySpan<string> members, NumericBaseKind @base = NumericBaseKind.Base10)
        {
            var count = (uint)members.Length;
            var dst = new SymSet(count, name, type, size, @base, false, EmptyString);
            for(var i=0u; i<count; i++)
            {
                ref readonly var member = ref skip(members,i);
                dst.Symbols[i] = member;
                dst.Names[i] = member;
                dst.Values[i] = i;
                dst.Descriptions[i] = EmptyString;
                dst.Positions[i] = i;
            }
            return dst;
        }
    }
}