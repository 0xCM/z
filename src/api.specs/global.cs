//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

global using static global.sys;
global using static global.literals;
global using static global.api;

namespace global
{
    [ApiComplete(ApiName)]
    public partial class api
    {
        public const string ApiName = globals + dot + nameof(api);
    }
}
