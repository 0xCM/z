//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a term sequence t0...tn-1
    /// </summary>
    public readonly struct Union<T> : ISeqExpr<T>, IExpr
        where T : IExpr
    {
        readonly Index<T> _Data;

        [MethodImpl(Inline)]
        public Union(Index<T> src)
        {
            _Data = src;
        }

        public uint N
        {
            [MethodImpl(Inline)]
            get => _Data.Count;
        }

        public ReadOnlySpan<T> Terms
        {
            [MethodImpl(Inline)]
            get => _Data;
        }

        public string Format()
            => text.join(" | ", _Data.Storage);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Union<T>(T[] src)
            => new Union<T>(src);
    }
}