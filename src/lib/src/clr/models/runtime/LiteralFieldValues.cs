//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    public readonly struct LiteralFieldValues<F>
        where F : unmanaged
    {
        readonly FieldInfo[] FieldSpecs;

        readonly F[] FieldValues;

        [MethodImpl(Inline)]
        public LiteralFieldValues(FieldInfo[] specs, F[] values)
        {
            FieldSpecs = specs;
            FieldValues = values;
        }

        public Count Count
        {
            [MethodImpl(Inline)]
            get => FieldSpecs.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => FieldSpecs.Length;
        }

        public ReadOnlySpan<FieldInfo> Fields
        {
            [MethodImpl(Inline)]
            get => FieldSpecs;
        }

        public ReadOnlySpan<F> Values
        {
            [MethodImpl(Inline)]
            get => FieldValues;
        }

        [MethodImpl(Inline)]
        public string Name(ulong index)
            => FieldSpecs[index].Name;

        [MethodImpl(Inline)]
        public ref readonly F Value(ulong index)
            => ref FieldValues[index];

        public ref readonly F this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref Value(index);
        }

        [MethodImpl(Inline)]
        public ref readonly FieldInfo Spec(ulong index)
            => ref FieldSpecs[index];

        [MethodImpl(Inline)]
        public RenderWidth Width(F f)
            => @as<F,byte>(f);
    }
}