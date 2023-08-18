//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    partial class XedModels
    {
        public struct OpValue
        {
            public OpNameKind Name
            {
                [MethodImpl(Inline)]
                get => @as<OpNameKind>(_Data[0]);
            }

            readonly ByteBlock16 _Data;

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, MemoryScale value)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)name;
                data[1] = (byte)OpDataKind.Scale;
                data[2] = (byte)value;
                _Data = data;
            }

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, Register value)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)name;
                data[1] = (byte)OpDataKind.Reg;
                @as<Register>(data[2]) = value;
                _Data = data;
            }

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, Imm value)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)name;
                data[1] = (byte)OpDataKind.Imm;
                @as<Imm>(data[2]) = value;
                _Data = data;
            }

            [MethodImpl(Inline)]
            public OpValue(OpNameKind name, Disp value)
            {
                var data = ByteBlock16.Empty;
                data[0] = (byte)name;
                data[1] = (byte)OpDataKind.Disp;
                @as<Disp>(data[2]) = value;
                _Data = data;
            }

            internal Disp Disp
            {
                [MethodImpl(Inline), UnscopedRef]
                get => @as<Disp>(_Data[2]);
            }

            MemoryScale Scale
            {
                [MethodImpl(Inline)]
                get => @as<MemoryScale>(_Data[2]);
            }

            Register Reg
            {
                [MethodImpl(Inline)]
                get => @as<Register>(_Data[2]);
            }

            Imm Imm
            {
                [MethodImpl(Inline)]
                get => @as<Imm>(_Data[2]);
            }

            public OpDataKind DataKind
            {
                [MethodImpl(Inline)]
                get => @as<OpDataKind>(_Data[1]);
            }

            public string Format()
            {
                var dst = EmptyString;
                switch(DataKind)
                {
                    case OpDataKind.Scale:
                        dst = Scale.Format();
                    break;
                    case OpDataKind.Reg:
                        dst = Reg.Format();
                    break;
                    case OpDataKind.Disp:
                        dst = Disp.Format();
                    break;
                    case OpDataKind.Imm:
                        dst = Imm.Format();
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator Disp(OpValue src)
                => src.Disp;

            [MethodImpl(Inline)]
            public static explicit operator Imm(OpValue src)
                => src.Imm;

            [MethodImpl(Inline)]
            public static explicit operator MemoryScale(OpValue src)
                => src.Scale;

            [MethodImpl(Inline)]
            public static explicit operator Register(OpValue src)
                => src.Reg;

            public static OpValue Empty => new OpValue(OpNameKind.None, ScaleFactor.None);
        }
    }
}