//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using VCK = VarContextKind;

    public class MsgOps
    {
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
            => render(pattern<A0,A1>(RpOps.PSx2), a0, a1);

        [MethodImpl(Inline)]
        public static RenderCapture piped<A0,A1,A2>(A0 a0, A1 a1, A2 a2)
            => render(pattern<A0,A1,A2>(RpOps.PSx3), a0, a1, a2);

    }
}