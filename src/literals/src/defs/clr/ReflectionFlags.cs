//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Reflection.BindingFlags;

    /// <summary>
    /// Defines useful collection of reflection binding flags
    /// </summary>
    [LiteralProvider(clr)]
    public static class ReflectionFlags
    {
        /// <summary>
        ///  All declared non-public members
        /// </summary>
        public const BindingFlags BF_Public = FlattenHierarchy | Public | Instance | Static;

        /// <summary>
        ///  All declared non-public members
        /// </summary>
        public const BindingFlags BF_NonPublic = FlattenHierarchy | NonPublic | Instance | Static;

        /// <summary>
        /// All declared static members
        /// </summary>
        public const BindingFlags BF_Static = FlattenHierarchy | Public | NonPublic | Static;

        /// <summary>
        ///  All instance members
        /// </summary>
        public const BindingFlags BF_Instance = FlattenHierarchy | Public | NonPublic | Instance;

        /// <summary>
        /// All declared instance members
        /// </summary>
        public const BindingFlags BF_DeclaredInstance = FlattenHierarchy | Public | NonPublic | Instance;

        /// <summary>
        ///  All public static members, declared or inherited
        /// </summary>
        public const BindingFlags BF_PublicStatic = FlattenHierarchy | Public | Static;

        /// <summary>
        ///  All public instance members, declared or inherited
        /// </summary>
        public const BindingFlags BF_PublicInstance = FlattenHierarchy | Public | Instance;

        /// <summary>
        ///  All declared non-public static members
        /// </summary>
        public const BindingFlags BF_NonPublicStatic = FlattenHierarchy | NonPublic | Static;

        /// <summary>
        ///  All declared non-public instance members
        /// </summary>
        public const BindingFlags BF_NonPublicInstance = FlattenHierarchy | NonPublic | Instance;

        /// <summary>
        /// All of the knowable things
        /// </summary>
        public const BindingFlags BF_World = BF_NonPublicStatic | BF_NonPublicInstance | BF_PublicInstance | BF_PublicStatic;

        /// <summary>
        ///  All members, declared or inherited
        /// </summary>
        public const BindingFlags BF_All = BF_Public | BF_Static | BF_NonPublic | BF_Instance;

        /// <summary>
        /// All declared members
        /// </summary>
        public const BindingFlags BF_Declared = DeclaredOnly | BF_Public | BF_Static | BF_NonPublic | BF_Instance;

        /// <summary>
        /// Declared public static members
        /// </summary>
        public const BindingFlags BF_DeclaredPublic = DeclaredOnly | Public | Static | Instance;

        /// <summary>
        /// Declared public instance members
        /// </summary>
        public const BindingFlags BF_DeclaredPublicInstance = DeclaredOnly | Public | Instance;

        /// <summary>
        /// Declared public static members
        /// </summary>
        public const BindingFlags BF_DeclaredPublicStatic = DeclaredOnly | Public | Static;

        /// <summary>
        /// Declared static members, both public and non-public
        /// </summary>
        public const BindingFlags BF_DeclaredStatic = DeclaredOnly | BF_Public | BF_NonPublic | BF_Static;
    }
}