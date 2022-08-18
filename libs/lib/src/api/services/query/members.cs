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
            if(src.Count != 0)
                return new ApiMembers(src.First.BaseAddress, src.Sort());
            else
                return ApiMembers.Empty;
        }
    }
}