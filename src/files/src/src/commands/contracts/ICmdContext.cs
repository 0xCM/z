//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdContext
    {
        FolderPath WorkingDir {get;}

        EnvVars Vars {get;}

        ICmdContext WithVar(EnvVar var);

        ICmdContext Redirect(ISysIO io);

        Action<Process> ProcessCreated {get;}

        ISysIO IO {get;}
    }

    public interface ICmdContext<C> : ICmdContext
        where C : ICmdContext<C>
    {
        new C WithVar(EnvVar var);

        new C Redirect(ISysIO io);
    
        ICmdContext ICmdContext.WithVar(EnvVar var)
            => WithVar(var);
        
        ICmdContext ICmdContext.Redirect(ISysIO io)
            => Redirect(io);
    }
}