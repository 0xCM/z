//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using VCK = VarKind;
    using static sys;

    [ApiHost,Free]
    public class Vars
    {
        const NumericKind Closure = UnsignedInts;

        public static ScriptVars cmdvars(params Pair<string>[] src)
        {
            var dst = new CmdVar[src.Length];
            for(var i=0; i<src.Length; i++)
                seek(dst,i) = skip(src,i);
            return dst;
        }

        public static string pattern(VarKind vck)
            => vck switch
            {
                VCK.CmdScript => "%{0}%",
                VCK.PsScript => "${0}",
                VCK.BashScript => "${0}",
                VCK.MsBuild => "$({0})",
                _ => "{0}"
            };
        
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Var<T> var<T>(string name, T value = default)
            where T : IEquatable<T>, IComparable<T>
                => new Var<T>(name, value = default);

        [Op]
        public static ScriptVarClass @class(IVar kind)
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

        public static string format(IVar src)
        {
            var @class = Vars.@class(src);
            if(src.HasValue)
                return src.Value().ToString();

            switch(@class)
            {
                case ScriptVarClass.PrefixedFence:
                    return string.Format("{0}{1}{2}{3}", src.Prefix, src.Fence.Left, src.Name, src.Fence.Right);
                case ScriptVarClass.Fenced:
                    return string.Format("{0}{1}{2}", src.Fence.Left, src.Name, src.Fence.Right);
                case ScriptVarClass.Prefixed:
                    return string.Format("{0}{1}", src.Prefix, src.Name);
            }
            return EmptyString;
        }

        public static string eval(string expr, ICollection<IVar> vars)
        {
            var result = expr;
            foreach(var v in vars)
            {
                if(v.HasValue)
                {
                    
                    result = text.replace(result, string.Format("{0}{1}{2}{3}", v.Prefix, v.Fence.Left, v.Name, v.Fence.Right), v.Value().ToString());
                }
            }
            return result;
        }

        public static string eval(string expr, ICollection<IVar> vars, Fence<char> fence)
        {
            var result = expr;
            foreach(var v in vars)
            {
                if(v.HasValue)
                    result = text.replace(result, string.Format("{0}{1}{2}", fence.Left, v.Name, fence.Right), v.Value().ToString());
            }
            return result;
        }

        /// <summary>
        /// Parses a sequence of fixed variables using a caller-supplied parser
        /// </summary>
        /// <param name="src">The input text</param>
        /// <param name="kind">The variable kind instance</param>
        /// <param name="vf">The variable parser</param>
        public static Dictionary<string,IVar> vars(ReadOnlySpan<char> src, Fence<char> fence, Func<string,IVar> vf)
        {
            var count = src.Length;
            var dst = dict<string,IVar>();
            var name = EmptyString;
            var parsing = false;
            var LD = fence.Left;
            var RD = fence.Right;
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

       public static string format<T>(ScriptVar<T> src)
            where T : IEquatable<T>, INullity, new()
        {
            var dst = EmptyString;
            if(src.IsPrefixedFence)
                dst = $"{src.Prefix}{src.Fence.Left}{src.VarName}{src.Fence.Right}";
            else if(src.IsPrefixed)
                dst = $"{src.Prefix}{src.VarName}";
            else if(src.IsFenced)
                dst = $"{src.Fence.Left}{src.VarName}{src.Fence.Right}";
            else
                dst = src.Format();
            return dst;            
        }

        public static Dictionary<string,ScriptVar> extract(ReadOnlySpan<char> src, AsciSymbol prefix, AsciFence fence)
        {
            var dst = dict<string,ScriptVar>();
            var count = src.Length;
            var lpos = -1;
            var rpos = -1;
            var parsing = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var c0 = ref skip(src,i);
                if(c0 == prefix)
                {
                    if(i < count -1)
                    {
                        parsing = skip(src,++i) == fence.Left;
                        lpos = i + 1;
                    }
                }
                else if(c0 == fence.Right && parsing)
                {
                    rpos = i - 1;                    
                    var name = sys.@string(text.segment(src, lpos, rpos));
                    dst.TryAdd(name, new ScriptVar(name,prefix,fence));
                    lpos = -1;
                    rpos = -1;                    
                }
            }

            return dst;
        }
    }
}