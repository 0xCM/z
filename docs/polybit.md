# Polybit

## Bitfield Specification

A *bitfield* is a blittable type B with instance data D that can be presented as partition P defined
by named segments s0...s(N-1) of designated widths. A bitfield can thus be characterized
by a single enum E with N literals where each literal value specifies the width of a corresponding segment in P

A *bitvector* of length N is a bitfield with N segments, each of width 1. A bitvector can thus be characterized
by a sequence of names n0..n(N-1)

A *bitfield pattern* is a sequence of characters with segments partitioned by the space character ' ' with widths determined
by the length of a given partition. In this mannner a single string can characterize a bitfield