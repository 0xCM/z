//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ToolCmdArgs : Seq<ToolCmdArgs,ToolCmdArg>
    {
        [Op]
        public static bool arg(ToolCmdArgs src, string name, out ToolCmdArg dst)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src[i];
                if(string.Equals(arg.Name, name, NoCase))
                {
                    dst=arg;
                    return true;
                }
            }
            dst = ToolCmdArg.Empty;
            return false;
        }


        [Op]
        public static void render(ToolCmdArgs src, ITextEmitter dst)
        {
            var count = src.Count;
            for(var i=0u; i<count; i++)
            {
                dst.Append(src[i].Format());
                if(i != count - 1)
                    dst.Append(Space);
            }
        }        
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