//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Assert = PrimalClaims;

    [ApiHost]
    public class SpanBufferChecker : Checker<SpanBufferChecker>
    {
        static ICheckNumeric Claim = NumericClaims.Checker;

        public void CheckCaller()
        {
            var c = Events.caller();
            Claim.eq(c.CallerName, nameof(CheckCaller));
        }

        [Op]
        public void CheckStacks()
        {
            var stack = SpanBuffers.stack<uint>(3);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var x1 = stack.Pop();
            var x2 = stack.Pop();
            var x3 = stack.Pop();
            Assert.eq(x1,3);
            Assert.eq(x2,2);
            Assert.eq(x3,1u);
        }

        [Op]
        public void CheckBitCircles()
        {
            var stack = new BitCircles(0b101011);
            Claim.require(stack.Pop() == 1);
            Claim.require(stack.Pop() == 1);
            Claim.require(stack.Pop() == 0);
            Claim.require(stack.Pop() == 1);
            Claim.require(stack.Pop() == 0);
            Claim.require(stack.Pop() == 1);
            stack.Push(BitState.On);
            Claim.require(stack.Pop() != 0);
        }

        [Op]
        public void CheckRingBuffer()
        {
            var buffer = SpanBuffers.ring<uint>(Pow2.T08);
            var count = Random.Next<int>(20,Pow2.T07);
            var points = Random.Span<uint>(count);
            for(var i=0; i<points.Length; i++)
                buffer.Push(points[i]);

            for(var i=0; i<points.Length; i++)
                Claim.eq(points[i], buffer.Pop());
        }

        [Op]
        public void CheckPartRing()
        {
            var capacity = Pow2.T10;
            var partwidth = 4;
            var buffer = SpanBuffers.parts<byte,ulong>(capacity);
            buffer.Next = 0xFul;
            buffer.Next = 0xFFul;
            buffer.Next = 0xFFFul;
            buffer.Next = 0xFFFFul;
            Claim.eq(buffer.Data.AsUInt64()[0],0xF);
            Claim.eq(buffer.Data.AsUInt64()[1],0xFF);
            Claim.eq(buffer.Data.AsUInt64()[2],0xFFF);
            Claim.eq(buffer.Data.AsUInt64()[3],0xFFFF);
        }
    }
}