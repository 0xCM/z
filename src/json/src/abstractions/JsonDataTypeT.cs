//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class JsonDataType<T> : JsonDataType, IJsonType<T>
        where T : JsonDataType<T>, new()
    {
        protected JsonDataType(string name)
            : base(name)
        {
        }

        public static ref readonly T Type => ref _Type;

        public virtual bool Equals(T? src)
            => src == null ? false : Name == src.Name;

        public int CompareTo(T? src)
            => src == null ? 0 : Name.CompareTo(src.Name);

        static T _Type = new();
    }            
}