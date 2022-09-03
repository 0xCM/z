//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static BinaryBitLogicKind;
    using static math;
    using static core;

    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + dispatcher)]
        public readonly struct Dispatcher
        {
            [Op]
            public static void eval(ReadOnlySpan<BinaryBitLogicKind> ops, ReadOnlySpan<Pair<ulong>> args, Span<ulong> dst)
            {
                var count = math.min(ops.Length, args.Length);
                for(var i=0; i<count; i++)
                {
                    var op = skip(ops,i);
                    (var a, var b)  = skip(args,i);

                    switch(op)
                    {
                        case False:
                            seek(dst,i) = 0;
                            break;
                        case And:
                            seek(dst,i) = math.and(a,b);
                            break;
                        case CNonImpl:
                            seek(dst,i) = math.cnonimpl(a,b);
                            break;
                        case Left:
                            seek(dst,i) = math.left(a,b);
                            break;
                        case NonImpl:
                            seek(dst,i) = math.nonimpl(a,b);
                            break;
                        case Right:
                            seek(dst,i) = math.right(a,b);
                            break;
                        case Xor:
                            seek(dst,i) = math.xor(a,b);
                            break;
                        case Or:
                            seek(dst,i) = math.or(a,b);
                            break;
                        case Nor:
                            seek(dst,i) = math.nor(a,b);
                            break;
                        case Xnor:
                            seek(dst,i) = math.xnor(a,b);
                            break;
                        case RNot:
                            seek(dst,i) = math.rnot(a,b);
                            break;
                        case Impl:
                            seek(dst,i) = math.impl(a,b);
                            break;
                        case LNot:
                            seek(dst,i) = math.lnot(a,b);
                            break;
                        case CImpl:
                            seek(dst,i) = math.cimpl(a,b);
                            break;
                        case Nand:
                            seek(dst,i) = math.nand(a,b);
                            break;
                        case True:
                            seek(dst,i) = 1;
                            break;
                        }
                }
            }

            [Op]
            public ulong Eval(BinaryBitLogicKind k, ulong a, ulong b, ReadOnlySpan<Func<ulong,ulong,ulong>> f)
            {
                switch(k)
                {
                    case False:
                        return skip(f,0)(a,b);
                    case And:
                        return skip(f,1)(a,b);
                    case CNonImpl:
                        return skip(f,2)(a,b);
                    case Left:
                        return skip(f,3)(a,b);
                    case NonImpl:
                        return skip(f,4)(a,b);
                    case Right:
                        return skip(f,5)(a,b);
                    case Xor:
                        return skip(f,6)(a,b);
                    case Or:
                        return skip(f,7)(a,b);
                    case Nor:
                        return skip(f,8)(a,b);
                    case Xnor:
                        return skip(f,9)(a,b);
                    case RNot:
                        return skip(f,10)(a,b);
                    case Impl:
                        return skip(f,11)(a,b);
                    case LNot:
                        return skip(f,12)(a,b);
                    case CImpl:
                        return skip(f,13)(a,b);
                    case Nand:
                        return skip(f,14)(a,b);
                    case True:
                        return skip(f,15)(a,b);
                }

                return ulong.MaxValue;
            }
        }

        [ApiHost(prototypes + dot + evaluator)]
        public readonly struct Evaluator
        {
            [Op]
            public sbyte Eval(BinaryBitLogicKind k, sbyte a, sbyte b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }

            [Op]
            public byte Eval(BinaryBitLogicKind k, byte a, byte b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }

            [Op]
            public short Eval(BinaryBitLogicKind k, short a, short b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }

            [Op]
            public ushort Eval(BinaryBitLogicKind k, ushort a, ushort b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }

            [Op]
            public int Eval(BinaryBitLogicKind k, int a, int b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }

            [Op]
            public uint Eval(BinaryBitLogicKind k, uint a, uint b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }

            [Op]
            public long Eval(BinaryBitLogicKind k, long a, long b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }

            [Op]
            public ulong Eval(BinaryBitLogicKind k, ulong a, ulong b)
            {
                switch(k)
                {
                    case False:
                        return @false(a,b);
                    case And:
                        return and(a,b);
                    case CNonImpl:
                        return cnonimpl(a,b);
                    case Left:
                        return left(a,b);
                    case NonImpl:
                        return nonimpl(a,b);
                    case Right:
                        return right(a,b);
                    case Xor:
                        return xor(a,b);
                    case Or:
                        return or(a,b);
                    case Nor:
                        return nor(a,b);
                    case Xnor:
                        return xnor(a,b);
                    case RNot:
                        return rnot(a,b);
                    case Impl:
                        return impl(a,b);
                    case LNot:
                        return lnot(a,b);
                    case CImpl:
                        return cimpl(a,b);
                    case Nand:
                        return nand(a,b);
                    case True:
                        return @true(a,b);
                }

                return 0;
            }
        }

        [ApiHost(prototypes + evaluator + contracted)]
        public readonly struct ContractedEvaluator : IEvalContract
        {
            readonly Evaluator E;

            [Op]
            public static IEvalContract create()
                => new ContractedEvaluator(new Evaluator());

            ContractedEvaluator(Evaluator e)
            {
                E = e;
            }

            [Op]
            public sbyte Eval(BinaryBitLogicKind k, sbyte a, sbyte b)
                => E.Eval(k,a,b);

            [Op]
            public byte Eval(BinaryBitLogicKind k, byte a, byte b)
                => E.Eval(k,a,b);

            [Op]
            public short Eval(BinaryBitLogicKind k, short a, short b)
                => E.Eval(k,a,b);

            [Op]
            public ushort Eval(BinaryBitLogicKind k, ushort a, ushort b)
                => E.Eval(k,a,b);

            [Op]
            public int Eval(BinaryBitLogicKind k, int a, int b)
                => E.Eval(k,a,b);

            [Op]
            public uint Eval(BinaryBitLogicKind k, uint a, uint b)
                => E.Eval(k,a,b);

            [Op]
            public long Eval(BinaryBitLogicKind k, long a, long b)
                => E.Eval(k,a,b);

            [Op]
            public ulong Eval(BinaryBitLogicKind k, ulong a, ulong b)
                => E.Eval(k,a,b);
        }


        [ApiHost(prototypes + eval + client)]
        public readonly struct EvalClient
        {
            readonly Evaluator E;

            [Op]
            public static EvalClient create()
                => new EvalClient(new Evaluator());

            EvalClient(Evaluator e)
            {
                E = e;
            }

            [Op]
            public sbyte Eval(BinaryBitLogicKind k, sbyte a, sbyte b )
                => E.Eval(k,a,b);

            [Op]
            public byte Eval(BinaryBitLogicKind k, byte a, byte b)
                => E.Eval(k,a,b);

            [Op]
            public short Eval(BinaryBitLogicKind k, short a, short b)
                => E.Eval(k,a,b);

            [Op]
            public ushort Eval(BinaryBitLogicKind k, ushort a, ushort b)
                => E.Eval(k,a,b);

            [Op]
            public int Eval(BinaryBitLogicKind k, int a, int b)
                => E.Eval(k,a,b);

            [Op]
            public uint Eval(BinaryBitLogicKind k, uint a, uint b)
                => E.Eval(k,a,b);

            [Op]
            public long Eval(BinaryBitLogicKind k, long a, long b)
                => E.Eval(k,a,b);

            [Op]
            public ulong Eval(BinaryBitLogicKind k, ulong a, ulong b)
                => E.Eval(k,a,b);
        }

        public interface IEvalContract
        {
            sbyte Eval(BinaryBitLogicKind k, sbyte a, sbyte b);

            byte Eval(BinaryBitLogicKind k, byte a, byte b);

            short Eval(BinaryBitLogicKind k, short a, short b);

            ushort Eval(BinaryBitLogicKind k,ushort a, ushort b);

            int Eval(BinaryBitLogicKind k,int a, int b);

            uint Eval(BinaryBitLogicKind k,uint a, uint b);

            long Eval(BinaryBitLogicKind k,long a, long b);

            ulong Eval(BinaryBitLogicKind k,ulong a, ulong b);
        }
    }
}