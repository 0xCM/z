//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Relations
    {
        /// <summary>
        /// Identifies a projection
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ProjectionKey
        {
            public readonly SourceKey Source;

            public readonly TargetKey Target;

            public readonly uint Id;

            [MethodImpl(Inline)]
            public ProjectionKey(uint id, SourceKey src, TargetKey dst)
            {
                Id = id;
                Source = src;
                Target = dst;
            }
        }
    }
}