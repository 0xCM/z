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
        const string MachineName = "XedMachine";
        var decls = context.RuleDecls;

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
        dst.IndentLineFormat(indent, "ReadOnlySeq<Action> Rules;");
        dst.AppendLine();
        
        dst.IndentLine(indent, $"public {MachineName}()");
        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;
        dst.IndentLine(indent, "Rules = new Action[]");

        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;
        for(var i=0; i<decls.Count; i++)
        {
            ref readonly var decl = ref decls[i];
            dst.IndentLine(indent, $"{ActionName(decl.Table)},");
        }
        indent -=4;
        dst.IndentLine(indent,  $"{Chars.RBrace}{Chars.Semicolon}");

        indent -=4;
        dst.IndentLine(indent, Chars.RBrace);

        for(var i=0; i<decls.Count; i++)
        {
            ref readonly var decl = ref decls[i];
            render(ref indent, decl.Table, dst);
            dst.AppendLine();
        }
        indent -=4;

        dst.IndentLine(indent, Chars.RBrace);
    }

    static string ActionName(CellTable src)
        => string.Format("{0}_{1}", src.Name, src.Kind);

    static void render(ref uint indent, CellTable table, ITextEmitter dst)
    {
        dst.IndentLineFormat(indent, "public void {0}()",  ActionName(table));
        dst.IndentLine(indent, Chars.LBrace);
        indent += 4;
        for(var i=0; i<table.RowCount; i++)
        {
            ref readonly var row = ref table[i];

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