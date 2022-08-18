//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ListItem : IListItem
    {
        public readonly uint Key;

        public readonly object Value;

        [MethodImpl(Inline)]
        public ListItem(uint key, object value)
        {
            Key = key;
            Value = value;
        }

        uint IListItem.Key 
            => Key;

        object IListItem.Value 
            => Value;
    }
}