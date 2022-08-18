//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        /// <summary>
        /// Defines the render pattern for a 1-element vector
        /// </summary>
        public const string V1 = "<{0}>";

        /// <summary>
        /// Defines the render pattern for a 2-element vector
        /// </summary>
        public const string V2 = "<{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 3-element vector
        /// </summary>
        public const string V3 = "<{2},{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 4-element vector
        /// </summary>
        public const string V4 = "<{3},{2},{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 5-element vector
        /// </summary>
        public const string V5 = "<{4},{3},{2},{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 6-element vector
        /// </summary>
        public const string V6 = "<{5},{4},{3},{2},{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 7-element vector
        /// </summary>
        public const string V7 = "<{6},{5},{4},{3},{2},{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 8-element vector
        /// </summary>
        public const string V8 = "<{7},{6},{5},{4},{3},{2},{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 9-element vector
        /// </summary>
        public const string V9 = "<{8},{7},{6},{5},{4},{3},{2},{1},{0}>";

        /// <summary>
        /// Defines the render pattern for a 16-element vector
        /// </summary>
        public const string V16 =
        "<"
        + "{15},{14},{13},{12},{11},{10},"
        + "{9},{8},{7},{6},{5},{4},{3},{2},{1},{0}"
        + ">"
        ;

        /// <summary>
        /// Defines the render pattern for a 32-element vector
        /// </summary>
        public const string V32 =
        "<"
        + "{31},{30}"
        + "{29},{28},{27},{26},{25},{24},{23},{22},{21}{20},"
        + "{19},{18},{17},{16},{15},{14},{13},{12},{11},{10},"
        + "{9},{8},{7},{6},{5},{4},{3},{2},{1},{0}"
        + ">"
        ;

        /// <summary>
        /// Defines the render pattern for a 64-element vector
        /// </summary>
        public const string V64 =
        "<"
        + "{63},{62},{61}{60},"
        + "{59},{58},{57},{56},{55},{54},{53},{52},{51},{50}"
        + "{49},{48},{47},{46},{45},{44},{43},{42},{41},{40}"
        + "{39},{38},{37},{36},{35},{34},{33},{32},{31},{30}"
        + "{29},{28},{27},{26},{25},{24},{23},{22},{21}{20},"
        + "{19},{18},{17},{16},{15},{14},{13},{12},{11},{10},"
        + "{9},{8},{7},{6},{5},{4},{3},{2},{1},{0}"
        + ">"
        ;
    }
}