//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CreditModel
    {
        /// <summary>
        /// Defines volume segmentation classes
        /// </summary>
        public enum VolumePart : byte
        {
            None = 0,

            /// <summary>
            /// Volume part A
            /// </summary>
            VA = 8,

            /// <summary>
            /// Volume part B
            /// </summary>
            VB = 16,

            /// <summary>
            /// Volume part C
            /// </summary>
            VC = 32,

            /// <summary>
            /// Volume part D
            /// </summary>
            VD = 64,

            /// <summary>
            /// Volume part E
            /// </summary>
            VE = 128,
        }
    }
}