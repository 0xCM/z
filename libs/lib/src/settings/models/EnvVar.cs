//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines a nonparametric environment variable
    /// </summary>
    [Record(TableId)]
    public readonly record struct EnvVar : IEnvVar, IDataType<EnvVar>, IExpr
    {
        const string TableId = "env";

        [Render(12)]
        public readonly EnvVarKind Kind;

        [Render(64)]
        public readonly Name VarName;

        /// <summary>
        /// The environment variable value
        /// </summary>
        [Render(1)]
        public readonly string VarValue;

        [MethodImpl(Inline)]
        public EnvVar(EnvVarKind kind, Name name, string value)
        {
            Kind = kind;
            VarName = name;
            VarValue = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => VarName.Hash | hash(VarValue);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => VarName.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => VarName.IsNonEmpty;
        }

        public bool Contains(string match)
            => text.contains(VarValue,match);

        public bool Contains(ReadOnlySpan<char> match)
            => text.contains(VarValue,match);

        public bool Contains(char match)
            => text.contains(VarValue,match);

        [MethodImpl(Inline)]
        public string Format()
            => sys.nonempty(VarValue) ? string.Format("{0}={1}", VarName, VarValue) : $"{VarName.Format()}=";


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(EnvVar src)
            => VarName.Equals(src.VarName) && string.Equals(VarValue, src.VarValue, NoCase);

        public int CompareTo(EnvVar src)
            => VarName.CompareTo(src.VarName);

        [MethodImpl(Inline)]
        public EnvVar<FS.FolderPath> AsFolderPath()
            => new(VarName,FS.dir(VarValue));

        [MethodImpl(Inline)]
        public static implicit operator string(EnvVar src)
            => src.VarValue;

        Name IVarValue.VarName
            => VarName;

        object IVarValue.VarValue
            => VarValue;

        public static EnvVar Empty
        {
            [MethodImpl(Inline)]
            get => new EnvVar(0,EmptyString, EmptyString);
        }
    }
}