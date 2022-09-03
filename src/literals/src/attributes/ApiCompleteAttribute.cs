//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
/// <summary>
/// Marks a type as an api data type
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class ApiCompleteAttribute : ApiProviderAttribute
{
    public string Name {get;}

    public ApiCompleteAttribute()
        : base(ApiProviderKind.DataType)
    {
        Name = string.Empty;
    }

    public ApiCompleteAttribute(string name)
        : base(ApiProviderKind.DataType)
    {
        Name = name;
    }

    public ApiCompleteAttribute(string name, bool global)
        : base(ApiProviderKind.DataType, global)
    {
        Name = name;
    }
}
