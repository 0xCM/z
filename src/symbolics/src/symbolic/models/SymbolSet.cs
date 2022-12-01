//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a collection of symbols
    /// </summary>
    public class SymbolSet
    {
        public SymbolSet(uint count, string name, ClrEnumKind type,  DataSize size, NumericBaseKind @base, bool flags, string group)
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
                ref var dst = ref seek(buffer,i);
                dst.Name = Names[i];
                dst.Group = Group;
                dst.Type = Name;
                dst.Size = Size;
                dst.Value = Values[i];
                dst.Expr = Symbols[i];
                dst.Description = Descriptions[i];
                dst.Index = Positions[i];
            }
            return buffer;
        }
    }
}