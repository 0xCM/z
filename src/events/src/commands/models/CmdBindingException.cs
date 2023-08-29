//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public sealed class CmdBindingException : Exception
{
    public static void raise(Type cmdtype, CmdArgs args, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        => @throw(new CmdBindingException(Events.originate(cmdtype.DisplayName(), caller,file,line), cmdtype, args));

    public readonly EventOrigin Origin;
    
    public readonly Type CmdType;

    public readonly CmdArgs Args;

    CmdBindingException(EventOrigin origin, Type type, CmdArgs args)
        : base($"Command binding failed for type {type.DisplayName()} with arguments {args} at {origin}")
    {
        Origin = origin;
        CmdType = type;
        Args = args;
    }        
}
