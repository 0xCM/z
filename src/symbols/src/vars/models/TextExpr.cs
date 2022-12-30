//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines the root <see cref='ITextExpr'/> abstraction
    /// </summary>
    public class TextExpr
    {
        protected Dictionary<string,ITextVar> VarLookup;

        public string Body {get;}

        public ITextVarExpr VarExpr {get;}

        public TextExpr(string body, ITextVarExpr exr)
        {
            Body = body;
            VarExpr = exr;
        }

        public ITextVar this[string var]
        {
            [MethodImpl(Inline)]
            get => VarLookup[var];

            [MethodImpl(Inline)]
            set => VarLookup[var] = value;
        }

        public ITextVar[] Vars
        {
            [MethodImpl(Inline)]
            get => VarLookup.Values.Array();
        }

        public virtual string Eval()
        {
            switch(VarExpr.Class)
            {
                case ScriptVarClass.PrefixedFence:
                    return EvalPrefixFencedVarExpr(Body, Vars, VarExpr);
                case ScriptVarClass.Fenced:
                    return EvalFencedVarExpr(Body, Vars, VarExpr);
                case ScriptVarClass.Prefixed:
                    return EvalPrefixedVarExpr(Body, Vars, VarExpr);
            }
            return EmptyString;
        }

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
            var @class = TextExpr.@class(kind);
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

        public static string EvalFencedVarExpr(string expr, ReadOnlySpan<ITextVar> vars, ITextVarExpr kind)
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

        public static string EvalPrefixFencedVarExpr(string expr, ReadOnlySpan<ITextVar> vars, ITextVarExpr kind)
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

        public static string EvalPrefixedVarExpr(string expr, ReadOnlySpan<ITextVar> vars, ITextVarExpr kind)
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
    }
}