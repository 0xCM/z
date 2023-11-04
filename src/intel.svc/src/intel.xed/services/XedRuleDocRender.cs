//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static Markdown;
using static sys;

public class XedRuleDocRender
{
    static SectionHeader TableHeader(RuleIdentity sig)
        => new(3, sig.Format());

    public static XedRuleDocRender create(CellTables src)
        => new (src);

    readonly CellTables Data;

    public XedRuleDocRender(CellTables src)
    {
        Data = src;        
    }

    void Render(RuleIdentity sig, Index<RuleCell> src, ITextEmitter dst)
    {
        dst.AppendLine(TableHeader(sig));
        dst.AppendLine();
        dst.AppendLineFormat("{0}(){{", sig.TableName);
        var row = z16;
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var cell = ref src[i];
            ref readonly var key = ref cell.Key;
            if(i==0)
                dst.Append("    ");

            if(key.Row != row)
            {
                dst.AppendLine();
                row = key.Row;
                dst.Append("    ");
            }
            else
            {
                if(i != 0)
                    dst.Append(Chars.Space);
            }

            dst.Append(cell.Format());
        }

        dst.AppendLine();
        dst.AppendLine("}");
        dst.AppendLine();
    }

    public string Format()
    {
        var dst = text.emitter();
        for(var i=0u; i<Data.TableCount; i++)
        {
            ref readonly var cells = ref Data.TableCells(i);
            Render(cells.Left, cells.Right, dst);

        }
        return dst.Emit();
    }
}
