//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INameResolver : IExpr
    {
        int NameId {get;}

        string Name {get;}

        bool INullity.IsEmpty
        {
            [MethodImpl(Inline)]
            get => NameId < 0;
        }

        bool INullity.IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => NameId >= 0;
        }

        string IExpr.Format()
            => NameId >= 0 ? Name : EmptyString;
    }

    public interface INameResolver<T> : INameResolver
        where T : INameResolver<T>
    {
        T WithId(int id);
    }
}