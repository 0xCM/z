//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using VCK = VarContextKind;

    public class MsgOps
    {
        /// <summary>
        /// Produces the literal '{<paramref name='index'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index)
            => string.Concat("{", index, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>,<paramref name='pad'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(byte index, short pad)
            => string.Concat("{", index, ",", pad, "}");

        /// <summary>
        /// Produces the literal '{<paramref name='index'/>,<paramref name='pad'/>}
        /// </summary>
        /// <param name="index">The slot index value</param>
        [MethodImpl(Inline), Op]
        public static string slot(uint index, short pad)
            => string.Concat("{", index, ",", pad, "}");

        [MethodImpl(Inline), Op]
        public static string pad(int pad)
            => pad == 0 ? "{0}" : "{0," + pad.ToString() + "}";

        public const char PropertySep = Chars.Colon;

        /// <summary>
        /// Defines the format pattern '{n,pad}'
        /// </summary>
        /// <param name="n">The zero-based slot index</param>
        /// <param name="pad">The pad width specifier</param>
        [MethodImpl(Inline), Op]
        public static string pad(uint n, int pad)
            => "{0" + n.ToString() + "," + pad.ToString() + "}";

         public static string pattern(VarContextKind vck)
            => vck switch
            {
                VCK.CmdScript => "%{0}%",
                VCK.PsScript => "${0}",
                VCK.BashScript => "${0}",
                VCK.MsBuild => "$({0})",
                _ => "{0}"
            };

        [MethodImpl(Inline)]
        public static RenderPattern<A0> pattern<A0>(string content)
            => content;

        [MethodImpl(Inline)]
        public static RenderPattern<A0,A1> pattern<A0,A1>(string content)
            => content;

        [MethodImpl(Inline)]
        public static RenderPattern<A0,A1,A2> pattern<A0,A1,A2>(string content)
            => content;

        [MethodImpl(Inline)]
        public static RenderPattern<A0,A1,A2,A3> pattern<A0,A1,A2,A3>(string content)
            => content;        

        [MethodImpl(Inline)]
        public static RenderCapture render<T>(T src, params object[] args)
            where T : IFormatPattern
                => new RenderCapture(src, args);

        [MethodImpl(Inline)]
        public static MsgCapture message<T>(T src, params object[] args)
            where T : IMsgPattern
                => new MsgCapture(src, args);

        [MethodImpl(Inline)]
        public static RenderCapture piped<A0,A1>(A0 a0, A1 a1)
            => render(pattern<A0,A1>(RP.PSx2), a0, a1);

        [MethodImpl(Inline)]
        public static RenderCapture piped<A0,A1,A2>(A0 a0, A1 a1, A2 a2)
            => render(pattern<A0,A1,A2>(RP.PSx3), a0, a1, a2);
    }
}