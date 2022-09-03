//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines floating-point operations
    /// </summary>
    [ApiHost]
    public partial class fmath
    {
        internal const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        [ApiHost("fmath.refops")]
        public readonly partial struct RefOps
        {

        }

        [ApiHost("fmath.stageops")]
        public readonly partial struct StageOps
        {

        }

    }
}