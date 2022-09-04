//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static core;

    public class ImmSpecializer : AppService<ImmSpecializer>
    {
        AsmDecoder Decoder;

        ICaptureCore Core;

        IDynexus Dynamic;

        public ImmSpecializer()
        {

        }

        protected override void OnInit()
        {
            Decoder = Wf.AsmDecoder();
            Core = Wf.CaptureCore();
            Dynamic = Dynops.Dynexus;
        }

        public Option<AsmRoutine> UnaryOp(in CaptureExchange exchange, MethodInfo src, _OpIdentity id, byte imm8)
        {
            var width = VK.width(src.ReturnType);
            var f = Dynamic.CreateUnaryOp(width, src, imm8).OnNone(() => OnEmbeddingFailure(src));
            if(f)
              return
                    from c in Core.Capture(exchange, f.Value.Id, f.Value)
                    from d in Decoder.Decode(c)
                    select d;
            else
                return Option.none<AsmRoutine>();
        }

        public AsmRoutine[] UnaryOps(in CaptureExchange exchange, MethodInfo src, _OpIdentity id, params Imm8R[] imm8r)
        {
            var count = imm8r.Length;
            var buffer = alloc<AsmRoutine>(count);
            ref readonly var imm = ref first(imm8r);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst, i) = UnaryOp(exchange,src, id, skip(imm,i)).OnNone(() => OnCaptureFailed(id)).ValueOrDefault(AsmRoutine.Empty);
            return buffer;
        }

        public Option<AsmRoutine> BinaryOp(in CaptureExchange exchange, MethodInfo src, _OpIdentity id, byte imm8)
        {
            var width = VK.width(src.ReturnType);
            var f = Dynamic.CreateBinaryOp(width,src, imm8).OnNone(() => OnEmbeddingFailure(src));
            if(f)
              return
                    from c in Core.Capture(exchange, f.Value.Id, f.Value)
                    from d in Decoder.Decode(c)
                    select d;
            else
                return Option.none<AsmRoutine>();
        }

        public AsmRoutine[] BinaryOps(in CaptureExchange exchange, MethodInfo src, _OpIdentity id, params Imm8R[] imm8r)
        {
            var count = imm8r.Length;
            var buffer = alloc<AsmRoutine>(count);
            ref var dst = ref first(buffer);
            ref readonly var imm = ref first(imm8r);
            for(var i=0; i<count; i++)
                seek(dst, i) = BinaryOp(exchange, src, id, skip(imm,i)).OnNone(() => OnCaptureFailed(id)).ValueOrDefault(AsmRoutine.Empty);
            return buffer;
        }

        // public Option<AsmRoutine> Single<T>(in CaptureExchange exchange, IImm8UnaryResolver128<T> resolver, OpIdentity id, byte imm8)
        //     where T : unmanaged
        //         => from c in Core.Capture(exchange, resolver.Id.WithImm8(imm8), resolver.@delegate(imm8))
        //            from d in Decoder.Decode(c)
        //            select d;

        // public Option<AsmRoutine> Single<T>(in CaptureExchange exchange, IImm8UnaryResolver256<T> resolver, OpIdentity id, byte imm8)
        //     where T : unmanaged
        //         => from c in Core.Capture(exchange, resolver.Id.WithImm8(imm8), resolver.@delegate(imm8))
        //            from d in Decoder.Decode(c)
        //            select d;

        // public Option<AsmRoutine> Single<T>(in CaptureExchange exchange, IImm8BinaryResolver128<T> resolver, OpIdentity id, byte imm8)
        //     where T : unmanaged
        //         => from c in Core.Capture(exchange, resolver.Id.WithImm8(imm8), resolver.@delegate(imm8))
        //            from d in Decoder.Decode(c)
        //            select d;

        // public Option<AsmRoutine> Single<T>(in CaptureExchange exchange, IImm8BinaryResolver256<T> resolver, OpIdentity id, byte imm8)
        //     where T : unmanaged
        //         => from c in Core.Capture(exchange, resolver.Id.WithImm8(imm8), resolver.@delegate(imm8))
        //            from d in Decoder.Decode(c)
        //            select d;

        // public AsmRoutine[] Many<T>(in CaptureExchange exchange, IImm8UnaryResolver128<T> resolver, OpIdentity id, params byte[] imm8)
        //     where T : unmanaged
        // {
        //     var count = imm8.Length;
        //     var buffer = alloc<AsmRoutine>(count);
        //     ref var dst = ref first(buffer);
        //     ref readonly var imm = ref first(imm8);
        //     for(var i=0; i<count; i++)
        //         seek(dst, i) = Single(exchange, resolver, id, skip(imm,i)).ValueOrDefault(AsmRoutine.Empty);
        //     return buffer;
        // }

        // public AsmRoutine[] Many<T>(in CaptureExchange exchange, IImm8UnaryResolver256<T> resolver, OpIdentity id, params byte[] imm8)
        //     where T : unmanaged
        // {
        //     var count = imm8.Length;
        //     var buffer = alloc<AsmRoutine>(count);
        //     ref var dst = ref first(buffer);
        //     ref readonly var imm = ref first(imm8);
        //     for(var i=0; i<count; i++)
        //         seek(dst, i) = Single(exchange, resolver, id, skip(imm,i)).ValueOrDefault(AsmRoutine.Empty);
        //     return buffer;
        // }

        // public AsmRoutine[] Many<T>(in CaptureExchange exchange, IImm8BinaryResolver128<T> resolver, OpIdentity id, params byte[] imm8)
        //     where T : unmanaged
        // {
        //     var count = imm8.Length;
        //     var buffer = alloc<AsmRoutine>(count);
        //     ref var dst = ref first(buffer);
        //     ref readonly var imm = ref first(imm8);
        //     for(var i=0; i<count; i++)
        //         seek(dst, i) = Single(exchange, resolver, id, skip(imm,i)).ValueOrDefault(AsmRoutine.Empty);
        //     return buffer;
        // }

        // // public AsmRoutine[] Many<T>(in CaptureExchange exchange, IImm8BinaryResolver256<T> resolver, OpIdentity id, params byte[] imm8)
        //     where T : unmanaged
        // {
        //     var count = imm8.Length;
        //     var buffer = alloc<AsmRoutine>(count);
        //     ref var dst = ref first(buffer);
        //     ref readonly var imm = ref first(imm8);
        //     for(var i=0; i<count; i++)
        //         seek(dst, i) = Single(exchange, resolver, id, skip(imm,i)).ValueOrDefault(AsmRoutine.Empty);
        //     return buffer;
        // }

        static void OnCaptureFailed(_OpIdentity id)
            => term.error($"Capture failure for {id}");

        static void OnEmbeddingFailure(MethodInfo src)
            => term.error($"Embedding failure for {src.Name}");
    }
}