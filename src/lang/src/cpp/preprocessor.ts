
const Source = `https://docs.microsoft.com/en-us/cpp/preprocessor/grammar-summary-c-cpp?view=msvc-170`
const Description =
`
control-line:
 #define identifier token-stringopt
 #define identifier ( identifieropt , ... , identifieropt ) token-stringopt
 #include "path-spec"
 #include <path-spec>
 #line digit-sequence "filename"opt
 #undef identifier
 #error token-string
 #pragma token-string

constant-expression:
 defined( identifier )
 defined identifier
 any other constant expression

conditional:
 if-part elif-partsopt else-partopt endif-line

if-part:
 if-line text

if-line:
 #if constant-expression
 #ifdef identifier
 #ifndef identifier

elif-parts:
 elif-line text
 elif-parts elif-line text

elif-line:
 #elif constant-expression

else-part:
 else-line text

else-line:
 #else

endif-line:
 #endif

digit-sequence:
 digit
 digit-sequence digit

digit: one of
 0 1 2 3 4 5 6 7 8 9

token-string:
 String of token

token:
 keyword
 identifier
 constant
 operator
 punctuator

filename:
 Legal operating system filename

path-spec:
 Legal file path

text:
 Any sequence of text
`