//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolContext
    {
        FolderPath WorkingDir {get;}

        EnvVars Vars {get;}

        IToolContext WithVar(EnvVar var);

        IToolContext Redirect(ISysIO io);

        Action<Process> ProcessCreated {get;}

        ISysIO IO {get;}
    }

    public interface IToolContext<C> : IToolContext
        where C : IToolContext<C>
    {
        new C WithVar(EnvVar var);

        new C Redirect(ISysIO io);
    
        IToolContext IToolContext.WithVar(EnvVar var)
            => WithVar(var);
        
        IToolContext IToolContext.Redirect(ISysIO io)
            => Redirect(io);
    }
}