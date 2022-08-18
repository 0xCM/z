//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        /// <summary>
        /// Assigns aggregate identity to an identity sequence
        /// </summary>
        /// <param name="open">The left fence</param>
        /// <param name="close">The right fence</param>
        /// <param name="sep">The sequence element delimiter</param>
        /// <param name="src">The source sequence</param>
        [Op]
        public static string sequential(char open, char close, char sep, IEnumerable<string> src)
            => string.Concat(open, string.Join(sep,src), close);
    }
}