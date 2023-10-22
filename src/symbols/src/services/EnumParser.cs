//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class EnumParser : IParser
{
    readonly SymIndex Syms;

    public EnumParser(Type src)
    {
        Syms = SymIndex.create(src);
        TargetType = src;
    }

    public Type TargetType {get;}

    public Outcome Parse(string src, out dynamic dst)
    {
        if(Syms.Parse(src, out dst))
        {
            return true;
        }
        else
        {
            dst = default;
            return (false, string.Format("The value '{0}' could not be interpreted as a {1} member", src, TargetType.Name));
        }
    }
}
