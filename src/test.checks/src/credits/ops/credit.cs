//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CreditModel;

    partial class CreditBits
    {
        /// <summary>
        /// Defines a reference to a topic in a chapter
        /// </summary>
        /// <param name="v">The document vendor</param>
        /// <param name="vol">The referenced volume</param>
        /// <param name="c">The referenced chapter</param>
        /// <param name="s">The referenced section</param>
        /// <param name="t">The referenced topic</param>
        [MethodImpl(Inline), Op]
        public static DocRef credit(Vendor v, Volume vol, Chapter c, Section s, Topic t, ContentRef cr = default)
        {
            var r = 0ul;
            r |= vendor(v);
            r |= volume(vol);
            r |= chapter(c);
            r |= section(s);
            r |= topic(t);
            r |= content(cr);
            return r;
        }

        /// <summary>
        /// Defines a reference to a topic in an appendix
        /// </summary>
        /// <param name="v">The document vendor</param>
        /// <param name="vol">The referenced volume</param>
        /// <param name="a">The referenced appendix</param>
        /// <param name="s">The referenced section</param>
        /// <param name="t">The referenced topic</param>
        [MethodImpl(Inline), Op]
        public static DocRef credit(Vendor v, Volume vol, Appendix a, Section s, Topic t, ContentRef cr = default)
        {
            var r = 0ul;
            r |= vendor(v);
            r |= volume(vol);
            r |= appendix(a);
            r |= section(s);
            r |= topic(t);
            r |= content(cr);
            return r;
        }

        /// <summary>
        /// Defines a reference to a topic in either a chapter or appendix
        /// </summary>
        /// <param name="v">The document vendor</param>
        /// <param name="vol">The referenced volume</param>
        /// <param name="d">The referenced chapter or appendix</param>
        /// <param name="s">The referenced section</param>
        /// <param name="t">The referenced topic</param>
        [MethodImpl(Inline), Op]
        public static DocRef credit(Vendor v, Volume vol, Division d, Section s, Topic t, ContentRef cr = default)
        {
            var r = 0ul;
            r |= vendor(v);
            r |= volume(vol);
            r |= division(d);
            r |= section(s);
            r |= topic(t);
            r |= content(cr);
            return r;
        }

    }
}