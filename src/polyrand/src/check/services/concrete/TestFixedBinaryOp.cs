//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static CellDelegates;

    public class TestFixedBinaryOp : ICheckBinaryCellOp
    {
        public IPolyrand Random {get;}

        public IPolySource Source {get;}

        [MethodImpl(Inline)]
        public static TestFixedBinaryOp Check(IPolyrand random)
            => new TestFixedBinaryOp(random);

        [MethodImpl(Inline)]
        public static TestFixedBinaryOp Check(IPolySource source)
            => new TestFixedBinaryOp(source);

        [MethodImpl(Inline)]
        public TestFixedBinaryOp(IPolyrand source)
        {
            Random = source;
            Source = source;
        }

        [MethodImpl(Inline)]
        public TestFixedBinaryOp(IPolySource source)
        {
            Source = source;
        }

        ICheckAction ActionTest
            => cast<ICheckBinaryCellOp>(this);

        ITestCaseIdentity Identity
            => ActionTest;

        int RepCount
            => ActionTest.RepCount;

        ICheckEquatable Claim
            => CheckEquatable.Checker;


        /// <summary>
        /// Verifies that two 8-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        public TestCaseRecord Match(BinaryOp8 f, OpIdentity fId, BinaryOp8 g, OpIdentity gId)
        {
            var w = w8;

            void check()
            {
                for(var i=0; i<RepCount; i++)
                {
                    var x = Random.Cell(w);
                    var y = Random.Cell(w);
                    Claim.eq(f(x,y), g(x,y));
                }
            }

            return ActionTest.TestAction(check, Identity.match(fId, gId));
        }

        /// <summary>
        /// Verifies that two 16-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        public TestCaseRecord Match(BinaryOp16 f, OpIdentity fId, BinaryOp16 g, OpIdentity gId)
        {
            var w = w16;

            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Random.Cell(w);
                    var y = Random.Cell(w);
                    var a = f(x,y);
                    var b = g(x,y);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ActionTest.TestAction(check, Identity.match(fId, gId));
        }

        /// <summary>
        /// Verifies that two 32-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        public TestCaseRecord Match(BinaryOp32 f, OpIdentity fId, BinaryOp32 g, OpIdentity gId)
        {
            var w = w32;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Random.Cell(w);
                    var y = Random.Cell(w);
                    var a = f(x,y);
                    var b = g(x,y);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ActionTest.TestAction(check, Identity.match(fId, gId));
        }

        /// <summary>
        /// Verifies that two 64-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        public TestCaseRecord Match(BinaryOp64 f, OpIdentity fId, BinaryOp64 g, OpIdentity gId)
        {
            var w = w64;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Random.Cell(w);
                    var y = Random.Cell(w);
                    var a = f(x,y);
                    var b = g(x,y);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ActionTest.TestAction(check, Identity.match(fId, gId));
        }

        /// <summary>
        /// Verifies that two 128-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        public TestCaseRecord Match(BinaryOp128 f, OpIdentity fId, BinaryOp128 g, OpIdentity gId)
        {
            var w = w128;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Random.Cell(w);
                    var y = Random.Cell(w);
                    var a = f(x,y);
                    var b = g(x,y);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ActionTest.TestAction(check, Identity.match(fId, gId));
        }

        /// <summary>
        /// Verifies that two 128-bit binary operators agree over a random set of points
        /// </summary>
        /// <param name="f">The first operator</param>
        /// <param name="fId">The identity of the first operator</param>
        /// <param name="g">The second operator</param>
        /// <param name="gId">The identity of the second operator</param>
        public TestCaseRecord Match(BinaryOp256 f, OpIdentity fId, BinaryOp256 g, OpIdentity gId)
        {
            var w = w256;
            void check()
            {
                for(var i=0; i < RepCount; i++)
                {
                    var x = Random.Cell(w);
                    var y = Random.Cell(w);
                    var a = f(x,y);
                    var b = g(x,y);
                    Claim.eq(f(x,y),g(x,y));
                }
            }

            return ActionTest.TestAction(check, Identity.match(fId, gId));
        }
    }
}