//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct IntelPaths
    {
        public static IntelPaths Service => new();

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
        
        static IEnvDb EnvDb => AppSettings.Default.EnvDb();

        public DbArchive XedDb()
            => EnvDb.Scoped(SettingNames.XedDb);

        public DbArchive SdmDb()
            => EnvDb.Scoped(SettingNames.SdmDb);

        public DbArchive SdeDb()
            => EnvDb.Scoped(SettingNames.SdeDb);

        public DbArchive InxDb()
            => EnvDb.Scoped(SettingNames.InxDb);

        public IDbArchive XedKit()
            => Kit("xed");

        public IDbArchive PinKit()
            => Kit("pin");

        public IDbArchive SdeKit()
            => Kit("sde");

    }
}