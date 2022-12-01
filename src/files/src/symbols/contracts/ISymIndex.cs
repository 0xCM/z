//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISymIndex
    {
        SymIndex Untyped();

        ReadOnlySpan<SymVal> Values {get;}

        uint Count {get;}

        bool Lookup(SymExpr src, out Sym dst);

        bool Parse(SymExpr src, out object dst)
        {
            if(Lookup(src, out var sym))
            {
                dst = sym.FieldValue;
                return true;
            }
            else
            {
                dst = 0ul;
                return false;
            }
        }
    }
    
    public interface ISymIndex<K> : ISymIndex
        where K : unmanaged
    {
        ReadOnlySpan<K> Kinds {get;}

        ReadOnlySpan<Sym<K>> View {get;}

        bool Lookup(SymExpr src, out Sym<K> dst);

        bool ISymIndex.Lookup(SymExpr src, out Sym dst)
        {
            if(Lookup(src, out Sym<K> _dst))
            {
                dst = _dst;
                return true;
            }
            dst = default;
            return false;
        }

        ref readonly Sym<K> this[uint index] {get;}

        ref readonly Sym<K> this[K index] {get;}
    }
}