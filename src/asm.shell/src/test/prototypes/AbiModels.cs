//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public struct AbiModels
    {
        uint State;

        [Op]
        public static uint Run()
        {
            var abi = init(0);
            f1(ref abi);
            f2(ref abi);
            f3(ref abi);
            f4(ref abi);
            f5(ref abi);
            f4(ref abi);
            f3(ref abi);
            f2(ref abi);
            f1(ref abi);
            return abi.State;
        }

        [Op]
        public static uint Run2()
        {
            var abi = 133223888u;
            f1(ref abi);
            f2(ref abi);
            f3(ref abi);
            f4(ref abi);
            f5(ref abi);
            f4(ref abi);
            f3(ref abi);
            f2(ref abi);
            f1(ref abi);
            return abi;
        }

        [Op, MethodImpl(Inline)]
        public static AbiModels init(uint state)
        {
            var dst = new AbiModels();
            dst.State = state;
            return dst;
        }

        [Op, MethodImpl(NotInline)]
        public static uint f1(ref AbiModels abi)
        {
            abi.State += 7;
            return abi.State;
        }

        [Op, MethodImpl(NotInline)]
        public static uint f2(ref AbiModels abi)
        {
            abi.State -= 2;
            return abi.State;
        }

        [Op, MethodImpl(NotInline)]
        public static uint f3(ref AbiModels abi)
        {
            abi.State *= 2;
            return abi.State;
        }

        [Op, MethodImpl(NotInline)]
        public static uint f4(ref AbiModels abi)
        {
            abi.State = abi.State/4 + 3;
            return abi.State;
        }

        [Op, MethodImpl(NotInline)]
        public static uint f5(ref AbiModels abi)
        {
            abi.State = abi.State/4 + 3;
            return abi.State;
        }

        [Op, MethodImpl(NotInline)]
        public static ref uint f1(ref uint abi)
        {
            abi *= 2;
            return ref abi;

        }

        [Op, MethodImpl(NotInline)]
        public static ref uint f2(ref uint abi)
        {
            abi *= 4;

            return ref abi;
        }

        [Op, MethodImpl(NotInline)]
        public static ref uint f3(ref uint abi)
        {
            abi *= 8;

            return ref abi;
        }

        [Op, MethodImpl(NotInline)]
        public static ref uint f4(ref uint abi)
        {
            abi -= 9;

            return ref abi;
        }

        [Op, MethodImpl(NotInline)]
        public static ref uint f5(ref uint abi)
        {
            abi -= 12;
            return ref abi;
        }
    }
}