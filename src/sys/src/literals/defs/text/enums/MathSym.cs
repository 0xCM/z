//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Random selection of math-related unicode symbols
    /// </summary>
    /// <remarks>
    /// See https://en.wikipedia.org/wiki/Mathematical_operators_and_symbols_in_Unicode for a comprehensive list
    /// </remarks>
    [SymSource(chars)]
    public enum MathSym : ushort
    {
        Dots = '⋯',

        Infinity = '∞',

        OTimes = '⊗',

        Oplus = '⊕',

        Vee = '∨',

        Wedge = '∧',

        EmptySet = '∅',

        Times = '×',

        NEQ = '≠',

        LTEQ = '⩽',

        LShift = '≪',

        GTEQ = '⩾',

        RShift = '≫',

        NLT = '≮',

        NGT = '≯',

        NGTEQ = '≱',

        NLTEQ = '≰',

        Between = '≬',

        Sum = '∑',

        Product = '∏',

        Coproduct = '∐',

        Intersect = '∩',

        Union = '∪',

        IFF = '⟺',

        Member = '⋴',

        Some ='∃',

        All = '∀',

        None = '∄',

        Equivalence = '∼',

        Almost = '≈',

        Define = '≔',

        CDot = '·',

        Partial = '∂',

        Plus = '+',

        LeftBra = '〈',

        RightKet = '〉'
    }
}