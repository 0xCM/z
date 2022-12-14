//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiCanonicalClass;

    [Free]
    public interface IApiCanonicalClass : IApiClass<K>
    {
        new ApiCanonicalClass Kind {get;}

        K IApiClass<K>.Kind
            => Kind;
    }
}