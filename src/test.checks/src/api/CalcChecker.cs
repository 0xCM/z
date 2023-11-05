//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using System.Reflection;
using Masks = BitMaskLiterals;

partial class ApiOps : Checker<ApiOps>
{
    public void Run(string[] args)
    {
        var count = args.Length;
        if(count != 0)
        {
            for(var i=0; i<count; i++)
                Run(skip(args,i));
        }
        else
        {
            RunValidators(EventLog);
        }
    }
    
    new Action<object> Log
        => msg => Write(msg);

    void LogHeader<N>(MethodBase src, N n)
        where N : unmanaged, ITypeNat
    {
        Log(string.Format("{0} {1} ", src.Name, n).PadRight(80,Chars.Dash));
    }

    void Run(N1 n)
    {
        LogHeader(MethodInfo.GetCurrentMethod(), n);
        var checker = BitLogicChecker.create(Wf, Rng.@default());
        checker.Validate();
    }

    void EmitBitMasks()
    {
        var dst = AppDb.AppData(ApiAtomic.logs).Path("bitmasks", FileKind.Csv);
        var src = Bitfields.masks(typeof(BitMaskLiterals));
        var formatter = CsvTables.formatter<BitMaskInfo>();
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var mask = ref src[i];
            Channel.Row(formatter.Format(mask));
            Channel.Write(mask.Text);
        }
        Channel.TableEmit(src,dst,TextEncodingKind.Unicode);
    }

    [CmdOp("grids/check")]
    unsafe Outcome TestGrids(CmdArgs args)
    {
        const uint M = 17;
        const uint N = 19;
        const uint Count = M*N;
        var result = Outcome.Success;
        var storage = alloc<uint>(Count);
        var k=0u;
        for(var i=0u; i<M; i++)
        for(var j=0u; j<N; j++, k++)
            seek(storage,k) = i*j;

        var table = new Grid<uint>((M,N), storage);

        k = 0;
        var msg = EmptyString;
        for(var i=0u; i<M; i++)
        {
            for(var j=0u; j<N; j++, k++)
            {
                var expect = i*j;
                ref readonly var actual = ref table[i,j];
                var ok = actual == expect;
                if(ok)
                    msg = string.Format("{0}x{1} = {2}",i,j,expect);
                else
                    msg = string.Format("{0}x{1} = [{0},{1}] = {2} != {3}", i,j, actual, expect);

                if(ok)
                    Channel.Write(msg, FlairKind.Status);
                else
                    Channel.Write(msg, FlairKind.Error);
            }
        }

        return result;
    }

    void Run(N4 n)
    {
        LogHeader(MethodInfo.GetCurrentMethod(), n);
        var buffer = span<char>(Pow2.T12);
        var src = (uint)Masks.Hi32x16;
        var dst = ByteBlock32.Empty.Bytes;
        gpack.unpack1x32x8(src, dst);
        var count = HexRender.render(UpperCase, dst, buffer);
        var hex = text.format(slice(buffer,0,count));
        Log(hex);

        buffer.Clear();
        var k=0;
        for(var i=0; i<32; i++)
        {
            ref readonly var a = ref skip(dst,i);
            for(byte j=0; j<7; j++)
                seek(buffer,k++) = bit.test(a,j).ToChar();
            seek(buffer,k++) = Chars.Space;
        }

        var bitstring = text.format(slice(buffer,0,k));
        Log(bitstring);
    }

    void Run(N9 n)
    {
        LogHeader(MethodInfo.GetCurrentMethod(), n);
        var checker = BitLogicChecker.create(Wf, Rng.@default());
        checker.Validate();
    }

    void Run(N15 n)
    {
        LogHeader(MethodInfo.GetCurrentMethod(), n);

        Size<byte> a = 31;
        var b = a.Align(4);
        Log(a.Measure);
        Log(a.Untyped);
        Log(b.Measure);

        Log(string.Format("Align({0}) = {1}", a, b));
    }

    void Run(N8 n)
    {
        var result = Outcome.Success;
        var classifier = Classifiers.classifier<AsciLetterLoSym,byte>();
        var symbols = Symbols.index<AsciLetterLoSym>();
        var classes = classifier.Classes;
        var count = classes.Length;
        for(var i=0u; i<count; i++)
        {
            ref readonly var c = ref skip(classes,i);
            ref readonly var s = ref symbols[i];
            Require.equal(c.Index, i);
            Require.equal(s.Key.Value, c.Index);
            Require.equal(s.Expr.Format(), c.Symbol.Format());
            Require.equal(s.Name, c.Name.Format());
        }
    }

    void Run(N18 n)
    {
        LogHeader(MethodInfo.GetCurrentMethod(), n);
        var m0 = BitMaskLiterals.b00001111x32;
        var m1 = BitMaskLiterals.Even32;
        var m = (ulong)m0 | ((ulong)m1 << 32);
        var bf = Bitfields.create(m);
        var bytes = sys.bytes(bf);
        var buffer = CharBlock128.Null;
        var count = BitRender.render4x4(bytes, buffer.Data);
        var chars = slice(buffer.Data,0,count);
        var fmt = text.format(chars);
        Log(fmt);
    }

    void Run(N25 n)
    {
        LogHeader(MethodInfo.GetCurrentMethod(), n);
        Fsm.example1();
        PrimalStates.example2();
    }

    void Run(N28 n)
    {
        LogHeader(MethodInfo.GetCurrentMethod(), n);
        for(byte i = 120; i<148; i++)
        for(byte j = 120; j<148; j++)
        {
            var cin = math.odd(i + j);
            var y = math.adc(i, j, cin, out var cout);
            Log(string.Format("adc({0},{1}) carry {2} = {3} carry {4}", i, j, cin, y, (uint)cout));
        }
    }

    void Run(N30 n)
    {
        var x0 = "0x3412a";
        var x1 = zUInt128.Zero;
        var result = math.parse(x0, out x1);
        if(result)
        {
            var x2 = x1.Format();
            if(x0 != x2)
                Channel.Error(string.Format("'{0}' != '{1}'", x2, x0));
        }
        else
            Channel.Error(result.Message);
    }

    void RunValidators(IEventTarget log)
    {
        Md5Validator.create(Wf).Run();
        Run(n1);
        Run(n4);
        Run(n8);
        Run(n9);
        Run(n15);
        Run(n18);
        Run(n25);
        Run(n28);
        Run(n30);
        EmitBitMasks();
    }

    void Run(string spec)
    {
        if(uint.TryParse(spec, out var n))
        {
            switch(n)
            {
                case 1:
                    Run(n1);
                break;
                case 4:
                    Run(n4);
                break;
                case 8:
                    Run(n8);
                break;
                case 9:
                    Run(n9);
                break;
                case 15:
                    Run(n15);
                break;
                case 18:
                    Run(n18);
                break;
                case 25:
                    Run(n25);
                break;
                case 28:
                    Run(n28);
                break;
                case 30:
                    Run(n30);
                break;
                default:
                    Channel.Error(string.Format("Command '{0}' unrecognized", spec));
                break;
            }
        }
    }

    protected override void Execute(IEventTarget log)
    {
        RunValidators(log);
    }
}
