//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Class | AttributeTargets.Struct)]
public class CmdArgAttribute : Attribute
{
    public CmdArgAttribute(string name, string description = EmptyString)
    {
        Name = name;
        Position = -1;
        Description = description;
    }

    public CmdArgAttribute(string name, short position, string description = EmptyString)
    {
        Name = name;
        Position = position;
        Description = description;
    }

    public CmdArgAttribute()
    {
        Name = EmptyString;
        Description = EmptyString;
    }
    
    public string Name {get;}

    public short Position {get;}

    public string Description {get;}
    
}
