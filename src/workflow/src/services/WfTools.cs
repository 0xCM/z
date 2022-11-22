//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
 
    public class WfTools : WfSvc<WfTools>
    {
        public static Task<ExecToken> vscode<T>(IWfChannel channel, T target)
            => Cmd.start(channel, FS.path("code.exe"), Cmd.args(target));

        public static Task<ExecToken> devenv<T>(IWfChannel channel, T target)
            => Cmd.start(channel, FS.path("devenv.exe"), Cmd.args(target));

        [Op, Closures(UInt64k)]
        public static ToolCmdSpec spec<T>(Tool tool, in T src)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(src, fields, reflected);
            var buffer = sys.alloc<ToolCmdArg>(count);
            var target = span(buffer);
            var values = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(values,i);
                seek(target,i) = new ToolCmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmdSpec(tool, ApiCmdTypes.identify(t), buffer);
        }
    }
}