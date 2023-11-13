//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

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

    static ref readonly AppSettings Settings => ref AppSettings.Default;
                        
    public IDbArchive SdmDb()
        => Settings.Setting(SettingNames.SdmDb).DbArchive();

    public IDbArchive SdeDb()
        => Settings.Setting(SettingNames.SdeDb).DbArchive();

    public IDbArchive InxDb()
        => Settings.Setting(SettingNames.InxDb).DbArchive();

    public IDbArchive PinKit()
        => Kit("pin");

    public IDbArchive SdeKit()
        => Kit("sde");
}
