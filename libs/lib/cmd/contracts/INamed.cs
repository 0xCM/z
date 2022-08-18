//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes something with a name
    /// </summary>
    public interface INamed : IDataString
    {
        Name Name {get;}

        string IExpr.Format()
            => Name.Format();

    }

    [Free]
    public interface INamed<T> : INamed, IDataString<T>
        where T : IExpr, IDataType
    {
        new T Name {get;}

        Name INamed.Name
            => new Name(Name.Format());
    }
}