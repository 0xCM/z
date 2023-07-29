//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numeric;
    using static vcpu;
    using NK = NumericKind;
    using api = Variant;

    [Free]
    public interface IVariant
    {
        /// <summary>
        /// The number of bits that are used to store the enclosed data
        /// </summary>
        int DataWidth {get;}

        /// <summary>
        /// The numeric data type if unsegmented or, if segmented, the numeric cell kind
        /// </summary>
        NumericKind CellKind {get;}
    }

    [Free]
    public interface IVariant<V> : IVariant, IEquatable<V>
        where V : unmanaged, IVariant<V>
    {

    }

    /// <summary>
    /// Defines a polymorphic unmanaged value with a <see cref='NK'/> discriminator
    /// </summary>
    public readonly struct variant : IVariant<variant>
    {
        internal readonly Vector128<ulong> Storage;

        [MethodImpl(Inline)]
        internal variant(Vector128<ulong> src)
            => Storage = src;

        [MethodImpl(Inline)]
        public variant(sbyte value)
            => Storage = Store(value, NK.I8, 8);

        [MethodImpl(Inline)]
        public variant(byte value)
            => Storage = Store(value, NK.U8, 8);

        [MethodImpl(Inline)]
        public variant(short value)
            => Storage = Store(value, NK.I16, 16);

        [MethodImpl(Inline)]
        public variant(ushort value)
            => Storage = Store(value, NK.U16, 16);

        [MethodImpl(Inline)]
        public variant(int value)
            => Storage = Store(value, NK.I32, 32);

        [MethodImpl(Inline)]
        public variant(uint value)
            => Storage = Store(value, NK.U32, 32);

        [MethodImpl(Inline)]
        public variant(long value)
            => Storage = Store(value, NK.I64, 64);

        [MethodImpl(Inline)]
        public variant(ulong value)
            => Storage = Store(value, NK.U64, 64);

        [MethodImpl(Inline)]
        public variant(float value)
            => Storage = Store(value, NK.F32, 32);

        [MethodImpl(Inline)]
        public variant(double value)
            => Storage = Store(value, NK.F64, 64);

        public NK CellKind
        {
            [MethodImpl(Inline)]
            get => (NK)cell<int>(2);
        }

        public int CellWidth
        {
            [MethodImpl(Inline)]
            get => cell<int>(3);
        }

        public int DataWidth
        {
            [MethodImpl(Inline)]
            get => CellWidth;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Storage.GetHashCode();
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(variant src)
            => Storage.Equals(src.Storage);

        public override bool Equals(object src)
            => src is variant v && Equals(v);

        public string Format()
            => api.format(this);

        public string FormatHex()
            => api.hex(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        Vector128<T> to<T>()
            where T : unmanaged
                => sys.generic<T>(Storage);

        [MethodImpl(Inline)]
        internal T cell<T>(byte index)
            where T : unmanaged
                => vcell(to<T>(), index);

        ulong Low64
        {
            [MethodImpl(Inline)]
            get => vcell(Storage,0);
        }

        [MethodImpl(Inline)]
        static Vector128<ulong> Store(ulong value, NK kind, uint bitwidth)
            => SetWidth(Vector128.Create(value, (ulong)kind), (uint)bitwidth);

        [MethodImpl(Inline)]
        static Vector128<ulong> Store(long value, NK kind, uint bitwidth)
            => SetWidth(Vector128.Create((ulong)value, (ulong)kind), (uint)bitwidth);

        [MethodImpl(Inline)]
        static Vector128<ulong> Store(double value, NK kind, uint bitwidth)
            => SetWidth(Vector128.Create((ulong)value, (ulong)kind), (uint)bitwidth);

        [MethodImpl(Inline)]
        static Vector128<ulong> SetWidth(Vector128<ulong> src, uint width)
            => v64u(vcpu.vcell(v32u(src), 3, width));

        [MethodImpl(Inline)]
        public static bool operator ==(variant x, variant y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(variant x, variant y)
            => !x.Equals(y);

        [MethodImpl(Inline)]
        public static implicit operator variant(sbyte src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(byte src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(short src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(ushort src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(int src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(uint src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(long src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(ulong src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(float src)
            => new (src);

        [MethodImpl(Inline)]
        public static implicit operator variant(double src)
            => new (src);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(variant src)
            => src.cell<sbyte>(0);

        [MethodImpl(Inline)]
        public static explicit operator byte(variant src)
            => src.cell<byte>(0);

        [MethodImpl(Inline)]
        public static explicit operator short(variant src)
            => src.cell<short>(0);

        [MethodImpl(Inline)]
        public static explicit operator ushort(variant src)
            => src.cell<ushort>(0);

        [MethodImpl(Inline)]
        public static explicit operator int(variant src)
            => src.cell<int>(0);

        [MethodImpl(Inline)]
        public static explicit operator uint(variant src)
            => src.cell<uint>(0);

        [MethodImpl(Inline)]
        public static explicit operator long(variant src)
            => src.cell<long>(0);

        [MethodImpl(Inline)]
        public static explicit operator ulong(variant src)
            => src.cell<ulong>(0);

        [MethodImpl(Inline)]
        public static explicit operator float(variant src)
            => src.cell<float>(0);

        [MethodImpl(Inline)]
        public static explicit operator double(variant src)
            => src.cell<double>(0);

        public static variant Zero
            => default;
    }

    [ApiHost]
    public readonly struct Variant
    {
        [Op]
        public static string format(variant src)
        {
            var dst = EmptyString;
            if(src.CellKind.IsSigned())
                dst = src.cell<long>(0).ToString();
            else if(src.CellKind.IsUnsigned())
                dst = src.cell<ulong>(0).ToString();
            else if(src.CellKind.IsFloat32())
                dst = src.cell<float>(0).ToString();
            else if(src.CellKind.IsFloat64())
                dst = src.cell<double>(0).ToString();
            return dst;
        }

        [Op]
        public static string hex(variant src)
        {
            var dst = EmptyString;
            switch(src.CellKind)
            {
                case NK.I8:
                case NK.U8:
                    dst = ((byte)src).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.I16:
                case NK.U16:
                    dst = ((ushort)src).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.I32:
                case NK.U32:
                    dst = ((uint)src).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.I64:
                case NK.U64:
                    dst = ((ulong)src).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.F32:
                    dst = ((float)src).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
                case NK.F64:
                    dst = ((double)src).FormatHex(zpad:false,specifier:true,uppercase:true);
                break;
            }
            return dst;
        }

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static variant from<T>(T src)
            where T : unmanaged
                => from(store(force<T,ulong>(src), NumericKinds.kind<T>()));

        [MethodImpl(Inline), Op]
        public static variant define(ulong src, NumericKind dst)
            => from(store(src, dst));

        [MethodImpl(Inline), Op]
        public static variant convert(variant src, NumericKind dst)
            => from(src.Storage.WithElement(1,(ulong)dst));

        [MethodImpl(Inline)]
        public static NK kind(variant src)
            => (NK)vcell(src.Storage,1);

        [MethodImpl(Inline)]
        public static DataWidth width(variant src)
            => (DataWidth)src.DataWidth;

        [MethodImpl(Inline)]
        public static T extract<T>(variant src)
            where T : unmanaged
                => vcell(vector<T>(src), 0);

        [MethodImpl(Inline)]
        static Vector128<T> vector<T>(variant src)
            where T : unmanaged
                => sys.generic<T>(src.Storage);

        [MethodImpl(Inline)]
        static variant from(Vector128<ulong> src)
            => new variant(src);

        [MethodImpl(Inline)]
        static Vector128<ulong> store(ulong value, NK kind)
            => vcpu.vparts((ulong)value, (ulong)kind);

        [MethodImpl(Inline)]
        static Vector128<ulong> store(long value, NK kind)
            => vcpu.vparts((ulong)value, (ulong)kind);

        [MethodImpl(Inline)]
        static Vector128<ulong> store(double value, NK kind)
            => Vector128.Create(value).WithElement(1, (double)kind).AsUInt64();

        // [MethodImpl(Inline), Op]
        // public static unsafe variant scalar(Enum src)
        // {
        //     var kind = src.GetType().GetEnumUnderlyingType().NumericKind();
        //     var converted = (ulong)NumericBox.rebox(src,NumericKind.U64);
        //     return define(converted, kind);
        // }

        [MethodImpl(Inline), Op]
        public static variant define(object src, Type dst)
            => define(src, dst.NumericKind());

        [MethodImpl(Inline), Op]
        public static variant define(object src, NumericKind dst)
        {
            switch(dst)
            {
                case NK.I8:
                    return define((sbyte)src);

                case NK.U8:
                    return define((byte)src);

                case NK.I16:
                    return define((short)src);

                case NK.U16:
                    return define((ushort)src);

                case NK.I32:
                    return define((int)src);

                case NK.U32:
                    return define((uint)src);

                case NK.I64:
                    return define((long)src);

                case NK.U64:
                    return define((ulong)src);

                case NK.F32:
                    return define((float)src);

                case NK.F64:
                    return define((double)src);
            }

            return default;
        }

        [MethodImpl(Inline), Op]
        public static variant define(sbyte src)
            => from(store(src, NK.I8));

        [MethodImpl(Inline), Op]
        public static variant define(byte src)
            => from(store(src, NK.U8));

        [MethodImpl(Inline), Op]
        public static variant define(short src)
            => from(store(src, NK.I16));

        [MethodImpl(Inline), Op]
        public static variant define(ushort src)
            => from(store(src, NK.U16));

        [MethodImpl(Inline), Op]
        public static variant define(int src)
            => from(store(src, NK.I32));

        [MethodImpl(Inline), Op]
        public static variant define(uint src)
            => from(store(src, NK.U32));

        [MethodImpl(Inline), Op]
        public static variant define(long src)
            => from(store(src, NK.I64));

        [MethodImpl(Inline), Op]
        public static variant define(ulong src)
            => from(store(src, NK.U64));

        [MethodImpl(Inline), Op]
        public static variant define(float src)
            => from(store(src, NK.F32));

        [MethodImpl(Inline), Op]
        public static variant define(double src)
            => from(store(src, NK.F64));
    }
}