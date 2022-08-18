//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public partial class WinSdk : ToolService<WinSdk>
    {
        public WinSdk()
            : base("winsdk")
        {

        }

        public WinSdkInfo Latest()
            => latest();
    }
}