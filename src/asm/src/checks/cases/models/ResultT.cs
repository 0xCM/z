//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial class AsmCases
{
    public readonly struct Result<T>
    {
        public readonly T Case;

        public readonly Outcome Outcome;

        [MethodImpl(Inline)]
        public Result(T @case, Outcome outcome)
        {
            Case = @case;
            Outcome = outcome;
        }

        public string Format()
            => string.Format("{0} {1}", Outcome ? "Success:" :"Failure:", Case);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Result<T>((T @case, Outcome outcome) src)
            => new Result<T>(src.@case,src.outcome);
    }
}
