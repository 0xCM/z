//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct MemberValue
    {
        public readonly Label Member;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public MemberValue(Label member, dynamic value)
        {
            Member = member;
            Value = value;
        }
    }

    public readonly struct MemberValues
    {
        public static MemberValues extract<T>(T src)
        {
            var props = @readonly(typeof(T).DeclaredInstanceProperties());
            var fields = @readonly(typeof(T).DeclaredInstanceFields());
            var propcount = props.Length;
            var fieldcount = fields.Length;
            var count = propcount + fieldcount;
            var dst = alloc<MemberValue>(count);
            var j=0u;
            for(var i=0; i<propcount; i++)
            {
                ref readonly var prop = ref skip(props,i);
                seek(dst,j++) = new MemberValue(prop.Name, prop.GetValue(src));
            }
            for(var i=0; i<fieldcount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(dst,j++) = new MemberValue(field.Name, field.GetValue(src));
            }

            return dst;
        }

        readonly Index<MemberValue> Data;

        [MethodImpl(Inline)]
        public MemberValues(MemberValue[] src)
        {
            Data = src;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref MemberValue this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref MemberValue this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public MemberValue Value(int i)
            => Data[i];

        [MethodImpl(Inline)]
        public MemberValue Value(uint i)
            => Data[i];

        [MethodImpl(Inline)]
        public MemberValue<T> Value<T>(int i)
            => Data[i];

        [MethodImpl(Inline)]
        public MemberValue<T> Value<T>(uint i)
            => Data[i];

        public static implicit operator MemberValues(MemberValue[] src)
            => new MemberValues(src);
    }

    public readonly struct MemberValue<T>
    {
        public readonly Label Member;

        public readonly T Value;

        [MethodImpl(Inline)]
        public MemberValue(Label member, T value)
        {
            Member = member;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator MemberValue<T>(MemberValue src)
            => new MemberValue<T>(src.Member, src.Value);
    }
}