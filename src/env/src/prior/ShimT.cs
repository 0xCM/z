//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Shim<T> : Shim
        where T : Shim<T>, new()
    {
        protected Shim(FilePath target, ReadOnlySeq<string> args)
            : base(target,args)
        {

        }
    }
}