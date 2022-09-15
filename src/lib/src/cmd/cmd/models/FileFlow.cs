//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FileFlow : DataFlow<Actor,_FileUri,_FileUri>
    {
        [MethodImpl(Inline)]
        public FileFlow(DataFlow<Actor,_FileUri,_FileUri> spec)
            : base(spec.Id, spec.Actor, spec.Source, spec.Target)
        {

        }
    }
}