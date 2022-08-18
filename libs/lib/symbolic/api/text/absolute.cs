//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    partial class text
    {
        /// <summary>
        /// Returns a fixed-length string, padding or cutting as necessary
        /// </summary>
        /// <param name="src"></param>
        /// <param name="length"></param>
        [Op]
        public static string absolute(string src, short length)
            => src.Length < length ? string.Format(RP.pad(-length), src) : slice(src, 0, length);
    }
}