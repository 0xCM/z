//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures paired evaluations
    /// </summary>
    /// <typeparam name="T">The evaluation result type</typeparam>
    public readonly struct PairEvalResults<T>
        where T : unmanaged
    {
        readonly Pair<string> Labels;

        readonly Pairs<T> Target;

        [MethodImpl(Inline)]
        public PairEvalResults(Pair<string> labels, in Pairs<T> dst)
        {
            Labels = labels;
            Target = dst;
        }

        [MethodImpl(Inline)]
        public ref Pair<T> Pair(int index)
            => ref Target[index];

        public ref Pair<T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Pair(index);
        }

        public ref Pair<T> First
        {
            [MethodImpl(Inline)]
            get => ref Target.First;
        }

        public uint PointCount
        {
            [MethodImpl(Inline)]
            get => Target.PointCount;
        }

        public string LeftLabel
        {
            [MethodImpl(Inline)]
            get => Labels.Left;
        }

        public string RightLabel
        {
            [MethodImpl(Inline)]
            get => Labels.Right;
        }
    }
}