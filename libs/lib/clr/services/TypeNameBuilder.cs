//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;

    // This TypeNameBuilder is ported from CoreCLR's original.
    // It replaces the C++ bits of the implementation with a faithful C# port.
    [ApiHost]
    public class TypeNameBuilder
    {
        public enum FormatKind : byte
        {
            Canonical = 0,

            FullName = 1,

            AssemblyQualifiedName = 2,
        }

        public enum FormatOption : byte
        {
            None = 0,

            GenericSquares = 1
        }

        public static TypeNameBuilder create()
            => new TypeNameBuilder();

        public static string format(Type src, FormatKind kind)
        {
            if (kind == FormatKind.FullName || kind == FormatKind.AssemblyQualifiedName)
            {
                if (!src.IsGenericTypeDefinition && src.ContainsGenericParameters)
                    return null;
            }

            var tnb = new TypeNameBuilder();
            tnb.AddAssemblyQualifiedName(src, kind);
            return tnb.ToString();
        }

        [Op]
        public static bool reserved(char ch)
        {
            switch (ch)
            {
                case ',':
                case '[':
                case ']':
                case '&':
                case '*':
                case '+':
                case '\\':
                    return true;

                default:
                    return false;
            }
        }

        [Op]
        public static bool ContainsReservedChar(string name)
        {
            foreach (char c in name)
            {
                if (c == '\0')
                    break;
                if (reserved(c))
                    return true;
            }
            return false;
        }


        public override string ToString()
        {
            Debug.Assert(_instNesting == 0);

            return _str.ToString();
        }

        StringBuilder _str = new StringBuilder();

        int _instNesting;

        bool _firstInstArg;

        bool _nestedName;

        bool _hasAssemblySpec;

        bool _useAngleBracketsForGenerics;

        List<int> _stack = new List<int>();

        int _stackIdx;

        class State
        {
            public StringBuilder _str = new StringBuilder();

            public int _instNesting;

            public bool _firstInstArg;

            public bool _nestedName;

            public bool _hasAssemblySpec;

            public bool _useAngleBracketsForGenerics;

            public List<int> _stack = new List<int>();

            public int _stackIdx;
        }

        readonly State _State;

        TypeNameBuilder()
        {
            _State = new State();
        }

        TypeNameBuilder(State state)
            => _State = state;

        [Op]
        public void AddAssemblyQualifiedName(Type type, FormatKind format)
        {
            Type rootType = type;

            while (rootType.HasElementType)
                rootType = rootType.GetElementType()!;

            // Append namespace + nesting + name
            var nestings = new List<Type>();
            for (Type t = rootType; t != null; t = t.IsGenericParameter ? null : t.DeclaringType)
                nestings.Add(t);

            for (int i = nestings.Count - 1; i >= 0; i--)
            {
                Type enclosingType = nestings[i];
                string name = enclosingType.Name;

                if (i == nestings.Count - 1 && enclosingType.Namespace != null && enclosingType.Namespace.Length != 0)
                    name = enclosingType.Namespace + "." + name;

                AddName(name);
            }

            // Append generic arguments
            if (rootType.IsGenericType && (!rootType.IsGenericTypeDefinition || format == FormatKind.Canonical))
            {
                Type[] genericArguments = rootType.GetGenericArguments();

                OpenGenericArguments();
                for (int i = 0; i < genericArguments.Length; i++)
                {
                    FormatKind genericArgumentsFormat = format == FormatKind.FullName ? FormatKind.AssemblyQualifiedName : format;

                    OpenGenericArgument();
                    AddAssemblyQualifiedName(genericArguments[i], genericArgumentsFormat);
                    CloseGenericArgument();
                }
                CloseGenericArguments();
            }

            // Append pointer, byRef and array qualifiers
            AddElementType(type);

            if (format == FormatKind.AssemblyQualifiedName)
                AddAssemblySpec(type.Module.Assembly.FullName!);
        }

        [Op]
        public void SetUseAngleBracketsForGenerics(bool value)
        {
            _useAngleBracketsForGenerics = value;
        }

        [Op]
        public void AddElementType(Type type)
        {
            if (!type.HasElementType)
                return;

            AddElementType(type.GetElementType()!);

            if (type.IsPointer)
                Append('*');
            else if (type.IsByRef)
                Append('&');
            else if (type.IsSZArray)
                Append("[]");
            else if (type.IsArray)
                AddArray(type.GetArrayRank());
        }

        [Op]
        public void OpenGenericArguments()
        {
            _instNesting++;
            _firstInstArg = true;

            if (_useAngleBracketsForGenerics)
                Append('<');
            else
                Append('[');
        }

        [Op]
        public void CloseGenericArguments()
        {
            Debug.Assert(_instNesting != 0);

            _instNesting--;

            if (_firstInstArg)
            {
                _str.Remove(_str.Length - 1, 1);
            }
            else
            {
                if (_useAngleBracketsForGenerics)
                    Append('>');
                else
                    Append(']');
            }
        }

        [Op]
        public void OpenGenericArgument()
        {
            Debug.Assert(_instNesting != 0);

            _nestedName = false;

            if (!_firstInstArg)
                Append(',');

            _firstInstArg = false;

            if (_useAngleBracketsForGenerics)
                Append('<');
            else
                Append('[');

            PushOpenGenericArgument();
        }

        [Op]
        public void CloseGenericArgument()
        {
            Debug.Assert(_instNesting != 0);

            if (_hasAssemblySpec)
            {
                if (_useAngleBracketsForGenerics)
                    Append('>');
                else
                    Append(']');
            }

            PopOpenGenericArgument();
        }

        [Op]
        public void AddName(string name)
        {
            Debug.Assert(name != null);

            if (_nestedName)
                Append('+');

            _nestedName = true;

            EscapeName(name);
        }

        [Op]
        public void AddArray(int rank)
        {
            Debug.Assert(rank > 0);

            if (rank == 1)
            {
                Append("[*]");
            }
            else if (rank > 64)
            {
                // Only taken in an error path, runtime will not load arrays of more than 32 dimensions
                _str.Append('[').Append(rank).Append(']');
            }
            else
            {
                Append('[');
                for (int i = 1; i < rank; i++)
                    Append(',');
                Append(']');
            }
        }

        [Op]
        public void AddAssemblySpec(string assemblySpec)
        {
            if (assemblySpec != null && !assemblySpec.Equals(""))
            {
                Append(", ");

                if (_instNesting > 0)
                    EscapeEmbeddedAssemblyName(assemblySpec);
                else
                    EscapeAssemblyName(assemblySpec);

                _hasAssemblySpec = true;
            }
        }

        [Op]
        public void EscapeName(string name)
        {
            if (ContainsReservedChar(name))
            {
                foreach (char c in name)
                {
                    if (c == '\0')
                        break;
                    if (reserved(c))
                        _str.Append('\\');
                    _str.Append(c);
                }
            }
            else
                Append(name);
        }

        [Op]
        public void EscapeAssemblyName(string name)
        {
            Append(name);
        }

        [Op]
        public void EscapeEmbeddedAssemblyName(string name)
        {
            if (name.Contains(']'))
            {
                foreach (char c in name)
                {
                    if (c == ']')
                        Append('\\');

                    Append(c);
                }
            }
            else
            {
                Append(name);
            }
        }

        [Op]
        void PushOpenGenericArgument()
        {
            _stack.Add(_str.Length);
            _stackIdx++;
        }

        [Op]
        void PopOpenGenericArgument()
        {
            int index = _stack[--_stackIdx];
            _stack.RemoveAt(_stackIdx);

            if (!_hasAssemblySpec)
                _str.Remove(index - 1, 1);

            _hasAssemblySpec = false;
        }


        [Op]
        void Append(string pStr)
        {
            foreach(char c in pStr)
            {
                if (c == '\0')
                    break;
                _str.Append(c);
            }
        }

        [Op]
        void Append(char c)
        {
            _str.Append(c);
        }
    }
}