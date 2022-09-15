//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cmd
    {
        [Op]
        public static void parse(ReadOnlySpan<TextLine> src, out ReadOnlySpan<CmdFlow> dst)
            => dst = flows(src);

        [Op]
        public static bool parse(ReadOnlySpan<char> src, out AppCmdSpec dst)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new AppCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = sys.@string(SQ.left(src,i));
                var _args = sys.@string(SQ.right(src,i)).Split(Chars.Space);
                dst = new AppCmdSpec(name, args(_args));
            }
            return true;
        }
    }
}