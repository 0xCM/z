//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [LiteralProvider]
        public readonly struct SdmEncodingSigs
        {
            const string _ = "_";

            const string W = "W";

            const string R = "R";

            const string X = "X";

            const string B = "B";

            const string C = "C";

            const string V = "V";

            const string tick = "'";

            const string dot = ".";

            const string or = "/";

            /// <summary>
            /// (r)
            /// </summary>
            [TextMarker]
            public const string r = "(r)";

            /// <summary>
            /// (w)
            /// </summary>
            [TextMarker]
            public const string w = "(w)";

            /// <summary>
            /// ModRM:
            /// </summary>
            [TextMarker]
            public const string ModRm = "ModRM:";

            /// <summary>
            /// REX
            /// </summary>
            [TextMarker]
            public const string Rex = "REX";

            /// <summary>
            /// REX.W
            /// </summary>
            [TextMarker]
            public const string RexW = Rex + dot + W;

            /// <summary>
            /// REX.B
            /// </summary>
            [TextMarker]
            public const string RexB = Rex + dot + B;

            [TextMarker]
            public const string Vex = "VEX" + dot;

            [TextMarker]
            public const string Evex = "EVEX.";

            [TextMarker]
            public const string rw = "(r,w)";

            [TextMarker]
            public const string rm = "r/m";

            [TextMarker]
            public const string reg = "reg";

            /// <summary>
            /// ModRM:r/m (r)
            /// </summary>
            [TextMarker]
            public const string ModRm_RmR = ModRm + rm + _ + r;

            /// <summary>
            /// ModRM:r/m (w)
            /// </summary>
            [TextMarker]
            public const string ModRm_RmW = ModRm + rm + _ + w;

            /// <summary>
            /// ModRM:r/m (r,w)
            /// </summary>
            [TextMarker]
            public const string ModRm_RmRW = ModRm + rm + _ + rw;

            /// <summary>
            /// ModRM:reg (r)
            /// </summary>
            [TextMarker]
            public const string ModRm_RegR = ModRm + reg + _ + r;

            /// <summary>
            /// ModRM:reg (w)
            /// </summary>
            [TextMarker]
            public const string ModRm_RegW = ModRm + reg + _ + w;

            /// <summary>
            /// ModRM:reg (r,w)
            /// </summary>
            [TextMarker]
            public const string ModRm_RegRW = ModRm + reg  + _ + rw;

            /// <summary>
            /// ModRM:r/m (r, ModRM:[7:6] must be 11b)
            /// </summary>
            [TextMarker]
            public const string ModRm_RmR11 = ModRm + rm + _ + "(r, ModRM:[7:6] must be 11b)";

            /// <summary>
            /// ModRM:r/m (w, ModRM:[7:6] must not be 11b)
            /// </summary>
            [TextMarker]
            public const string ModRm_RmWNot11 = ModRm + rm + _ + "(w, ModRM:[7:6] must not be 11b)";

            [TextMarker]
            public const string vvvv = "vvvv";

            /// <summary>
            /// R'
            /// </summary>
            [TextMarker]
            public const string RTick = R + tick;

            /// <summary>
            /// V'
            /// </summary>
            [TextMarker]
            public const string VTick = V + tick;

            /// <summary>
            /// RC
            /// </summary>
            [TextMarker]
            public const string RC = R + C;

            /// <summary>
            /// RX
            /// </summary>
            [TextMarker]
            public const string RX = R + X;

            /// <summary>
            /// RXB
            /// </summary>
            [TextMarker]
            public const string RXB = R + X + B;

            /// <summary>
            /// WRXB
            /// </summary>
            [TextMarker]
            public const string WRXB = W + R + X + B;
        }
    }
}