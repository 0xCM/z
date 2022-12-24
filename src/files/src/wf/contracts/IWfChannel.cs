//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfChannel : IEventChannel, IMsgChannel, ITableChannel, IFileChannel, ICmdChannel
    {

    }
}