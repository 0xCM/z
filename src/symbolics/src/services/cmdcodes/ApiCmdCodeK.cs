//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using api = ApiCmdCodes;

    /// <summary>
    /// Identifies and classifies an api command
    /// </summary>
    public readonly struct ApiCmdCode<K>
        where K : unmanaged
    {
        public readonly asci32 Domain;

        public readonly asci32 Name;

        public readonly K Data;

        [MethodImpl(Inline)]
        public ApiCmdCode(asci32 domain, asci32 name, K data)
        {
            Domain = domain;
            Name = name;
            Data = data;
        }

        public ApiCmdId CmdId
        {
            [MethodImpl(Inline)]
            get => @as<K,ApiCmdId>(Data);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ApiCmdCode(ApiCmdCode<K> src)
            => api.untype(src);
    }
}