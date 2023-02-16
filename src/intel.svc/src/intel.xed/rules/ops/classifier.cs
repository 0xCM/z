//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static XedInstClass classifier(XedInstClass src)
        {
            var dst = src;
            var name = src.Format();
            if(name.EndsWith("_LOCK"))
                XedParsers.parse(name.Remove("_LOCK"), out dst);
            return dst;
        }
    }
}