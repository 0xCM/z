//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Defines the literal '{0}:{1}'
        /// </summary>
        [RenderPattern(2, SemiSlot)]
        public const string SemiSlot = "{0}:{1}";

        /// <summary>
        /// Defines the literal '{0}:{1}; {2}:{3};'
        /// </summary>
        [RenderPattern(4, SemiSlots2)]
        public const string SemiSlots2 = "{0}:{1}; {2}:{3}";

        /// <summary>
        /// Defines the literal '{0}:{1}; {2}:{3}; {4}:{5}'
        /// </summary>
        [RenderPattern(6, SemiSlots3)]
        public const string SemiSlots3 = "{0}:{1}; {2}:{3}; {4}:{5}";

        /// <summary>
        /// Defines the literal '{0}:{1}; {2}:{3}; {4}:{5}; {6}:{7}'
        /// </summary>
        [RenderPattern(8, SemiSlots4)]
        public const string SemiSlots4 = "{0}:{1}; {2}:{3}; {4}:{5}; {6}:{7}";
    }
}