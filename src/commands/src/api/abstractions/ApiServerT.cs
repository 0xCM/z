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

        protected Cmd Cmd => Wf.Cmd();

        public override Type HostType
            => typeof(T);

        public void RunCmd(string name)
            => Cmd.RunCmd(name);

        public void RunCmd(string name, CmdArgs args)
            => Cmd.RunCmd(name,args);

        public void RunCmd(ApiCmdSpec cmd)
            => Cmd.RunCmd(cmd);

        public Task Start()
            => CmdLoop.start(Channel);

        public void Loop()
            => Start().Wait();
    }
}