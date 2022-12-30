//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Symbols<K> : ISymIndex<K>
        where K : unmanaged
    {
        readonly Index<Sym<K>> Data;

        readonly Dictionary<string,Sym<K>> ExprMap;

        readonly Dictionary<SymVal,Sym<K>> ValMap;

        readonly Index<K> SymKinds;

        readonly Index<SymVal> SymVals;

        readonly Dictionary<K,Sym<K>> KindMap;

        readonly Dictionary<string,Sym<K>> NameMap;

        Symbols()
        {

        }

        [MethodImpl(Inline)]
        internal Symbols(Index<Sym<K>> src, Dictionary<string,Sym<K>> exprMap, Dictionary<SymVal,Sym<K>> valMap)
        {
            Data = src;
            ExprMap = exprMap;
            ValMap = valMap;
            SymKinds = src.Select(x => x.Kind);
            SymVals = valMap.Keys.Array();
            KindMap = CreateKindMap(src);
            NameMap = CreateNameMap(src);
        }

        static Dictionary<K,Sym<K>> CreateKindMap(Index<Sym<K>> src)
        {
            var dst = dict<K,Sym<K>>();
            var count = src.Count;
            for(var i=0; i<count; i++)
                dst.TryAdd(src[i].Kind, src[i]);
            return dst;
        }

        static Dictionary<string,Sym<K>> CreateNameMap(Index<Sym<K>> src)
        {
            var dst = dict<string,Sym<K>>();
            var count = src.Count;
            for(var i=0; i<count; i++)
                dst.TryAdd(src[i].Name, src[i]);
            return dst;
        }

        public ref readonly Sym<K> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref index < Data.Length ? ref Data[index] : ref Data[0];
        }

        public ref readonly Sym<K> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref index < Data.Length ? ref Data[index] : ref Data[0];
        }

        public ref readonly Sym<K> this[K kind]
        {
            [MethodImpl(Inline)]
            get => ref bw32(kind) < Data.Length ? ref Data[bw32(kind)] : ref Data[0];
        }

        [MethodImpl(Inline)]
        public bool FindByExpr(SymExpr src, out Sym<K> dst)
            => ExprMap.TryGetValue(src.Text, out dst);

        [MethodImpl(Inline)]
        public bool FindByValue(SymVal src, out Sym<K> dst)
            => ValMap.TryGetValue(src, out dst);

        [MethodImpl(Inline)]
        public bool FindByKind(K src, out Sym<K> dst)
            => KindMap.TryGetValue(src, out dst);

        [MethodImpl(Inline)]
        public bool FindByName(string src, out Sym<K> dst)
            => NameMap.TryGetValue(src, out dst);

        [MethodImpl(Inline)]
        public ref readonly Sym<K> FindByPos(uint pos)
            => ref this[pos];

        [MethodImpl(Inline)]
        public ref readonly Sym<K> FindByPos(int pos)
            => ref this[pos];

        public bool Lookup(SymExpr src, out Sym<K> dst)
            => ExprMap.TryGetValue(src.Text, out dst);

        public bool MapValue(SymVal src, out Sym<K> dst)
            => ValMap.TryGetValue(src, out dst);

        public bool MapExpr(SymExpr src, out Sym<K> dst)
            => ExprMap.TryGetValue(src.Text, out dst);

        public bool MapKind(K src, out Sym<K> dst)
            => KindMap.TryGetValue(src, out dst);

        public bool ExprKind(SymExpr src, out K dst)
        {
            dst = default;
            var result = MapExpr(src, out var sym);
            if(result)
                dst = sym.Kind;
            return result;
        }

        /// <summary>
        /// Presents an untyped view of the source data
        /// </summary>
        [MethodImpl(Inline)]
        public SymIndex Untyped()
            => SymIndexer.untype(Data.Storage);

        public ReadOnlySpan<K> Kinds
        {
            [MethodImpl(Inline)]
            get => SymKinds;
        }

        public ReadOnlySpan<SymVal> Values
        {
            [MethodImpl(Inline)]
            get => SymVals;
        }

        public Sym<K>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref Sym<K> First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public ReadOnlySpan<Sym<K>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        [MethodImpl(Inline)]
        public static implicit operator Sym<K>[](Symbols<K> src)
            => src.Data;
    }
}