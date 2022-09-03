//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Roslyn
{
    public interface ICaSymbolArtifact<R,S>
        where R : IRuntimeObject
        where S : ICaSymbol
    {
        R Artifact {get;}

        S Symbol {get;}
    }
}