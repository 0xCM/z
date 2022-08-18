//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PropFormat : ITextual
    {
        public NameOld Name {get;}

        public dynamic Value {get;}

        public sbyte Pad {get;}

        [MethodImpl(Inline)]
        internal PropFormat(NameOld name, dynamic value, sbyte pad)
        {
            Name = name;
            Value = value;
            Pad = pad;
        }

        public string Format(char sep)
            => string.Format("{0}{1}{2}",
                string.Format(RpOps.pad(Pad), Name),
                string.Format("{0} ", sep),
                    Value);

        public string Format()
            => Format(RpOps.PropertySep);

        public override string ToString()
            => Format();
    }

    public readonly struct PropFormat<T> : ITextual
    {
        public NameOld Name {get;}

        public T Value {get;}

        public sbyte Pad {get;}

        [MethodImpl(Inline)]
        public PropFormat(NameOld name, T value, sbyte pad)
        {
            Name = name;
            Value = value;
            Pad = pad;
        }

        [MethodImpl(Inline)]
        public PropFormat(NameOld name, T value)
        {
            Name = name;
            Value = value;
            Pad = RpOps.PropertyPad;
        }

        public string Format(char sep)
            => string.Format("{0}{1}{2}",
                string.Format(RpOps.pad(Pad), Name),
                string.Format("{0} ",sep),
                    Value);

        public string Format()
            => Format(RpOps.PropertySep);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PropFormat<T>((string name, T value) src)
            => new PropFormat<T>(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator PropFormat<T>((string name, T value, int pad) src)
            => new PropFormat<T>(src.name, src.value, (sbyte)src.pad);

        [MethodImpl(Inline)]
        public static implicit operator PropFormat(PropFormat<T> src)
            => new PropFormat(src.Name, src.Value, src.Pad);
    }
}