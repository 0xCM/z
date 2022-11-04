//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        public static ApiMembers members(Index<ApiMember> src)
        {
            if(src.IsNonEmpty)
            {
                src.Sort();
                return new ApiMembers(src.First.BaseAddress, src);
            }
            else
                return ApiMembers.Empty;
        }
    }
}