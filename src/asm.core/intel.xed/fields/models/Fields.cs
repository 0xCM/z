//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedFields;

    partial class XedRules
    {
        public readonly struct Fields
        {
            public static Fields allocate()
                => new Fields(core.alloc<Field>(Fields.MaxCount));

            [MethodImpl(Inline), Op]
            public static Field field<T>(FieldKind kind, T value)
                where T : unmanaged
                    => Field.init(kind, bw16(value));

            readonly Index<Field> Data;

            readonly Index<FieldKind> Kinds;

            public const byte MaxCount = 128;

            [MethodImpl(Inline)]
            public Fields(Field[] src)
            {
                Data = src;
                Kinds = alloc<FieldKind>(src.Length);
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => (uint)min(Data.Length, MaxCount);
            }

            [MethodImpl(Inline)]
            public Fields Clear()
            {
                Data.Clear();
                return this;
            }

            [MethodImpl(Inline)]
            public FieldSet Members()
            {
                var dst = FieldSet.create();
                for(var i=0; i<Count; i++)
                {
                    ref readonly var field = ref this[i];
                    if(field.IsNonEmpty)
                        dst.Include(field.Kind);
                }
                return dst;
            }

            [MethodImpl(Inline)]
            public ReadOnlySpan<FieldKind> MemberKinds()
            {
                var count = Members().Members(Kinds);
                return slice(Kinds.View,0, count);
            }

            public ref Field this[uint index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            public ref Field this[int index]
            {
                [MethodImpl(Inline)]
                get => ref Data[index];
            }

            [MethodImpl(Inline)]
            public ref Field Update(in FieldPack src)
            {
                ref var dst = ref this[(uint)src.Field];
                dst = field(src.Field, src.Value());
                return ref this[src.Field];
            }

            public ref Field this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref Data[(byte)kind];
            }

            public static Fields Empty => new Fields(sys.empty<Field>());
        }
    }
}