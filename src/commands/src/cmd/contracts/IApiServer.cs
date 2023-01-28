//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiServer : IApiService, IRunLoop
    {
        void RunCmd(string name);
        
        void RunCmd(string name, CmdArgs args);

        void RunCmd(ApiCmdSpec cmd);

        Task Start();        
    }

    public interface IApiServer<T> : IApiServer
        where T : IApiServer<T>,new()
    {

    }
}