//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;
using static XedModels;
using static Markdown;
using static sys;

partial class XedChecks
{
    void CheckInstDefs()
    {
        var a = span("0x83 MOD[mm] MOD!=3 REG[0b010] RM[nnn] MODRM() SIMM8() LOCK=0");
        XedCells.parse(a, out var body);
        var dst = text.emitter();
        for(var i=0; i<body.Count; i++)
        {
            ref readonly var cell = ref body[i];
            if(i != 0)
                dst.Append(Chars.Space);
            dst.Append(cell.Format());
        }
        Channel.Write(dst.Emit());
    }

    void CheckRuleNames()
    {
        const uint RuleCount = RuleNames.MaxCount;
        var src = Symbols.index<RuleName>();
        var names = src.Kinds;
        for(var i=0; i<names.Length; i++)
        {
            var name = names[i];
            if((ushort)name != i)
            {
                Channel.Error($"(ushort){name} != {i}");
                return;
                //Errors.Throw(name);
            }
        }

        if(RuleCount != names.Length)
        {
            Channel.Error($"RuleCount={RuleCount} != {names.Length}");
            return;
        }

        
        var dst = RuleNames.init(names);
        var buffer = alloc<RuleName>(RuleCount);
        var count = Require.equal(dst.Members(buffer), (uint)names.Length);

        for(var i=0; i<count; i++)
        {
            ref readonly var name = ref skip(names,i);
            if(!dst.Contains(name))
                Errors.Throw($"{name} is missing");
        }

        var smaller = slice(names,100,150);
        dst.Clear();
        dst.Include(smaller);
        for(var i=0; i<RuleNames.MaxCount; i++)
        {
            var min = skip(smaller,0);
            var max = skip(smaller,smaller.Length - 1);
            var kind = (RuleName)i;
            if(kind != 0)
            {
                if(kind >= min & kind<= max)
                    Require.invariant(dst.Contains(kind));
                else
                    Require.invariant(!dst.Contains(kind));
            }
        }
    }
}
