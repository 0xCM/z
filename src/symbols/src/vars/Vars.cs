//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = ExprPatterns;
    using VCK = VarContextKind;


    [ApiHost]
    public class Vars
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScriptVar<T> expr<T>(string name, T value)
            where T : IEquatable<T>, IComparable<T>, new()
                => new ScriptVar<T>(name,(Chars.LBrace, Chars.RBrace), value);

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

        public static string format<T>(ScriptVar<T> src, bool name = false)
            where T : IEquatable<T>, IComparable<T>, new()
        {
            var dst = RP.Null;
            if(src.VarValue != null)
            {
                if(src.IsFenced)
                {
                    if(name && src.IsNamed)
                    {
                        dst = $"{src.VarName}={src.Fence.Format(src.VarValue)}";

                    }
                    else
                        dst = src.Fence.Format(src.VarValue);
                }
                else if(src.IsPrefixed)
                {
                    if(name && src.IsNamed)
                        dst = $"{src.VarName}={src.Prefix}{src.VarValue}";
                    else
                        dst = $"{src.Prefix}{src.VarValue}";
                }
                else
                {
                    if(name && src.IsNamed)
                        dst = $"{src.VarName}={src.VarValue}";
                    else
                        dst = $"{src.VarValue}";
                }
            }
            return dst;
        }

        public static string format(Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        public static string format<T>(Var<T> src, bool bind = true)
            where T : IEquatable<T>, IComparable<T>, new()
                => bind ? src.Value.ToString() : string.Format(XF.TypedVar, src);
    }
}
