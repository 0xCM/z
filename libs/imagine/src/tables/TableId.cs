//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TableId : ITableId
    {
        /// <summary>
        /// Computes the <see cref='TableId'/> of a parametrically-identified record
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [MethodImpl(Inline)]
        public static TableId identify<T>()
            where T : struct
                => identify(typeof(T));

        [MethodImpl(Inline)]
        public static TableId identify<T>(string name)
            where T : struct
                => identify(typeof(T), name);

        /// <summary>
        /// Computes the <see cref='TableId'/> of a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [MethodImpl(Inline)]
        public static TableId identify(Type src)
            => src.Tag<RecordAttribute>().MapValueOrElse(
                    a => new TableId(a.TableId),
                    () => new TableId(src.Name));

        [MethodImpl(Inline)]
        public static TableId identify(Type src, string name)
            => new TableId(name);

        [MethodImpl(Inline)]
        public static TableId define(string name)
            => new TableId(name);

        public Identifier Identifier {get;}

        [MethodImpl(Inline)]
        TableId(string name)
        {
            Identifier = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Identifier.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Identifier.Format();

        public override string ToString()
            => Format();

        public static TableId Empty => new TableId(EmptyString);
    }
}