//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [RenderPattern(2, Attrib)]
        public const string Attrib = "{0}:{1}";

        [RenderPattern(4, Attrib2)]
        public const string Attrib2 ="{0}:{1} | {2}:{3}";

        [RenderPattern(6, Attrib3)]
        public const string Attrib3 ="{0}:{1} | {2}:{3} | {4}:{5}";

        [RenderPattern(8, Attrib4)]
        public const string Attrib4 ="{0}:{1} | {2}:{3} | {4}:{5} | {6}:{7}";

        [RenderPattern(10, Attrib5)]
        public const string Attrib5 ="{0}:{1} | {2}:{3} | {4}:{5} | {6}:{7} | {8}:{9}";

        [RenderPattern(12, Attrib6)]
        public const string Attrib6 ="{0}:{1} | {2}:{3} | {4}:{5} | {6}:{7} | {8}:{9} | {10}:{11}";
    }
}