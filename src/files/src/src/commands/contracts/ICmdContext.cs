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

        Action<Process> ProcessCreated {get;}
    }

    public interface ICmdContext<C> : ICmdContext
        where C : ICmdContext<C>
    {
        new C WithVar(EnvVar var);

        ICmdContext ICmdContext.WithVar(EnvVar var)
            => WithVar(var);
    }
}