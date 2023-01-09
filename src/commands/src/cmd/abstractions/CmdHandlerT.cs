//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class CmdHandler<T> : CmdHandler, ICmdBinder<T>
        where T : IApiCmd<T>, new()
    {            
        protected static void unbound(CmdArgs args, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => CmdBindingException.raise(typeof(T), args, caller, file, line);

        public abstract BoundCmd<T> Bind(CmdArgs args);

        public abstract void Run(T cmd);

        public override void Run(CmdArgs args)
            => Run(Bind(args).Command);

        protected static T command()
            => new();
    }   
}