//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IApiClass : IExpr
    {
        ApiClassKind ClassId {get;}

        string IExpr.Format()
            => ClassId.ToString().ToLower();

        bool INullity.IsEmpty
            => ClassId == 0;

        bool INullity.IsNonEmpty
            => ClassId != 0;
    }
    public interface IApiClass<K> : IApiClass
        where K : unmanaged
    {
        K Kind  {get;}

        ApiClassKind IApiClass.ClassId
            => @as<K,ApiClassKind>(Kind);
    }
}