// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.IO;

    public class ReadableILStringToTextWriter : IILStringCollector
    {
        protected readonly TextWriter _writer;

        public ReadableILStringToTextWriter(TextWriter writer)
        {
            _writer = writer;
        }

        public virtual void Process(ILInlineInstruction ilInstruction, string operandString)
        {
            _writer.WriteLine("IL_{0:x4}: {1,-10} {2}", ilInstruction.Offset, ilInstruction.OpCode.Name, operandString);
        }
    }
}
