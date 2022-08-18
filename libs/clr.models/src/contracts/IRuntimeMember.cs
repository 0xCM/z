//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRuntimeMember : IRuntimeObject
    {
        MemberInfo Definition {get;}

        string IClrArtifact.Name
            => Definition.Name;

        CliToken IClrArtifact.Token
            => Definition.MetadataToken;
    }

    [Free]
    public interface IRuntimeMember<D> : IRuntimeMember, IRuntimeObject<D>
        where D : MemberInfo
    {
        MemberInfo IRuntimeMember.Definition
            => (this as IRuntimeObject<D>).Definition;
    }

    [Free]
    public interface IRuntimeMember<H,D> : IRuntimeMember<D>, IRuntimeObject<H,D>
        where D : MemberInfo
        where H : struct, IRuntimeMember<H,D>
    {

    }
}