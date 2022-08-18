//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;

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
