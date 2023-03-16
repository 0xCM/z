//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.AssemblyRef), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct AssemblyRefRow : IEcmaRow<AssemblyRefRow>
        {
            [Render(12)]
            public EcmaBlobKey Token;

            [Render(12)]
            public EcmaStringKey Name;

            [Render(12)]
            public AssemblyVersion Version;

            [Render(12)]
            public EcmaStringKey Culture;

            [Render(12)]
            public EcmaBlobKey Hash;

            [Render(1)]
            public AssemblyFlags Flags;
        }        
    }
}