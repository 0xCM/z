//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using static CMake.Types;

    partial class CMake
    {
        public class Values
        {
            public sealed record class Unknown : Value<Unknown, UnknownType>
            {
                readonly dynamic? Data;
                
                public override bool IsEmpty 
                {
                    [MethodImpl(Inline)]
                    get => Data == null;
                }

                public Unknown(dynamic data)
                {
                    Data = data;
                }

                public Unknown()
                {
                    Data = null;
                }

                public override string Format()
                    => Data is Value v ? v.Format() : EmptyString;
            }

            public sealed record class Bool : Value<Bool, BoolType>
            {
                readonly bool? Data;
                
                public override bool IsEmpty 
                {
                    [MethodImpl(Inline)]
                    get => Data == null;
                }

                public Bool(bool data)
                {
                    Data = data;
                }

                public Bool()
                {
                    Data = null;
                }

                [MethodImpl(Inline)]
                public static implicit operator Bool(bool src)
                    => new Bool(src);

                public override string Format()
                    => Data == null ? EmptyString : Data.Value.ToString();
            }

            public sealed record class String : Value<String, StringType>
            {
                readonly string? Data;

                public override bool IsEmpty
                {
                    [MethodImpl(Inline)]
                    get => Data == null;
                }

                public String(string data)
                {
                    Data = data ?? EmptyString;
                }

                public String()
                {
                    Data = null;
                }

                [MethodImpl(Inline)]
                public static implicit operator String(string src)
                    => new String(src);

                public override string Format()
                    => text.quote(Data ?? EmptyString);
            }

            public sealed record class File : Value<File, FileType>
            {
                readonly FilePath Data;

                public override bool IsEmpty
                {
                    [MethodImpl(Inline)]
                    get => Data.IsEmpty;
                }

                public File(FilePath data)
                {
                    Data = data;
                }

                public File()
                {
                    Data = FilePath.Empty;
                }

                [MethodImpl(Inline)]
                public static implicit operator File(FilePath src)
                    => new File(src);

                public override string Format()
                    => Data.Format(PathSeparator.FS, true);
            }

            public sealed record class Folder : Value<Folder, FolderType>
            {
                readonly FolderPath Data;

                public Folder(FolderPath data)
                {
                    Data = data;
                }

                public Folder()
                {
                    Data = FolderPath.Empty;
                }

                public override bool IsEmpty
                {
                    [MethodImpl(Inline)]
                    get => Data.IsEmpty;
                }

                [MethodImpl(Inline)]
                public static implicit operator Folder(FolderPath src)
                    => new Folder(src);

                public override string Format()
                    => Data.Format(PathSeparator.FS, true);
            }
        }
    }
}