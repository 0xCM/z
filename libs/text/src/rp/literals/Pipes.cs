//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Defines the literal '|'
        /// </summary>
        [RenderLiteral(Pipe, 1)]
        public const string Pipe = "|";

        /// <summary>
        /// Defines the literal '| '
        /// </summary>
        public const string PipeJoin = "| ";

        /// <summary>
        /// The " | " character sequence
        /// </summary>
        [RenderLiteral(" | ", 3)]
        public const string SpacedPipe = " | ";

        /// <summary>
        /// Defines the literal " |"
        /// </summary>
        [RenderLiteral(" |")]
        public const string SpacePipe = Space + Pipe;

        /// <summary>
        /// Defines the literal '| {0}'
        /// </summary>
        [RenderPattern(1, "{0} | ")]
        public const string SlottedSpacePipe = Slot0 + SpacePipe + Space;

        /// <summary>
        /// Defines the literal '{0} | {1}'
        /// </summary>
        [RenderPattern(2, "{0} | {1}")]
        public const string PSx2 = Slot0 + SpacePipe + Space + Slot1;

        /// <summary>
        /// Defines the literal '{0} | {1} | {2}'
        /// </summary>
        [RenderPattern(3, "{0} | {1} | {2}")]
        public const string PSx3 = PSx2 + SpacePipe + Space + Slot2;

        /// <summary>
        /// Defines the literal '{0} | {1} | {2} | {3}'
        /// </summary>
        [RenderPattern(4, "{0} | {1} | {2} | {3}")]
        public const string PSx4 = PSx3 + SpacePipe + Space + Slot3;

        /// <summary>
        /// Defines the literal '{0} | {1} | {2} | {3} | {4}'
        /// </summary>
        [RenderPattern(5, "{0} | {1} | {2} | {3} | {4}")]
        public const string PSx5 = PSx4 + SpacePipe + Space + Slot4;

        /// <summary>
        /// Defines the literal '| {0} | {1} | {2} | {3} | {4} | {5}'
        /// </summary>
        [RenderPattern(6, "{0} | {1} | {2} | {3} | {4} | {5}")]
        public const string PSx6 = PSx5 + SpacePipe + Space + Slot5;

        /// <summary>
        /// Defines the literal '| {0} | {1} | {2} | {3} | {4} | {5} | {6}'
        /// </summary>
        [RenderPattern(7, "{0} | {1} | {2} | {3} | {4} | {5} | {6}")]
        public const string PSx7 = PSx6 + SpacePipe + Space + Slot6;
    }
}