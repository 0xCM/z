//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        /// <summary>
        /// Computes the <see cref='TableId'/> of a parametrically-identified record
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static TableId identify<T>()
            where T : struct
                => TableId.identify<T>();

        [Op]
        public static TableId identify(Type type)
            => TableId.identify(type);

        [Op]
        public static TableId identify(Type type, string name)
            => TableId.identify(type, name);
    }
}