//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        public class InstIsaKinds : HashSet<InstIsaKind>
        {
            public static InstIsaKinds Empty => new();
        }
    }
}