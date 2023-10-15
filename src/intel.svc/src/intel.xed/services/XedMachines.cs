//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;
using static sys;

public partial class XedMachines
{            
    public static MachineContext context(MachineMode? mode = null)
        => new(mode ?? MachineMode.Mode64);

    public static void gen(MachineContext context, ITextEmitter dst)
    {
        var indent = 0u;
        dst.IndentLineFormat(indent,"namespace Z0;");
        dst.AppendLine();
        dst.IndentLine(indent, "using static sys;");
        dst.IndentLine(indent, "using static XedModels;");
        dst.IndentLine(indent, "using static XedRules;");
        dst.IndentLine(indent, "using static XedMachines;");
        dst.AppendLine();
        dst.IndentLineFormat(indent, "public class XedMachine");
        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;

        dst.IndentLineFormat(indent, "public XedFieldState FieldState;");
        dst.AppendLine();
        
        var decls = context.RuleDecls;
        for(var i=0; i<decls.Count; i++)
        {
            ref readonly var decl = ref decls[i];
            render(ref indent, decl.Table, dst);
            dst.AppendLine();
        }
        indent -=4;

        dst.IndentLine(indent, Chars.RBrace);
    }

    static void render(ref uint indent, CellTable Table, ITextEmitter dst)
    {
        dst.IndentLineFormat(indent, "public void {0}_{1}()", Table.Name, Table.Kind);
        dst.IndentLine(indent, Chars.LBrace);
        indent += 4;
        for(var i=0; i<Table.RowCount; i++)
        {
            ref readonly var row = ref Table[i];

            dst.Indent(indent,"// ");
            var antecedants = row.Antecedants();
            var consequents = row.Consequents();

            for(var j=0; j<antecedants.Length; j++)
            {
                if(j != 0)
                    dst.Append(Chars.Space);
                
                dst.Append(skip(antecedants,j));
            }
            if(antecedants.Length != 0 && consequents.Length != 0)
            {                
                dst.Append(Chars.Space);
                dst.Append("=>");
                dst.Append(Chars.Space);
            }

            for(var j=0; j<consequents.Length; j++)
            {
                if(j != 0)
                    dst.Append(Chars.Space);

                dst.Append(skip(consequents,j));
            }

            dst.Append(Chars.NL);
        }

        indent-=4;
        dst.IndentLine(indent, Chars.RBrace);            
    }
}