//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using LU = System.Collections.Generic.Dictionary<ApiHostUri,ApiHostBlocks>;

    public sealed class ApiHostCodeLookup : LU
    {
        public static ApiHostCodeLookup create(LU src)
            => new ApiHostCodeLookup(src);

        public ApiHostCodeLookup()
        {

        }

        ApiHostCodeLookup(LU src)
            : base(src)
        {

        }

        public static ApiHostCodeLookup Empty
           => new ApiHostCodeLookup();
    }
}