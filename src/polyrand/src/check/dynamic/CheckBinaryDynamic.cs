//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static BufferSeqId;

    using K = BinaryOperatorClass;
    using Test = TestFixedBinaryOp;

    [ApiHost]
    public class CheckBinaryDynamic : ApiValidator<CheckBinaryDynamic>
    {
        IDynexus Dynamic;

        public override void Validate()
        {
            Dynamic = CheckDynamic.Checker.Dynamic;
        }

        [Op]
        public TestCaseRecord Match(K k, NativeTypeWidth w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            switch(w)
            {
                case NativeTypeWidth.W8:
                    return Match(k, w8, a, b, dst);

                case NativeTypeWidth.W16:
                    return Match(k, w16, a, b, dst);

                case NativeTypeWidth.W32:
                    return Match(k, w32, a, b, dst);

                case NativeTypeWidth.W64:
                    return Match(k, w64, a, b, dst);

                case NativeTypeWidth.W128:
                    return Match(k, w128, a, b, dst);

                case NativeTypeWidth.W256:
                    return Match(k, w256, a, b, dst);
            }

            throw Unsupported.define(w.GetType());
        }

        [Op]
        public TestCaseRecord Match(K k, W8 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Source).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W16 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Source).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W32 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Source).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W64 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Source).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k,  W128 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Source).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W256 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Source).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }
    }

    [ApiHost]
    readonly struct TestBinaryDynamic : ITestBinaryDynamic
    {
        readonly IDynexus Dynamic;

        readonly CheckBinaryDynamic Validator;

        public IPolyrand Random {get;}

        [MethodImpl(Inline), Op]
        internal static TestBinaryDynamic create(ICheckBinaryCellOp matcher)
            => new TestBinaryDynamic(matcher);

        [MethodImpl(Inline), Op]
        internal static TestBinaryDynamic create(IWfRuntime runtime)
            => new TestBinaryDynamic(runtime);

        internal TestBinaryDynamic(IWfRuntime runtime)
        {
            Dynamic = CheckDynamic.Checker.Dynamic;
            Validator = CheckBinaryDynamic.create(runtime);
            Random = Rng.@default();
        }

        internal TestBinaryDynamic(ICheckBinaryCellOp matcher)
        {
            Dynamic = CheckDynamic.Checker.Dynamic;
            Random = matcher.Random;
            Validator = default;
        }

        [Op]
        public TestCaseRecord Match(K k, NativeTypeWidth w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            switch(w)
            {
                case NativeTypeWidth.W8:
                    return Match(k, w8, a, b, dst);

                case NativeTypeWidth.W16:
                    return Match(k, w16, a, b, dst);

                case NativeTypeWidth.W32:
                    return Match(k, w32, a, b, dst);

                case NativeTypeWidth.W64:
                    return Match(k, w64, a, b, dst);

                case NativeTypeWidth.W128:
                    return Match(k, w128, a, b, dst);

                case NativeTypeWidth.W256:
                    return Match(k, w256, a, b, dst);
            }

            throw Unsupported.define(w.GetType());
        }

        [Op]
        public TestCaseRecord Match(K k, W8 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Random).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W16 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Random).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W32 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Random).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W64 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Random).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k,  W128 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Random).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }

        [Op]
        public TestCaseRecord Match(K k, W256 w, ApiCodeBlock a, ApiCodeBlock b, BufferTokens dst)
        {
            var f = Dynamic.EmitFixedBinary(dst[Left], w, a);
            var g = Dynamic.EmitFixedBinary(dst[Right], w, b);
            return Test.Check(Random).Match(f, a.Id.WithAsm(), g, b.Id.WithAsm());
        }
    }
}