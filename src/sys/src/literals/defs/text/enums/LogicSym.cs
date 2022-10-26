//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines logic symbols as described by https://en.wikipedia.org/wiki/List_of_logic_symbols and
    /// https://de.wikipedia.org/wiki/Logikgatter#Typen_von_Logikgattern_und_Symbolik
    /// </summary>
    [SymSource(chars)]
    public enum LogicSym : ushort
    {
        [Symbol("∨", "or,inclusive disjunction")]
        Or = '∨',

        [Symbol("∧", "and,conjugation")]
        And = '∧',

        [Symbol("⊕", "xor,exclusive disjuntion")]
        Xor = '⊕',

        [Symbol("~", "not")]
        Not = '~',

        [Symbol("⊤", "top,true")]
        Top = '⊤',

        [Symbol("⊥", "bottom,false")]
        Bottom = '⊥',

        [Symbol("∃", "existence, existential quantification")]
        Exists = '∃',

        [Symbol("→", "if-then,material implication")]
        IfThen = '→',

        [Symbol("⟷", "if and only if,material equivalence")]
        Iff = '⟷',

        [Symbol("∀", "for all, universial quantification")]
        All = '∀',

        [Symbol("≔", "definition")]
        Def = '≔',

        [Symbol("(", "begin precedence group")]
        Left = '(',

        [Symbol(")", "end precedence group")]
        Right = ')',

        [Symbol("↑", "nand")]
        Nand = '↑',

        [Symbol("↓", "nor")]
        Nor = '↓',

        [Symbol("⊙", "xnor")]
        Xnor = '⊙',

        [Symbol("≡", "logical equivalence")]
        Equivalent = '≡',
    }
}