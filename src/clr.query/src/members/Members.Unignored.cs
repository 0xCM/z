//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects source members that are not tagged with <see cref='IgnoreAttribute'/>
        /// </summary>
        /// <param name="src">The members to examine</param>
        /// <param name="name">The name to match</param>
        public static T[] Unignored<T>(this T[] src)
            where T : MemberInfo
                => src.Where(m => !m.Tagged(typeof(IgnoreAttribute)));

        /// <summary>
        /// Selects source methods that are not tagged with <see cref='IgnoreAttribute'/>
        /// </summary>
        /// <param name="src">The source methods</param>
        /// <param name="name">The name to match</param>
        [Op]
        public static MethodInfo[] Unignored(this MethodInfo[] src)
        {
            var dst = new List<MethodInfo>();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var method = ref src[i];
                var ignored = method.Tagged(typeof(IgnoreAttribute));
                var name = method.Name;
                var declarer = method.DeclaringType;
                var isGetter = name.Contains("get_");
                var isSetter = name.Contains("set_");

                if(ignored)
                    continue;

                if(!method.IsSpecialName)
                {
                    dst.Add(method);
                    continue;
                }

                if(!isGetter && !isSetter)
                {
                    dst.Add(method);
                    continue;
                }

                if(isGetter)
                {
                    var getterName = name.Replace("get_", EmptyString);
                    var getter = declarer.Members(getterName).FirstOrDefault();
                    var getterIgnored = getter != null && getter.Tagged(typeof(IgnoreAttribute));
                    if(!getterIgnored)
                        dst.Add(method);

                }
                else //setter
                {
                    var setterName = name.Replace("set_", EmptyString);
                    var setter = declarer.Members(setterName).FirstOrDefault();
                    var setterIgnored = setter != null && setter.Tagged(typeof(IgnoreAttribute));
                    if(!setterIgnored)
                        dst.Add(method);
                }

            }

            return dst.ToArray();
        }
    }
}