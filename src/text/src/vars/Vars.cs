//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using VCK = VarContextKind;
    using static sys;

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

    }
}