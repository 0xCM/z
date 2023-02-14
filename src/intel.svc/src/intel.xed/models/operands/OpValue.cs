//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XedModels
    {
        public enum OpDataKind : byte
        {
            None,

            Scale,

            Reg,

            Imm,

            Disp,
        }

        public struct OpValue
        {
            public ref readonly OpNameKind Name
            {
                [MethodImpl(Inline)]
                get => ref @as<OpNameKind>(_Data[0]);
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

            internal ref readonly Disp Disp
            {
                [MethodImpl(Inline)]
                get => ref @as<Disp>(_Data[2]);
            }

            ref readonly MemoryScale Scale
            {
                [MethodImpl(Inline)]
                get => ref @as<MemoryScale>(_Data[2]);
            }

            ref readonly Register Reg
            {
                [MethodImpl(Inline)]
                get => ref @as<Register>(_Data[2]);
            }

            ref readonly Imm Imm
            {
                [MethodImpl(Inline)]
                get => ref @as<Imm>(_Data[2]);
            }

            public ref readonly OpDataKind DataKind
            {
                [MethodImpl(Inline)]
                get => ref @as<OpDataKind>(_Data[1]);
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