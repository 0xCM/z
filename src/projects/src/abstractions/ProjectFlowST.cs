//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectModels
    {
        public abstract record class ProjectFlow<S,T> : IProjectFlow<S,T>
            where S : IProjectFile, new()
            where T : IProjectTarget,new()
        {
            public readonly S Source;

            public readonly T Target;

            S IArrow<S, T>.Source 
                => Source;

            T IArrow<S, T>.Target 
                => Target;
        }
    }
}