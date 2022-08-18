//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdSource : ILookup<Name,Setting64>
    {
        ref readonly ReadOnlySeq<Setting64> Commands {get;}

        ref readonly Setting64 Command(uint index);

        ref readonly Setting64 Command(int index)
            => ref Command((uint)index);
    }
}