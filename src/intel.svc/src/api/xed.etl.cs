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
    [CmdOp("xed/ock")]
    void ListOcKinds()
    {
        var src = AsmOpCodes.info();
        iter(src, r => {
            Channel.RowFormat("{0} {1}", r.Name, r.Number);
        });
    }
    [CmdOp("xed/rules")]
    void LoadRuleBlocks()
    {
        var src = XedZ.rules(XedDb.DocSource(XedDocKind.RuleBlocks));
        var imports = src.Imports;
        var domain = dict<string,HashSet<RuleAttribute>>();
        var dst = text.emitter();
        var counter = 0u;
        var rules = bag<FormRules>();
        iter(imports, import => {            
            var block = src.FormBlocks[import.Form];
            dst.AppendLine(RP.PageBreak160);
            dst.AppendLineFormat("{0:D5} {1,-82} {2}", counter++, import.Form, import.Class); 
            if(XedZ.parse(import.Form, block, out FormRules _rules))
            {
                rules.Add(_rules);
                foreach(var rule in _rules.Rules)
                {
                    dst.AppendLine(rule);
                    if(rule is RuleAttribute a)
                    {
                        if(domain.TryGetValue(a.Name, out var _values))
                        {
                            _values.Add(a);
                        }
                        else
                        {
                            domain[a.Name] = hashset(a);
                        }
                    }
                }
            }

            if(block.Count != _rules.Rules.Count)
            {
                @throw("block.Count != _rules.Rules.Count");
            }


            dst.AppendLine(RP.PageBreak160);
        });

        var _domains = text.emitter();
        foreach(var name in domain.Keys.Array().Sort())
        {
            switch(name)
            {
                case RuleNames.opcode_base10:
                case RuleNames.comment:
                    break;
                default:
                {
                    var values = domain[name].Map(x => x.Value).Sort();
                    _domains.AppendLine($"{name}:["); 
                    foreach(var value in values)
                    {
                        _domains.AppendLine($"    {value},");
                    }
                    _domains.AppendLine("],");

                }
                break;
            }
        }
        Channel.FileEmit(_domains.Emit(), XedDb.Targets().Path("xed.instblocks.domain", FS.ext("txt")));
    }

    [CmdOp("xed/etl")]
    void RunImport()
    {
        exec(true, 
            () => XedZ.emit(Channel, XedZ.rules(XedDb.DocSource(XedDocKind.RuleBlocks))),
            () => Channel.TableEmit(XedRegMap.Service.REntries, XedDb.Targets().Table<RegMapEntry>("rmap")),
            () => Channel.TableEmit(XedRegMap.Service.XEntries, XedDb.Targets().Table<RegMapEntry>("xmap")),
            () => DataFlow.EmitChipCodes(Symbols.symkinds<ChipCode>()),
            () => DataFlow.EmitBroadcastDefs(Xed.broadcasts(Symbols.kinds<BroadcastKind>())),
            () => DataFlow.EmitCpuIdDataset(DataFlow.CalcCpuIdDataset(XedDb.DocSource(XedDocKind.CpuId))),
            () => {
                var chips = DataFlow.CalcChipMap(XedDb.DocSource(XedDocKind.ChipMap));
                DataFlow.EmitChipMap(chips);
                var forms = DataFlow.CalcFormImports(XedDb.DocSource(XedDocKind.FormData));
                DataFlow.EmitFormImports(forms);
                var inst = DataFlow.CalcChipInstructions(forms, chips);
                DataFlow.EmitChipInstructions(inst);
            },
            () => {
                var widths = DataFlow.CalcWidths(XedDb.DocSource(XedDocKind.Widths));
                DataFlow.EmitOpWidths(widths.OpWidths);
                DataFlow.EmitPointerWidths(widths.PointerWidthDescriptions);
            }
        );
                        
    }
}
