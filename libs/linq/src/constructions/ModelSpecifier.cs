//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0.DynamicModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class ModelSpecifier
    {
        public static ModelSpecifier<M,T> Create<M,T>(ModelQueryProvider<M> provider)
            => new ModelSpecifier<M,T>(provider);
    }

    public class ModelSpecifier<T> :
        IModelSpecifier,
        IQueryable<T>,
        IQueryable,
        IEnumerable<T>,
        IEnumerable,
        IOrderedQueryable<T>,
        IOrderedQueryable
    {
        protected readonly IQueryProvider Provider;

        protected readonly Expression Content;

        public ModelSpecifier(ModelQueryProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            this.Provider = provider;
            this.Content = Expression.Constant(this);
        }

        public ModelSpecifier(ModelQueryProvider provider, Expression content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            if (!typeof(IQueryable<T>).IsAssignableFrom(content.Type))
                throw new ArgumentOutOfRangeException(nameof(content));

            Provider = provider;
            Content = content;
        }

        Expression IQueryable.Expression
            => Content;

        Type IQueryable.ElementType
            => typeof(T);

        IQueryProvider IQueryable.Provider
            => Provider;

        public IEnumerator<T> GetEnumerator()
            => ((IEnumerable<T>)Provider.Execute(Content)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)Provider.Execute(Content)).GetEnumerator();

        object IModelSpecifier.SpecifyModel()
            => Provider.Execute(Content);

        public override string ToString()
            => Provider.Execute(Content).ToString();
    }

    public class ModelSpecifier<M,T> : ModelSpecifier<T>, IModelSpecifier<M>
    {
        public ModelSpecifier(ModelQueryProvider<M> provider)
            : base(provider)
        { }

        public ModelSpecifier(ModelQueryProvider<M> provider, Expression X)
            : base(provider, X)
        { }

        public M SpecifyModel()
            => (M)Provider.Execute(Content);
    }
}