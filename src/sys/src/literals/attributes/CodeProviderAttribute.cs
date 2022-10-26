//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
public class CodeProviderAttribute : Attribute
{
    public Type[] SymbolTypes {get;}

    public CodeProviderAttribute()
    {

    }

    public CodeProviderAttribute(params Type[] sym)
    {
        SymbolTypes = sym;
    }
}
