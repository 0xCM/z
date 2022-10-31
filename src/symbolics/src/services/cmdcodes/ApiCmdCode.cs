//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Identifies an api command
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct ApiCmdCode
    {
        public readonly asci32 Domain;

        public readonly asci32 Name;

        public readonly ulong Data;

        [MethodImpl(Inline)]
        public ApiCmdCode(asci32 domain, asci32 name, ulong data)
        {
            Domain = domain;
            Data = data;
            Name = name;
        }

        public ApiCmdId CmdId
        {
            [MethodImpl(Inline)]
            get => @as<ulong,ApiCmdId>(Data);
        }

        public ReadOnlySpan<byte> Serialize()
            => sys.bytes(this);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}