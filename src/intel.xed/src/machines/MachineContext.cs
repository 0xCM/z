//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static XedModels;
using static XedRules;

partial class XedMachines
{
    public class MachineContext
    {
        public bool LoadInstruction(XedInstForm form, bool @lock = false)
        {
            var matched = Instructions.Patterns.Match(form, MachineMode, @lock).FirstOrDefault();
            if(matched != null)
            {
                Instruction = matched;                
            }
            return matched != null;
        }

        internal MachineContext(Action<RuleIdentity> activation, MachineMode mode)
        {
            ActivationHandler = activation ?? (r => {});
            RuleTables = XedTables.CellTables(XedTables.RuleCells(XedTables.RuleTables()));
            MachineMode = mode;
            Instructions = XedTables.Instructions();
            RuleDecls = RuleTables.View.Map(x => new RuleDecl(x));         
            RuleSeq = XedRuleSeq.defs();
            RuleControls = XedRuleSeq.controls();
        }
        
        readonly Action<RuleIdentity> ActivationHandler;

        public readonly InstructionRules Instructions;

        public readonly ReadOnlySeq<SeqDef> RuleSeq;

        public readonly ReadOnlySeq<SeqControl> RuleControls;

        public readonly CellTables RuleTables;

        public ref readonly ReadOnlySeq<RuleIdentity> RuleNames
        {
            [MethodImpl(Inline)]
            get => ref RuleTables.RuleNames;
        }

        public readonly ReadOnlySeq<RuleDecl> RuleDecls;

        public MachineMode MachineMode;

        public InstBlockPattern Instruction;

        public void RuleActivated(RuleIdentity rule)
            => ActivationHandler(rule);
    }
}
