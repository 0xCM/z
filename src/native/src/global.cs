//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using static global.literals;
global using static global.sys;
global using static global.native;
namespace global
{
    using static Z0.sys;
    using asm = Z0.Asm.asm;
    using static ApiAtomic;

    [ApiComplete(ApiName)]
    public partial class native
    {
        public const string ApiName = globals + dot + nameof(native);

    }
}