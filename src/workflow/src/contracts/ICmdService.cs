//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdService : IAppService, ICmdRunner, ICmdProvider
    {
        //void Install(ReadOnlySeq<ICmdProvider> providers);
    }
}