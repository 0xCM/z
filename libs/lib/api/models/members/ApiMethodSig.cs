//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class ApiMethodSigs
    {
        public abstract class ApiSig<S,K>
            where K : unmanaged
            where S : ApiSig<S,K>, new()
        {
            public K SigKind {get;}

            protected ApiSig(K kind)
            {
                SigKind = kind;
            }

        }

        public abstract class MethodSig<S,K> : ApiSig<S,K>
            where K : unmanaged
            where S : MethodSig<S,K>, new()
        {
            protected MethodSig(K kind)
                : base(kind)
            {

            }
        }

        public abstract class TypeSig<S,K> : ApiSig<S,K>
            where K : unmanaged
            where S : TypeSig<S,K>, new()
        {
            protected TypeSig(K kind)
                : base(kind)
            {

            }
        }

        public enum MethodSigKind : uint
        {
            None,

            UnaryOperator,

            BinaryOperator,

            TernaryOperator
        }

        public enum TypeSigKind : uint
        {
            None,

            Primitive
        }


        public class BinaryOperator : MethodSig<BinaryOperator,MethodSigKind>
        {
            public BinaryOperator()
                : base(MethodSigKind.BinaryOperator)
            {

            }
        }
    }
}