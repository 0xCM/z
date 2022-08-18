//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static LogicSig;

    using BLK = BinaryBitLogicKind;

    /// <summary>
    /// Implements reference bitvector operations
    /// </summary>
    [ApiHost]
    public readonly struct BitVectorLogix : IBitVectorLogix
    {
        public static BitVectorLogix Service => default(BitVectorLogix);

        [Op, Closures(UnsignedInts)]
        public BinaryOp<ScalarBits<T>> Lookup<T>(BLK kind)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return BitVectors.@true;
                case BLK.False: return BitVectors.@false;
                case BLK.And: return BitVectors.and;
                case BLK.Nand: return BitVectors.nand;
                case BLK.Or: return BitVectors.or;
                case BLK.Nor: return BitVectors.nor;
                case BLK.Xor: return BitVectors.xor;
                case BLK.Xnor: return BitVectors.xnor;
                case BLK.Left: return BitVectors.left;
                case BLK.Right: return BitVectors.right;
                case BLK.LNot: return BitVectors.lnot;
                case BLK.RNot: return BitVectors.rnot;
                case BLK.Impl: return BitVectors.impl;
                case BLK.NonImpl: return BitVectors.nonimpl;
                case BLK.CImpl: return BitVectors.cimpl;
                case BLK.CNonImpl: return BitVectors.cnonimpl;
                default: throw Unsupported.value(sig<T>(kind));
           }
        }

        [Op, Closures(UnsignedInts)]
        public ScalarBits<T> EvalDirect<T>(BLK kind, ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return BitVectors.@true(x,y);
                case BLK.False: return BitVectors.@false(x,y);
                case BLK.And: return BitVectors.and(x,y);
                case BLK.Nand: return BitVectors.nand(x,y);
                case BLK.Or: return BitVectors.or(x,y);
                case BLK.Nor: return BitVectors.nor(x,y);
                case BLK.Xor: return BitVectors.xor(x,y);
                case BLK.Xnor: return BitVectors.xnor(x,y);
                case BLK.Left: return BitVectors.left(x,y);
                case BLK.Right: return BitVectors.right(x,y);
                case BLK.LNot: return BitVectors.lnot(x,y);
                case BLK.RNot: return BitVectors.rnot(x,y);
                case BLK.Impl: return BitVectors.impl(x,y);
                case BLK.NonImpl: return BitVectors.nonimpl(x,y);
                case BLK.CImpl: return BitVectors.cimpl(x,y);
                case BLK.CNonImpl: return BitVectors.cnonimpl(x,y);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        [Op, Closures(UnsignedInts)]
        public ScalarBits<T> EvalRef<T>(BLK kind, ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            switch(kind)
            {
                case BLK.True: return BitVectors.@true(x,y);
                case BLK.False: return BitVectors.@false(x,y);
                case BLK.And: return and(x,y);
                case BLK.Nand: return nand(x,y);
                case BLK.Or: return or(x,y);
                case BLK.Nor: return nor(x,y);
                case BLK.Xor: return xor(x,y);
                case BLK.Xnor: return xnor(x,y);
                case BLK.Left: return x;
                case BLK.Right: return y;
                case BLK.LNot: return lnot(x,y);
                case BLK.RNot: return rnot(x,y);
                case BLK.Impl: return impl(x,y);
                case BLK.NonImpl: return nonimpl(x,y);
                case BLK.CImpl: return cimpl(x,y);
                case BLK.CNonImpl: return cnonimpl(x,y);
                default: throw Unsupported.value(sig<T>(kind));
            }
        }

        BitLogix bitlogix => BitLogix.Service;

        /// <summary>
        /// Computes the bitwise AND of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> and<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.And, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise AND of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> nand<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Nand, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise OR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> or<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Or, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise OR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> nor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Nor, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise XOR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> xor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Xor, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise XOR of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> xnor<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Xnor, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise LeftNot of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> lnot<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = BitLogix.Service.Evaluate(UnaryBitLogicKind.Not, x[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise LeftNot of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> rnot<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = BitLogix.Service.Evaluate(UnaryBitLogicKind.Not, y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise Impliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> impl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.Impl, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise NotImpliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> nonimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.NonImpl, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise ConverseImpliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> cimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.CImpl, x[i], y[i]);
            return z;
        }

        /// <summary>
        /// Computes the bitwise ConverseImpliction of the source vetors via component-wise logical operations to define a reference implementation
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <typeparam name="T">The primal scalar upon which the bitvector is predicated</typeparam>
        ScalarBits<T> cnonimpl<T>(ScalarBits<T> x, ScalarBits<T> y)
            where T : unmanaged
        {
            var len = x.Width;
            var z = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                z[i] = bitlogix.Evaluate(BLK.CNonImpl, x[i], y[i]);
            return z;
        }

        ScalarBits<T> select<T>(ScalarBits<T> x, ScalarBits<T> y, ScalarBits<T> z)
            where T : unmanaged
        {
            var len = x.Width;
            var dst = BitVectors.alloc<T>();
            for(var i=0; i< len; i++)
                dst[i] = BitLogix.select(x[i], y[i], z[i]);
            return z;
        }
    }
}