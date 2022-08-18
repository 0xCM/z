//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Logix
{
    using System;

    using static BinaryBitLogicKind;

    using BLK = BinaryBitLogicKind;

    public class t_truthtables : t_logix<t_truthtables>
    {
        public void unary_truth()
        {
            using var dst = UnitWriter(FS.file(Events.caller().CallerName));
            var src = bitlogix.UnaryOpKinds;
            TruthTables.save(src, dst);
        }

        public void binary_truth()
        {
            using var dst = UnitWriter(FS.file(Events.caller().CallerName));
            var src = bitlogix.BinaryOpKinds;
            TruthTables.save(src, dst);
        }

        public void ternary_truth()
        {
            using var dst = UnitWriter(FS.file(Events.caller().CallerName));
            var src = bitlogix.TernaryOpKinds;
            TruthTables.save(src, dst);
        }

        public void unary_sig_check()
        {
            foreach(var op in bitlogix.UnaryOpKinds)
            {
                var table = TruthTables.table(op);
                var result = table.GetCol(table.ColCount - 1).ToBitVector(n8).Lo;
                var sig = TruthTables.vector(n4, op);
                Claim.eq(result,sig);
            }
        }

        public void binary_sig_check()
        {
            foreach(var op in bitlogix.BinaryOpKinds)
            {
                var table = TruthTables.table(op);
                var result = table.GetCol(table.ColCount - 1).ToBitVector(n8).Lo;
                var sig = TruthTables.vector(n4,op);
                Claim.eq(result,sig);
            }
        }

        public void ternary_sig_check()
        {
            foreach(var op in bitlogix.TernaryOpKinds)
            {
                var table = TruthTables.table(op);
                var result = table.GetCol(table.ColCount - 1).ToBitVector(n8);
                var sig = TruthTables.vector(n8,op);
                Claim.eq(result,sig);
            }
        }

        public void check_logical_and_truth()
            => check_truth(And);

        public void check_typed_and_truth()
            => check_typed_truth(And);

        public void check_logical_nand_truth()
            => check_truth(Nand);

        public void check_typed_nand_truth()
            => check_typed_truth(Nand);

        public void check_logical_or_truth()
            => check_truth(Or);

        public void check_typed_or_truth()
            => check_typed_truth(Or);

        public void check_logical_nor_truth()
            => check_truth(Nor);

        public void check_typed_nor_truth()
            => check_typed_truth(Nor);

        public void check_logical_xor_truth()
            => check_truth(Xor);

        public void check_typed_xor_truth()
            => check_typed_truth(Xor);

        public void check_logical_xnor_truth()
            => check_truth(Xnor);

        public void check_typed_xnor_truth()
            => check_typed_truth(Xnor);

        public void check_logical_imply_truth()
            => check_truth(Impl);

        public void check_typed_imply_truth()
            => check_typed_truth(Impl);

        public void check_logical_notimply_truth()
            => check_truth(NonImpl);

        public void check_typed_notimply_truth()
            => check_typed_truth(NonImpl);

        public void check_logical_cimply_truth()
            => check_truth(CImpl);

        public void check_typed_cimply_truth()
            => check_typed_truth(CImpl);

        public void check_logical_cnotimply_truth()
            => check_truth(CNonImpl);

        public void check_typed_cnotimply_truth()
            => check_typed_truth(CNonImpl);

        void check_typed_truth(BinaryBitLogicKind op)
        {
            const byte on = 1;
            const byte off = 0;

            var dst = BitVectors.alloc(n4);
            dst[0] = (byte)(NumericLogixHost.eval(op, off,off) & on) == on;
            dst[1] = (byte)(NumericLogixHost.eval(op, on,off) & on) == on;
            dst[2] = (byte)(NumericLogixHost.eval(op, off,on) & on) == on;
            dst[3] = (byte)(NumericLogixHost.eval(op, on,on) & on) == on;
            var sig = TruthTables.vector(n4, op);
            Claim.eq(sig,dst);
        }

        void check_truth(BinaryBitLogicKind op)
        {
            var dst = BitVectors.alloc(n4);
            dst[0] = bitlogix.Evaluate(op, Z0.Bit32.Off, Z0.Bit32.Off);
            dst[1] = bitlogix.Evaluate(op, Z0.Bit32.On, Z0.Bit32.Off);
            dst[2] = bitlogix.Evaluate(op, Z0.Bit32.Off, Z0.Bit32.On);
            dst[3] = bitlogix.Evaluate(op, Z0.Bit32.On, Z0.Bit32.On);
            var sig = TruthTables.vector(n4, op);
            Claim.eq(sig,dst);
        }

        public void truth_vectors()
        {
            Notify(TruthTables.vector(n16, BLK.And).Format());
            Notify(TruthTables.vector(n16, BLK.Or).Format());
            Notify(TruthTables.vector(n16,BLK.Nand).Format());
        }
    }
}