//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Defines the canonical setting format
        /// </summary>
        [RenderPattern(2, Setting)]
        public const string Setting = "{0}:{1}";

        [RenderPattern(4, Settings2)]
        public const string Settings2 ="{0}:{1} | {2}:{3}";

        [RenderPattern(6, Settings3)]
        public const string Settings3 ="{0}:{1} | {2}:{3} | {4}:{5}";

        [RenderPattern(8, Settings4)]
        public const string Settings4 ="{0}:{1} | {2}:{3} | {4}:{5} | {6}:{7}";
    }
}