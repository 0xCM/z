//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class DemandException : Exception
    {
        public static void Throw(string constraint, object expect, object actual)
            => throw new DemandException(constraint, expect, actual);

        public static void Throw(string constraint, (ulong x, ulong y) relation)
            => throw new DemandException(constraint, relation);

        public string Expect {get;}

        public string Actual{get;}

        public string Constraint {get;}

        public DemandException(string constraint, object expect, object actual)
        {
            Constraint = constraint;
            Expect = expect.ToString();
            Actual = actual.ToString();
        }

        public DemandException(string constraint, (uint x, uint y) relation )
        {
            Constraint = constraint;
            Expect = $"({relation.x}, {relation.y})";
            Actual = string.Empty;
        }

        public DemandException(string constraint, (ulong x, ulong y) relation)
        {
            Constraint = constraint;
            Expect = $"({relation.x}, {relation.y})";
            Actual = string.Empty;
        }

        public override string Message
            => Actual != string.Empty
             ? $"Constraint {Constraint} failed. Expected: {Expect} | Actual: {Actual}"
             : $"Invariant {Constraint} failed: {Expect}";
    }
}