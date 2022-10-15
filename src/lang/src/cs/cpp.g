// From llvm
grammar cpp;

Lower : [a-z];

Upper: [A-Z];

Letter : Lower | Upper;

Digit: [0..9];

Underscore: '_';

IdentifierLead : Letter | Underscore;

IdentifierTail : Letter | Digit | Underscore;

Identifier : IdentifierLead(IdentifierTail)*;

AsciSymbol : 
     '+'
   | '-'
   ;

FoldOperator : 
     '+' 
   | '-'
   | '*'
   | '/'
   | '%'
   | '^'
   | '|'
   | '<<'
   | 'greatergreater'
   | '+='
   | '-='
   | '*='
   | '/='
   | '%='
   | '^='
   | '&='
   | '|='
   | '<<='
   | '>>='
   | '='
   | '=='
   | '!='
   | '<'
   | '>'
   | '<='
   | '>='
   | '&&'
   | '||'
   | ','
   | '.*'
   | '->*'
   ;
