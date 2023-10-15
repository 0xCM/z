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

        internal MachineContext(MachineMode mode)
        {
            RuleTables = XedTables.CellTables(XedTables.RuleCells(XedTables.RuleTables()));

            MachineMode = MachineMode.Mode64;
            Instructions = XedTables.Instructions();
            RuleDecls = RuleTables.View.Map(x => new RuleDecl(x));
            RuleNames = RuleTables.RuleNames;
        }
        
        public readonly InstructionRules Instructions;

        public readonly CellTables RuleTables;

        public readonly ReadOnlySeq<RuleIdentity> RuleNames;

        public readonly ReadOnlySeq<RuleDecl> RuleDecls;

        public MachineMode MachineMode;

        public InstBlockPattern Instruction;
    }
}
