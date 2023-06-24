//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnvCfg : IDbArchive
    {
        EnvId EnvName {get;}

        EnvReport Report(EnvVarKind kind = EnvVarKind.Process);
    }
}