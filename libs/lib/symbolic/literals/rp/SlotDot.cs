//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        /// <summary>
        /// Defines the literal '{0}.{1}'
        /// </summary>
        [RenderPattern(2, "{0}.{1}")]
        public const string SlotDot2 = Slot0 + Dot + Slot1;

        /// <summary>
        /// Defines the literal '{0}.{1}.{2}'
        /// </summary>
        [RenderPattern(3, "{0}.{1}.{2}")]
        public const string SlotDot3 = SlotDot2 + Dot + Slot2;

        /// <summary>
        /// Defines the literal '{0}.{1}.{2}.{3}'
        /// </summary>
        [RenderPattern(4, "{0}.{1}.{2}.{3}")]
        public const string SlotDot4 = SlotDot3 + Dot + Slot3;

        /// <summary>
        /// Defines the literal '{0}.{1}.{2}.{3}.{4}'
        /// </summary>
        [RenderPattern(5, "{0}.{1}.{2}.{3}.{4}")]
        public const string SlotDot5 = SlotDot4 + Dot + Slot4;
    }
}