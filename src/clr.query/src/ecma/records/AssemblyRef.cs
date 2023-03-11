//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.AssemblyRef), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct AssemblyRef : IEcmaRecord<AssemblyRef>
        {
            [Render(12)]
            public EcmaBlobIndex Token;

            [Render(12)]
            public EcmaStringIndex Name;

            [Render(12)]
            public AssemblyVersion Version;

            [Render(12)]
            public EcmaStringIndex Culture;

            [Render(12)]
            public EcmaBlobIndex Hash;

            [Render(1)]
            public AssemblyFlags Flags;
        }        
    }
}