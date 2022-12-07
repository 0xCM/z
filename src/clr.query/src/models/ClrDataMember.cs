//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Unifies fields and properties from a structural metadata represetnation perspective
    /// </summary>
    public readonly struct ClrDataMember : IRuntimeMember<ClrDataMember,MemberInfo>
    {
        /// <summary>
        /// The represented member
        /// </summary>
        public readonly MemberInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrDataMember(PropertyInfo src)
            => Definition = src;

        [MethodImpl(Inline)]
        public ClrDataMember(FieldInfo src)
            => Definition = src;

        bool IsField
        {
            [MethodImpl(Inline)]
            get => Definition is FieldInfo;
        }

        bool IsProperty
        {
            [MethodImpl(Inline)]
            get => Definition is PropertyInfo;
        }

        public Type MemberType
        {
            [MethodImpl(Inline)]
            get => Definition is FieldInfo f ? f.FieldType : (Definition as PropertyInfo).PropertyType;
        }

        public ClrArtifactKind Kind
        {
            [MethodImpl(Inline)]
            get => IsField ? ClrArtifactKind.Field : ClrArtifactKind.Property;
        }

        public object GetValue(object o)
            => Definition is FieldInfo f ? f.GetValue(o) :  (Definition as PropertyInfo).GetValue(o);

        public T GetValue<T>(object o)
            => (T)GetValue(o);

        public void SetValue(object o, object value)
        {
            if (Definition is FieldInfo f)
                f.SetValue(o, value);
            else
                (Definition as PropertyInfo).SetValue(o, value);
        }

        /// <summary>
        /// The member name
        /// </summary>
        public string Name
            => Definition.Name;

        public ClrArtifactKind ClrKind
        {
            [MethodImpl(Inline)]
            get => IsField ? ClrArtifactKind.Field : ClrArtifactKind.Assembly;
        }

        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public override string ToString()
            => Definition.ToString();

        [MethodImpl(Inline)]
        public static implicit operator ClrDataMember(PropertyInfo src)
            => new ClrDataMember(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrDataMember(FieldInfo src)
            => new ClrDataMember(src);

        [MethodImpl(Inline)]
        public static implicit operator MemberInfo(ClrDataMember src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrMember(ClrDataMember src)
            => new ClrMember(src.Definition);
    }
}