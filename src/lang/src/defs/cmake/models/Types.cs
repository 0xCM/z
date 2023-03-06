//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    partial class CMake
    {
        /// <summary>
        /// https://cmake.org/cmake/help/latest/prop_cache/TYPE.html
        /// BOOL          = Boolean ON/OFF value.
        /// PATH          = Path to a directory.
        /// FILEPATH      = Path to a file.
        /// STRING        = Generic string value.
        /// INTERNAL      = Do not present in GUI at all.
        /// STATIC        = Value managed by CMake, do not change.
        /// UNINITIALIZED = Type not yet specified.
        /// </summary>
        public class Types
        {
            public sealed record class UnknownType : DataType<UnknownType>
            {
                public UnknownType()
                    : base("UNINITIALIZED", TypeKind.Unknown)
                {

                }
            }

            public sealed record class InternalType : DataType<InternalType>
            {
                public InternalType()
                    : base("INTERNAL", TypeKind.Internal)
                {

                }
            }

            public sealed record class FolderType : DataType<FolderType>
            {
                public FolderType()
                    : base("PATH", TypeKind.Folder)
                {

                }
            }

            public sealed record class FileType : DataType<FileType>
            {
                public FileType()
                    : base("FILEPATH", TypeKind.File)
                {

                }
            }

            public sealed record class BoolType : DataType<BoolType>
            {
                public BoolType()
                    : base("BOOL", TypeKind.Bool)
                {

                }
            }

            public sealed record class StringType : DataType<StringType>             
            {
                public StringType()
                    : base("STRING", TypeKind.String)
                {

                }
            }

            public sealed record class StaticType : DataType<StaticType>
            {
                public StaticType()
                    : base("STATIC", TypeKind.Static)
                {

                }
            }

        }
    }
}