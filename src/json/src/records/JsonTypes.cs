//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost("json/primitives")]
    public class JsonTypes 
    {
        public static ReadOnlySpan<IJsonType> Types => Lookup.Values;

        public sealed record class Parameter : IJsonParameter<Parameter>
        {
            public Parameter(string name)
            {
                Name = name;
            }

            public Parameter()
            {
                Name = EmptyString;
            }

            public @string Name {get;}


            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name.IsNonEmpty;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Name.Hash;
            }

            public int CompareTo(Parameter src)
                => Name.CompareTo(src.Name);

            public override int GetHashCode()
                => Hash;

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            public bool Equals(Parameter src)
                => Name.Equals(src.Name);

            [MethodImpl(Inline)]
            public static implicit operator Parameter(string name)
                => new(name);
        }

        public sealed class Parameters : Seq<Parameters,Parameter>
        {
            public Parameters()
            {

            }

            public Parameters(params Parameter[] src)
                : base(src)
            {

            }
            
        }

        public sealed record class Date : JsonDataType<Date> 
        {
            public const string TypeName = "date";

            public Date()
                : base(TypeName)
            {

            }
        }

        public sealed record class Time : JsonDataType<Time> 
        {
            public const string TypeName = "time";

            public Time()
                : base(TypeName)
            {

            }
        }

        public sealed record class Timestamp : JsonDataType<Timestamp>
        {
            public const string TypeName = "timestamp";

            public Timestamp()
                : base(TypeName)
            {

            }
        }

        public sealed record class Array : JsonDataType<Array> 
        {
            public const string TypeName = "array<${T}>";

            public Array()
                : base(TypeName)
            {

            }
        }

        public sealed record class Record : JsonDataType<Record>
        {
            public const string TypeName = "record<${T}>";

            public Record()
                : base(TypeName)
            {

            }
        }

        public sealed record class Records : JsonDataType<Records>
        {
            public const string TypeName = "array<record<${T}>>";

            public Records()
                : base(TypeName)
            {

            }
        }

        public sealed record class Url : JsonDataType<Url>
        {
            public const string TypeName = "url";

            public Url()
                : base(TypeName)
            {

            }
        }

        public sealed record class File : JsonDataType<File>
        {
            public const string TypeName = "file";

            public File()
                : base(TypeName)
            {

            }
        }

        public sealed record class Folder : JsonDataType<Folder>
        {
            public const string TypeName = "folder";

            public Folder()
                : base(TypeName)
            {

            }
        }

        public sealed record class Path : JsonDataType<Path>
        {
            public const string TypeName = "path";

            public Path()
                : base(TypeName)
            {

            }
        }

        public sealed record class Text : JsonDataType<Text>
        {
            public const string TypeName = "text";

            public Text()
                : base(TypeName)
            {

            }
        }

        public sealed record class Bit : JsonDataType<Bit>
        {
            public const string TypeName = "bit";

            public Bit()
                : base(TypeName)
            {

            }
        }

        public sealed record class Bits : JsonDataType<Bits>
        {
            public const string TypeName = "bits<${n}>";

            public Bits()
                : base(TypeName)
            {

            }
        }

        public sealed record class Bool : JsonDataType<Bool>
        {
            public const string TypeName = "bool";

            public Bool()
                : base(TypeName)
            {

            }
        }

        public sealed record class I8 : JsonDataType<I8>
        {
            public const string TypeName = "i8";

            public I8()
                : base(TypeName)
            {

            }
        }

        public sealed record class U8 : JsonDataType<U8>
        {
            public const string TypeName = "u8";

            public U8()
                : base(TypeName)
            {

            }
        }

        public sealed record class I16 : JsonDataType<I16>
        {
            public const string TypeName = "i16";

            public I16()
                : base(TypeName)
            {

            }
        }

        public sealed record class U16 : JsonDataType<U16>
        {
            public const string TypeName = "u16";

            public U16()
                : base(TypeName)
            {

            }
        }

        public sealed record class I32 : JsonDataType<I32>
        {
            public const string TypeName = "i32";

            public I32()
                : base(TypeName)
            {

            }
        }

        public sealed record class U32 : JsonDataType<U32>
        {
            public const string TypeName = "u32";

            public U32()
                : base(TypeName)
            {

            }
        }

        public sealed record class I64 : JsonDataType<I64>
        {
            public const string TypeName = "i64";

            public I64()
                : base(TypeName)
            {

            }
        }

        public sealed record class U64 : JsonDataType<U64>
        {
            public const string TypeName = "u64";

            public U64()
                : base(TypeName)
            {

            }
        }

        public sealed record class F32 : JsonDataType<F32>
        {
            public const string TypeName = "f32";

            public F32()
                : base(TypeName)
            {

            }
        }

        public sealed record class F64 : JsonDataType<F64>
        {
            public const string TypeName = "f64";

            public F64()
                : base(TypeName)
            {

            }
        }

        static readonly ConstLookup<@string,IJsonType> Lookup;

        static IJsonType factory(Type src)
            => (IJsonType)Activator.CreateInstance(src);

        static JsonTypes()
        {
            Lookup = typeof(JsonTypes).GetNestedTypes().Concrete().Select(factory).Select(x => (x.Name,x)).ToConstLookup();
        }
    }        
}