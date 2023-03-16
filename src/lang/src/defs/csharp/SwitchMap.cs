//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CsModels
    {
        public record class SwitchMap<S,T>
            where S : unmanaged
            where T : unmanaged
        {
            public readonly Identifier Name;

            public readonly Index<S> Sources;

            public readonly Index<T> Targets;

            public SwitchMap(string name, S[] src, T[] dst)
            {
                Name = name;
                Sources = src;
                Targets = dst;
            }
        }    
    }
}