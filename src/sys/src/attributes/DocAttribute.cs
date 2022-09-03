//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes anything, or at least something
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DocAttribute : Attribute
    {
        /// <summary>
        /// The documentation origin, if applicable
        /// </summary>
        public readonly string Origin;

        /// <summary>
        /// The documentation content
        /// </summary>
        public readonly string Content;

        public DocAttribute(string content)
        {
            Origin = EmptyString;
            Content = content;
        }

        public DocAttribute(string src, string content)
        {
            Origin = src;
            Content = content;
        }
    }
}