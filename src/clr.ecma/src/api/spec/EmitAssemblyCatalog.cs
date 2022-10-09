//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(Name)]
    public record class EmitAssemblyCatalog : ICmd<EmitAssemblyCatalog>
    {
        const string Name = "emit-assembly-catalog";

        public FolderPath Source;

        public FolderPath Target;
    }
}