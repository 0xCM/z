//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSizeCheck
    {
        public NativeSize Input;

        public ushort Expect;

        public ushort Actual;

        public bit Passed
        {
            [MethodImpl(Inline)]
            get => Expect == Actual;
        }

        public string Format()
        {
            const string Pattern = "{0} | Input={1,-16} | Expect={2,-16} | Actual={3,-16} | {4}";
            return string.Format(Pattern, nameof(AsmSizeCheck),
                Input, Expect, Actual, Passed ? "Pass" : "Fail");
        }

        public override string ToString()
            => Format();
    }
}