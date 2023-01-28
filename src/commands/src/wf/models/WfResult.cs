//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct WfResult
    {
        public readonly ExecToken Token;
                
        [MethodImpl(Inline)]
        public WfResult(ExecToken token)
        {
            Token = token;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Token.Hash;
        }

        public override string ToString()
            => Token.Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator WfResult(ExecToken token)
            => new WfResult(token);
    }
}