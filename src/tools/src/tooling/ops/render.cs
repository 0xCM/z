//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Tooling
    {
        // static readonly EnumRender<ArgSepKind> ArgSepRender = new();

        // static readonly EnumRender<ArgPrefixKind> ArgPrefixRender = new();

        // public static void render(ArgSepKind src, ITextEmitter dst)
        //     => dst.Append(ArgSepRender.Format(src));

        // public static void render(ArgPrefixKind src, ITextEmitter dst)
        //     => dst.Append(ArgPrefixRender.Format(src));

        // public static string format(ToolCmdArg src)
        // {
        //     var dst = text.emitter();
        //     render(src,dst);
        //     return dst.Emit();
        // }

        // public static void render(ToolCmdArg src, ITextEmitter dst)
        // {
        //     render(src.Prefix, dst);
        //     dst.Append(src.Name);
        //     render(src.Sep, dst);
        //     dst.Append(src.Value.Format());
        // }

        // public static void render(ToolCmdArgs src, ITextEmitter dst)
        // {
        //     for(var i=0; i<src.Count; i++)
        //     {
        //         if(i != 0)
        //             dst.Append(Chars.Space);
                
        //         render(src[i], dst);
        //     }
        // }
    }
}