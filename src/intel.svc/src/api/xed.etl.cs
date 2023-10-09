//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;
using static XedZ;

partial class XedCmd
{
    XedImport XedImport => Wf.XedImport();

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
        var path =  XedPaths.DocSource(XedDocKind.RuleBlocks);
        XedZ.BlockLines(path, spec => {
            var attribs = list<Attribute>();
            var result = true;
            Channel.Row($"form:{spec.Form}");

            foreach(var line in spec.Lines)
            {                
                if(XedZ.parse(line, out Attribute attrib))
                {
                    attribs.Add(attrib);
                    switch(attrib.Field)
                    {
                        case InstBlockField.iclass:
                        {
                            if(XedParsers.parse(attrib.Value, out XedInstClass @class))
                            {
                                Channel.Row($"iclass:{@class}");
                            }
                        }
                        break;
                        case InstBlockField.pattern:
                        {
                            result = XedInstParser.parse(attrib.Value, out InstPatternBody pattern);
                            ref readonly var fields = ref pattern.Cells;
                            var layout = fields.Layout;
                            var expr = fields.Expr;
                            foreach(var f in fields)
                                Channel.Row($"field:{f.Format()}");
                        }
                        break;
                        
                        case InstBlockField.operands:
                        break;
                    }
                }
                if(!result)                
                {
                    Channel.Error(line);
                    break;
                }                
            }
        });
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        XedImport.Run();        
    }
}
