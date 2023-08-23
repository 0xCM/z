//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines and index over <see cref='ApiMember'/> values
    /// </summary>
    public class ApiMembers : ReadOnlySeq<ApiMembers,ApiMember>
    {
        public readonly MemoryAddress BaseAddress;

        public ApiMembers()
        {

        }

        [MethodImpl(Inline)]
        public ApiMembers(MemoryAddress @base, Index<ApiMember> src)
        {
            BaseAddress = @base;
            Data = src;
        }

        public Methods Methods
            => Data.Select(x => x.Method).Storage;

        public ReadOnlySpan<CilMember> Msil
            => Data.Map(x => x.Msil);

        public ReadOnlySpan<ClrMethodArtifact> Artifacts
            => Data.Map(x => x.Metadata);
    }
}