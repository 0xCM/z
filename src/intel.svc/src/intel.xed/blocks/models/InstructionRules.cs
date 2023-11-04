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


        readonly ReadOnlySeq<InstBlock> _Defs;
        
        public readonly uint Count;

        internal InstructionRules(ReadOnlySeq<InstBlock> defs, InstBlockPatterns lu)
        {
            _PatternLookup = lu;
            _Defs = defs;
            Count = defs.Count;
        }        

        public ref readonly InstBlock this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref _Defs[i];
        }

        public IEnumerable<InstBlock> Defs => _Defs;            

        public ref readonly InstBlockPatterns Patterns => ref _PatternLookup;

        public IEnumerable<InstBlockOperand> Operands => XedInstBlocks.operands(_Defs);

        public static InstructionRules Empty => new (sys.empty<InstBlock>(), InstBlockPatterns.Empty);
    }
}
