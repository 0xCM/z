// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.IO;
    using Z0;

    public class RichILStringToTextWriter : ReadableILStringToTextWriter
    {
        readonly Dictionary<int,int> _startCounts = new Dictionary<int,int>();

        readonly Dictionary<int,Type> _startCatch = new Dictionary<int,Type>();

        readonly Dictionary<int,int> _endCounts = new Dictionary<int,int>();

        readonly HashSet<int> _startFinally = new HashSet<int>();

        readonly HashSet<int> _startFault = new HashSet<int>();

        readonly HashSet<int> _startFilter = new HashSet<int>();

        string _indent = "";

        public RichILStringToTextWriter(TextWriter writer, ExceptionInfo[] exceptions)
            : base(writer)
        {
            foreach (var e in exceptions)
            {
                int startCount = 0;
                if (!_startCounts.TryGetValue(e.StartAddress, out startCount))
                {
                    _startCounts.Add(e.StartAddress, startCount);
                }

                _startCounts[e.StartAddress] += e.Handlers.Length;

                foreach (var c in e.Handlers)
                {
                    if (c.Kind == ExceptionHandlerKind.Finally)
                        _startFinally.Add(c.StartAddress);
                    else if (c.Kind == ExceptionHandlerKind.Fault)
                        _startFault.Add(c.StartAddress);
                    else if (c.Kind == ExceptionHandlerKind.Filter)
                        _startFilter.Add(c.StartAddress);
                    else
                        _startCatch.Add(c.StartAddress, c.Type);

                    int endCount = 0;

                    if (!_endCounts.TryGetValue(c.EndAddress, out endCount))
                    {
                        _endCounts.Add(c.EndAddress, endCount);
                    }

                    _endCounts[c.EndAddress]++;
                }
            }
        }

        public override void Process(ILInlineInstruction instruction, string operandString)
        {
            int endCount = 0;
            if (_endCounts.TryGetValue(instruction.Offset, out endCount))
            {
                for (var i = 0; i<endCount; i++)
                {
                    Dedent();
                    _writer.WriteLine(_indent + "}");
                }
            }

            int startCount = 0;
            if (_startCounts.TryGetValue(instruction.Offset, out startCount))
            {
                for (var i = 0; i < startCount; i++)
                {
                    _writer.WriteLine(_indent + ".try");
                    _writer.WriteLine(_indent + "{");
                    Indent();
                }
            }

            var t = default(Type);
            if (_startCatch.TryGetValue(instruction.Offset, out t))
            {
                Dedent();
                _writer.WriteLine(_indent + "}");
                _writer.WriteLine(_indent + $"catch ({t.GetILSig()})");
                _writer.WriteLine(_indent + "{");
                Indent();
            }

            if (_startFilter.Contains(instruction.Offset))
            {
                Dedent();
                _writer.WriteLine(_indent + "}");
                _writer.WriteLine(_indent + "filter");
                _writer.WriteLine(_indent + "{");
                Indent();
            }

            if (_startFinally.Contains(instruction.Offset))
            {
                Dedent();
                _writer.WriteLine(_indent + "}");
                _writer.WriteLine(_indent + "finally");
                _writer.WriteLine(_indent + "{");
                Indent();
            }

            if (_startFault.Contains(instruction.Offset))
            {
                Dedent();
                _writer.WriteLine(_indent + "}");
                _writer.WriteLine(_indent + "fault");
                _writer.WriteLine(_indent + "{");
                Indent();
            }

            _writer.WriteLine(string.Format("{3}IL_{0:x4}: {1,-10} {2}", instruction.Offset, instruction.OpCode.Name, operandString, _indent));
        }

        public void Indent()
        {
            _indent = new string(' ', _indent.Length + 2);
        }

        public void Dedent()
        {
            _indent = new string(' ', _indent.Length - 2);
        }
    }
}
