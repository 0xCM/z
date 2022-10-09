//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed record class ExecResult
    {
        public readonly ExecToken Token;

        public readonly Outcome Outcome;

        public ExecResult()
        {
            Token = ExecToken.Empty;
            Outcome = Outcome.Empty;
        }
        public ExecResult(ExecToken token, Outcome outcome)
        {
            Token = token;
            Outcome = outcome;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Token.IsNonEmpty;
        }

        public string Format()
            => $"{Token} | {Outcome}";

        public override string ToString()
            => Format();

        public static ExecToken Empty => new();
    }
}