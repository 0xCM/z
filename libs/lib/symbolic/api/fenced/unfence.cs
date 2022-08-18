//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Fenced
    {
        /// <summary>
        /// Extracts text that is enclosed between left and right boundaries, i.e. {left}{content}{right} => {content}
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="left">The left boundary</param>
        /// <param name="right">The right boundary</param>
        [Op]
        public static string unfence(string src, Fence<string> fence)
        {
            (var i0, var i1) = text.indices(src, fence);
            if(i0 != NotFound && i1 != NotFound && (i0 < i1))
            {
                var start = i0 + fence.Left.Length;
                var length = i1 - start;
                return text.slice(src, start, length);
            }

            return EmptyString;
        }

        [Op]
        public static string unfence(string src, Fence<char> fence)
        {
            (var i0, var i1) = text.indices(src, fence);
            if(i0 != NotFound && i1 != NotFound && (i0 < i1))
            {
                var start = i0 + 1;
                var length = i1 - start;
                return text.slice(src, start, length);
            }

            return EmptyString;
        }

        [Op]
        public static string unfence(string src, int offset, Fence<char> fence)
            => unfence(text.slice(src,offset), fence);

        /// <summary>
        /// Extracts text that is enclosed between left and right boundaries, i.e. {left}{content}{right} => {content}
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="left">The left boundary</param>
        /// <param name="right">The right boundary</param>
        [Op]
        public static bool unfence(string src, Fence<char> fence, out string dst)
        {
            dst = EmptyString;
            if(!text.blank(src))
            {
                if(Fenced.find(src, fence, out var location))
                {
                    dst = text.segment(src, location.Left + 1,  location.Right - 1);
                    return true;
                }
            }
            return false;
        }
    }
}