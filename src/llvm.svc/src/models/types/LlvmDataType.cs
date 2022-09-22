//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct LlvmDataType : IComparable<LlvmDataType>, IEquatable<LlvmDataType>
    {
        public readonly LlvmTypeKind Kind;

        public readonly Identifier Name;

        public readonly Index<string> Parameters;

        public readonly string Spec;

        [MethodImpl(Inline)]
        public LlvmDataType(Identifier name, LlvmTypeKind kind, string[] parameters)
        {
            Name = name;
            Kind = kind;
            Parameters = parameters;
            Spec = EmptyString;
            Spec = format(this);
        }

        public byte Arity
        {
            [MethodImpl(Inline)]
            get => (byte)Parameters.Count;
        }

        public bool IsParametric
        {
            [MethodImpl(Inline)]
            get => Arity != 0;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Spec);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Spec);
        }

        public bool IsKnown
            => Kind != 0;

        public bool IsBits
            => Kind == LlvmTypeKind.Bits;

        public bool IsBit
            => Kind == LlvmTypeKind.Bit;

        public bool IsString
            => Kind == LlvmTypeKind.String;

        public bool IsInt
            => Kind == LlvmTypeKind.Int;

        public bool IsDag
            => Kind == LlvmTypeKind.Dag;

        public bool IsNameList
            => Kind == LlvmTypeKind.NameList;

        public bool Equals(LlvmDataType src)
            => Spec.Equals(src.Spec);

        public override int GetHashCode()
            => Spec.GetHashCode();

        public override bool Equals(object src)
            => src is LlvmDataType t && Equals(t);

        public int CompareTo(LlvmDataType src)
            => Spec.CompareTo(src.Spec);

        public string Format()
            => Spec;

        public override string ToString()
            => Format();

        public static LlvmDataType Empty => new LlvmDataType(EmptyString,0,sys.empty<string>());

        static string format(in LlvmDataType src)
        {
            var arity = src.Arity;
            if(arity == 0)
                return src.Name;

            var dst = text.buffer();
            dst.AppendFormat("{0}<", src.Name);

            for(var i=0; i<arity; i++)
            {
                dst.Append(src.Parameters[i]);
                if(i!= arity - 1)
                    dst.Append(Chars.Comma);
            }

            dst.Append(">");

            return dst.Emit();
        }
   }
}