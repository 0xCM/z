//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using S = ToolSettings;

    partial class Cmd
    {
        public static ToolSettings settings(FilePath src)
        {
            var data = Settings.env(src);
            var dst = new ToolSettings();
            var setting = EmptyString;
            if(data.Find(nameof(S.ToolId), out setting))
                dst.ToolId = setting;
            if(data.Find(nameof(S.Group), out setting))
                dst.Group = setting;
            if(data.Find(nameof(S.ToolEnv), out setting))
                dst.ToolEnv = FS.uri(setting);
            if(data.Find(nameof(S.InstallBase), out setting))
                dst.InstallBase = FS.dir(setting);
            if(data.Find(nameof(S.ToolHome), out setting))
                dst.ToolHome = FS.dir(setting);
            if(data.Find(nameof(S.ToolLogs), out setting))
                dst.ToolLogs = FS.dir(setting);
            if(data.Find(nameof(S.ToolDocs), out setting))
                dst.ToolDocs = FS.dir(setting);
            if(data.Find(nameof(S.ToolScripts), out setting))
                dst.ToolScripts = FS.dir(setting);
            return dst;
        }
    }
}