//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        public void Read(Action<MethodDebugInformation> receiver)
        {
            iter(MethodDebugInfoHandles(), handle => receiver(ReadDebugInfo(handle)));
        }

        [MethodImpl(Inline), Op]
        public System.Reflection.Metadata.CustomAttribute Read(CustomAttributeHandle src)
            => MD.GetCustomAttribute(src);

        [MethodImpl(Inline), Op]
        public MethodImplementation Read(MethodImplementationHandle src)
            => MD.GetMethodImplementation(src);

        [MethodImpl(Inline), Op]
        public MemberReference ReadMemberRef(MemberReferenceHandle src)
            => MD.GetMemberReference(src);

        [MethodImpl(Inline), Op]
        public Parameter ReadParameter(ParameterHandle src)
            => MD.GetParameter(src);

        [MethodImpl(Inline), Op]
        public TypeReference ReadTypeRef(TypeReferenceHandle src)
            => MD.GetTypeReference(src);

        [MethodImpl(Inline), Op]
        public InterfaceImplementation Read(InterfaceImplementationHandle src)
            => MD.GetInterfaceImplementation(src);
    }
}