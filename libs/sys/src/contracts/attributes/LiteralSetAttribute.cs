//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;

/// <summary>
/// Defines a grouping mechanism for a set of related literals
/// </summary>
public class LiteralSetAttribute : Attribute
{
    public LiteralSetAttribute(object set)
    {
        SetIdentifier = set;
    }

    public object SetIdentifier {get;}
}
