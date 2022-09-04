//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

using Z0;

[AttributeUsage(AttributeTargets.Assembly)]
public class PartIdAttribute : Attribute
{    
    public static PartId id(Assembly src)
    {
        var dst = PartId.None;
        if(src != null && Attribute.IsDefined(src, typeof(PartIdAttribute)))
        {
            var value = ((PartIdAttribute)Attribute.GetCustomAttribute(src, typeof(PartIdAttribute)))._provided;
            if(value is PartId id)
                dst = id;
        }

        return dst;
        // if(src != null && Attribute.IsDefined(src, typeof(PartIdAttribute)))
        //     return ((PartIdAttribute)Attribute.GetCustomAttribute(src, typeof(PartIdAttribute))).Id;
        // else
        //     return PartId.None;
    }

    static string symbol(PartId id)
    {
        var dst = EmptyString;
        if(typeof(PartId).LiteralField(id.ToString(), out var f))
        {
            var attrib = Attribute.GetCustomAttribute(f, typeof(SymbolAttribute)) as SymbolAttribute;
            if(attrib != null)
                dst = attrib.Symbol;
        }                
        return dst;
    }

    public static string name(Assembly src)
    {
        var dst = EmptyString;
        if(src != null && Attribute.IsDefined(src, typeof(PartIdAttribute)))
        {
            var value = ((PartIdAttribute)Attribute.GetCustomAttribute(src, typeof(PartIdAttribute)))._provided;
            if(value is string s)
                dst = s;
            else if(value is PartId id)
                dst = symbol(id);
        }
        return dst;
    }

    readonly object _provided;

    readonly string Name;

    public PartIdAttribute(string id)
    {
        _provided = id;
        //Name = id;
    }

    public PartIdAttribute(object id)
    {
        _provided = id;
        // Id = (PartId)id;
        // Name = Id.ToString();
        
    }

    PartId Id {get;}
}