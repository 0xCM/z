//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmRoutineCode
    {
        public AsmRoutine Routine {get;}

        public ApiCaptureBlock Code {get;}

        public TextBlock Asm {get;}

        [MethodImpl(Inline)]
        public AsmRoutineCode(AsmRoutine f, ApiCaptureBlock code, TextBlock asm)
        {
            Routine = f;
            Code = code;
            Asm = asm;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => (Routine == null || Routine.IsEmpty) && Code.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => (Routine != null && Routine.IsNonEmpty) && Code.IsNonEmpty;
        }

        public static AsmRoutineCode Empty
            => default;

        public string Format()
            => Asm;

        public override string ToString()
            => Format();
    }
}