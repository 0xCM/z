//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Relations
    {
        /// <summary>
        /// Defines a correlation set between scalar sequences and expresions
        /// </summary>
        /// <typeparam name="S">The scalar type</typeparam>
        /// <typeparam name="M">The expression type</typeparam>
        public class ScalarMatch<S,M>
            where S : IScalarValue
        {
            readonly Dictionary<S[],M> Data;

            public ScalarMatch()
            {
                Data = new();
            }

            public ScalarMatch<S,M> Include(M match, params S[] scalars)
            {
                Data[scalars] = match;
                return this;
            }

            public string Format()
            {
                var dst = text.buffer();
                var keys = Data.Keys.Array();
                var count = keys.Length;
                dst.Append(Chars.LBracket);
                for(var i=0; i<count; i++)
                {
                    var key = skip(keys,i);
                    dst.AppendFormat("({0} -> {1})", text.embrace(key.Delimit()), Data[key]);
                    if(i < count -1)
                        dst.Append(", ");

                }
                dst.Append(Chars.RBracket);

                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}