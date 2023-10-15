//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedRules;
using static sys;

/*
partial class XedCmd
{
    [CmdOp("xed/run")]
    void Run()
    {
        var context = XedMachines.context(rule => Channel.Row($"{rule} activated"));
        var machine = new XedMachine(context);
        var rules = context.RuleNames;
        foreach(var name in rules)
        {
            machine.Rule(name)();
        }        
    }
}

*/
public partial class XedMachines
{            
    const string MachineName = "XedMachine";

    [MethodImpl(Inline)]
    public static num11 key(RuleIdentity identity)
    {
        var kind = num2.number(identity.TableKind);
        var name = num9.number(identity.TableName);
        return BitPack.pack(name,kind);
    }


    public static MachineContext context(Action<RuleIdentity> activation = null, MachineMode? mode = null)
        => new(activation, mode ?? MachineMode.Mode64);

    struct FieldNames
    {
        public const string RuleIndex = "Rules";
        
        public const string Context = "Context";
        
        public const string FieldState = "FieldState";
    }

    struct CommandNames
    {
        public const string Run = "xed/run";
    }

    static void GenCommands(ref uint indent, ITextEmitter dst)
    {
        dst.IndentLine(indent, "partial class XedCmd");
        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;

        dst.IndentLine(indent,$"[CmdOp({text.dquote(CommandNames.Run)})]");
        dst.IndentLine(indent, "void Run()");
        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;

        dst.IndentLine(indent, "var context = XedMachines.context(rule => Channel.Row($\"{rule} activated\"));");
        dst.IndentLine(indent, $"var machine = new {MachineName}(context);");
        dst.IndentLine(indent, "var rules = context.RuleNames;");
        dst.IndentLine(indent, "foreach(var name in rules)");

        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;
        dst.IndentLine(indent, "machine.Rule(name)();");
        indent-=4;
        dst.IndentLine(indent, Chars.RBrace);

        indent-=4;
        dst.IndentLine(indent, Chars.RBrace);

        indent -=4;

        dst.IndentLine(indent, Chars.RBrace);
    }

    public static void gen(MachineContext context, ITextEmitter dst)
    {
        const string MethodImpl = "[MethodImpl(Inline)]";

        var decls = context.RuleDecls;

        var indent = 0u;
        dst.IndentLineFormat(indent,"namespace Z0;");
        dst.AppendLine();
        dst.IndentLine(indent, $"using static sys;");
        dst.IndentLine(indent, $"using static {nameof(XedModels)};");
        dst.IndentLine(indent, $"using static {nameof(XedRules)};");
        dst.IndentLine(indent, $"using static {nameof(XedMachines)};");
        dst.AppendLine();
                
        GenCommands(ref indent, dst);
        dst.AppendLine();

        dst.IndentLineFormat(indent, $"public class {MachineName}");
        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;

        dst.IndentLineFormat(indent, $"public {nameof(XedFieldState)} {FieldNames.FieldState};");
        dst.AppendLine();
        dst.IndentLineFormat(indent, $"readonly {nameof(MachineContext)} {FieldNames.Context};");
        dst.AppendLine();
        dst.IndentLineFormat(indent, $"Seq<{nameof(Action)}> {FieldNames.RuleIndex};");
        dst.AppendLine();
    
        dst.IndentLine(indent, MethodImpl);
        dst.IndentLine(indent, $"public ref readonly {nameof(Action)} Rule({nameof(RuleIdentity)} id)");
        indent += 4;
        dst.IndentLine(indent, $"=> ref {FieldNames.RuleIndex}[key(id)];");
        indent -=4 ;
        dst.AppendLine();
        
        dst.IndentLine(indent, $"public {MachineName}({nameof(MachineContext)} context)");
        dst.IndentLine(indent, Chars.LBrace);
        indent+=4;
        dst.IndentLine(indent, $"{FieldNames.Context} = context;");
        dst.IndentLine(indent, $"{FieldNames.FieldState} = {nameof(XedFieldState)}.Empty;");
        dst.IndentLine(indent, $"{FieldNames.RuleIndex} = sys.alloc<{nameof(Action)}>({num11.Mod});");

        dst.AppendLine();

        for(var i=0; i<decls.Count; i++)
        {
            ref readonly var decl = ref decls[i];
            dst.IndentLine(indent, $"{FieldNames.RuleIndex}[{key(decl.Rule).Hex()}] = {ActionName(decl.Table)};");
        }
        dst.AppendLine();

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

    static string ActionName(in CellTable src)
        => string.Format("{0}_{1}", src.Name, src.Kind);

    static void render(ref uint indent, in CellTable table, ITextEmitter dst)
    {
        ref readonly var rule = ref table.Identity;
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

        var kind = $"{nameof(RuleTableKind)}.{rule.TableKind}";
        var name = $"{nameof(RuleName)}.{rule.TableName}";
        var selector = $"({kind},{name})";
        dst.IndentLine(indent, $"{FieldNames.Context}.RuleActivated({selector});");

        indent-=4;
        dst.IndentLine(indent, Chars.RBrace);            
    }
}