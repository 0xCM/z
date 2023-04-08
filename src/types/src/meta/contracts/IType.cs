//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IType : INullity, IExpr
    {
        Identifier Name {get;}

        ulong Kind => 0;

        bool INullity.IsEmpty 
            => Name.IsEmpty;

        bool INullity.IsNonEmpty 
            => !IsEmpty;

        string IExpr.Format()
            => Name;
    }

    [Free]
    public interface IType<K> : IType
        where K : unmanaged
    {
        new K Kind {get;}

        ulong IType.Kind
            => Sized.bw64(Kind);
    }

    public interface ISizedType : IType
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}

        bool INullity.IsEmpty
            => StorageWidth == 0;

        bool INullity.IsNonEmpty
            => StorageWidth != 0;
    }

    [Free]
    public interface ISizedType<K> : ISizedType, IType<K>
        where K : unmanaged
    {

    }

    [Free]
    public interface ITyped
    {
        IType Type {get;}
    }

    [Free]
    public interface ITyped<T> : ITyped
        where T : IType, new()
    {
        new T Type => new();

        IType ITyped.Type 
            => Type;
    }    
}