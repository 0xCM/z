//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public void EmitRuleBlocks()
        {
            var names = hashset<string>();
            var enc = EmitRuleBlocks(RuleTableKind.ENC);
            iter(enc, table => names.Add(table.TableName));

            var dec = EmitRuleBlocks(RuleTableKind.DEC);
            iter(dec, table => names.Add(table.TableName));

            var known = Symbols.kinds<RuleName>().Where(x => x != 0).ToArray().Map(x => x.ToString()).ToHashSet();
            foreach(var name in names)
            {
                if(!known.Contains(name))
                    Channel.Write($"Not known: {name}");
            }
        }

        Index<RuleTableBlock> EmitRuleBlocks(RuleTableKind kind)
        {
            var dst = text.emitter();
            var blocks = XedRules.blocks(kind);
            var count = blocks.Count;
            for(var i=0u; i<count; i++)
            {
                blocks[i].Render(i, dst);
                dst.AppendLine();
            }

            Channel.FileEmit(dst.Emit(), count, XedPaths.RuleTarget($"blocks.{kind.ToString().ToLower()}", FS.Csv));
            return blocks;
        }
    }
}