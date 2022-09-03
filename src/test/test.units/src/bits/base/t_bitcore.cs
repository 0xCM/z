//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITestBits : ICheckBitVectors, ICheckBitStrings, ICheckNumeric, ICheckVectors
    {

    }

    public readonly struct BitTester : ITestBits
    {


    }

    public abstract class t_bits<X> : UnitTest<X, BitTester, ITestBits>
        where X : t_bits<X>, new()
    {
        protected override int RepCount => Pow2.T04;

        protected override int CycleCount => Pow2.T03;
    }
}