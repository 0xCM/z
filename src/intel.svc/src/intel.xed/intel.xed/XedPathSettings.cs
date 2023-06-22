//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct XedPathSettings
    {
        public readonly FolderPath XedSources;

        public readonly FolderPath XedTargets;

        public XedPathSettings(FolderPath src, FolderPath dst)
        {
            XedSources = src;
            XedTargets = dst;
        }
    }
}