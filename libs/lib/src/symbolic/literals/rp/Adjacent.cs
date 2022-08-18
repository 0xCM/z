//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        /// <summary>
        /// Defines the literal '{0}{1}'
        /// </summary>
        [RenderPattern(2, Adjacent2)]
        public const string Adjacent2 = "{0}{1}";

        /// <summary>
        /// Defines the literal '{0}{1}{2}'
        /// </summary>
        [RenderPattern(3, Adjacent3)]
        public const string Adjacent3 = "{0}{1}{2}";

        /// <summary>
        /// Defines the literal '{0}{1}{2}{3}'
        /// </summary>
        [RenderPattern(4, Adjacent4)]
        public const string Adjacent4 = "{0}{1}{2}{3}";

        /// <summary>
        /// Defines the literal '{0}{1}{2}{3}{4}'
        /// </summary>
        [RenderPattern(5, Adjacent5)]
        public const string Adjacent5 = "{0}{1}{2}{3}{4}";

        /// <summary>
        /// Defines the literal '{0}{1}{2}{3}{4}'
        /// </summary>
        [RenderPattern(6, Adjacent6)]
        public const string Adjacent6 = "{0}{1}{2}{3}{4}{5}";
    }
}
