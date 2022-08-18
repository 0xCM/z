//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Creates a string of the form "name: content"
        /// </summary>
        /// <param name="name">The label name</param>
        /// <param name="content">The labeled content</param>
        [Op]
        public static string label(object name, object content)
            => string.Concat(name, Chars.Colon, Space, content);
    }
}