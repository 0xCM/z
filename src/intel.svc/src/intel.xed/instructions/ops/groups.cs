//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

partial class XedPatterns
{
    public static SortedLookup<XedInstClass,InstGroup> groups(Index<InstPattern> src)
    {
        var dst = dict<XedInstClass,Index<InstPattern>>();
        var patterns = list<InstPattern>();
        var @class = XedInstClass.Empty;
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var pattern = ref src[i];
            if(i==0)
                @class = pattern.Classifier;
            else
            {
                if(@class != pattern.Classifier)
                {
                    dst.Add(@class, patterns.ToIndex().Sort());
                    patterns.Clear();
                    @class = pattern.Classifier;
                }
            }

            patterns.Add(pattern);

            if(i == count - 1)
                dst.Add(@class, patterns.ToIndex().Sort());
        }

        var groups = dict<XedInstClass,InstGroup>();
        var classes = dst.Keys.Array();
        for(var i=0; i<classes.Length; i++)
        {
            @class = skip(classes,i);
            groups.Add(@class, group(@class, dst[@class]));
        }

        return groups;
    }

    public static InstGroup group(XedInstClass @class, Index<InstPattern> src)
        => new InstGroup(@class, members(@class, src));

    public static Index<InstGroupMember> members(XedInstClass @class, Index<InstPattern> src)
    {
        var opcode = AsmOpCode.Empty;
        var count = src.Count;
        var k=z8;
        var seq = new InstGroupSeq{Instruction = @class};
        var dst = alloc<InstGroupMember>(count);
        for(var i=0u; i<count; i++)
        {
            ref readonly var pattern = ref src[i];
            ref readonly var fields = ref pattern.Cells;

            if(i==0)
                opcode = pattern.OpCode;

            if(opcode != pattern.OpCode)
            {
                k=0;
                opcode = pattern.OpCode;
            }

            seq = seq with {
                Seq = i,
                Index=k++,
                PatternId = (ushort)pattern.PatternId,
                Lock = pattern.Lock,
                OpCode = opcode,
                OpCodeBytes = opcode.Value,
                Mode = pattern.Mode,
                Mod = XedCells.mod(fields),
                RexW = XedCells.rexw(fields),
                Rep = XedCells.rep(fields),
                Form = pattern.InstForm,
                };

            seek(dst,i) = new (seq,pattern);
        }
        return dst.Sort();
    }
}
