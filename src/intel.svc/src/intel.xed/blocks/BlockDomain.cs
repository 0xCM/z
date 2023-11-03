//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;
using static XedInstBlocks.BlockFieldName;

using static sys;
public partial class XedInstBlocks
{
    public sealed class BlockDomain : Dictionary<BlockFieldName,HashSet<RuleAttribute>>
    {
        public HashSet<InstAttrib> InstAttribs {get;} = new();

        public string Format()
        {
            var dst = text.emitter();
            var names = Symbols.index<BlockFieldName>().Kinds;
            var skip = hashset(opcode_base10,comment);
            foreach(var name in names)
            {
                if(skip.Contains(name))
                    continue;

                dst.AppendLine($"{name}:["); 

                switch(name)
                {
                    case BlockFieldName.attributes:
                    {
                        foreach(var value in InstAttribs.Array().Sort())
                            if(value.IsNonEmpty)
                                dst.AppendLine($"    {value},");
                    }
                    break;
                    default:
                    {
                        if(TryGetValue(name, out var _values))
                            foreach(var value in _values.Map(x => x.Value).Sort())
                                dst.AppendLine($"    {value},");
                    }
                    break;
                }

                dst.AppendLine("],");

            }
            return dst.Emit();
        }
    }
}
