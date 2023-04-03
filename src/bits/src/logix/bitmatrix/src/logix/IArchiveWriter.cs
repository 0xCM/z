//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IArchiveWriter : IDisposable
    {

    }

    public interface IArchiveWriter<H> : IArchiveWriter
        where H : struct, IArchiveWriter<H>
    {

    }
}