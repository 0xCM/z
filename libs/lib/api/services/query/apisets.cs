//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        public ReadOnlySeq<ApiSets> apisets(ReadOnlySeq<Assembly> src)
            => src.Select(apiset);

        public static ApiSets apiset(Assembly src)
            => new (src);
    }
}