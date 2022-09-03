//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISizedValue : IValued, ISized
    {
        bool INullity.IsEmpty
            => BitWidth == 0;
    }

    public interface ISizedValue<T> : ISizedValue, IValued<T>, ISized<T>
        where T : unmanaged
    {

    }
}