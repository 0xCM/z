//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdProvider]
    public abstract class ApiServer<T> : ApiServer, IApiServer
        where T : ApiServer<T>, new()
    {
        protected AppDb AppDb => AppDb.Service;

        protected ApiCmd ApiCmd => Wf.ApiCmd();

        public override Type HostType
            => typeof(T);

        public void RunCmd(string name)
            => ApiCmd.RunCmd(name);

        public void RunCmd(string name, CmdArgs args)
            => ApiCmd.RunCmd(name,args);

        public void RunCmd(ApiCmdSpec cmd)
            => ApiCmd.RunCmd(cmd);

        public Task Start()
            => CmdLoop.start(Channel);

        public void Loop()
            => Start().Wait();
    }
}