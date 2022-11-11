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

        Assembly Assembly
            => HostType.Assembly;
            
        PartName PartName 
            => HostType.Assembly.PartName();

        Identifier HostName
            => HostUri.HostName;

        ApiHostUri HostUri
            => HostType.ApiHostUri();

        Index<MethodInfo> Methods
            => HostType.DeclaredMethods();
    }
}