//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.literals;
namespace global
{
    [ApiComplete(ApiName)]
    public partial class sys
    {
        public const string ApiName = globals + dot + nameof(sys);
    }
}