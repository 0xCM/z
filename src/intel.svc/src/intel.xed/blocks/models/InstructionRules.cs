//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;
using static sys;

using static XedModels;

partial class XedRules
{
    public class InstructionRules
    {     
        readonly InstBlockPatterns _PatternLookup;

        readonly ReadOnlySeq<InstBlockPattern> _Patterns;

        readonly ReadOnlySeq<InstBlockOperand> _Ops;

        readonly ReadOnlySeq<InstRuleDef> _Defs;
        
        public readonly uint Count;

        internal InstructionRules(ReadOnlySeq<InstRuleDef> defs,  ReadOnlySeq<InstBlockPattern> patterns, InstBlockPatterns lu, ReadOnlySeq<InstBlockOperand> operands)
        {
            _PatternLookup = lu;
            _Ops = operands;            
            _Defs = defs;
            _Patterns = patterns;
            Count = Require.equal(defs.Count, patterns.Count);
        }        

        public ref readonly InstRuleDef this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Defs[i];
        }

        public IEnumerable<InstRuleDef> Defs => _Defs;            

        public ref readonly InstBlockPatterns Patterns => ref _PatternLookup;

        public ref readonly ReadOnlySeq<InstBlockOperand> Operands => ref _Ops;

        public static InstructionRules Empty => new (sys.empty<InstRuleDef>(), sys.empty<InstBlockPattern>(), InstBlockPatterns.Empty, sys.empty<InstBlockOperand>());
    }
}
