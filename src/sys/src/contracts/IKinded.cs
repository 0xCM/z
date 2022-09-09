//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IKinded : IExpr
    {
        ulong Kind {get;}

        bool INullity.IsEmpty
            => Kind == 0;
    }

    /// <summary>
    /// Characterizes a kinded thing
    /// </summary>
    /// <typeparam name="K">The classifier type</typeparam>
    [Free]
    public interface IKinded<K> : IKinded
        where K : unmanaged
    {
        new K Kind {get;}

        bool INullity.IsEmpty
            => sys.bw64(Kind) == 0;

        ulong IKinded.Kind
            => sys.bw64(Kind);

        string IExpr.Format()
            => Kind.ToString();
    }
}