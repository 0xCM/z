//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Iced = Iced.Intel;
    using NI = NumericIndicator;
    using TI = TypeIndicator;
    using MZ = Asm.IceMemorySize;
    using NK = NumericKind;
    using SI = SegmentedIdentity;
    using FIX = CpuCellWidth;

    [ApiHost]
    public readonly partial struct IceConverters
    {
        /// <summary>
        /// Adapted from http://github.com/dotnet/BenchmarkDotNet/src/BenchmarkDotNet.Disassembler.x64/ClrMdDisassembler.cs
        /// </summary>
        /// <param name="src"></param>
        public static MemoryAddress TargetAddress(Iced.Instruction src)
        {
            var address = MemoryAddress.Zero;
            for (int i = 0; i < src.OpCount; i++)
            {
                switch (src.GetOpKind(i))
                {
                    case Iced.OpKind.NearBranch16:
                    case Iced.OpKind.NearBranch32:
                    case Iced.OpKind.NearBranch64:
                        address = src.NearBranchTarget;
                        return address > (uint)ushort.MaxValue ? address : MemoryAddress.Zero;
                    case Iced.OpKind.Immediate16:
                    case Iced.OpKind.Immediate8to16:
                    case Iced.OpKind.Immediate8to32:
                    case Iced.OpKind.Immediate8to64:
                    case Iced.OpKind.Immediate32to64:
                    case Iced.OpKind.Immediate32:
                    case Iced.OpKind.Immediate64:
                        address = src.GetImmediate(i);
                        return address > (uint)ushort.MaxValue ? address : MemoryAddress.Zero;
                    case Iced.OpKind.Memory64:
                        address = src.MemoryAddress64;
                        return address > (uint)ushort.MaxValue ? address : MemoryAddress.Zero;
                    case Iced.OpKind.Memory when src.IsIPRelativeMemoryOperand:
                        address = src.IPRelativeMemoryAddress;
                        return address > (uint)ushort.MaxValue ? address : MemoryAddress.Zero;
                    case Iced.OpKind.Memory:
                        address = src.MemoryDisplacement;
                        return address > (uint)ushort.MaxValue ? address : MemoryAddress.Zero;
                }
            }

            return address;
        }

        public static IceUsedMemory[] UsedMemory(Iced.InstructionInfo src)
            => src.GetUsedMemory().Map(x => Thaw(x));

        public static IceUsedRegister[] UsedRegisters(Iced.InstructionInfo src)
            => src.GetUsedRegisters().Map(x => Thaw(x));

        [MethodImpl(Inline)]
        public static Func<IceOpAccess[]> OpAccessDefer(Iced.InstructionInfo src)
            => () => access(src);

        [Op]
        public static AsmFormInfo formxpr(Iced.Instruction src)
        {
            var ocinfo = Iced.EncoderCodeExtensions.ToOpCode(src.Code);
            return new (
                ocxpr(ocinfo.ToOpCodeString()),
                new AsmSigInfo(src.Mnemonic.ToString(),ocinfo.ToInstructionString())
                );
        }

        static string ocxpr(string src)
            => new (src.Replace("o32 ", EmptyString).Replace("o16 ", EmptyString).Replace("+", " +"));

        [MethodImpl(Inline), Op]
        public static IceOpAccess[] access(Iced.InstructionInfo src)
            => sys.array(
                    Thaw(src.Op0Access),
                    Thaw(src.Op0Access),
                    Thaw(src.Op2Access),
                    Thaw(src.Op3Access),
                    Thaw(src.Op4Access)).Where(x => x != 0);

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [Op]
        public static IceInstruction extract(Iced.Instruction src, string formatted, BinaryCode decoded)
        {
            var info = src.GetInfo();
            Require.invariant(src.ByteLength == decoded.Length, () => $"The instruction byte length {src.ByteLength} does not match the encoded length {decoded.Length}");
            return new IceInstruction
            {
                Decoded = decoded,
                UsedMemory = UsedMemory(info),
                UsedRegisters = UsedRegisters(info),
                Access = OpAccessDefer(info),
                Specifier = formxpr(src),
                ByteLength = src.ByteLength,
                ConditionCode = Thaw(src.ConditionCode),
                CodeSize = Thaw(src.CodeSize),
                FormattedInstruction = formatted,
                Code = Thaw(src.Code),
                CpuidFeatures = src.CpuidFeatures.Map(x => Thaw(x)),
                DeclareDataCount = src.DeclareDataCount,
                Encoding = Thaw(src.Encoding),
                FarBranch16 = src.FarBranch16,
                FarBranch32 = src.FarBranch32,
                FarBranchSelector = src.FarBranchSelector,
                FlowControl = Thaw(src.FlowControl),
                IP = src.IP,
                IP16 = src.IP16,
                IP32 = src.IP32,
                IPRelativeMemoryAddress = src.IPRelativeMemoryAddress,
                IsBroadcast = src.IsBroadcast,
                IsCallFar = src.IsCallFar,
                IsCallFarIndirect = src.IsCallFarIndirect,
                IsCallNear = src.IsCallNear,
                IsCallNearIndirect = src.IsCallNearIndirect,
                IsIPRelativeMemoryOperand = src.IsIPRelativeMemoryOperand,
                IsJccShortOrNear = src.IsJccShortOrNear,
                IsJccShort = src.IsJccShort,
                IsJmpShort = src.IsJmpShort,
                IsJmpNear = src.IsJmpNear,
                IsJmpShortOrNear = src.IsJmpShortOrNear,
                IsJmpFar = src.IsJmpFar,
                IsJmpNearIndirect = src.IsJmpNearIndirect,
                IsJmpFarIndirect = src.IsJmpFarIndirect,
                IsJccNear = src.IsJccNear,
                IsPrivileged = src.IsPrivileged,
                IsProtectedMode = src.IsProtectedMode,
                IsStackInstruction = src.IsStackInstruction,
                IsSaveRestoreInstruction = src.IsSaveRestoreInstruction,
                IsVsib64 = src.IsVsib64,
                IsVsib = src.IsVsib,
                IsVsib32 = src.IsVsib32,
                Immediate8 = src.Immediate8,
                Immediate8_2nd = src.Immediate8_2nd,
                Immediate16 = src.Immediate16,
                Immediate32 = src.Immediate32,
                Immediate64 = src.Immediate64,
                Immediate8to16 = src.Immediate8to16,
                Immediate8to32 = src.Immediate8to32,
                Immediate8to64 = src.Immediate8to64,
                Immediate32to64 = src.Immediate32to64,
                HasLockPrefix = src.HasLockPrefix,
                HasOpMask = src.HasOpMask,
                HasRepPrefix = src.HasRepPrefix,
                HasRepePrefix = src.HasRepePrefix,
                HasRepnePrefix = src.HasRepnePrefix,
                HasXacquirePrefix = src.HasXacquirePrefix,
                HasXreleasePrefix = src.HasXreleasePrefix,
                MemorySize = Thaw(src.MemorySize),
                MemoryIndex = Thaw(src.MemoryIndex),
                MemoryIndexScale = src.MemoryIndexScale,
                MemoryDisplacement = src.MemoryDisplacement,
                MemoryAddress64 = src.MemoryAddress64,
                MemoryDisplSize = src.MemoryDisplSize,
                MemorySegment = Thaw(src.MemorySegment),
                MemoryBase =  Thaw(src.MemoryBase),
                MergingMasking = src.MergingMasking,
                Mnemonic = Thaw(src.Mnemonic),
                NearBranch16 = src.NearBranch16,
                NearBranch32 = src.NearBranch32,
                NearBranch64 = src.NearBranch64,
                NearBranchTarget = src.NearBranchTarget,
                NextIP = src.NextIP,
                NextIP16 = src.NextIP16,
                NextIP32 = src.NextIP32,
                OpCode = extract(src.OpCode),
                OpCount = src.OpCount,
                OpMask = Thaw(src.OpMask),
                Op0Kind = Thaw(src.Op0Kind),
                Op1Kind = Thaw(src.Op1Kind),
                Op2Kind = Thaw(src.Op2Kind),
                Op3Kind = Thaw(src.Op3Kind),
                Op4Kind = Thaw(src.Op4Kind),
                Op0Register = Thaw(src.Op0Register),
                Op1Register = Thaw(src.Op1Register),
                Op2Register = Thaw(src.Op2Register),
                Op3Register = Thaw(src.Op3Register),
                Op4Register = Thaw(src.Op4Register),
                RflagsRead = Thaw(src.RflagsRead),
                RflagsWritten = Thaw(src.RflagsWritten),
                RflagsCleared = Thaw(src.RflagsCleared),
                RflagsSet = Thaw(src.RflagsSet),
                RflagsUndefined = Thaw(src.RflagsUndefined),
                RflagsModified = Thaw(src.RflagsModified),
                RoundingControl = Thaw(src.RoundingControl),
                SegmentPrefix = Thaw(src.SegmentPrefix),
                SuppressAllExceptions = src.SuppressAllExceptions,
                StackPointerIncrement = src.StackPointerIncrement,
                ZeroingMasking = src.ZeroingMasking,
           };
        }

        /// <summary>
        /// Assigns identity to a <see cref='IceMemorySize'/> specification
        /// </summary>
        /// <param name="src">A memory size specification</param>
        [Op]
        public static SegmentedIdentity identify(IceMemorySize src)
            => src switch {
                    MZ.UInt8 => NK.U8,
                    MZ.UInt16 => NK.U16,
                    MZ.UInt32 => NK.U32,
                    MZ.UInt64 => NK.U64,
                    MZ.Int8 => NK.I8,
                    MZ.Int16 => NK.I16,
                    MZ.Int32 => NK.I32,
                    MZ.Int64 => NK.I64,
                    MZ.Float32 => NK.F32,
                    MZ.Float64 => NK.F64,
                    MZ.Packed128_Int8 => (TI.Signed, FIX.W128, FIX.W8, NI.Signed),
                    MZ.Packed128_UInt8 => (TI.Unsigned, FIX.W128, FIX.W8, NI.Unsigned),
                    MZ.Packed128_Int16 => (TI.Signed, FIX.W128, FIX.W16, NI.Signed),
                    MZ.Packed128_UInt16 => (TI.Unsigned, FIX.W128, FIX.W16, NI.Unsigned),
                    MZ.Packed128_Int32 => (TI.Signed, FIX.W128, FIX.W32, NI.Signed),
                    MZ.Packed128_UInt32 => (TI.Unsigned, FIX.W128, FIX.W32, NI.Unsigned),
                    MZ.Packed128_Int64 => (TI.Signed, FIX.W128, FIX.W64, NI.Signed),
                    MZ.Packed128_UInt64 => (TI.Unsigned, FIX.W128, FIX.W64, NI.Unsigned),
                    MZ.Packed128_Float32 => (TI.Float, FIX.W128, FIX.W32, NI.Float),
                    MZ.Packed128_Float64 => (TI.Float, FIX.W128, FIX.W64, NI.Float),
                    MZ.Packed256_Int8 => (TI.Signed, FIX.W256, FIX.W8, NI.Signed),
                    MZ.Packed256_UInt8 => (TI.Unsigned, FIX.W256, FIX.W8, NI.Unsigned),
                    MZ.Packed256_Int16 => (TI.Signed, FIX.W256, FIX.W16, NI.Signed),
                    MZ.Packed256_UInt16 => (TI.Unsigned, FIX.W256, FIX.W16, NI.Unsigned),
                    MZ.Packed256_Int32 => (TI.Signed, FIX.W256, FIX.W32, NI.Signed),
                    MZ.Packed256_UInt32 => (TI.Unsigned, FIX.W256, FIX.W32, NI.Unsigned),
                    MZ.Packed256_Int64 => (TI.Signed, FIX.W256, FIX.W64, NI.Signed),
                    MZ.Packed256_UInt64 => (TI.Unsigned, FIX.W256, FIX.W64, NI.Unsigned),
                    MZ.Packed256_Float32 => (TI.Float, FIX.W256, FIX.W32, NI.Float),
                    MZ.Packed256_Float64 => (TI.Float, FIX.W256, FIX.W64, NI.Float),
                    MZ.Unknown => SI.Empty,
                    _ => SI.from(src.ToString())
            };

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [Op]
        public static IceOpCodeInfo extract(Iced.OpCodeInfo src)
            => new IceOpCodeInfo
            {
                AddressSize = src.AddressSize,
                CanBroadcast = src.CanBroadcast,
                CanSuppressAllExceptions = src.CanSuppressAllExceptions,
                CanUseBndPrefix = src.CanUseBndPrefix,
                CanUseHintTakenPrefix = src.CanUseHintTakenPrefix,
                CanUseNotrackPrefix = src.CanUseNotrackPrefix,
                CanUseOpMaskRegister = src.CanUseOpMaskRegister,
                CanUseZeroingMasking = src.CanUseZeroingMasking,
                CanUseLockPrefix = src.CanUseLockPrefix,
                CanUseXacquirePrefix = src.CanUseXacquirePrefix,
                CanUseXreleasePrefix = src.CanUseXreleasePrefix,
                CanUseRepPrefix = src.CanUseRepPrefix,
                CanUseRepnePrefix = src.CanUseRepnePrefix,
                CanUseRoundingControl = src.CanUseRoundingControl,
                Code = Thaw(src.Code),
                Encoding = Thaw(src.Encoding),
                Fwait = src.Fwait,
                IsInstruction = src.IsInstruction,
                IsGroup = src.IsGroup,
                IsLIG = src.IsLIG,
                IsWIG = src.IsWIG,
                IsWIG32 = src.IsWIG32,
                GroupIndex = src.GroupIndex,
                L = src.L,
                MandatoryPrefix = Thaw(src.MandatoryPrefix),
                Mode16 = src.Mode16,
                Mode32 = src.Mode32,
                Mode64 = src.Mode64,
                OpCode = src.OpCode,
                OperandSize = src.OperandSize,
                OpCount = src.OpCount,
                OpCodeString = ocxpr(src.ToOpCodeString()),
                InstructionString = src.ToInstructionString(),
                Op0Kind = Thaw(src.Op0Kind),
                Op1Kind = Thaw(src.Op1Kind),
                Op2Kind = Thaw(src.Op2Kind),
                Op3Kind = Thaw(src.Op3Kind),
                Op4Kind = Thaw(src.Op4Kind),
                RequireNonZeroOpMaskRegister = src.RequireNonZeroOpMaskRegister,
                Table = Thaw(src.Table),
                TupleType = Thaw(src.TupleType),
                W = src.W,
            };

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceUsedMemory Thaw(Iced.UsedMemory src)
            => new IceUsedMemory(
                Access : Thaw(src.Access),
                Base  : Thaw(src.Base),
                Displacement : src.Displacement,
                Index : Thaw(src.Index),
                MemorySize : Thaw(src.MemorySize),
                Scale : src.Scale,
                Segment : Thaw(src.Segment),
                Formatted : src.ToString()
            );

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceUsedRegister Thaw(Iced.UsedRegister src)
            => new IceUsedRegister(Thaw(src.Register), Thaw(src.Access));

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceOpAccess Thaw(Iced.OpAccess src)
            => (IceOpAccess)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceOpCodeId Thaw(Iced.Code src)
            => Enums.parse(src.ToString(), IceOpCodeId.INVALID);

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceCodeSize Thaw(Iced.CodeSize src)
            => (IceCodeSize)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceConditionCode Thaw(Iced.ConditionCode src)
            => (IceConditionCode)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceCpuidFeature Thaw(Iced.CpuidFeature src)
            => (IceCpuidFeature)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceEncodingKind Thaw(Iced.EncodingKind src)
            => (IceEncodingKind)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceFlowControl Thaw(Iced.FlowControl src)
            => (IceFlowControl)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceMandatoryPrefix Thaw(Iced.MandatoryPrefix src)
            => (IceMandatoryPrefix)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceMemorySize Thaw(Iced.MemorySize src)
            => (IceMemorySize)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceMnemonic Thaw(Iced.Mnemonic src)
            => (IceMnemonic)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceOpCodeOperandKind Thaw(Iced.OpCodeOperandKind src)
            => (IceOpCodeOperandKind)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceOpCodeTableKind Thaw(Iced.OpCodeTableKind src)
            => (IceOpCodeTableKind)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceOpKind Thaw(Iced.OpKind src)
            => (IceOpKind)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceRegister Thaw(Iced.Register src)
            => (IceRegister)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceRflagsBits Thaw(Iced.RflagsBits src)
            => (IceRflagsBits)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceRoundingControl Thaw(Iced.RoundingControl src)
            => (IceRoundingControl)src;

        /// <summary>
        /// Converts the iced-defined data structure to a Z0-defined replication of the iced structure
        /// </summary>
        /// <param name="src">The iced source value</param>
        [MethodImpl(Inline), Op]
        static IceTupleType Thaw(Iced.TupleType src)
            => (IceTupleType)src;
    }
}