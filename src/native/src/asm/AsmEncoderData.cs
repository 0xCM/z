//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    public class AsmEncoderData
    {
        const byte ConditionCount = 16;

        const byte Jcc8Base = 0x70;

        const byte Jcc32Base = 0x80;

        [MethodImpl(Inline)]
        public static AsmEncoderData get()
            => Instance;

        [MethodImpl(Inline)]
        public ReadOnlySpan<Jcc8Code> Jcc8Codes()
            => _Jcc8Codes;

        [MethodImpl(Inline)]
        public ReadOnlySpan<Jcc8AltCode> Jcc8AltCodes()
            => _Jcc8AltCodes.View;

        [MethodImpl(Inline)]
        public ReadOnlySpan<Jcc32Code> Jcc32Codes()
            => _Jcc32Codes;

        [MethodImpl(Inline)]
        public ReadOnlySpan<Jcc32AltCode> Jcc32AltCodes()
            => _Jcc32AltCodes.View;

        [MethodImpl(Inline), Op]
        public JccInfo Describe(Jcc8Code code)
            => new JccInfo(code, Name(code));

        [MethodImpl(Inline), Op]
        public JccInfo Describe(Jcc8AltCode code)
            => new JccInfo(code, Name(code));

        [MethodImpl(Inline), Op]
        public JccInfo Describe(Jcc32Code code)
            => new JccInfo(code,Name(code));

        [MethodImpl(Inline), Op]
        public JccInfo Describe(Jcc32AltCode code)
            => new JccInfo(code,Name(code));

        [MethodImpl(Inline)]
        public ref readonly text7 Name(Jcc8Code src)
            => ref _Jcc8Names[(byte)(src - Jcc8Base)];

        [MethodImpl(Inline)]
        public ref readonly text7 Name(Jcc8AltCode src)
            => ref _Jcc8AltNames[(byte)(src - Jcc8Base)];

        [MethodImpl(Inline)]
        public ref readonly text7 Name(Jcc32Code src)
            => ref _Jcc32Names[(byte)(src - Jcc32Base)];

        [MethodImpl(Inline)]
        public ref readonly text7 Name(Jcc32AltCode src)
            => ref _Jcc32AltNames[(byte)(src - Jcc32Base)];

        Index<Jcc8Code> _Jcc8Codes;

        Index<Jcc8AltCode> _Jcc8AltCodes;

        Index<Jcc32Code> _Jcc32Codes;

        Index<Jcc32AltCode> _Jcc32AltCodes;

        Index<text7> _Jcc8Names;

        Index<text7> _Jcc8AltNames;

        Index<text7> _Jcc32Names;

        Index<text7> _Jcc32AltNames;

        AsmEncoderData()
        {
            Load();
        }

        void Load()
        {

            var jcc8a = Symbols.index<Jcc8Code>();
            Require.equal(jcc8a.Count, ConditionCount);

            _Jcc8Names = alloc<text7>(ConditionCount);
            FixedChars.expr(jcc8a, _Jcc8Names.Edit);

            _Jcc8Codes = alloc<Jcc8Code>(ConditionCount);
            Symbols.kinds(jcc8a, _Jcc8Codes.Edit);

            var jcc8b = Symbols.index<Jcc8AltCode>();
            Require.equal(jcc8b.Count, ConditionCount);

            _Jcc8AltNames = alloc<text7>(ConditionCount);
            FixedChars.expr(jcc8b, _Jcc8AltNames.Edit);

            _Jcc8AltCodes = alloc<Jcc8AltCode>(ConditionCount);
            Symbols.kinds(jcc8b, _Jcc8AltCodes.Edit);

            var jcc32a = Symbols.index<Jcc32Code>();
            Require.equal(jcc32a.Count, ConditionCount);

            _Jcc32Names = alloc<text7>(ConditionCount);
            FixedChars.expr(jcc32a, _Jcc32Names.Edit);

            _Jcc32Codes = alloc<Jcc32Code>(ConditionCount);
            Symbols.kinds(jcc32a, _Jcc32Codes.Edit);

            var jcc32b = Symbols.index<Jcc32AltCode>();
            Require.equal(jcc32b.Count, ConditionCount);

            _Jcc32AltNames = alloc<text7>(ConditionCount);
            FixedChars.expr(jcc32b, _Jcc32AltNames.Edit);

            _Jcc32AltCodes = alloc<Jcc32AltCode>(ConditionCount);
            Symbols.kinds(jcc32b, _Jcc32AltCodes.Edit);
        }

        static AsmEncoderData Instance = new();
    }
}