//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct IntelPaths
    {
        public static IntelPaths service()
            => new();

        readonly IDbArchive Root;

        public IntelPaths()
        {
            Root = AppSettings.Default.IntelKits();
        }

        public IDbArchive Kits()
            => Root;
        
        IDbArchive Kit(string name)
            => Kits().Scoped(name);
        
        public DbArchive XedDb()
            => AppSettings.Default.Setting(SettingNames.XedDb).Folder();

        public DbArchive SdmDb()
            => AppSettings.Default.Setting(SettingNames.SdmDb).Folder();

        public DbArchive SdeDb()
            => AppSettings.Default.Setting(SettingNames.SdeDb).Folder();

        public DbArchive InxDb()
            => AppSettings.Default.Setting(SettingNames.InxDb).Folder();

        public IDbArchive XedKit()
            => Kit("xed");

        public IDbArchive PinKit()
            => Kit("pin");

        public IDbArchive SdeKit()
            => Kit("sde");

    }
}