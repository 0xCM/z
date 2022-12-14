//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
public class FacetProviderAttribute : Attribute
{
    public Type TargetType {get;}

    public FacetProviderAttribute(Type target)
    {
        TargetType = target;
    }
}
