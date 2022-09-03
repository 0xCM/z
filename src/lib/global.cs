//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.literals;
global using static global.lib;
global using static global.api;
using static Z0.ApiAtomic;
namespace global
{
    [ApiComplete(ApiName)]
    public partial class lib
    {
        public const string ApiName = globals + dot + nameof(lib);
    }
}
