//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static HandleFormatKind;
    using static Refs;

    public enum HandleFormatKind
    {
        HandleAddress,

        PointerAddress,

        Raw
    }

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public unsafe readonly struct HandleAdapter
    {
        [MethodImpl(Inline)]
        public static HandleAdapter from(RuntimeMethodHandle src)
            => src;

        readonly RuntimeMethodHandle Data;

        [MethodImpl(Inline)]
        public HandleAdapter(RuntimeMethodHandle src)
        {
             Data = src;
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => Data.Value;
        }

        public FPtr FunctionPointer
        {
            [MethodImpl(Inline)]
            get => Data.GetFunctionPointer();
        }

        public string Format(HandleFormatKind kind)
            => kind switch {
                HandleAddress => Address.Format(),
                PointerAddress => FunctionPointer.Format(),
                _ => sys.@as<RuntimeMethodHandle,MemoryAddress>(Data).Format()
            };

        public override string ToString()
            => Format(HandleAddress);

        [MethodImpl(Inline)]
        public static implicit operator HandleAdapter(RuntimeMethodHandle src)
            => new HandleAdapter(src);

    }
}