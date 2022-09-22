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
        public MemberInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrDataMember(PropertyInfo src)
            => Definition = src;

        [MethodImpl(Inline)]
        public ClrDataMember(FieldInfo src)
            => Definition = src;

        public bool IsField
        {
            [MethodImpl(Inline)]
            get => Definition is FieldInfo;
        }

        public bool IsProperty
        {
            [MethodImpl(Inline)]
            get => Definition is PropertyInfo;
        }

        public ClrArtifactKind Kind
        {
            [MethodImpl(Inline)]
            get => IsField ? ClrArtifactKind.Field : ClrArtifactKind.Property;
        }

        public object GetValue(object o)
        {
            var objType = o.GetType();
            var declarer = Definition.DeclaringType;
            return IsField ? (Definition as FieldInfo).GetValue(o)
                : (Definition as PropertyInfo).GetValue(o);
        }

        public T GetValue<T>(object o)
            => (T)(IsField ? (Definition as FieldInfo).GetValue(o)
                : (Definition as PropertyInfo).GetValue(o));

        public void SetValue(object o, object value)
        {
            if (IsField)
                (Definition as FieldInfo).SetValue(o, value);
            else
                (Definition as PropertyInfo).SetValue(o, value);
        }

        /// <summary>
        /// The member name
        /// </summary>
        public string Name
            => Definition.Name;

        /// <summary>
        /// The type of data represented by the member
        /// </summary>
        public Type DataType
        {
             [MethodImpl(Inline)]
             get => IsField ? (Definition as FieldInfo).FieldType : (Definition as PropertyInfo).PropertyType;
        }

        public ClrArtifactKind ClrKind
        {
            [MethodImpl(Inline)]
            get => IsField ? ClrArtifactKind.Field : ClrArtifactKind.Assembly;
        }

        public CliToken Token
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