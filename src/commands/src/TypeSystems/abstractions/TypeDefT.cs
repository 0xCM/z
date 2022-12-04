//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace TypeSystems
{
    public abstract class TypeDef<T> : IType<T>
    {
        public abstract @string Scope { get; }

        internal Option<TypeDefAttribute> Tag => GetType().Tag<TypeDefAttribute>();

        public virtual TypeName Name 
            => Tag.MapValueOrDefault(tag => (TypeName)tag.TypeName, (TypeName)typeof(T).Name);

        public Type RuntimeType 
            => typeof(T);

        public virtual T Value(params object[] args)
            => Factory()(args);
                
        public virtual Func<object[],T> Factory() 
            => (object[] args) => (T)Activator.CreateInstance(typeof(T),args);
    }
}