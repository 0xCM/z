//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Shim
    {
        public FS.FilePath TargetPath {get;}

        public ReadOnlySeq<string> Args {get;}

        protected Shim(FS.FilePath target, ReadOnlySeq<string> args)
        {
            TargetPath = target;
            Args = args;
        }

        public virtual Task<int> Start()
        {
            return default;
        }
    }

    public abstract class Shim<T> : Shim
        where T : Shim<T>, new()
    {
        protected Shim(FS.FilePath target, ReadOnlySeq<string> args)
            : base(target,args)
        {

        }
    }
}