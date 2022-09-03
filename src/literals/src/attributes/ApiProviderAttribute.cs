//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

/// <summary>
/// Applied to an exposed surface to classify its role/purpose
/// </summary>
public class ApiProviderAttribute : ApiPartAttribute
{
    public ApiProviderKind Kind {get;}

    public bool Global {get;}

    public ApiProviderAttribute(ApiProviderKind kind)
    {
        Kind = kind;
        Global = false;
    }

    public ApiProviderAttribute(ApiProviderKind kind, bool global)
    {
        Kind = kind;
        Global = global;
    }
}
