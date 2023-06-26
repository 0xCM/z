//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    /// <summary>
    /// Specifies the asm routine determined by an api member
    /// </summary>
    public readonly struct ApiHostRoutine
    {
        public OpIdentity OpId {get;}

        public Index<ApiInstruction> Instructions {get;}

        public MemoryAddress BaseAddress {get;}

        public MemoryAddress HostAddress {get;}

        [MethodImpl(Inline)]
        public ApiHostRoutine(MemoryAddress @base, ApiInstruction[] src)
        {
            if(src.Length != 0)
            {
                var i = first(src);
                OpId = i.OpId;
                Instructions = src;
                HostAddress = @base;
                BaseAddress = i.IP;
            }
            else
            {
                OpId = OpIdentity.Empty;
                Instructions = default;
                HostAddress = default;
                BaseAddress = default;
            }
        }

        public uint InstructionCount
        {
            [MethodImpl(Inline)]
            get => Instructions.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Instructions.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Instructions.IsNonEmpty;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Instructions.Length;
        }
    }
}