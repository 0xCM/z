//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = BinaryOperatorClass;
    using Test = TestBinaryDynamic;

    public interface ITestBinaryDynamic : ITestOperatorMatch, ICheckDynamic
    {
        TestCaseRecord Match(K k, NativeTypeWidth w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
            => Test.create((ICheckBinaryCellOp)this).Match(k,w,a,b,dst);

        TestCaseRecord Match(K k, W8 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
            => Test.create((ICheckBinaryCellOp)this).Match(k,w,a,b,dst);

        TestCaseRecord Match(K k, W16 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
            => Test.create((ICheckBinaryCellOp)this).Match(k,w,a,b,dst);

        TestCaseRecord Match(K k, W32 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
            => Test.create((ICheckBinaryCellOp)this).Match(k,w,a,b,dst);

        TestCaseRecord Match(K k, W64 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
            => Test.create((ICheckBinaryCellOp)this).Match(k,w,a,b,dst);

        TestCaseRecord Match(K k,  W128 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
            => Test.create((ICheckBinaryCellOp)this).Match(k,w,a,b,dst);

        TestCaseRecord Match(K k, W256 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
            => Test.create((ICheckBinaryCellOp)this).Match(k,w,a,b,dst);
    }
}