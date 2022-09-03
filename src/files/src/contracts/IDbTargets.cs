//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IDbTargets : IRootedArchive
    {
        void Delete()
            => Root.Delete();

        void Clear()
            => Root.Clear();
    }
}