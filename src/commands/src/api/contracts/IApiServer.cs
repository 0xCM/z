//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiServer : IApiService, IRunLoop
    {
        void RunCmd(string name);
        
        public void RunCmd(string name, CmdArgs args);

        public void RunCmd(ApiCmdSpec cmd);

        public Task Start();        
    }

    public interface IApiServer<T> : IApiServer, IApiService<T>
        where T : IApiServer<T>,new()
    {

    }
}