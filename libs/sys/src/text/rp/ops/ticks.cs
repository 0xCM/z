//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Encloses content between left and right backticks
        /// </summary>
        /// <param name="content">The content to enclose</param>
        [Op,Closures(Closure)]
        public static string ticks<T>(T src)
            => Ticks + denullify(src) + Ticks;
    }
}