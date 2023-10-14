//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class BitPatternAttribute : Attribute
{
    public BitPatternAttribute(string symbols)
    {
        Symbols = symbols;
    }

    public string Symbols {get;}
}
