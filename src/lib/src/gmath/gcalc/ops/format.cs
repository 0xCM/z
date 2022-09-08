//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        /// <summary>
        /// Renders the term by default as 'a_i = Value' where i denotes the term index
        /// </summary>
        /// <param name="name">The sequence identifier, if specified</param>
        public static string format<T>(in SeqTerm<T> src, char? name = null)
            => src.IsEmpty ? "{}" : $"{name ?? 'a'}_{src.Index} = {src.Value}";

        /// <summary>
        /// Renders the term by default as 'a_i = Value' where i denotes the term index
        /// </summary>
        /// <param name="name">The sequence identifier, if specified</param>
        public static string format<I,T>(in SeqTerm<I,T> src, char? name = null)
            where I : unmanaged
                => src.IsEmpty ? "{}" : $"{name ?? 'a'}_{src.Index} = {src.Value}";

        public static void format<T>(in SeqTerms<T> src, char delimiter, ITextBuffer dst)
        {
            var count = src.Length;
            var terms = src.View;
            dst.Append(Chars.LBrace);
            for(var i=0; i<count; i++)
            {
                ref readonly var term = ref skip(terms,i);
                dst.Append(format(term));
                if(i != count - 1)
                {
                    dst.Append(delimiter);
                    dst.Append(Chars.Space);
                }
            }
            dst.Append(Chars.RBrace);
        }
    }
}