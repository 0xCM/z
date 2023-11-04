//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using static XedModels;
using static XedRules;
using static sys;

partial class XedCmd
{

    [CmdOp("xed/check/fields")]
    void CheckXedFields()
    {
        var instructions = XedTables.Instructions();
        var fields = Fields.allocate();
        Span<FieldKind> members = stackalloc FieldKind[128];

        foreach(var def in instructions.Defs)
        {
            fields.Clear();
            members.Clear();

            var cells = def.Pattern.Body;
            var set = XedFields.pack(cells, fields);
            var count = set.Members(members);
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref members[i];
                var value = fields[kind];
                Channel.Row($"{kind}:{value}");                
            }


        }
    }

    XedImport XedImport => Wf.XedImport();

    [CmdOp("xed/check/bits")]
    void CheckBitfields()
    {
        // var pattern = BitPatterns.def<RexPrefix>();
        // var dst = text.emitter();
        // pattern.Symbolic(dst);
        // Channel.Row(dst.Emit());

        var a = num3.One;
        for(var i=0; i<50; i++)
        {
            a++;
            Channel.Row($"{(byte)a} | {a}");
        }       
    }


    [CmdOp("xed/ock")]
    void ListOcKinds()
    {
        var src = AsmOpCodes.info();
        iter(src, r => {
            Channel.RowFormat("{0} {1}", r.Name, r.Number);
        });
    }

    [CmdOp("xed/blocks")]
    void EmitBlockLines()
    {
        var rules = XedTables.Instructions();
        XedImport.Emit(rules);
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }
}
