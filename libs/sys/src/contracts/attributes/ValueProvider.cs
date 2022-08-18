//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;

/// <summary>
/// Applied to a class or struct to indicate that the target provides invariant static values of homogenous type
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class ValueProviderAttribute : Attribute
{
    public ValueProviderAttribute(Type vt)
    {
        ValueType = vt;
    }

    public Type ValueType {get;}
}
