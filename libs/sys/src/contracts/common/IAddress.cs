//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAddress : ITextual, INullity
    {

    }

    public interface IAddress<T> : IAddress
        where T : unmanaged
    {
        T Location {get;}

        bool INullity.IsEmpty
            => Location.Equals(default(T));
    }
}