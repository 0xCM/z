//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = ExprPatterns;
    using VCK = VarContextKind;

    [ApiHost,Free]
    public class Vars
    {
        const NumericKind Closure = UnsignedInts;

        public static string pattern(VarContextKind vck)
            => vck switch
            {
                VCK.CmdScript => "%{0}%",
                VCK.PsScript => "${0}",
                VCK.BashScript => "${0}",
                VCK.MsBuild => "$({0})",
                _ => "{0}"
            };
        
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Var<T> var<T>(T src)
            where T : IEquatable<T>, IComparable<T>
                => new Var<T>(() => src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Var<T> var<T>(string name, T src)
            where T : IEquatable<T>, IComparable<T>
                => new Var<T>(name, () => src);

        public static string format(Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        public static string format<T>(Var<T> src, bool bind = true)
            where T : IEquatable<T>, IComparable<T>, new()
                => bind ? src.Value.ToString() : string.Format(XF.TypedVar, src);
    }
}