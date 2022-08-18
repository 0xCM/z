//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiHost
    {
        Type HostType {get;}

        bool FindMethod(OpUri uri, out MethodInfo method);

        Identifier HostName
            => HostUri.HostName;

        ApiHostUri HostUri
            => HostType.ApiHostUri();

        PartId PartId
            => HostType.Assembly.Id();

        Index<MethodInfo> Methods
            => HostType.DeclaredMethods();
    }
}