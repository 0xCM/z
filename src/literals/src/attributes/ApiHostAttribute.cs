//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
/// <summary>
/// Identifies an api host
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class ApiHostAttribute : ApiProviderAttribute
{
    public string HostName {get;}

    public ApiHostAttribute(string name)
        : base(ApiProviderKind.Stateless)
    {
        HostName = name;
    }

    public ApiHostAttribute(string name, bool global)
        : base(ApiProviderKind.Stateless, global)
    {
        HostName = name;
    }

    public ApiHostAttribute()
        : this(string.Empty)
    {

    }
}
