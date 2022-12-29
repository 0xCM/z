//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static JsonRecords;

    [ApiHost("json/primitives")]
    public class JsonPrimitives 
    {

        public static ref readonly I8 i8() => ref I8.Type;

        public static ref readonly U8 u8() => ref U8.Type;

        public static ref readonly I16 i16() => ref I16.Type;

        public static ref readonly U16 u16() => ref U16.Type;

        public static ref readonly Text text() => ref Text.Type;

        public static ref readonly File file() => ref File.Type;

        public static ref readonly Folder folder() => ref Folder.Type;

        public static ref readonly Path path() => ref Path.Type;

        public static ref readonly Url url() => ref Url.Type;

        public sealed record class Url : DataType<Url>
        {
            public const string TypeName = "url";

            public Url()
                : base(TypeName)
            {

            }
        }

        public sealed record class File : DataType<File>
        {
            public const string TypeName = "file";

            public File()
                : base(TypeName)
            {

            }
        }

        public sealed record class Folder : DataType<Folder>
        {
            public const string TypeName = "folder";

            public Folder()
                : base(TypeName)
            {

            }
        }

        public sealed record class Path : DataType<Path>
        {
            public const string TypeName = "path";

            public Path()
                : base(TypeName)
            {

            }
        }

        public sealed record class Text : DataType<Text>
        {
            public const string TypeName = "text";

            public Text()
                : base(TypeName)
            {

            }
        }

        public sealed record class I8 : DataType<I8>
        {
            public const string TypeName = "i8";

            public I8()
                : base(TypeName)
            {

            }
        }

        public sealed record class U8 : DataType<U8>
        {
            public const string TypeName = "u8";

            public U8()
                : base(TypeName)
            {

            }
        }

        public sealed record class I16 : DataType<I16>
        {
            public const string TypeName = "i16";

            public I16()
                : base(TypeName)
            {

            }
        }

        public sealed record class U16 : DataType<U16>
        {
            public const string TypeName = "u16";

            public U16()
                : base(TypeName)
            {

            }
        }

        static readonly ConstLookup<@string,JsonRecords.IDataType> Types;

        static JsonPrimitives()
        {
            Types = new JsonRecords.IDataType[]{
                i8(),
                u8(),
                i16(),
                u16(),
                text(),
            }.Map(x => (x.Name, x)).ToDictionary();
        }
    }        
}