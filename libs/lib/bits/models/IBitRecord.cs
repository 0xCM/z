//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBitRecord
    {
        Span<byte> Storage {get;}
    }

    public interface IBitRecord<T> : IBitRecord
        where T : unmanaged, IBitRecord<T>
    {

    }
}