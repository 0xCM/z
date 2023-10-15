//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;
using static sys;
using static XedModels;
using static XedRules;
using static XedCells;
using static XedZ;

using Names = XedModels.RuleName;
using Forms = XedFormType;

public class XedMachine
{
    public class Rule
    {
        public readonly RuleIdentity Identity;

        public Rule(RuleIdentity identity)
        {
            Identity = identity;
        }
    }

    readonly RuleTableKind RuleMode;

    readonly InstBlockPatterns Instructions;

    readonly TableSpecs Rules;

    TableSpec RuleTable(RuleName name)
    {
        if(Rules.Find((RuleMode,name), out var spec))
        {
            return spec;
        }
        else
            sys.@throw($"Unknown rule {RuleMode}:{name}");

        return TableSpec.Empty;
    }
    
    byte OperandCount
    {
        [MethodImpl(Inline)]
        get => (byte)Instruction.Operands.Count;
    }
    
    [MethodImpl(Inline)]
    ref readonly InstBlockOperand Operand(byte index)
        => ref Instruction.Operands[index];

    InstBlockPattern _Instruction;

    MachineMode MachineMode;

    public XedMachine()
    {
        Instructions = XedTables.BlockPatterns();    
        MachineMode = MachineMode.Mode64;
        Rules = XedTables.RuleTables().Specs();
        RuleMode = RuleTableKind.ENC;
        Load(Forms.XOR_GPRv_GPRv_31);
    }

    ref readonly InstCells InstRules
    {
        [MethodImpl(Inline)]
        get => ref Instruction.Body;
    }


    public ref readonly InstBlockPattern Instruction
    {
        [MethodImpl(Inline)]
        get
        {
            return ref _Instruction;            
        }
    }

    public Rule MODRM_MOD_EA16_DISP0() 
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA16_DISP0));

        return rule;
    }

    public Rule MODRM_MOD_EA16_DISP16() 
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA16_DISP16));

        return rule;

    }

    public Rule MODRM_MOD_EA16_DISP8()
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA16_DISP8));

        return rule;
    }

    public Rule MODRM_MOD_EA32_DISP0()
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA32_DISP0));

        return rule;

    }

    public Rule MODRM_MOD_EA32_DISP32() 
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA32_DISP0));

        return rule;

    }

    public Rule MODRM_MOD_EA32_DISP8()
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA32_DISP0));

        return rule;

    }

    public Rule MODRM_MOD_EA64_DISP0()
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA32_DISP0));

        return rule;

    }

    public Rule MODRM_MOD_EA64_DISP32()
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA32_DISP0));

        return rule;

    }

    public Rule MODRM_MOD_EA64_DISP8()
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA32_DISP0));

        return rule;

    }



    public Rule MODRM_MOD_ENCODE()
    {
        var rule = new Rule(new (RuleMode, Names.MODRM_MOD_EA32_DISP0));

        return rule;
    }

    public bool Load(XedInstForm form)
    {
        var matched = Instructions.Match(form, MachineMode).FirstOrDefault();
        if(matched != null)
        {
            _Instruction = matched;
            
        }
        return matched != null;
    }

}
