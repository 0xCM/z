//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using VP = CreditModel.VolumePart;

    partial class CreditModel
    {
        /// <summary>
        /// Defines volume reference component values
        /// </summary>
        [Flags]
        public enum Volume : byte
        {
            None = 0,

            /// <summary>
            /// Volume 1
            /// </summary>
            V1 = 1,

            /// <summary>
            /// Volume 2
            /// </summary>
            V2 = 2,

            /// <summary>
            /// Volume 3
            /// </summary>
            V3 = 3,

            /// <summary>
            /// Volume 4
            /// </summary>
            V4 = 4,

            /// <summary>
            /// Volume 5
            /// </summary>
            V5 = 5,

            /// <summary>
            /// Volume 6
            /// </summary>
            V6 = 6,

            /// <summary>
            /// Volume 7
            /// </summary>
            V7 = 7,

            /// <summary>
            /// Volume 1
            /// </summary>
            Vol1 = V1,

            /// <summary>
            /// Volume 2A
            /// </summary>
            Vol2A = V2 | VPA,

            /// <summary>
            /// Volume 2B
            /// </summary>
            Vol2B = V2 | VPB,

            /// <summary>
            /// Volume 2C
            /// </summary>
            Vol2C = V2 | VPC,

            /// <summary>
            /// Volume 2D
            /// </summary>
            Vol2D = V2 | VPD,

            /// <summary>
            /// Volume 3A
            /// </summary>
            Vol3A = V3 | VPA,

            /// <summary>
            /// Volume 3B
            /// </summary>
            Vol3B = V3 | VPB,

            /// <summary>
            /// Volume 3C
            /// </summary>
            Vol3C = V3 | VPC,

            /// <summary>
            /// Volume 4
            /// </summary>
            Vol4 = V4,

            /// <summary>
            /// Volume Part A
            /// </summary>
            VPA = VP.VA,

            /// <summary>
            /// Volume Part B
            /// </summary>
            VPB = VP.VC,

            /// <summary>
            /// Volume Part C
            /// </summary>
            VPC = VP.VC,

            /// <summary>
            /// Volume Part D
            /// </summary>
            VPD = VP.VD,

            /// <summary>
            /// Volume Part E
            /// </summary>
            VPE = VP.VE,
        }
    }
}