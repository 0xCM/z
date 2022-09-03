//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;

    using static BufferSeqId;

    public interface ICaptureChecks : IContextual<IAsmContextDepr>, IBufferedChecker, ITestDynamic, ICheckDynamicVectors
    {
        IPolyrand IPolyrandProvider.Random
            => Context.Random;

        AsmDecoder Decoder
            => Context.Decoder;

        AsmFormatConfig FormatConfig
            => Context.FormatConfig;

        void WriteAsm(ApiCaptureBlock capture, StreamWriter dst)
        {
            dst.Write(AsmFormatter.format(Decoder.Decode(capture).Require(), FormatConfig));
        }

        void WriteAsm(ApiCaptureBlock[] src, StreamWriter dst)
        {
            for(var i=0; i<src.Length; i++)
                WriteAsm(src[i], dst);
        }

        void WriteAsm(ReadOnlySpan<ApiCaptureBlock> src, StreamWriter dst)
        {
            for(var i=0; i<src.Length; i++)
                WriteAsm(src[i], dst);
        }

        void WriteAsm(AsmRoutine f, StreamWriter dst)
            => dst.WriteLine(AsmFormatter.format(f,FormatConfig));

        // Option<AsmRoutine> CaptureAsm<D>(DynamicDelegate<D> src)
        //     where D : Delegate
        //         => from capture in Capture.Capture(CaptureExchange.Context, src.Id, src)
        //         from asm in Decoder.Decode(capture)
        //         select asm;

        TestCaseRecord TestMatch<T>(BinaryOp<T> f, ApiCodeBlock src)
            where T : unmanaged
        {
            var g = Dynamic.EmitBinaryOp<T>(this[Main],src);
            void check()
            {
                for(var i=0; i<RepCount; i++)
                {
                    (var x, var y) = Random.ConstPair<T>();
                    eq(f(x,y),g(x,y));
                }
            }

            return TestAction(check, src.Id);
        }

        // TestCaseRecord TestImmInjection<T>(W128 w, BinaryOperatorClass k, MethodInfo src, byte imm)
        //     where T : unmanaged
        // {
        //     void check()
        //     {
        //         var injector = Dynamic.BinaryInjector<T>(w);
        //         var f = injector.EmbedImmediate(src, imm);
        //         var fAsm = CaptureAsm(f).Require();
        //         var g = Dynamic.EmitFixedBinary(this[Main], w, fAsm.Code);

        //         var x = Random.CpuVector<T>(w);
        //         var y = Random.CpuVector<T>(w);

        //         var v1 = f.Operation.Invoke(x,y);
        //         var v2 = g(x.ToCell(),y.ToCell()).ToVector<T>();

        //         eq(v1,v2);
        //     }

        //     return TestAction(check, name<T>(src.Name));
        // }

        // TestCaseRecord TestImmInjection<T>(W256 w, BinaryOperatorClass k, MethodInfo src, byte imm)
        //     where T : unmanaged
        // {
        //     void check()
        //     {
        //         var injector = Dynamic.BinaryInjector<T>(w);
        //         var f = injector.EmbedImmediate(src, imm);
        //         var fAsm = CaptureAsm(f).Require();
        //         var g = Dynamic.EmitFixedBinary(this[Main], w, fAsm.Code);

        //         var x = Random.CpuVector<T>(w);
        //         var y = Random.CpuVector<T>(w);

        //         var v1 = f.Operation.Invoke(x,y);
        //         var v2 = g(x.ToCell(),y.ToCell()).ToVector<T>();

        //         eq(v1,v2);
        //     }

        //     return TestAction(check, name<T>(src.Name));
        // }

        // TestCaseRecord TestBinaryImm<T>(W128 w, MethodInfo method, byte imm)
        //     where T : unmanaged
        // {
        //     void check()
        //     {
        //         var injector = Dynamic.BinaryInjector<T>(w);
        //         var f = injector.EmbedImmediate(method,imm);

        //         var x = Random.CpuVector<T>(w);
        //         var y = Random.CpuVector<T>(w);

        //         var v1 = f.Operation.Invoke(x,y);
        //         var captured = CaptureService.Capture(CaptureExchange.Context, f.Id, f.Operation).Require();
        //         var asm = Decoder.Decode(captured).Require();
        //         var g = Dynamic.EmitFixedBinary<Cell128>(this[Main], asm.Code);
        //         var v2 = g(x.ToCell(),y.ToCell()).ToVector<T>();
        //         gcpu.veq(v1,v2);
        //     }
        //     return TestAction(check, name<T>(method.Name));
        // }

        // TestCaseRecord TestUnaryImm<T>(W256 w, MethodInfo method, byte imm)
        //     where T : unmanaged
        // {

        //     void check()
        //     {
        //         var k = OperatorClasses.unary();
        //         var injector = Dynamic.UnaryInjector<T>(w);
        //         var dynop = injector.EmbedImmediate(method,imm);

        //         var x = Random.CpuVector<T>(w);
        //         var v1 = dynop.Operation.Invoke(x);

        //         var capture = CaptureService.Capture(CaptureExchange.Context, dynop.Id, dynop).Require();
        //         var asm = Decoder.Decode(capture).Require();

        //         var f = Dynamic.EmitFixedUnary<Cell256>(this[Main], capture.CodeBlock);
        //         var v2 = f(x.ToCell()).ToVector<T>();
        //         gcpu.veq(v1,v2);
        //     }

        //     return TestAction(check, name<T>(method.Name));
        // }
    }
}