//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public abstract class WfSvc<S> : AppService<S>
        where S : WfSvc<S>, new()
    {
        protected static AppSettings AppSettings => AppSettings.Default;

        protected static IEnvDb EnvDb => AppSettings.EnvDb();

        protected static AppDb AppDb => AppDb.Service;

        protected static IApiCmdRunner CmdRunner => ApiCmdRunner.Service();
        
    }
}