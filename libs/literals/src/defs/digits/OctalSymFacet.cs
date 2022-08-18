//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(octal_digits, NBK.Base8)]
    public enum OctalSymFacet : ushort
    {
        First = OctalDigitSym.o0,

        Last = OctalDigitSym.o7
    }
}