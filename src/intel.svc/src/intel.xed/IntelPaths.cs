//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct IntelPaths
    {
        public static IntelPaths paths()
            => new();
        readonly IDbArchive Root;

        public IntelPaths()
        {
            Root = AppSettings.Default.IntelKits();
        }

        public IDbArchive Kits()
            => Root;
        
        public IDbArchive Kit(string name)
            => Kits().Scoped(name);
    }
}