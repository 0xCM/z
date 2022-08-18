//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [MethodImpl(Inline), Op]
        public static DbDataType type(uint seq, Name name, Name primitive, DataSize size, Name refinement = default)
            => new DbDataType(seq, name, primitive, size, refinement.IsNonEmpty, refinement);

        public static Index<DbTypeTable> typetables(Assembly src, string group, ICompositeDispenser dst)
        {
            var types = MeasuredType.symbolic(src, group);
            Index<DbTypeTable> tables = sys.alloc<DbTypeTable>(types.Count);
            for(var i=0; i<types.Count; i++)
                tables[i] = MemDb.typetable(types[i], dst);
            return tables.Sort();
        }

        public static DbTypeTable typetable(MeasuredType type, ICompositeDispenser dst)
        {
            var symbols = Symbols.syminfo(type.Definition);
            Index<TypeTableRow> rows = sys.alloc<TypeTableRow>(symbols.Count);
            for(var j=0; j<symbols.Count; j++)
            {
                ref readonly var sym = ref symbols[j];
                ref var row = ref rows[j];
                row.Seq = NextSeq(DbObjectKind.TypeTableRow);
                row.TypeName = dst.Label(type.Definition.Name);
                row.LiteralName = dst.Label(sym.Name.Text);
                row.Position = (ushort)sym.Index;
                row.PackedWidth = (byte)type.Size.PackedWidth;
                row.NativeWidth = (byte)type.Size.NativeWidth;
                row.LiteralValue = sym.Value;
                row.Symbol = dst.Label(sym.Expr.Text);
                row.Description = dst.String(sym.Description.Text);
            }

            return new DbTypeTable(
                NextSeq(DbObjectKind.TypeTable),
                dst.Label(type.Definition.Name),
                type.Size,
                rows
                );
        }
    }
}