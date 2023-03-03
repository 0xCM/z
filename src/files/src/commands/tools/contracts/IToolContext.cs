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

        Action<Process> ProcessCreated {get;}
    }
}