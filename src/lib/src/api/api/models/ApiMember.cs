//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes a concrete api
    /// </summary>
    public class ApiMember : IApiMember<ApiMember>
    {
        public readonly OpUri OpUri;

        public readonly MethodInfo Method;

        public readonly ApiClassKind ApiClass;

        public readonly ApiMsil Msil;

        public readonly ClrMethodArtifact Metadata;

        public ApiMember(OpUri uri, MethodInfo method, MemoryAddress address, ApiMsil msil)
        {
            OpUri =  Require.notnull(uri);
            Method = Require.notnull(method);
            ApiClass = method.ApiClass();
            Msil = Require.notnull(msil);
            Metadata = method.Artifact();
        }

        public OpIdentity Id
        {
            [MethodImpl(Inline)]
            get => OpUri.OpId;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Msil.BaseAddress;
        }

        public ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => OpUri.Host;
        }

        public EcmaSig CliSig
        {
             [MethodImpl(Inline)]
             get => Msil.CliSig;
        }

        public bool IsEmpty
        {
             [MethodImpl(Inline)]
            get => Method == null || Method == EmptyVessels.EmptyMethod;
        }

        public bool IsNonEmpty
        {
             [MethodImpl(Inline)]
            get => Method != null && Method != EmptyVessels.EmptyMethod;
        }

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => Msil.Token;
        }

        [MethodImpl(Inline)]
        public bool Equals(ApiMember src)
        {
            var result = Id.Equals(src.Id);
            result &= OpUri.Equals(src.OpUri);
            result &= Method.Equals(src.Method);
            result &= ApiClass.Equals(src.ApiClass);
            result &= BaseAddress.Equals(src.BaseAddress);
            result &= Host.Equals(src.Host);
            return result;
        }

        [MethodImpl(Inline)]
        public int CompareTo(ApiMember src)
            => BaseAddress.CompareTo(src.BaseAddress);

        public static ApiMember Empty
            => new ApiMember(OpUri.Empty, EmptyVessels.EmptyMethod, 0, ApiMsil.Empty);

        ApiMsil IApiMember.Msil
            => Msil;

        MethodInfo IApiMethod.Method
            => Method;
    }
}