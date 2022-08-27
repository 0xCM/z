//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IIdentifiedType : IIdentification
    {
        IdentityTargetKind IIdentification.TargetKind
            => IdentityTargetKind.Type;
    }

   [Free]
   public interface IIdentifiedType<T> : IIdentifiedType, IIdentification<T>
        where T : IIdentifiedType<T>, new()
    {
        Func<string,T> Factory  => s => new T();
    }
}