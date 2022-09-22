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
        public readonly struct ProjectionKey<S,T>
        {
            public readonly SourceKey<T> Source;

            public readonly TargetKey<T> Target;

            public readonly uint Id;

            [MethodImpl(Inline)]
            public ProjectionKey(uint id, SourceKey<T> src, TargetKey<T> dst)
            {
                Id = id;
                Source = src;
                Target = dst;
            }
        }
    }
}