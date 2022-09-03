//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Cil.OpCodeSpecs;

    using ILOpCode = System.Reflection.Metadata.ILOpCode;

    partial struct Cil
    {
        public readonly struct OpCode : IEquatable<OpCode>
        {
            public readonly OpCodeValue Value;

            readonly int m_flags;

            [MethodImpl(Inline)]
            internal OpCode(OpCodeValue value, int flags)
            {
                Value = value;
                m_flags = flags;
            }

            public ushort Index
            {
                [MethodImpl(Inline)]
                get => (ushort) Value;
            }

            [MethodImpl(Inline)]
            internal bool EndsUncondJmpBlk()
                => (m_flags & EndsUncondJmpBlkFlag) != 0;

            [MethodImpl(Inline)]
            internal int StackChange()
                => m_flags >> StackChangeShift;

            public OperandType OperandType
            {
                [MethodImpl(Inline)]
                get => (OperandType)(m_flags & OperandTypeMask);
            }

            public FlowControl FlowControl
            {
                [MethodImpl(Inline)]
                get => (FlowControl)((m_flags >> FlowControlShift) & FlowControlMask);
            }

            public OpCodeType OpCodeType
            {
                [MethodImpl(Inline)]
                get => (OpCodeType)((m_flags >> OpCodeTypeShift) & OpCodeTypeMask);
            }

            public StackBehaviour StackBehaviourPop
            {
                [MethodImpl(Inline)]
                get => (StackBehaviour)((m_flags >> StackBehaviourPopShift) & StackBehaviourMask);
            }

            public StackBehaviour StackBehaviourPush
            {
                [MethodImpl(Inline)]
                get => (StackBehaviour)((m_flags >> StackBehaviourPushShift) & StackBehaviourMask);
            }

            public int Size
            {
                [MethodImpl(Inline)]
                get => (m_flags >> SizeShift) & SizeMask;
            }

            [MethodImpl(Inline)]
            public bool Equals(OpCode obj)
                => obj.Value == Value;


            public override bool Equals(object? obj)
                => obj is OpCode other && Equals(other);

            public override int GetHashCode()
                => (int)Value;

            [MethodImpl(Inline)]
            public static bool operator ==(OpCode a, OpCode b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(OpCode a, OpCode b)
                => !(a == b);

            [MethodImpl(Inline)]
            public static implicit operator OpCodeValue(OpCode src)
                => src.Value;

            [MethodImpl(Inline)]
            public static implicit operator ILOpCode(OpCode src)
                => (ILOpCode)src.Value;
        }
    }
}