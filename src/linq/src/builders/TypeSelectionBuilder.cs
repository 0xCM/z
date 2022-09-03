//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;

    public class TypeSelectionBuilder<R>
    {
        public static implicit operator Selector<Type,object,R>(TypeSelectionBuilder<R> builder)
            => builder.Finish();

        Dictionary<Type, Func<object,R>> functions { get; }
            = new Dictionary<Type, Func<object,R>>();

        readonly object value;

        public TypeSelectionBuilder()
        {

        }

        public TypeSelectionBuilder(object value)
        {
            this.value = value;
        }

        public TypeSelectionBuilder<R> When<T>(Func<T, R> f)
        {
            functions[typeof(T)] = x => f((T)x);
            return this;
        }

        public Selector<Type, object, R> Finish()
            => new Selector<Type, object, R>(functions);

        public R Eval(object value)
            => Finish().Select(value.GetType(), value);

        public R Eval()
            => Finish().Select(value.GetType(), value);
    }
}