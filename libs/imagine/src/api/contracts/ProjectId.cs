//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies an internal or external tool
    /// </summary>
    public readonly record struct ProjectId : ITypedIdentity<ProjectId,string>
    {
        public readonly string Id;

        [MethodImpl(Inline)]
        public ProjectId(string id)
            => Id = id;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(Id);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !string.IsNullOrWhiteSpace(Id);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash(Id);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Id;

        public override string ToString()
            => Id;

        [MethodImpl(Inline)]
        public bool Equals(ProjectId src)
            => Id.Equals(src.Id);

        public override int GetHashCode()
            => Id.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator ProjectId(string src)
            => new ProjectId(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ProjectId src)
            => src.Id;

        [MethodImpl(Inline)]
        public static implicit operator ProjectId(Type src)
            => new ProjectId(src.Name);

        public static ProjectId Empty
        {
            [MethodImpl(Inline)]
            get => new ProjectId(EmptyString);
        }

        string ITypedIdentity<string>.Id
            => Id;
    }
}