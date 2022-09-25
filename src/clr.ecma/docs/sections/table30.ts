/*
The Document table has the following columns:
* _Name_ (Blob heap index of [document name blob](#DocumentNameBlob))
* _HashAlgorithm_ (Guid heap index)
* _Hash_ (Blob heap index)
* _Language_ (Guid heap index)

*/

import { BlobIndex, GuidIndex } from "./common"
export {}


export type Document = {
    Name:BlobIndex
    HashAlgorithm:GuidIndex
    Hash:BlobIndex
    Language:GuidIndex
}