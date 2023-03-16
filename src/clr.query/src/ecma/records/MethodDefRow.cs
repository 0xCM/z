//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.MethodDef), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct MethodDefRow : IEcmaRow<MethodDefRow>
        {
            public Address32 Rva;

            public MethodImplAttributes ImplFlags;

            public MethodAttributes Flags;

            public EcmaBlobKey Signature;

            public EcmaRowKey ParamList;
        }
    }
}