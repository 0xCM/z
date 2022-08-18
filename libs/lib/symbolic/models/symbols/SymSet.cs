//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a collection of symbols
    /// </summary>
    public class SymSet
    {
        public SymSet(uint count, string name, ClrEnumKind type,  DataSize size, NumericBaseKind @base,  bool flags, string group)
        {
            DataType = type;
            Name = name;
            Group = group;
            SymbolCount = count;
            Flags = flags;
            Base = @base;
            Size = size;
            Symbols = alloc<SymExpr>(count);
            Names = alloc<Identifier>(count);
            Values = alloc<SymVal>(count);
            Descriptions = alloc<TextBlock>(count);
            Positions = alloc<uint>(count);
        }

        public readonly string Name;

        public readonly ClrEnumKind DataType;

        public readonly DataSize Size;

        public readonly NumericBaseKind Base;

        public readonly bool Flags;

        public readonly string Group;

        public readonly uint SymbolCount;

        public readonly Index<Identifier> Names;

        public readonly Index<SymVal> Values;

        public readonly Index<SymExpr> Symbols;

        public readonly Index<TextBlock> Descriptions;

        public readonly Index<uint> Positions;

        public Index<SymInfo> Records()
        {
            var buffer = alloc<SymInfo>(SymbolCount);
            for(var i=0; i <SymbolCount; i++)
            {
                ref readonly var name = ref Names[i];
                ref readonly var symbol = ref Symbols[i];
                ref readonly var value = ref Values[i];
                ref readonly var desc = ref Descriptions[i];
                ref readonly var index = ref Positions[i];
                ref var dst = ref seek(buffer,i);
                dst.Group = Group;
                dst.Type = Name;
                dst.Size = Size;
                dst.Value = value;
                dst.Name = name;
                dst.Expr = symbol;
                dst.Description = desc;
                dst.Index = index;
            }
            return buffer;
        }
    }
}