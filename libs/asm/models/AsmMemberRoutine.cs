//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmMemberRoutine : IComparable<AsmMemberRoutine>
    {
        /// <summary>
        /// The defining member
        /// </summary>
        public ApiMember Member {get;}

        /// <summary>
        /// The assembly routine
        /// </summary>
        public AsmRoutine Routine {get;}

        public AsmMemberRoutine(in ApiMember member, AsmRoutine routine)
        {
            Member = member;
            Routine = routine;
        }

        public Index<ApiInstruction> Instructions
            => Routine.Instructions;

        /// <summary>
        /// The x86 encoded content
        /// </summary>
        public ApiCodeBlock CodeBlock
            => Routine.Code;

        public MemoryAddress Base
        {
            [MethodImpl(Inline)]
            get => CodeBlock.BaseAddress;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => CodeBlock.Length;
        }

        public int CompareTo(AsmMemberRoutine src)
            => Base.CompareTo(src.Base);

        public static AsmMemberRoutine Empty
        {
            [MethodImpl(Inline)]
            get => new AsmMemberRoutine(ApiMember.Empty, AsmRoutine.Empty);
        }
    }
}