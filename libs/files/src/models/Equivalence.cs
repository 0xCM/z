//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Equivalence
    {
        public static ClassLookup lookup()
            => new ClassLookup();

        public readonly struct Class : IEquatable<Class>
        {
            public uint ClassId {get;}

            public string ClassName {get;}

            [MethodImpl(Inline)]
            public Class(uint id, string name)
            {
                ClassId = id;
                ClassName = name;
            }

            public string Format()
                => ClassName;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(Class src)
                => ClassName.Equals(src.ClassName);

            public override int GetHashCode()
                => ClassName.GetHashCode();

            public override bool Equals(object src)
                => src is Class c && Equals(c);

            [MethodImpl(Inline)]
            public static bool operator ==(Class a, Class b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(Class a, Class b)
                => !a.Equals(b);

            [MethodImpl(Inline)]
            public static implicit operator Class((uint id, string name) src)
                => new Class(src.id, src.name);
        }

        public readonly struct ClassMember: IEquatable<ClassMember>
        {
            public Class Class {get;}

            public uint MemberId {get;}

            public string MemberName {get;}

            [MethodImpl(Inline)]
            public ClassMember(Class @class, uint id, string name)
            {
                Class = @class;
                MemberId = id;
                MemberName = name;
            }

            public string Format()
                => string.Format("{0} -> {1}", MemberName, Class.ClassName);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(ClassMember src)
                => Class.Equals(src.Class) && MemberName == src.MemberName;

            public override int GetHashCode()
                => MemberName.GetHashCode();

            public override bool Equals(object src)
                => src is Class c && Equals(c);

            [MethodImpl(Inline)]
            public static bool operator ==(ClassMember a, ClassMember b)
                => a.Equals(b);

            [MethodImpl(Inline)]
            public static bool operator !=(ClassMember a, ClassMember b)
                => !a.Equals(b);
        }

        public sealed class ClassLookup
        {
            readonly Dictionary<string,Class> NameLookup;

            readonly Dictionary<uint,Class> SurrogateLookup;

            Index<Class> IndexedClasses;

            bool Sealed;

            public ClassLookup()
            {
                NameLookup = new();
                SurrogateLookup = new();
                IndexedClasses = Index<Class>.Empty;
                Sealed = false;
            }

            public ReadOnlySpan<Class> Classes
            {
                [MethodImpl(Inline)]
                get => IndexedClasses;
            }

            public ReadOnlySpan<Class> Seal()
            {
                IndexedClasses = NameLookup.Values.Array();
                Sealed = true;
                return Classes;
            }

            public bool IsSealed
            {
                [MethodImpl(Inline)]
                get => Sealed;
            }

            public bool Include(Class src)
            {
                if(Sealed)
                    return false;

                if(NameLookup.TryAdd(src.ClassName, src))
                {
                    if(SurrogateLookup.TryAdd(src.ClassId, src))
                        return true;
                    else
                        NameLookup.Remove(src.ClassName);
                }

                return false;
            }

            public bool Find(string name, out Class dst)
                => NameLookup.TryGetValue(name, out dst);

            public bool Find(uint id, out Class dst)
                => SurrogateLookup.TryGetValue(id, out dst);
        }
    }
}