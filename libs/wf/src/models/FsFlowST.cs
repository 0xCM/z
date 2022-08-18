//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class FsFlow<S,T> : IFlow<S,T>
        where S : IFsEntry
        where T : IFsEntry
    {
        public readonly S Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public FsFlow(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        S IArrow<S,T>.Source 
            => Source;

        T IArrow<S,T>.Target 
            => Target;        
    }
}