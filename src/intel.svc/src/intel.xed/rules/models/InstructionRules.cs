//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedModels;

partial class XedRules
{
    public class InstructionRules
    {
        readonly InstBlockPatterns _Patterns;

        readonly ReadOnlySeq<InstRuleDef> _Defs;

        readonly ReadOnlySeq<InstBlockOperand> _Ops;

        public InstructionRules(InstBlockPatterns patterns, ReadOnlySeq<InstRuleDef> src, ReadOnlySeq<InstBlockOperand> operands)
        {
            _Patterns = patterns;
            _Defs = src;
            _Ops = operands;
        }        

        public ref readonly InstBlockPatterns Patterns => ref _Patterns;

        public ref readonly ReadOnlySeq<InstRuleDef> Definitions => ref _Defs;

        public ref readonly ReadOnlySeq<InstBlockOperand> Operands => ref _Ops;

        public static InstructionRules Empty => new (InstBlockPatterns.Empty, sys.empty<InstRuleDef>(), sys.empty<InstBlockOperand>());
    }
}
