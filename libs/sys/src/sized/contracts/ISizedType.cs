//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISizedType : IType
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}

        bool INullity.IsEmpty
            => StorageWidth == 0;

        bool INullity.IsNonEmpty
            => StorageWidth != 0;

    }

    public interface ISizedType<K> : ISizedType, IType<K>
        where K : unmanaged
    {

    }
}