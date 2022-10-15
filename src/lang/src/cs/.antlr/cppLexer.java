// Generated from d:\env\dev\projects\z0\src\lang\src\cs\cpp.g by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class cppLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		Lower=1, Upper=2, Letter=3, Digit=4, Underscore=5, IdentifierLead=6, IdentifierTail=7, 
		Identifier=8, AsciSymbol=9, FoldOperator=10;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"Lower", "Upper", "Letter", "Digit", "Underscore", "IdentifierLead", 
			"IdentifierTail", "Identifier", "AsciSymbol", "FoldOperator"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, null, null, "'_'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "Lower", "Upper", "Letter", "Digit", "Underscore", "IdentifierLead", 
			"IdentifierTail", "Identifier", "AsciSymbol", "FoldOperator"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public cppLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "cpp.g"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\fr\b\1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\3\2\3\2\3\3\3\3\3\4\3\4\5\4\36\n\4\3\5\3\5\3\6\3\6\3\7\3\7\5\7&\n"+
		"\7\3\b\3\b\3\b\5\b+\n\b\3\t\3\t\7\t/\n\t\f\t\16\t\62\13\t\3\n\3\n\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\13"+
		"\3\13\3\13\5\13q\n\13\2\2\f\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25"+
		"\f\3\2\b\3\2c|\3\2C\\\5\2\60\60\62\62;;\4\2--//\b\2\'\',-//\61\61``~~"+
		"\4\2>>@@\2\u008d\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13"+
		"\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2"+
		"\2\3\27\3\2\2\2\5\31\3\2\2\2\7\35\3\2\2\2\t\37\3\2\2\2\13!\3\2\2\2\r%"+
		"\3\2\2\2\17*\3\2\2\2\21,\3\2\2\2\23\63\3\2\2\2\25p\3\2\2\2\27\30\t\2\2"+
		"\2\30\4\3\2\2\2\31\32\t\3\2\2\32\6\3\2\2\2\33\36\5\3\2\2\34\36\5\5\3\2"+
		"\35\33\3\2\2\2\35\34\3\2\2\2\36\b\3\2\2\2\37 \t\4\2\2 \n\3\2\2\2!\"\7"+
		"a\2\2\"\f\3\2\2\2#&\5\7\4\2$&\5\13\6\2%#\3\2\2\2%$\3\2\2\2&\16\3\2\2\2"+
		"\'+\5\7\4\2(+\5\t\5\2)+\5\13\6\2*\'\3\2\2\2*(\3\2\2\2*)\3\2\2\2+\20\3"+
		"\2\2\2,\60\5\r\7\2-/\5\17\b\2.-\3\2\2\2/\62\3\2\2\2\60.\3\2\2\2\60\61"+
		"\3\2\2\2\61\22\3\2\2\2\62\60\3\2\2\2\63\64\t\5\2\2\64\24\3\2\2\2\65q\t"+
		"\6\2\2\66\67\7>\2\2\67q\7>\2\289\7i\2\29:\7t\2\2:;\7g\2\2;<\7c\2\2<=\7"+
		"v\2\2=>\7g\2\2>?\7t\2\2?@\7i\2\2@A\7t\2\2AB\7g\2\2BC\7c\2\2CD\7v\2\2D"+
		"E\7g\2\2Eq\7t\2\2FG\7-\2\2Gq\7?\2\2HI\7/\2\2Iq\7?\2\2JK\7,\2\2Kq\7?\2"+
		"\2LM\7\61\2\2Mq\7?\2\2NO\7\'\2\2Oq\7?\2\2PQ\7`\2\2Qq\7?\2\2RS\7(\2\2S"+
		"q\7?\2\2TU\7~\2\2Uq\7?\2\2VW\7>\2\2WX\7>\2\2Xq\7?\2\2YZ\7@\2\2Z[\7@\2"+
		"\2[q\7?\2\2\\q\7?\2\2]^\7?\2\2^q\7?\2\2_`\7#\2\2`q\7?\2\2aq\t\7\2\2bc"+
		"\7>\2\2cq\7?\2\2de\7@\2\2eq\7?\2\2fg\7(\2\2gq\7(\2\2hi\7~\2\2iq\7~\2\2"+
		"jq\7.\2\2kl\7\60\2\2lq\7,\2\2mn\7/\2\2no\7@\2\2oq\7,\2\2p\65\3\2\2\2p"+
		"\66\3\2\2\2p8\3\2\2\2pF\3\2\2\2pH\3\2\2\2pJ\3\2\2\2pL\3\2\2\2pN\3\2\2"+
		"\2pP\3\2\2\2pR\3\2\2\2pT\3\2\2\2pV\3\2\2\2pY\3\2\2\2p\\\3\2\2\2p]\3\2"+
		"\2\2p_\3\2\2\2pa\3\2\2\2pb\3\2\2\2pd\3\2\2\2pf\3\2\2\2ph\3\2\2\2pj\3\2"+
		"\2\2pk\3\2\2\2pm\3\2\2\2q\26\3\2\2\2\b\2\35%*\60p\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}