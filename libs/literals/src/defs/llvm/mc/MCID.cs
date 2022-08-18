//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.mc
{
    using T = MCID.Flag;

    using static ApiAtomic;

    [LiteralProvider(llvm)]
    public readonly struct MCID
    {
        /// <summary>
        /// These should be considered private to the implementation of the
        /// MCInstrDesc class.  Clients should use the predicate methods on MCInstrDesc,
        /// not use these directly.  These all correspond to bitfields in the
        /// MCInstrDesc::Flags field.
        /// </summary>
        [SymSource(llvm_mc)]
        public enum Flag : byte
        {
            PreISelOpcode = 0,

            Variadic,

            HasOptionalDef,

            Pseudo,

            Return,

            EHScopeReturn,

            Call,

            Barrier,

            Terminator,

            Branch,

            IndirectBranch,

            Compare,

            MoveImm,

            MoveReg,

            Bitcast,

            Select,

            DelaySlot,

            FoldableAsLoad,

            MayLoad,

            MayStore,

            MayRaiseFPException,

            Predicable,

            NotDuplicable,

            UnmodeledSideEffects,

            Commutable,

            ConvertibleTo3Addr,

            UsesCustomInserter,

            HasPostISelHook,

            Rematerializable,

            CheapAsAMove,

            ExtraSrcRegAllocReq,

            ExtraDefRegAllocReq,

            RegSequence,

            ExtractSubreg,

            InsertSubreg,

            Convergent,

            Add,

            Trap,

            VariadicOpsAreDefs,

            Authenticated,
        }

        public const byte PreISelOpcode = (byte)T.PreISelOpcode;

        public const byte Variadic = (byte)T.Variadic;

        public const byte HasOptionalDef = (byte)T.HasOptionalDef;

        public const byte Pseudo = (byte)T.Pseudo;

        public const byte Return = (byte)T.Return;

        public const byte EHScopeReturn = (byte)T.EHScopeReturn;

        public const byte Call = (byte)T.Call;

        public const byte Barrier = (byte)T.Barrier;

        public const byte Terminator = (byte)T.Terminator;

        public const byte Branch = (byte)T.Branch;

        public const byte IndirectBranch = (byte)T.IndirectBranch;

        public const byte Compare = (byte)T.Compare;

        public const byte MoveImm = (byte)T.MoveImm;

        public const byte MoveReg = (byte)T.MoveReg;

        public const byte Bitcast = (byte)T.Bitcast;

        public const byte Select = (byte)T.Select;

        public const byte DelaySlot = (byte)T.DelaySlot;

        public const byte FoldableAsLoad = (byte)T.FoldableAsLoad;

        public const byte MayLoad = (byte)T.MayLoad;

        public const byte MayStore = (byte)T.MayStore;

        public const byte MayRaiseFPException = (byte)T.MayRaiseFPException;

        public const byte Predicable = (byte)T.Predicable;

        public const byte NotDuplicable = (byte)T.NotDuplicable;

        public const byte UnmodeledSideEffects = (byte)T.UnmodeledSideEffects;

        public const byte Commutable = (byte)T.Commutable;

        public const byte ConvertibleTo3Addr = (byte)T.ConvertibleTo3Addr;

        public const byte UsesCustomInserter = (byte)T.UsesCustomInserter;

        public const byte HasPostISelHook = (byte)T.HasPostISelHook;

        public const byte Rematerializable = (byte)T.Rematerializable;

        public const byte CheapAsAMove = (byte)T.CheapAsAMove;

        public const byte ExtraSrcRegAllocReq = (byte)T.ExtraSrcRegAllocReq;

        public const byte ExtraDefRegAllocReq = (byte)T.ExtraDefRegAllocReq;

        public const byte RegSequence = (byte)T.RegSequence;

        public const byte ExtractSubreg = (byte)T.ExtractSubreg;

        public const byte InsertSubreg = (byte)T.InsertSubreg;

        public const byte Convergent = (byte)T.Convergent;

        public const byte Add = (byte)T.Add;

        public const byte Trap = (byte)T.Trap;

        public const byte VariadicOpsAreDefs = (byte)T.VariadicOpsAreDefs;

        public const byte Authenticated = (byte)T.Authenticated;
    }
}