//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Defines the canonical assignment pattern
        /// </summary>
        [RenderPattern(2, Assign)]
        public const string Assign = "{0}={1}";

        /// <summary>
        /// Defines the canonical assignment pattern, but with spaces
        /// </summary>
        [RenderPattern(2, SpacedAssign)]
        public const string SpacedAssign = "{0} = {1}";
    }
}