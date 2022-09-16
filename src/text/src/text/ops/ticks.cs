//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Encloses content between left and right backticks
        /// </summary>
        /// <param name="content">The content to enclose</param>
        [Op,Closures(Closure)]
        public static string ticked<T>(T src)
            => RP.Ticked.Format(src);    

        [Op]
        public static bool ticks(string src, out Pair<int> indices)
        {
            indices = (-1,-1);
            var i = index(src, RP.Ticks);
            if(i>=0)
            {
                var j = index(right(src,i), RP.Ticks);
                if(j >=0)
                    indices = (i,j);
            }
            return false;
        }
    }
}