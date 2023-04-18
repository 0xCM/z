//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvResolvers
    {
        object locker = new();

        IncludeResolver _IncludeResolver;

        IncludeResolver IncludeResolver
        {
            get
            {
                lock(locker)
                {
                    if(_IncludeResolver == null)
                        _IncludeResolver = new(Env.INCLUDE());
                }
                return _IncludeResolver;
            }
        }

        internal EnvResolvers()
        {

        }

        public ReadOnlySeq<FilePath> Includes()
            => IncludeResolver.Resolutions();

        public bool ResolveInclude(RelativeFilePath src, out FilePath dst)
            => IncludeResolver.Resolve(src, out dst);
    }
}