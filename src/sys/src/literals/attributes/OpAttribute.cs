//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
/// <summary>
/// Identifies a formal operation for inclusing in the identity assignment and catalog system
/// </summary>
public class OpAttribute : ApiPartAttribute
{
    public string ApiGroup {get;}

    public ApiClassKind ApiClass {get;}

    public OpAttribute()
    {
        ApiGroup = "";
    }

    public OpAttribute(ApiClassKind @class)
    {
        ApiClass = @class;
    }

    public OpAttribute(string group)
    {
        ApiGroup = group;
    }
}
