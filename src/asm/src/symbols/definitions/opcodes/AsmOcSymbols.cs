//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[LiteralProvider("asm")]
public readonly struct AsmOcSymbols
{
    public const string W0 = "W0";

    public const string W1 = "W1";

    public const string Rex = "REX";

    public const string RexR = "REX.R";

    public const string RexW = "REX.W";

    public const string Vex = "VEX";

    public const string Evex = "EVEX";

    public const string NP = "NP";

    public const string F2 = "F2";

    public const string F3 = "F3";

    public const string x0F38 = x0F + "38";

    public const string x0F3A = x0F + "3A";

    public const string n0 = "0";

    public const string n1 = "1";

    public const string n2 = "2";

    public const string n3 = "3";

    public const string n4 = "4";

    public const string n5 = "5";

    public const string n6 = "6";

    public const string n128 = "128";

    public const string n256 = "256";

    public const string n512 = "512";

    public const string L0 = "L0";

    public const string L1 = "L1";

    public const string L2 = "L2";

    public const string LZ = "LZ";

    public const string Vsib = "/vsib";

    public const string Sep = " ";

    public const string Plus = "+";

    public const string Dot = ".";

    public const string W = "W";

    public const string LIG = "LIG";

    public const string WIG = "WIG";

    public const string R = "R";

    public const string B = "B";

    public const string X = "X";

    public const string cb = "cb";

    public const string cw = "cw";

    public const string cd = "cd";

    public const string cp = "cp";

    public const string co = "co";

    public const string ct = "ct";

    public const string ib = "ib";

    public const string iw = "iw";

    public const string id = "id";

    public const string io = "io";

    public const string ST0 = "+0";

    public const string ST1 = "+1";

    public const string ST2 = "+2";

    public const string ST3 = "+3";

    public const string ST4 = "+4";

    public const string ST5 = "+5";

    public const string ST6 = "+6";

    public const string ST7 = "+7";

    public const string RRM = "/r";

    public const string rd0 = "/0";

    public const string rd1 = "/1";

    public const string rd2 = "/2";

    public const string rd3 = "/3";

    public const string rd4 = "/4";

    public const string rd5 = "/5";

    public const string rd6 = "/6";

    public const string rd7 = "/7";

    public const string mmmmm = "mmmmm";

    public const string mmmm = "mmmm";

    public const string RPrime = "R'";

    public const string b = "b";

    public const string VPrime = "V'";

    public const string LPrimeL = "L'L";

    public const string RXB = "RXB";

    public const string vvv = "vvv";

    public const string aaa = "aaa";

    public const string vvvv = "vvvv";

    public const string pp = "pp";

    public const string gs = "gs";

    public const string fs = "fs";

    public const string es = "es";

    public const string ss = "ss";

    public const string cs = "cs";

    public const string ds = "ds";

    public const string k1 = "{k1}";

    public const string z = "{z}";

    public const string k1z = "{k1}{z}";

    public const string rb = "+rb";

    public const string rw = "+rw";

    public const string rd = "+rd";

    public const string ro = "+ro";

    public const string NDS = "NDS";

    public const string NFx = "NFx";

    public const string x00 = "00";

    public const string x01 = "01";

    public const string x02 = "02";

    public const string x03 = "03";

    public const string x04 = "04";

    public const string x05 = "05";

    public const string x06 = "06";

    public const string x07 = "07";

    public const string x08 = "08";

    public const string x09 = "09";

    public const string x0A = "0A";

    public const string x0B = "0B";

    public const string x0C = "0C";

    public const string x0D = "0D";

    public const string x0E = "0E";

    public const string x0F = "0F";

    public const string x10 = "10";

    public const string x11 = "11";

    public const string x12 = "12";

    public const string x13 = "13";

    public const string x14 = "14";

    public const string x15 = "15";

    public const string x16 = "16";

    public const string x17 = "17";

    public const string x18 = "18";

    public const string x19 = "19";

    public const string x1A = "1A";

    public const string x1B = "1B";

    public const string x1C = "1C";

    public const string x1D = "1D";

    public const string x1E = "1E";

    public const string x1F = "1F";

    public const string x20 = "20";

    public const string x21 = "21";

    public const string x22 = "22";

    public const string x23 = "23";

    public const string x24 = "24";

    public const string x25 = "25";

    public const string x26 = "26";

    public const string x27 = "27";

    public const string x28 = "28";

    public const string x29 = "29";

    public const string x2A = "2A";

    public const string x2B = "2B";

    public const string x2C = "2C";

    public const string x2D = "2D";

    public const string x2E = "2E";

    public const string x2F = "2F";

    public const string x30 = "30";

    public const string x31 = "31";

    public const string x32 = "32";

    public const string x33 = "33";

    public const string x34 = "34";

    public const string x35 = "35";

    public const string x36 = "36";

    public const string x37 = "37";

    public const string x38 = "38";

    public const string x39 = "39";

    public const string x3A = "3A";

    public const string x3B = "3B";

    public const string x3C = "3C";

    public const string x3D = "3D";

    public const string x3E = "3E";

    public const string x3F = "3F";

    public const string x40 = "40";

    public const string x41 = "41";

    public const string x42 = "42";

    public const string x43 = "43";

    public const string x44 = "44";

    public const string x45 = "45";

    public const string x46 = "46";

    public const string x47 = "47";

    public const string x48 = "48";

    public const string x49 = "49";

    public const string x4A = "4A";

    public const string x4B = "4B";

    public const string x4C = "4C";

    public const string x4D = "4D";

    public const string x4E = "4E";

    public const string x4F = "4F";

    public const string x50 = "50";

    public const string x51 = "51";

    public const string x52 = "52";

    public const string x53 = "53";

    public const string x54 = "54";

    public const string x55 = "55";

    public const string x56 = "56";

    public const string x57 = "57";

    public const string x58 = "58";

    public const string x59 = "59";

    public const string x5A = "5A";

    public const string x5B = "5B";

    public const string x5C = "5C";

    public const string x5D = "5D";

    public const string x5E = "5E";

    public const string x5F = "5F";

    public const string x60 = "60";

    public const string x61 = "61";

    public const string x62 = "62";

    public const string x63 = "63";

    public const string x64 = "64";

    public const string x65 = "65";

    public const string x66 = "66";

    public const string x67 = "67";

    public const string x68 = "68";

    public const string x69 = "69";

    public const string x6A = "6A";

    public const string x6B = "6B";

    public const string x6C = "6C";

    public const string x6D = "6D";

    public const string x6E = "6E";

    public const string x6F = "6F";

    public const string x70 = "70";

    public const string x71 = "71";

    public const string x72 = "72";

    public const string x73 = "73";

    public const string x74 = "74";

    public const string x75 = "75";

    public const string x76 = "76";

    public const string x77 = "77";

    public const string x78 = "78";

    public const string x79 = "79";

    public const string x7A = "7A";

    public const string x7B = "7B";

    public const string x7C = "7C";

    public const string x7D = "7D";

    public const string x7E = "7E";

    public const string x7F = "7F";

    public const string x80 = "80";

    public const string x81 = "81";

    public const string x82 = "82";

    public const string x83 = "83";

    public const string x84 = "84";

    public const string x85 = "85";

    public const string x86 = "86";

    public const string x87 = "87";

    public const string x88 = "88";

    public const string x89 = "89";

    public const string x8A = "8A";

    public const string x8B = "8B";

    public const string x8C = "8C";

    public const string x8D = "8D";

    public const string x8E = "8E";

    public const string x8F = "8F";

    public const string x90 = "90";

    public const string x91 = "91";

    public const string x92 = "92";

    public const string x93 = "93";

    public const string x94 = "94";

    public const string x95 = "95";

    public const string x96 = "96";

    public const string x97 = "97";

    public const string x98 = "98";

    public const string x99 = "99";

    public const string x9A = "9A";

    public const string x9B = "9B";

    public const string x9C = "9C";

    public const string x9D = "9D";

    public const string x9E = "9E";

    public const string x9F = "9F";

    public const string xA0 = "A0";

    public const string xA1 = "A1";

    public const string xA2 = "A2";

    public const string xA3 = "A3";

    public const string xA4 = "A4";

    public const string xA5 = "A5";

    public const string xA6 = "A6";

    public const string xA7 = "A7";

    public const string xA8 = "A8";

    public const string xA9 = "A9";

    public const string xAA = "AA";

    public const string xAB = "AB";

    public const string xAC = "AC";

    public const string xAD = "AD";

    public const string xAE = "AE";

    public const string xAF = "AF";

    public const string xB0 = "B0";

    public const string xB1 = "B1";

    public const string xB2 = "B2";

    public const string xB3 = "B3";

    public const string xB4 = "B4";

    public const string xB5 = "B5";

    public const string xB6 = "B6";

    public const string xB7 = "B7";

    public const string xB8 = "B8";

    public const string xB9 = "B9";

    public const string xBA = "BA";

    public const string xBB = "BB";

    public const string xBC = "BC";

    public const string xBD = "BD";

    public const string xBE = "BE";

    public const string xBF = "BF";

    public const string xC0 = "C0";

    public const string xC1 = "C1";

    public const string xC2 = "C2";

    public const string xC3 = "C3";

    public const string xC4 = "C4";

    public const string xC5 = "C5";

    public const string xC6 = "C6";

    public const string xC7 = "C7";

    public const string xC8 = "C8";

    public const string xC9 = "C9";

    public const string xCA = "CA";

    public const string xCB = "CB";

    public const string xCC = "CC";

    public const string xCD = "CD";

    public const string xCE = "CE";

    public const string xCF = "CF";

    public const string xD0 = "D0";

    public const string xD1 = "D1";

    public const string xD2 = "D2";

    public const string xD3 = "D3";

    public const string xD4 = "D4";

    public const string xD5 = "D5";

    public const string xD6 = "D6";

    public const string xD7 = "D7";

    public const string xD8 = "D8";

    public const string xD9 = "D9";

    public const string xDA = "DA";

    public const string xDB = "DB";

    public const string xDC = "DC";

    public const string xDD = "DD";

    public const string xDE = "DE";

    public const string xDF = "DF";

    public const string xE0 = "E0";

    public const string xE1 = "E1";

    public const string xE2 = "E2";

    public const string xE3 = "E3";

    public const string xE4 = "E4";

    public const string xE5 = "E5";

    public const string xE6 = "E6";

    public const string xE7 = "E7";

    public const string xE8 = "E8";

    public const string xE9 = "E9";

    public const string xEA = "EA";

    public const string xEB = "EB";

    public const string xEC = "EC";

    public const string xED = "ED";

    public const string xEE = "EE";

    public const string xEF = "EF";

    public const string xF0 = "F0";

    public const string xF1 = "F1";

    public const string xF2 = "F2";

    public const string xF3 = "F3";

    public const string xF4 = "F4";

    public const string xF5 = "F5";

    public const string xF6 = "F6";

    public const string xF7 = "F7";

    public const string xF8 = "F8";

    public const string xF9 = "F9";

    public const string xFA = "FA";

    public const string xFB = "FB";

    public const string xFC = "FC";

    public const string xFD = "FD";

    public const string xFE = "FE";

    public const string xFF = "FF";    
}
