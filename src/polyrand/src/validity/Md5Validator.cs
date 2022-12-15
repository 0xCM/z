//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Alg
{
    using static sys;

    public sealed class Md5Validator : Validator<Md5Validator>
    {
        public override void Run()
        {
            Handle(CheckCalc());
            Handle(CheckSineTable());
        }

        void Handle(Outcome result)
        {
            if(result.Fail)
                Channel.Error(result.Message);
        }

        Outcome CheckCalc()
        {
            var result = Outcome.Success;
            var input = Md5Ref.InputData;
            var buffer = input.ToArray();
            var output = Md5Ref.calc(buffer);
            var expect = Md5Ref.OutputHash;
            var length = output.Length;
            if(length != 16)
            {
                result = (false, string.Format("{0} != {1}", length, 16));
            }
            else
            {
                for(var i=0; i<16; i++)
                {
                    ref readonly var a = ref skip(expect,i);
                    ref readonly var b = ref skip(output,i);
                    if(a != b)
                    {
                        result = (false, string.Format("output[{0}] != expect[{0}]", i));
                        break;
                    }
                }
            }
            return result;
        }

        Outcome CheckSeqMatch<T>(ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : IEquatable<T>
        {
            var result = Outcome.Success;
            var count = a.Length;
            if(b.Length != count)
                result = (false,"Sequence length mismatch, {0} != {1}");
            else
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var x = ref skip(a,i);
                    ref readonly var y = ref skip(b,i);
                    if(!x.Equals(y))
                    {
                        result = (false,string.Format("Item equality failure at position {0}, {1} != {2}", i, x, y));
                        break;
                    }
                }
            }
            return result;
        }

        Outcome CheckSineTable()
        {
            var actual = @readonly(Md5Ref.sines());
            var expect = @readonly(Md5Ref.SinesTable);
            var result = CheckSeqMatch(actual,expect);
            return result;
        }
    }
}