//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonType : INamed<@string>
    {
        bool Concrete {get;}

        ReadOnlySeq<IJsonParameter> Parameters 
            => sys.empty<IJsonParameter>();
    }

    public interface IJsonType<T> : IJsonType, IDataType<T>
        where T : IJsonType<T>, new()
    {
    }
}
