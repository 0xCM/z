//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using Z0;

public class SymSourceAttribute : Attribute
{
    public SymSourceAttribute()
    {
        SymGroup = string.Empty;
        NumericBase = NumericBaseKind.Base10;
        SymKind = string.Empty;
    }

    public SymSourceAttribute(NumericBaseKind @base)
    {
        SymGroup = string.Empty;
        NumericBase = @base;
        SymKind = string.Empty;
    }

    public SymSourceAttribute(object group)
    {
        SymGroup = group?.ToString() ?? string.Empty;
        NumericBase = NumericBaseKind.Base10;
        SymKind = string.Empty;
    }

    public SymSourceAttribute(string group, NumericBaseKind @base)
    {
        SymGroup = group ?? string.Empty;
        NumericBase = @base;
        SymKind = string.Empty;
    }

    public string SymGroup {get;}

    public object SymKind {get;}

    public NumericBaseKind NumericBase {get;}
}
