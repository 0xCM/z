//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiQuery
    {
        [Op]
        public static ApiHostInfo hostinfo(Type t)
        {
            var methods = t.DeclaredMethods();
            return new ApiHostInfo(t, t.ApiHostUri(), t.Assembly.Id(), methods, index(methods));
        }
    }
}