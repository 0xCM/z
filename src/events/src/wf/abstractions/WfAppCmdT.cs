//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using CCN = CmdContextNames;

class CmdContextNames
{
    public const string fs = "fs/context";

    public const string db = "db/context";

    public const string sln = "sln/context";
}

[CmdProvider]
public abstract class WfAppCmd<T> : WfSvc<T>, IApiService
    where T : WfAppCmd<T>, new()
{
    protected ApiServer ApiServer => Wf.ApiServer();

    protected WfAppCmd()
    {
    }

    [CmdOp(CCN.db)]
    protected void SetDbContext(CmdArgs args)
    {
        const string Name = CCN.db;
        if(args.Count != 0)
            ContextValue(Name, args.First);
    }

    [CmdOp(CCN.fs)]
    protected void SetFsContext(CmdArgs args)
    {
        const string Name = CCN.fs;
        if(args.Count != 0)
            ContextValue(Name, args.First);
    }

    [CmdOp(CCN.sln)]
    protected void SetSlnContext(CmdArgs args)
    {
        const string Name = CCN.sln;
        if(args.Count != 0)
            ContextValue(Name, args.First);
    }

    public virtual void Loop()
        => ApiCmdLoop.start(Channel, CmdRunner).Wait();
}
