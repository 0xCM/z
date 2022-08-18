//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies an internal or external tool
    /// </summary>
    public struct ToolIdOld
    {
        public string Id {get;}

        [MethodImpl(Inline)]
        public ToolIdOld(string id)
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

        [MethodImpl(Inline)]
        public string Format()
            => Id;

        public override string ToString()
            => Id;

        public int CompareTo(ToolIdOld src)
            => IsNonEmpty ? Id.CompareTo(src.Id) : -1;

        [MethodImpl(Inline)]
        public bool Equals(ToolIdOld src)
            => Id.Equals(src.Id);

        public override int GetHashCode()
            => Id.GetHashCode();

        public override bool Equals(object src)
            => src is ToolIdOld x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator ToolIdOld(string src)
            => new ToolIdOld(src);


        [MethodImpl(Inline)]
        public static implicit operator string(ToolIdOld src)
            => src.Id;

        [MethodImpl(Inline)]
        public static bool operator ==(ToolIdOld a, ToolIdOld b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ToolIdOld a, ToolIdOld b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator ToolIdOld(Type src)
            => new ToolIdOld(src.Name);

        public static ToolIdOld Empty
        {
            [MethodImpl(Inline)]
            get => new ToolIdOld(EmptyString);
        }
    }
}