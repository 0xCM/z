//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[StructLayout(LayoutKind.Sequential, Pack=1)]
public struct AsmSizeCheck
{
    [Op]
    public static bit check(ref AsmSizeCheck src)
    {
        src.Actual = (ushort)Sized.width(src.Input);
        switch(src.Input.Code)
        {
            case NativeSizeCode.W8:
                src.Expect = (ushort)Sized.native(w8).Width;
            break;
            case NativeSizeCode.W16:
                src.Expect = (ushort)Sized.native(w16).Width;
            break;
            case NativeSizeCode.W32:
                src.Expect = (ushort)Sized.native(w32).Width;
            break;
            case NativeSizeCode.W64:
                src.Expect = (ushort)Sized.native(w64).Width;
            break;
            case NativeSizeCode.W128:
                src.Expect = (ushort)Sized.native(w128).Width;
            break;
            case NativeSizeCode.W256:
                src.Expect = (ushort)Sized.native(w256).Width;
            break;
            case NativeSizeCode.W512:
                src.Expect = (ushort)Sized.native(w512).Width;
            break;
            case NativeSizeCode.W80:
                src.Expect = (ushort)Sized.native(w80).Width;
            break;
        }
        return src.Passed;
    }

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
