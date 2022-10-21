//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   [Free]
    public interface IReadOnlyString : IExpr
    {
        ReadOnlySpan<byte> Bytes {get;}
    }

    [Free]
    public interface IReadOnlyString<T> : IReadOnlyString
        where T : unmanaged
    {
        ReadOnlySpan<T> Cells {get;}

        ReadOnlySpan<byte> IReadOnlyString.Bytes
            => sys.recover<T,byte>(Cells);
    }
}