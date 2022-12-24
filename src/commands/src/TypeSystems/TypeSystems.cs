//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class TypeSystems
    {       
        public record class TypeSystem
        {
            public @string Name;

            public ReadOnlySeq<TypeDef> TypeDefs;
        }


        public record class TypeDef
        {
            public @string Scope;
            
            public TypeName Name;
        }    

        public interface ITypeSystem
        {
            @string Name {get;}
        }

        public interface ITypeSystem<T> : ITypeSystem
            where T : ITypeSystem<T>, new()
        {
            ref readonly T Instance {get;}
        }

        public abstract class TypeSystem<T> : ITypeSystem<T>
            where T : TypeSystem<T>, new()
        {
            public virtual @string Name => typeof(T).Name;

            static T _Instance = new();

            public static ref readonly T Instance => ref _Instance;

            ref readonly T ITypeSystem<T>.Instance
                => ref Instance;    
        }
        public abstract class TypeDef<R,S,T,A> : TypeDef<R,S,T>, IType<R,T,A>
            where S : ITypeSystem, new()
            where R : TypeDef<R,S,T,A>, new()
        {
            public virtual T Value(A args)
                => Factory()(args);

            public new virtual Func<A,T> Factory() 
                => a => (T)Activator.CreateInstance(typeof(T), new object[]{a});
        }    

        public abstract class TypeDef<R,T> : TypeDef<T>, IType<R,T>
            where R : TypeDef<R,T>, new()
        {
            static readonly R _Instance;

            ref readonly R IType<R,T>.Representative
                => ref _Instance;

            public static ref readonly R Representative => ref _Instance;        
        }
        public abstract class TypeDef<R,S,T> : TypeDef<R,T> 
            where S : ITypeSystem, new()
            where R : TypeDef<R,S,T>, new()
        {
            public override @string Scope 
                => new S().Name;
        }         
            public static ReadOnlySeq<TypeDef> typedefs(params Assembly[] src)
                => from type in src.Types().Tagged<TypeDefAttribute>().Concrete()
                let tag = type.Tag<TypeDefAttribute>().Require()
                select new TypeDef {
                        Scope = tag.Scope,
                        Name = text.ifempty(tag.TypeName, type.Name)
                        };




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

        public interface IType
        {
            @string Scope {get;}
            
            TypeName Name {get;}

            Type RuntimeType {get;}

            dynamic Value(params object[] args);

            dynamic Representative 
                => throw new NotImplementedException();
        }

        public interface IType<T> : IType
        {        
            Func<object[],T> Factory();

            new T Value(params object[] args) 
                => Factory()(args);
            
            dynamic IType.Value(params object[] args)
                => Value(args);
        }

        public interface IType<R,T> : IType<T>
            where R : IType
        {
            new ref readonly R Representative {get;}

            dynamic IType.Representative
                => Representative;
        }

        public interface IType<R,T,A> : IType<R,T>
            where R : IType
        {
            new Func<A,T> Factory();
                    
            T Value(A args)
                => Factory()(args);
        }


        public readonly record struct TypeName : IDataType<TypeName>, IDataString<TypeName>
        {
            readonly @string Value;

            public TypeName()
            {
                Value = @string.Empty;
            }

            [MethodImpl(Inline)]
            public TypeName(@string value)   
            {
                Value = value;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsNonEmpty;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Value.Hash;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(TypeName src)
                => Value == src.Value;

            [MethodImpl(Inline)]
            public int CompareTo(TypeName src)
                => Value.CompareTo(src.Value);

            public string Format()
                => Value.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator TypeName(Type src)
                => new TypeName(src.AssemblyQualifiedName);

            [MethodImpl(Inline)]
            public static implicit operator TypeName(string src)
                => new TypeName(src);

            [MethodImpl(Inline)]
            public static implicit operator TypeName(@string src)
                => new TypeName(src);

            public static TypeName Empty => new();
        }
    }
}
