//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct ClrMethodOp
    {
        public readonly CliToken Assembly;

        public readonly CliToken Type;

        public readonly CliToken Method;

        public readonly CliToken Parameter;

        [MethodImpl(Inline)]
        public ClrMethodOp(CliToken assembly, CliToken type, CliToken method, CliToken name)
        {
            Assembly = assembly;
            Type = type;
            Parameter = name;
            Method = method;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Assembly.Hash | Type.Hash | Parameter.Hash | Method.Hash;
        }

        public override int GetHashCode()
            => Hash;
    }
}