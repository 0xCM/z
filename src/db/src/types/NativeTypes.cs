//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class NativeTypes
    {
        // public static ReadOnlySeq<MeasuredType> symbolic(Assembly src, string group)
        // {
        //     var x = src.Enums().TypeTags<SymSourceAttribute>().Storage.Where(x => x.Right.SymGroup == group).ToIndex();
        //     return x.Select(x => new MeasuredType(x.Left, Sizes.measure(x.Left))).Sort();
        // }

        // public static ReadOnlySeq<DbTypeTable> typetables(Assembly src, string group, ICompositeDispenser dst)
        // {
        //     var types = symbolic(src, group);
        //     Index<DbTypeTable> tables = sys.alloc<DbTypeTable>(types.Count);
        //     for(var i=0; i<types.Count; i++)
        //         tables[i] = typetable(types[i], dst);
        //     return tables.Sort();
        // }

        // public static DbTypeTable typetable(MeasuredType type, ICompositeDispenser dst)
        // {
        //     var symbols = Symbols.syminfo(type.Definition);
        //     Index<TypeTableRow> rows = sys.alloc<TypeTableRow>(symbols.Count);
        //     for(var j=0; j<symbols.Count; j++)
        //     {
        //         ref readonly var sym = ref symbols[j];
        //         ref var row = ref rows[j];
        //         row.Seq = MemDb.NextSeq(DbObjectKind.TypeTableRow);
        //         row.TypeName = dst.Label(type.Definition.Name);
        //         row.LiteralName = dst.Label(sym.Name.Text);
        //         row.Position = (ushort)sym.Index;
        //         row.PackedWidth = (byte)type.Size.PackedWidth;
        //         row.NativeWidth = (byte)type.Size.NativeWidth;
        //         row.LiteralValue = sym.Value;
        //         row.Symbol = dst.Label(sym.Expr.Text);
        //         row.Description = dst.String(sym.Description.Text);
        //     }

        //     return new DbTypeTable(
        //         MemDb.NextSeq(DbObjectKind.TypeTable),
        //         dst.Label(type.Definition.Name),
        //         type.Size,
        //         rows
        //         );
        // }
         
        const NumericKind Closure = NumericKind.All;
    }
}