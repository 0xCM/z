//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
public class TextProviderAttribute : Attribute
{
    public TextProviderAttribute(Type target)
    {
        Target = target;
    }

    public Type Target {get;}
}
