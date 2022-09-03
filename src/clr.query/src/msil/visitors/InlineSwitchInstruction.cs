// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class InlineSwitchInstruction : ILInlineInstruction
    {
        readonly int[] _deltas;

        int[] _targetOffsets;

        public InlineSwitchInstruction(int offset, OpCode opCode, int[] deltas)
            : base(offset, opCode)
        {
            _deltas = deltas;
        }

        public int[] Deltas => (int[])_deltas.Clone();

        public int[] TargetOffsets
        {
            get
            {
                if (_targetOffsets == null)
                {
                    int cases = _deltas.Length;
                    int itself = 1 + 4 + 4 * cases;
                    _targetOffsets = new int[cases];
                    for (int i = 0; i < cases; i++)
                        _targetOffsets[i] = Offset + _deltas[i] + itself;
                }

                return _targetOffsets;
            }
        }

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineSwitchInstruction(this);
    }
}