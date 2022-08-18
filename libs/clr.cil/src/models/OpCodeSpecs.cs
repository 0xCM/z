//-----------------------------------------------------------------------------
// Copyright   :  Microsoft/DotNet Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Cil.OpCodeValue;

    partial struct Cil
    {
        [ApiComplete]
        public readonly struct OpCodeSpecs
        {
            public const int OperandTypeMask = 0x1F;              // 000000000000000000000000000XXXXX

            public const int FlowControlShift = 5;                // 00000000000000000000000XXXX00000

            public const int FlowControlMask = 0x0F;

            public const int OpCodeTypeShift = 9;                 // 00000000000000000000XXX000000000

            public const int OpCodeTypeMask = 0x07;

            public const int StackBehaviourPopShift = 12;         // 000000000000000XXXXX000000000000

            public const int StackBehaviourPushShift = 17;        // 0000000000XXXXX00000000000000000

            public const int StackBehaviourMask = 0x1F;

            public const int SizeShift = 22;                      // 00000000XX0000000000000000000000

            public const int SizeMask = 0x03;

            public const int EndsUncondJmpBlkFlag = 0x01000000;   // 0000000X000000000000000000000000

            public const int StackChangeShift = 28;               // XXXX0000000000000000000000000000

            public static Index<OpCode> All()
                => typeof(OpCodeSpecs).StaticProperties().Where(p => p.PropertyType == typeof(OpCode)).Values().Cast<OpCode>();

            const int NopFlags =
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift);

            public static OpCode Nop => new OpCode(K.Nop, NopFlags);

            public static OpCode Break => new OpCode(K.Break,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Break << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldarg_0 => new OpCode(K.Ldarg_0,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldarg_1 => new OpCode(K.Ldarg_1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldarg_2 => new OpCode(K.Ldarg_2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldarg_3 => new OpCode(K.Ldarg_3,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldloc_0 => new OpCode(K.Ldloc_0,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldloc_1 => new OpCode(K.Ldloc_1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldloc_2 => new OpCode(K.Ldloc_2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldloc_3 => new OpCode(K.Ldloc_3,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Stloc_0 => new OpCode(K.Stloc_0,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Stloc_1 => new OpCode(K.Stloc_1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Stloc_2 => new OpCode(K.Stloc_2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Stloc_3 => new OpCode(K.Stloc_3,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldarg_S => new OpCode(K.Ldarg_S,
                ((int)OperandType.ShortInlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldarga_S => new OpCode(K.Ldarga_S,
                ((int)OperandType.ShortInlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Starg_S => new OpCode(K.Starg_S,
                ((int)OperandType.ShortInlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldloc_S => new OpCode(K.Ldloc_S,
                ((int)OperandType.ShortInlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldloca_S => new OpCode(K.Ldloca_S,
                ((int)OperandType.ShortInlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Stloc_S => new OpCode(K.Stloc_S,
                ((int)OperandType.ShortInlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldnull => new OpCode(K.Ldnull,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_M1 => new OpCode(K.Ldc_I4_M1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_0 => new OpCode(K.Ldc_I4_0,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_1 => new OpCode(K.Ldc_I4_1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_2 => new OpCode(K.Ldc_I4_2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_3 => new OpCode(K.Ldc_I4_3,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_4 => new OpCode(K.Ldc_I4_4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_5 => new OpCode(K.Ldc_I4_5,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_6 => new OpCode(K.Ldc_I4_6,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_7 => new OpCode(K.Ldc_I4_7,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_8 => new OpCode(K.Ldc_I4_8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4_S => new OpCode(K.Ldc_I4_S,
                ((int)OperandType.ShortInlineI) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I4 => new OpCode(K.Ldc_I4,
                ((int)OperandType.InlineI) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_I8 => new OpCode(K.Ldc_I8,
                ((int)OperandType.InlineI8) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_R4 => new OpCode(K.Ldc_R4,
                ((int)OperandType.ShortInlineR) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr4 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldc_R8 => new OpCode(K.Ldc_R8,
                ((int)OperandType.InlineR) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Dup => new OpCode(K.Dup,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1_push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Pop => new OpCode(K.Pop,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Jmp => new OpCode(K.Jmp,
                ((int)OperandType.InlineMethod) |
                ((int)FlowControl.Call << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Call => new OpCode(K.Call,
                ((int)OperandType.InlineMethod) |
                ((int)FlowControl.Call << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Varpop << StackBehaviourPopShift) |
                ((int)StackBehaviour.Varpush << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Calli => new OpCode(K.Calli,
                ((int)OperandType.InlineSig) |
                ((int)FlowControl.Call << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Varpop << StackBehaviourPopShift) |
                ((int)StackBehaviour.Varpush << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ret => new OpCode(K.Ret,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Return << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Varpop << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Br_S => new OpCode(K.Br_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Brfalse_S => new OpCode(K.Brfalse_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Brtrue_S => new OpCode(K.Brtrue_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Beq_S => new OpCode(K.Beq_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bge_S => new OpCode(K.Bge_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bgt_S => new OpCode(K.Bgt_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Ble_S => new OpCode(K.Ble_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Blt_S => new OpCode(K.Blt_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bne_Un_S => new OpCode(K.Bne_Un_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bge_Un_S => new OpCode(K.Bge_Un_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bgt_Un_S => new OpCode(K.Bgt_Un_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Ble_Un_S => new OpCode(K.Ble_Un_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Blt_Un_S => new OpCode(K.Blt_Un_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Br => new OpCode(K.Br,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Branch << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Brfalse => new OpCode(K.Brfalse,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Brtrue => new OpCode(K.Brtrue,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Beq => new OpCode(K.Beq,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bge => new OpCode(K.Bge,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bgt => new OpCode(K.Bgt,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Ble => new OpCode(K.Ble,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Blt => new OpCode(K.Blt,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bne_Un => new OpCode(K.Bne_Un,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bge_Un => new OpCode(K.Bge_Un,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Bgt_Un => new OpCode(K.Bgt_Un,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Ble_Un => new OpCode(K.Ble_Un,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Blt_Un => new OpCode(K.Blt_Un,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Macro << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Switch => new OpCode(K.Switch,
                ((int)OperandType.InlineSwitch) |
                ((int)FlowControl.Cond_Branch << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldind_I1 => new OpCode(K.Ldind_I1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_U1 => new OpCode(K.Ldind_U1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_I2 => new OpCode(K.Ldind_I2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_U2 => new OpCode(K.Ldind_U2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_I4 => new OpCode(K.Ldind_I4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_U4 => new OpCode(K.Ldind_U4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_I8 => new OpCode(K.Ldind_I8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_I => new OpCode(K.Ldind_I,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_R4 => new OpCode(K.Ldind_R4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr4 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_R8 => new OpCode(K.Ldind_R8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldind_Ref => new OpCode(K.Ldind_Ref,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Stind_Ref => new OpCode(K.Stind_Ref,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Stind_I1 => new OpCode(K.Stind_I1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Stind_I2 => new OpCode(K.Stind_I2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Stind_I4 => new OpCode(K.Stind_I4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Stind_I8 => new OpCode(K.Stind_I8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi8 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Stind_R4 => new OpCode(K.Stind_R4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popr4 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Stind_R8 => new OpCode(K.Stind_R8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popr8 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Add => new OpCode(K.Add,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Sub => new OpCode(K.Sub,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Mul => new OpCode(K.Mul,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Div => new OpCode(K.Div,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Div_Un => new OpCode(K.Div_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Rem => new OpCode(K.Rem,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Rem_Un => new OpCode(K.Rem_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode And => new OpCode(K.And,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Or => new OpCode(K.Or,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Xor => new OpCode(K.Xor,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Shl => new OpCode(K.Shl,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Shr => new OpCode(K.Shr,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Shr_Un => new OpCode(K.Shr_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Neg => new OpCode(K.Neg,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Not => new OpCode(K.Not,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_I1 => new OpCode(K.Conv_I1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_I2 => new OpCode(K.Conv_I2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_I4 => new OpCode(K.Conv_I4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_I8 => new OpCode(K.Conv_I8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_R4 => new OpCode(K.Conv_R4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr4 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_R8 => new OpCode(K.Conv_R8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_U4 => new OpCode(K.Conv_U4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_U8 => new OpCode(K.Conv_U8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Callvirt => new OpCode(K.Callvirt,
                ((int)OperandType.InlineMethod) |
                ((int)FlowControl.Call << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Varpop << StackBehaviourPopShift) |
                ((int)StackBehaviour.Varpush << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Cpobj => new OpCode(K.Cpobj,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Ldobj => new OpCode(K.Ldobj,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldstr => new OpCode(K.Ldstr,
                ((int)OperandType.InlineString) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Newobj => new OpCode(K.Newobj,
                ((int)OperandType.InlineMethod) |
                ((int)FlowControl.Call << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Varpop << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Castclass => new OpCode(K.Castclass,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Isinst => new OpCode(K.Isinst,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_R_Un => new OpCode(K.Conv_R_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Unbox => new OpCode(K.Unbox,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Throw => new OpCode(K.Throw,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Throw << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldfld => new OpCode(K.Ldfld,
                ((int)OperandType.InlineField) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldflda => new OpCode(K.Ldflda,
                ((int)OperandType.InlineField) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Stfld => new OpCode(K.Stfld,
                ((int)OperandType.InlineField) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Ldsfld => new OpCode(K.Ldsfld,
                ((int)OperandType.InlineField) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldsflda => new OpCode(K.Ldsflda,
                ((int)OperandType.InlineField) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Stsfld => new OpCode(K.Stsfld,
                ((int)OperandType.InlineField) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Stobj => new OpCode(K.Stobj,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I1_Un => new OpCode(K.Conv_Ovf_I1_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I2_Un => new OpCode(K.Conv_Ovf_I2_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I4_Un => new OpCode(K.Conv_Ovf_I4_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I8_Un => new OpCode(K.Conv_Ovf_I8_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U1_Un => new OpCode(K.Conv_Ovf_U1_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U2_Un => new OpCode(K.Conv_Ovf_U2_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U4_Un => new OpCode(K.Conv_Ovf_U4_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U8_Un => new OpCode(K.Conv_Ovf_U8_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I_Un => new OpCode(K.Conv_Ovf_I_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U_Un => new OpCode(K.Conv_Ovf_U_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Box => new OpCode(K.Box,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Newarr => new OpCode(K.Newarr,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldlen => new OpCode(K.Ldlen,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldelema => new OpCode(K.Ldelema,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_I1 => new OpCode(K.Ldelem_I1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_U1 => new OpCode(K.Ldelem_U1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_I2 => new OpCode(K.Ldelem_I2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_U2 => new OpCode(K.Ldelem_U2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_I4 => new OpCode(K.Ldelem_I4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_U4 => new OpCode(K.Ldelem_U4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_I8 => new OpCode(K.Ldelem_I8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_I => new OpCode(K.Ldelem_I,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_R4 => new OpCode(K.Ldelem_R4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr4 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_R8 => new OpCode(K.Ldelem_R8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldelem_Ref => new OpCode(K.Ldelem_Ref,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushref << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Stelem_I => new OpCode(K.Stelem_I,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Stelem_I1 => new OpCode(K.Stelem_I1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Stelem_I2 => new OpCode(K.Stelem_I2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Stelem_I4 => new OpCode(K.Stelem_I4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Stelem_I8 => new OpCode(K.Stelem_I8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popi8 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Stelem_R4 => new OpCode(K.Stelem_R4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popr4 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Stelem_R8 => new OpCode(K.Stelem_R8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popr8 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Stelem_Ref => new OpCode(K.Stelem_Ref,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Ldelem => new OpCode(K.Ldelem,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Stelem => new OpCode(K.Stelem,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref_popi_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Unbox_Any => new OpCode(K.Unbox_Any,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I1 => new OpCode(K.Conv_Ovf_I1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U1 => new OpCode(K.Conv_Ovf_U1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I2 => new OpCode(K.Conv_Ovf_I2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U2 => new OpCode(K.Conv_Ovf_U2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I4 => new OpCode(K.Conv_Ovf_I4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U4 => new OpCode(K.Conv_Ovf_U4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I8 => new OpCode(K.Conv_Ovf_I8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U8 => new OpCode(K.Conv_Ovf_U8,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Refanyval => new OpCode(K.Refanyval,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ckfinite => new OpCode(K.Ckfinite,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushr8 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Mkrefany => new OpCode(K.Mkrefany,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldtoken => new OpCode(K.Ldtoken,
                ((int)OperandType.InlineTok) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Conv_U2 => new OpCode(K.Conv_U2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_U1 => new OpCode(K.Conv_U1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_I => new OpCode(K.Conv_I,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_I => new OpCode(K.Conv_Ovf_I,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Conv_Ovf_U => new OpCode(K.Conv_Ovf_U,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Add_Ovf => new OpCode(K.Add_Ovf,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Add_Ovf_Un => new OpCode(K.Add_Ovf_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Mul_Ovf => new OpCode(K.Mul_Ovf,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Mul_Ovf_Un => new OpCode(K.Mul_Ovf_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Sub_Ovf => new OpCode(K.Sub_Ovf,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Sub_Ovf_Un => new OpCode(K.Sub_Ovf_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Endfinally => new OpCode(K.Endfinally,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Return << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Leave => new OpCode(K.Leave,
                ((int)OperandType.InlineBrTarget) |
                ((int)FlowControl.Branch << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Leave_S => new OpCode(K.Leave_S,
                ((int)OperandType.ShortInlineBrTarget) |
                ((int)FlowControl.Branch << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Stind_I => new OpCode(K.Stind_I,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (-2 << StackChangeShift)
            );

            public static OpCode Conv_U => new OpCode(K.Conv_U,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefix7 => new OpCode(K.Prefix7,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefix6 => new OpCode(K.Prefix6,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefix5 => new OpCode(K.Prefix5,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefix4 => new OpCode(K.Prefix4,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefix3 => new OpCode(K.Prefix3,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefix2 => new OpCode(K.Prefix2,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefix1 => new OpCode(K.Prefix1,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Prefixref => new OpCode(K.Prefixref,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Nternal << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (1 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Arglist => new OpCode(K.Arglist,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ceq => new OpCode(K.Ceq,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Cgt => new OpCode(K.Cgt,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Cgt_Un => new OpCode(K.Cgt_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Clt => new OpCode(K.Clt,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Clt_Un => new OpCode(K.Clt_Un,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1_pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldftn => new OpCode(K.Ldftn,
                ((int)OperandType.InlineMethod) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldvirtftn => new OpCode(K.Ldvirtftn,
                ((int)OperandType.InlineMethod) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popref << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Ldarg => new OpCode(K.Ldarg,
                ((int)OperandType.InlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldarga => new OpCode(K.Ldarga,
                ((int)OperandType.InlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Starg => new OpCode(K.Starg,
                ((int)OperandType.InlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Ldloc => new OpCode(K.Ldloc,
                ((int)OperandType.InlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push1 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Ldloca => new OpCode(K.Ldloca,
                ((int)OperandType.InlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Stloc => new OpCode(K.Stloc,
                ((int)OperandType.InlineVar) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Localloc => new OpCode(K.Localloc,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Endfilter => new OpCode(K.Endfilter,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Return << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (-1 << StackChangeShift)
            );

            public static OpCode Unaligned => new OpCode(K.Unaligned_,
                ((int)OperandType.ShortInlineI) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Prefix << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Volatile => new OpCode(K.Volatile_,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Prefix << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Tailcall => new OpCode(K.Tail_,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Prefix << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Initobj => new OpCode(K.Initobj,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-1 << StackChangeShift)
            );

            public static OpCode Constrained => new OpCode(K.Constrained_,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Prefix << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Cpblk => new OpCode(K.Cpblk,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Initblk => new OpCode(K.Initblk,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Popi_popi_popi << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (-3 << StackChangeShift)
            );

            public static OpCode Rethrow => new OpCode(K.Rethrow,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Throw << FlowControlShift) |
                ((int)OpCodeType.Objmodel << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                EndsUncondJmpBlkFlag |
                (0 << StackChangeShift)
            );

            public static OpCode Sizeof => new OpCode(K.Sizeof,
                ((int)OperandType.InlineType) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (1 << StackChangeShift)
            );

            public static OpCode Refanytype => new OpCode(K.Refanytype,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Next << FlowControlShift) |
                ((int)OpCodeType.Primitive << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop1 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Pushi << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static OpCode Readonly => new OpCode(K.Readonly_,
                ((int)OperandType.InlineNone) |
                ((int)FlowControl.Meta << FlowControlShift) |
                ((int)OpCodeType.Prefix << OpCodeTypeShift) |
                ((int)StackBehaviour.Pop0 << StackBehaviourPopShift) |
                ((int)StackBehaviour.Push0 << StackBehaviourPushShift) |
                (2 << SizeShift) |
                (0 << StackChangeShift)
            );

            public static bool TakesSingleByteArgument(OpCode inst)
            {
                switch (inst.OperandType)
                {
                    case OperandType.ShortInlineBrTarget:
                    case OperandType.ShortInlineI:
                    case OperandType.ShortInlineVar:
                        return true;
                }
                return false;
            }
        }
    }
}