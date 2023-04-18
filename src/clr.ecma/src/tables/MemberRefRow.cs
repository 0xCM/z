//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.MemberRef), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct MemberRefRow : IEcmaRow<MemberRefRow>
        {
            /// <summary>
            /// The row identifier
            /// </summary>
            [Render(12)]
            public EcmaToken Index;

            /// <summary>
            /// An index into the MethodDef, ModuleRef,TypeDef, TypeRef, or TypeSpec tables
            /// </summary>
            /// <remarks>
            /// * A TypeRef token, if the class that defines the member is defined in another module. (Note that it is unusual, but valid, to use a TypeRef token when the member is defined in this same module, in which case, its TypeDef token can be used instead.)
            /// * A ModuleRef token, if the member is defined, in another module of the same assembly, as a global function or variable
            /// * A MethodDef token, when used to supply a call-site signature for a vararg method that is defined in this module. The Name shall match the Name in the corresponding MethodDef row. The Signature shall match the Signature in the target method definition
            /// * A TypeSpec token, if the member is a member of a generic type
            /// </remarks>
            [Render(12)]
            public EcmaToken Class;

            [Render(48)]
            public EcmaStringKey Name;

            [Render(12)]
            public MemberReferenceKind RefKind;

            [Render(1)]
            public EcmaBlobKey Sig;
        }
    }
}