//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCmdArgs : Seq<ToolCmdArgs,ToolCmdArg>
    {
        public static ToolCmdArgs load<T>(T src)
            where T : struct, IToolCmd
        {
            var fields = typeof(T).DeclaredInstanceFields();
            return fields.Select(f => new ToolCmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));
        }        

        public ToolCmdArgs()
        {

        }

        [MethodImpl(Inline)]
        public ToolCmdArgs(ToolCmdArg[] src)
            :base(src)
        {

        }

        [MethodImpl(Inline)]
        public static implicit operator ToolCmdArgs(ToolCmdArg[] src)
            => new ToolCmdArgs(src);
    }
}