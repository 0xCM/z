//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.literals;
namespace global
{
    [ApiHost(ApiName)]
    public partial class literals
    {
        public const string ApiName = globals + dot + nameof(literals);
    }
}
