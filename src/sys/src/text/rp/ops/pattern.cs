//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using VCK = VarContextKind;

    partial class RP
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
    }
}