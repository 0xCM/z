//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbSettings
    {
        IDbSources Settings();

        FS.FilePath SettingsPath(string name, FileKind kind);

        FS.FilePath SettingsPath<S>(FileKind kind);
    }
}