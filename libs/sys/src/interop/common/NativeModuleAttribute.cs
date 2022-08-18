//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class NativeModuleAttribute : Attribute
{
    public NativeModuleAttribute(string name)
    {
        Name = name;
    }

    public string Name {get;}
}