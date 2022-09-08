//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.sys;
global using static global.literals;
global using static global.bit;
global using static global.bitrender;
namespace global
{
    [ApiComplete(ApiName)]
    public partial class bitrender
    {
        public const string ApiName = globals + dot + nameof(bitrender);
    }
}