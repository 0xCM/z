//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ApiPartCatalogs : Seq<ApiPartCatalogs,ApiPartCatalog>
    {
        public ApiPartCatalogs()
        {

        }

        [MethodImpl(Inline)]
        public ApiPartCatalogs(ApiPartCatalog[] src)
            : base(src)
        {
            Data = src;
        }
    }
}