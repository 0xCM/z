//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        /// <summary>
        /// Defines the '`' literal
        /// </summary>
        [RenderLiteral(Tick)]
        public const string Tick = "`";

        /// <summary>
        /// Defines the '``' literal
        /// </summary>
        [RenderLiteral(Ticks)]
        public const string Ticks = "``";
    }
}