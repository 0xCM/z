//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public struct SymCounts<K>
        where K : unmanaged
    {
        readonly Symbols<K> Syms;

        readonly Index<int> Counts;

        public SymCounts(Symbols<K> symbols)
        {
            Syms = symbols;
            Counts = alloc<int>(Syms.Count);
        }

        uint Seq(K kind)
        {
            Syms.MapKind(kind, out var sym);
            return sym.Key.Value;
        }

        [MethodImpl(Inline)]
        public void Inc(K kind)
            => ++Counts[Seq(kind)];

        [MethodImpl(Inline)]
        public void Dec(K kind)
            => --Counts[Seq(kind)];

        [MethodImpl(Inline)]
        public ref readonly int Count(K kind)
            => ref Counts[Seq(kind)];

        [MethodImpl(Inline)]
        public uint Total()
            => (uint)Counts.Storage.Sum();

        public string Format()
        {
            var dst = text.buffer();
            var count = Syms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(Syms.Kinds,i);
                Syms.MapKind(kind, out var sym);
                dst.AppendLineFormat("{0,-16} | {1}", sym.Expr, Count(kind));
            }
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}