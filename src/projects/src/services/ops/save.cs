//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using static ProjectModels;

    partial class ProjectServices
    {
        public static ExecToken save(IWfChannel channel, WorkspaceFile src)   
        {
            var buffer = text.emitter();
            var emitter = Json.emitter(buffer);
            emitter.Serialize(new {
                folders = src.Folders.Storage
            });
            return channel.FileEmit(buffer.Emit(), src.Path);
        }

        public static ExecToken save(IWfChannel channel, LaunchScript src)   
            => channel.FileEmit(src.Script.Body, src.Path);

        public static ExecToken save(IWfChannel channel, ConfigFile src)
        {
            var buffer = text.emitter();
            iter(src.Body, setting => buffer.AppendLine(setting.Format()));
            return channel.FileEmit(buffer.Emit(), src.Path);
        }
    }
}