//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[AttributeUsage(AttributeTargets.Assembly)]
public class PartIdAttribute : Attribute
{
    public static PartId id(Assembly src)
    {
        if(src != null && Attribute.IsDefined(src, typeof(PartIdAttribute)))
            return ((PartIdAttribute)Attribute.GetCustomAttribute(src, typeof(PartIdAttribute))).Id;
        else
            return PartId.None;
    }

    public static string name(Assembly src)
    {
        if(src != null && Attribute.IsDefined(src, typeof(PartIdAttribute)))
            return ((PartIdAttribute)Attribute.GetCustomAttribute(src, typeof(PartIdAttribute))).Name;
        else
            return EmptyString;
    }

    public readonly string Name;

    public PartIdAttribute(string id)
    {
        Name = id;
    }

    public PartIdAttribute(object id)
    {
        Id = (PartId)id;
        Name = Id.ToString();
        
    }

    public PartId Id {get;}
}