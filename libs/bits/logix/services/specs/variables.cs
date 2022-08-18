//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitLogicSpec
    {
        /// <summary>
        /// Defines a bit variable expression initialized to a literal value
        /// </summary>
        /// <param name="name">The variable's single-character name</param>
        /// <param name="init">The variable's initial value</param>
        [MethodImpl(Inline), Op]
        public static LogicVariable lvar(char name, bit init = default)
            => new LogicVariable((uint)name, init);

        /// <summary>
        /// Defines a bit variable expression initialized to a literal value
        /// and the variable name is defined by an integer
        /// </summary>
        /// <param name="symbol">The variable's name</param>
        /// <param name="init">The variable's initial value</param>
        [MethodImpl(Inline), Op]
        public static LogicVariable lvar(uint symbol, bit init = default)
            => new LogicVariable(symbol, init);

        /// <summary>
        /// Defines a typed logic variable expression initialized to a literal value
        /// </summary>
        /// <param name="symbol">The variable's symbolic identifier</param>
        /// <param name="init">The variable's initial value</param>
        [MethodImpl(Inline)]
        public static LogicVariable<T> lvar<T>(uint symbol, ILogicExpr<T> init)
            where T : unmanaged
                => new LogicVariable<T>(symbol, init);

        /// <summary>
        /// Defines a typed logic variable expression initialized to a literal value
        /// </summary>
        /// <param name="symbol">The variable's name</param>
        /// <param name="init">The variable's initial value</param>
        [MethodImpl(Inline)]
        public static LogicVariable<T> lvar<T>(char symbol, bit init = default)
            where T : unmanaged
                => new LogicVariable<T>((uint)symbol, init);

        /// <summary>
        /// Defines a typed logic variable expression initialized to a literal value
        /// </summary>
        /// <param name="symbol">The variable's name</param>
        /// <param name="init">The variable's initial value</param>
        [MethodImpl(Inline)]
        public static LogicVariable<T> lvar<T>(uint symbol, bit init = default)
            where T : unmanaged
                => new LogicVariable<T>(symbol, init);

        /// <summary>
        /// Defines a specified number n of logic variable expressions where each variable is respectively named 0,..., n - 1
        /// </summary>
        /// <param name="n">The number of variables to define</param>
        [Op]
        public static LogicVariable[] lvars(uint n)
        {
            var vars = new LogicVariable[n];
            for(var i =0u; i<n; i++)
                vars[i] = lvar(i);
            return vars;
        }

        /// <summary>
        /// Defines a specified number n of typed logic variable expressions where each variable is respectively named 0,..., n - 1
        /// </summary>
        /// <param name="n">The number of variables to define</param>
        public static LogicVariable<T>[] lvars<T>(uint n)
            where T : unmanaged
        {
            var vars = new LogicVariable<T>[n];
            for(var i=0u; i<n; i++)
                vars[i] = lvar<T>(i);
            return vars;
        }

        /// <summary>
        /// Creates a varied expression predicated on a specified variable sequence
        /// </summary>
        /// <param name="expr">The variable-dependent expression</param>
        /// <param name="vars">The variable sequence</param>
        [MethodImpl(Inline), Op]
        public static VariedLogicExpr varied(ILogicExpr expr, params LogicVariable[] vars)
            => new VariedLogicExpr(expr, vars);

        /// <summary>
        /// Creates a varied expression predicated on a specified variable sequence
        /// </summary>
        /// <param name="expr">The variable-dependent expression</param>
        /// <param name="vars">The variable sequence</param>
        [MethodImpl(Inline)]
        public static VariedLogicExpr<T> varied<T>(ILogicExpr<T> expr, params LogicVariable<T>[] vars)
            where T : unmanaged
                => new VariedLogicExpr<T>(expr, vars);
    }
}