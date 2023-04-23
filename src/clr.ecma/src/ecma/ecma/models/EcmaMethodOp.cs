//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct EcmaMethodOp
    {
        public readonly EcmaToken Assembly;

        public readonly EcmaToken Type;

        public readonly EcmaToken Method;

        public readonly EcmaToken Parameter;

        [MethodImpl(Inline)]
        public EcmaMethodOp(EcmaToken assembly, EcmaToken type, EcmaToken method, EcmaToken name)
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