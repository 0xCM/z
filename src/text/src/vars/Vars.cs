//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using XF = ExprPatterns;
    using VCK = VarContextKind;

    using static sys;

    [ApiHost]
    public class Vars
    {
        public static ScriptVarClass @class(ITextVarExpr kind)
        {
            if(kind.IsPrefixedFence)
                return ScriptVarClass.PrefixedFence;
            else if(kind.IsFenced)
                return ScriptVarClass.Fenced;
            else if(kind.IsPrefixed)
                return ScriptVarClass.Prefixed;
            else
                return 0;
        }

        /// <summary>
        /// Formats a specified <see cref='ITextVar'/> variable
        /// </summary>
        /// <param name="src">The variable to parse</param>
        public static string format(ITextVar src)
        {
            var kind = src.Expr;
            var @class = Vars.@class(kind);
            if(src.IsNonEmpty)
                return src.Value;

            switch(@class)
            {
                case ScriptVarClass.PrefixedFence:
                    return string.Format("{0}{1}{2}{3}", kind.Prefix, kind.Fence.Left, src.Name, kind.Fence.Right);
                case ScriptVarClass.Fenced:
                    return string.Format("{0}{1}{2}", kind.Fence.Left, src.Name, kind.Fence.Right);
                case ScriptVarClass.Prefixed:
                    return string.Format("{0}{1}", kind.Prefix, src.Name);
            }
            return EmptyString;
        }

        public static string EvalFencedVarExpr(string expr, ICollection<ITextVar> vars, ITextVarExpr kind)
        {
            var result = expr;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            foreach(var v in vars)
            {
                if(v.IsNonEmpty)
                    result = text.replace(result, string.Format("{0}{1}{2}", LD, v.Name, RD), v.Value);
            }
            return result;
        }

        public static string EvalPrefixFencedVarExpr(string expr, ICollection<ITextVar> vars, ITextVarExpr kind)
        {
            var result = expr;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            var prefix = kind.Prefix;
            foreach(var v in vars)
            {
                if(v.IsNonEmpty)
                    result = text.replace(result, string.Format("{0}{1}{2}{3}", prefix, LD, v.Name, RD), v.Value);
            }
            return result;
        }

        public static string EvalPrefixedVarExpr(string expr, ICollection<ITextVar> vars, ITextVarExpr kind)
        {
            var result = expr;
            var prefix = kind.Prefix;
            foreach(var v in vars)
            {
                if(v.IsNonEmpty)
                    result = text.replace(result, string.Format("{0}{1}", prefix, v.Name), v.Value);
            }
            return result;
        }

        /// <summary>
        /// Parses a sequence of fixed variables using a caller-supplied parser
        /// </summary>
        /// <param name="src">The input text</param>
        /// <param name="kind">The variable kind instance</param>
        /// <param name="vf">The variable parser</param>
        public static Dictionary<string,ITextVar> ParseFencedVars(ReadOnlySpan<char> src, ITextVarExpr kind, Func<string,ITextVar> vf)
        {
            var count = src.Length;
            var dst = dict<string,ITextVar>();
            var name = EmptyString;
            var parsing = false;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(!parsing)
                {
                    if(c == LD)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(nonempty(name) && c == RD)
                    {
                        dst.TryAdd(name, vf(name));
                        name = EmptyString;
                        parsing = false;
                    }
                    else
                    {
                        name += c;
                    }
                }
            }

            if(nonempty(name))
                dst.TryAdd(name, vf(name));
            return dst;
        }

        public static Dictionary<string,ITextVar> ParsePrefixedVars(ReadOnlySpan<char> src, ITextVarExpr kind, Func<string,ITextVar> vf)
        {
            var count = src.Length;
            var dst = dict<string,ITextVar>();
            var name = EmptyString;
            var parsing = false;
            var prefix = kind.Prefix;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);

                if(!parsing)
                {
                    if(c == prefix)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(c == Chars.Space)
                    {
                        dst.TryAdd(name,vf(name));
                        name = EmptyString;
                        parsing = false;
                    }
                    else
                    {
                        name += c;
                    }
                }
            }

            if(nonempty(name))
                dst.TryAdd(name,vf(name));
            return dst;
        }

        public static Dictionary<string,ITextVar> ParsePrefixedFencedVars(ReadOnlySpan<char> src, ITextVarExpr kind, Func<string,ITextVar> vf)
        {
            var count = src.Length;
            var dst = dict<string,ITextVar>();
            var name = EmptyString;
            var parsing = false;
            var LD = kind.Fence.Left;
            var RD = kind.Fence.Right;
            var prefix = kind.Prefix;

            for(var i=0; i<count-1; i++)
            {
                ref readonly var c0 = ref skip(src,i);
                ref readonly var c1 = ref skip(src,i+1);

                if(!parsing)
                {
                    if(c0 == prefix && c1 == LD)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(nonempty(name) && c1 == RD)
                    {
                        dst.TryAdd(name,vf(name));
                        name = EmptyString;
                        parsing = false;
                    }
                    else
                    {
                        name += c1;
                    }
                }
            }

            if(nonempty(name))
                dst.TryAdd(name, vf(name));
            return dst;
        }
         
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
