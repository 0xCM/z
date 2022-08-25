//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        public static CmdArgs args(ReadOnlySpan<string> src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg(skip(src,i));
            return CmdArgs.create(dst);
        }

        public static ToolCmdArgs args<T>(T src)
            where T : struct, IToolCmd
        {
            var fields = typeof(T).DeclaredInstanceFields();
            return fields.Select(f => new ToolCmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));
        }
    }
}