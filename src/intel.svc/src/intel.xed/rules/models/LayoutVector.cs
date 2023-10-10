//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct LayoutVector
    {
        readonly SegRef<LayoutComponent> Components;

        [MethodImpl(Inline)]
        public LayoutVector(SegRef<LayoutComponent> src)
        {
            Components = src;
        }
    }

    public class LayoutVectors : IDisposable
    {
        readonly NativeCells<LayoutComponent> Components;

        readonly Index<LayoutVector> Vectors;

        public LayoutVectors(NativeCells<LayoutComponent> components, Index<LayoutVector> vectors)
        {
            Components = components;
            Vectors = vectors;
        }

        public void Dispose()
        {
            Components.Dispose();
        }
    }
}
