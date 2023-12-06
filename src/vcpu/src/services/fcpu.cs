//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

[ApiHost, Free]
public unsafe class fcpu
{
    /// <summary>
    /// __m128 _mm_cmpnge_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(1)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vngteq(Vector128<float> x, Vector128<float> y)
        => CompareNotGreaterThanOrEqual(x, y);

    /// <summary>
    /// __m128d _mm_cmpnge_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(1)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vngteq(Vector128<double> x, Vector128<double> y)
        => CompareNotGreaterThanOrEqual(x, y);    

    /// <summary>
    /// __m128 _mm_cmple_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(2)
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vle(Vector128<float> a, Vector128<float> b)
        => CompareLessThanOrEqual(a, b);

    /// <summary>
    /// __m128d _mm_cmple_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(2)
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vle(Vector128<double> a, Vector128<double> b)
        => CompareLessThanOrEqual(a, b);

    /// <summary>
    /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vle(Vector256<float> a, Vector256<float> b)
        => Compare(a, b, FloatComparisonMode.OrderedLessThanOrEqualNonSignaling);

    /// <summary>
    /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
    /// Computes a <= b
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vle(Vector256<double> a, Vector256<double> b)
        => Compare(a, b,FloatComparisonMode.OrderedLessThanOrEqualNonSignaling);

    /// <summary>
    /// __m128 _mm_cmpgt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(6)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vgt(Vector128<float> x, Vector128<float> y)
        => CompareGreaterThan(x, y);

    /// <summary>
    /// __m128d _mm_cmpgt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(6)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vgt(Vector128<double> x, Vector128<double> y)
        => CompareGreaterThan(x, y);

    /// <summary>
    /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vgt(Vector256<float> x, Vector256<float> y)
        => Compare(x, y, FloatComparisonMode.OrderedGreaterThanNonSignaling);

    /// <summary>
    /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm,ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vgt(Vector256<double> x, Vector256<double> y)
        => Compare(x, y, FloatComparisonMode.OrderedGreaterThanNonSignaling);

    /// <summary>
    /// __m128 _mm_cmpge_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(5)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vgteq(Vector128<float> x, Vector128<float> y)
        => CompareGreaterThanOrEqual(x, y);

    /// <summary>
    /// __m128d _mm_cmpge_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(5)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vgteq(Vector128<double> x, Vector128<double> y)
        => CompareGreaterThanOrEqual(x, y);

    /// <summary>
    /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vgteq(Vector256<float> x, Vector256<float> y)
        => Compare(x, y, FloatComparisonMode.OrderedGreaterThanOrEqualNonSignaling);

    /// <summary>
    /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm,ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vgteq(Vector256<double> x, Vector256<double> y)
        => Compare(x, y, FloatComparisonMode.OrderedGreaterThanOrEqualNonSignaling);

    /// <summary>
    /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> veq(Vector256<float> x, Vector256<float> y)
        => Compare(x, y, FloatComparisonMode.UnorderedEqualNonSignaling);

    /// <summary>
    /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> veq(Vector256<double> x, Vector256<double> y)
        => Compare(x, y, FloatComparisonMode.UnorderedEqualNonSignaling);

    /// <summary>
    /// __m128 _mm_cmpneq_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(4)
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vneq(Vector128<float> a, Vector128<float> b)
        => CompareNotEqual(a, b);

    /// <summary>
    /// __m128d _mm_cmpneq_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(4)
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vneq(Vector128<double> a, Vector128<double> b)
        => CompareNotEqual(a, b);

    /// <summary>
    /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vneq(Vector256<float> a, Vector256<float> b)
        => Compare(a, b, FloatComparisonMode.OrderedNotEqualNonSignaling);

    /// <summary>
    /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vneq(Vector256<double> a, Vector256<double> b)
        => Compare(a, b, FloatComparisonMode.OrderedNotEqualNonSignaling);

    /// <summary>
    ///  __m128 _mm_cmplt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(1)
    /// </summary>
    /// <param name="lhs">The left vector</param>
    /// <param name="rhs">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vlt(Vector128<float> lhs, Vector128<float> rhs)
        => CompareLessThan(lhs, rhs);

    /// <summary>
    /// __m128d _mm_cmplt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(1)
    /// </summary>
    /// <param name="lhs">The left vector</param>
    /// <param name="rhs">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vlt(Vector128<double> lhs, Vector128<double> rhs)
        => CompareLessThan(lhs, rhs);

    /// <summary>
    /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="lhs">The left vector</param>
    /// <param name="rhs">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vlt(Vector256<float> lhs, Vector256<float> rhs)
        => Compare(lhs, rhs, FloatComparisonMode.OrderedLessThanNonSignaling);

    /// <summary>
    /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="lhs">The left vector</param>
    /// <param name="rhs">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vlt(Vector256<double> lhs, Vector256<double> rhs)
        => Compare(lhs, rhs,FloatComparisonMode.OrderedLessThanNonSignaling);

    /// <summary>
    /// __m128 _mm_andnot_ps (__m128 a, __m128 b) ANDNPS xmm, xmm/m128
    /// Effects the composite operation x & (~y) for the left and right operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vcnonimpl(Vector128<float> x, Vector128<float> y)
        => AndNot(y, x);

    /// <summary>
    ///  __m128d _mm_andnot_pd (__m128d a, __m128d b) ADDNPD xmm, xmm/m128
    /// Effects the composite operation x & (~y) for the left and right operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vcnonimpl(Vector128<double> x, Vector128<double> y)
        => AndNot(y, x);

    /// <summary>
    /// __m256 _mm256_andnot_ps (__m256 a, __m256 b) VANDNPS ymm, ymm, ymm/m256
    /// Effects the composite operation x & (~y) for the left and right operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vcnonimpl(Vector256<float> x, Vector256<float> y)
        => AndNot(y, x);

    /// <summary>
    /// __m256d _mm256_andnot_pd (__m256d a, __m256d b) VANDNPD ymm, ymm, ymm/m256
    /// Effects the composite operation x & (~y) for the left and right operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vcnonimpl(Vector256<double> x, Vector256<double> y)
        => AndNot(y, x);

    /// <summary>
    /// Computes ~(x & y) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<float> vnand(Vector128<float> x, Vector128<float> y)
        => vnot(And(x, y));

    /// <summary>
    /// Computes ~(x & y) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector128<double> vnand(Vector128<double> x, Vector128<double> y)
        => vnot(And(x, y));

    /// <summary>
    /// Computes ~(x & y) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<float> vnand(Vector256<float> x, Vector256<float> y)
        => vnot(And(x, y));

    /// <summary>
    /// Computes ~(x & y) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nand]
    public static Vector256<double> vnand(Vector256<double> x, Vector256<double> y)
        => vnot(And(x, y));

    /// <summary>
    /// Computes XOR(x,NOT(y)) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vxornot(Vector128<float> x, Vector128<float> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes XOR(x,NOT(y)) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vxornot(Vector128<double> x, Vector128<double> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes XOR(x,NOT(y)) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vxornot(Vector256<float> x, Vector256<float> y)
        => Xor(x, vnot(y));

    /// <summary>
    /// Computes XOR(x,NOT(y)) for vectors x and y
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vxornot(Vector256<double> x, Vector256<double> y)
        => Xor(x, vnot(y));        
    /// <summary>
    /// __m128d _mm_cmp_pd (__m128d a, __m128d b, const int imm8)
    /// VCMPPD xmm, xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="mode"></param>
    public static Vector128<double> cmp(Vector128<double> left, Vector128<double> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
        => Compare(left,right,mode);

    /// <summary>
    /// __m128 _mm_cmp_ps (__m128 a, __m128 b, const int imm8)
    /// VCMPPS xmm, xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="mode"></param>
    public static Vector128<float> cmp(Vector128<float> left, Vector128<float> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
        => Compare(left,right,mode);
    
    /// <summary>
    /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8)
    /// VCMPPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="mode"></param>
    public static Vector256<double> cmp(Vector256<double> left, Vector256<double> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
        => Compare(left,right,mode);

    /// <summary>
    /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8)
    /// VCMPPS ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="mode"></param>
    public static Vector256<float> cmp(Vector256<float> left, Vector256<float> right, [ConstantExpected(Max = FloatComparisonMode.UnorderedTrueSignaling)] FloatComparisonMode mode)
        => Compare(left,right,mode);

    /// <summary>
    /// __m128 _mm_cmpeq_ps (__m128 a, __m128 b)
    /// CMPPS xmm, xmm/m128, imm8(0)
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Vector128<float> cmpeq(Vector128<float> left, Vector128<float> right)
        => CompareEqual(left,right);

    /// <summary>
    /// __m128d _mm_cmpeq_pd (__m128d a, __m128d b)
    /// CMPPD xmm, xmm/m128, imm8(0)
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Vector128<double> cmpeq(Vector128<double> left, Vector128<double> right)
        => CompareEqual(left,right);

    /// <summary>
    /// __m256 _mm256_cmpeq_ps (__m256 a, __m256 b)
    /// CMPPS ymm, ymm/m256, imm8(0)
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Vector256<float> cmpeq(Vector256<float> left, Vector256<float> right)
        => CompareEqual(left,right);

    /// <summary>
    /// __m256d _mm256_cmpeq_pd (__m256d a, __m256d b)
    /// CMPPD ymm, ymm/m256, imm8(0)
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static Vector256<double> cmpeq(Vector256<double> left, Vector256<double> right)
        => CompareEqual(left,right);

    /// <summary>
    /// __m128 _mm_rcp_ps (__m128 a) RCPPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vrcp(Vector128<float> x)
        => Reciprocal(x);

    /// <summary>
    /// __m256 _mm256_rcp_ps (__m256 a) VRCPPS ymm, ymm/m256
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vrcp(Vector256<float> x)
        => Reciprocal(x);

    /// <summary>
    /// dst = x*y + z
    /// __m128 _mm_fmadd_ps (__m128 a, __m128 b, __m128 c) VFMADDPS xmm, xmm, xmm/m128
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vfmadd(Vector128<float> a, Vector128<float> b, Vector128<float> c)
        => MultiplyAdd(a, b, c);

    /// <summary>
    /// dst = x*y + z
    ///  __m128d _mm_fmadd_pd (__m128d a, __m128d b, __m128d c) VFMADDPD xmm, xmm, xmm/m128
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="b">The second operand</param>
    /// <param name="c">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vfmadd(Vector128<double> a, Vector128<double> b, Vector128<double> c)
        => MultiplyAdd(a, b, c);

    /// <summary>
    /// __m256 _mm256_fmadd_ps (__m256 a, __m256 b, __m256 c) VFMADDPS ymm, ymm, ymm/m256
    /// dst = a*b + c
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vfmadd(Vector256<float> x, Vector256<float> y, Vector256<float> z)
        => MultiplyAdd(x,y,z);

    /// <summary>
    /// __m256d _mm256_fmadd_pd (__m256d a, __m256d b, __m256d c) VFMADDPS ymm, ymm, ymm/m256
    /// dst = a*b + c
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vfmadd(Vector256<double> x, Vector256<double> y, Vector256<double> z)
        => MultiplyAdd(x,y,z);

    /// <summary>
    /// __m128d _mm_ceil_sd (__m128d a) ROUNDSD xmm, xmm/m128, imm8(10)
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vceil(Vector128<float> src)
        => Ceiling(src);

    /// <summary>
    /// __m128d _mm_ceil_pd (__m128d a) ROUNDPD xmm, xmm/m128, imm8(10)
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vceil(Vector128<double> src)
        => Ceiling(src);

    /// <summary>
    /// __m256 _mm256_ceil_ps (__m256 a) VROUNDPS ymm, ymm/m256, imm8(10)
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vceil(Vector256<float> src)
        => Ceiling(src);

    /// <summary>
    /// __m256 _mm256_ceil_pd (__m256 a) VROUNDPS ymm, ymm/m256, imm8(10)
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vceil(Vector256<double> src)
        => Ceiling(src);

    /// <summary>
    /// __m128 _mm_floor_ps (__m128 a) ROUNDPS xmm, xmm/m128, imm8(9)
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vfloor(Vector128<float> x)
        => Floor(x);

    /// <summary>
    /// __m128 _mm_floor_ps (__m128 a) ROUNDPS xmm, xmm/m128, imm8(9)
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vfloor(Vector128<double> x)
        => Floor(x);

    /// <summary>
    /// __m256 _mm256_floor_ps (__m256 a) VROUNDPS ymm, ymm/m256, imm8(9)
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vfloor(Vector256<float> x)
        => Floor(x);

    /// <summary>
    ///  __m256d _mm256_floor_pd (__m256d a) VROUNDPS ymm, ymm/m256, imm8(9)
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vfloor(Vector256<double> x)
        => Floor(x);

    /// <summary>
    /// __m128 _mm_cvtepi32_ps (__m128i a) CVTDQ2PS xmm, xmm/m128
    /// Converts an integer source vector to a floating-point target vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vconvert128x32f(Vector128<int> src)
        => ConvertToVector128Single(src);

    /// <summary>
    /// __m128 _mm_cvtpd_ps (__m128d a) CVTPD2PS xmm, xmm/m128
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vconvert128x32f(Vector128<double> src)
        => ConvertToVector128Single(src);

    /// <summary>
    /// __m128 _mm256_cvtpd_ps (__m256d a) VCVTPD2PS xmm, ymm/m256
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vconvert128x32f(Vector256<double> src)
        => ConvertToVector128Single(src);

    /// <summary>
    /// __m128i _mm_cvttps_epi32 (__m128 a) CVTTPS2DQ xmm, xmm/m128
    /// Converts a floating-point source vector to an 32-bit integer target vector with a loss of precision
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vconvert128x32i(Vector128<float> src)
        => ConvertToVector128Int32(src);

    /// <summary>
    ///  __m128i _mm256_cvtpd_epi32 (__m256d a) VCVTPD2DQ xmm, ymm/m256
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vconvert128x32i(Vector256<double> src)
        => ConvertToVector128Int32(src);

    /// <summary>
    ///  __m128i _mm_cvttpd_epi32 (__m128d a) CVTTPD2DQ xmm, xmm/m128
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vconvert128x32i(Vector128<double> src)
        => ConvertToVector128Int32(src);

    /// <summary>
    /// __m256 _mm256_cvtepi32_ps (__m256i a) VCVTDQ2PS ymm, ymm/m256
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vconvert256x32f(Vector256<int> src)
        => ConvertToVector256Single(src);

    /// <summary>
    /// __m256i _mm256_cvtps_epi32 (__m256 a) VCVTPS2DQ ymm, ymm/m256
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target width</param>
    /// <param name="t">A target type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vconvert256x32i(Vector256<float> src)
        =>  ConvertToVector256Int32(src);

    /// <summary>
    /// __m256d _mm256_cvtepi32_pd (__m128i a) VCVTDQ2PD ymm, xmm/m128
    /// 4x32i -> 4x64f
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vconvert256x64f(Vector128<int> src)
        => ConvertToVector256Double(src);


    /// <summary>
    /// __m128 _mm_div_ps (__m128 a, __m128 b)DIVPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vdiv(Vector128<float> x, Vector128<float> y)
        => Divide(x, y);

    /// <summary>
    ///  __m128d _mm_div_pd (__m128d a, __m128d b)DIVPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vdiv(Vector128<double> x, Vector128<double> y)
        => Divide(x, y);

    /// <summary>
    /// __m256 _mm256_div_ps (__m256 a, __m256 b)VDIVPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vdiv(Vector256<float> x, Vector256<float> y)
        => Divide(x, y);

    /// <summary>
    /// __m256d _mm256_div_pd (__m256d a, __m256d b)VDIVPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vdiv(Vector256<double> x, Vector256<double> y)
        => Divide(x, y);

    /// <summary>
    /// __m128 _mm_sqrt_ps (__m128 a) SQRTPS xmm, xmm/m128
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vsqrt(Vector128<float> src)
        => Sqrt(src);

    /// <summary>
    /// __m128d _mm_sqrt_pd (__m128d a) SQRTPD xmm, xmm/m128
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vsqrt(Vector128<double> src)
        => Sqrt(src);

    /// <summary>
    /// __m256 _mm256_sqrt_ps (__m256 a) VSQRTPS ymm, ymm/m256
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vsqrt(Vector256<float> src)
        => Sqrt(src);

    /// <summary>
    /// __m256d _mm256_sqrt_pd (__m256d a) VSQRTPD ymm, ymm/m256
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vsqrt(Vector256<double> src)
        => Sqrt(src);

    /// <summary>
    /// __m128 _mm_rsqrt_ps (__m128 a) RSQRTPS xmm, xmm/m128
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vrsqrt(Vector128<float> src)
        => ReciprocalSqrt(src);

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vxor1(Vector128<float> x)
        => Xor(x, CompareEqual(default(Vector128<float>), default(Vector128<float>)));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vxor1(Vector128<double> x)
        => Xor(x, CompareEqual(default(Vector128<double>), default(Vector128<double>)));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vxor1(Vector256<float> x)
        => Xor(x, Compare(default(Vector256<float>), default(Vector256<float>), FloatComparisonMode.OrderedEqualNonSignaling));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vxor1(Vector256<double> x)
        => Xor(x, Compare(default(Vector256<double>), default(Vector256<double>), FloatComparisonMode.OrderedEqualNonSignaling));

    /// <summary>
    /// __m128 _mm_fnmadd_ps (__m128 a, __m128 b, __m128 c) VFNMADDPS xmm, xmm, xmm/m128
    /// dst = -(x*y + c)
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vfman(Vector128<float> x, Vector128<float> y, Vector128<float> z)
        => MultiplyAddNegated(x,y,z);

    /// <summary>
    /// __m128d _mm_fnmadd_pd (__m128d a, __m128d b, __m128d c) VFNMADDPD xmm, xmm, xmm/m128
    /// dst = -(x*y + z)
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vfman(Vector128<double> x, Vector128<double> y, Vector128<double> z)
        => MultiplyAddNegated(x,y,z);

    /// <summary>
    /// __m256 _mm256_fnmadd_ps (__m256 a, __m256 b, __m256 c) VFNMADDPS ymm, ymm, ymm/m256
    /// dst = -(x*y + z)
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vfman(Vector256<float> x, Vector256<float> y, Vector256<float> z)
        => MultiplyAddNegated(x,y,z);

    /// <summary>
    /// __m256d _mm256_fnmadd_pd (__m256d a, __m256d b, __m256d c) VFNMADDPD ymm, ymm,ymm/m256
    /// dst = -(x*y + z)
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vfman(Vector256<double> x, Vector256<double> y, Vector256<double> z)
        => MultiplyAddNegated(x,y,z);

    /// <summary>
    /// __m128 _mm_fmaddsub_ps (__m128 a, __m128 b, __m128 c) VFMADDSUBPS xmm, xmm, xmm/m128
    /// dst = x*y - z
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vfmas(Vector128<float> x, Vector128<float> y, Vector128<float> z)
        => MultiplyAddSubtract(x,y,z);

    /// <summary>
    /// __m128d _mm_fmaddsub_pd (__m128d a, __m128d b, __m128d c) VFMADDSUBPD xmm, xmm, xmm/m128
    /// dst[i] = x[i]*y[i] + z (i is even?)
    /// dst[i] = x[i]*y[i] - z (i is odd?)
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vfmas(Vector128<double> x, Vector128<double> y, Vector128<double> z)
        => MultiplyAddSubtract(x,y,z);

    /// <summary>
    /// __m256 _mm256_fmaddsub_ps (__m256 a, __m256 b, __m256 c) VFMADDSUBPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vfmas(Vector256<float> x, Vector256<float> y, Vector256<float> z)
        => MultiplyAddSubtract(x,y,z);

    /// <summary>
    /// __m256d _mm256_fmaddsub_pd (__m256d a, __m256d b, __m256d c) VFMADDSUBPD ymm, ymm, ymm/m256
    /// dst[i] = x[i]*y[i] + z (i is even?)
    /// dst[i] = x[i]*y[i] - z (i is odd?)
    /// </summary>
    /// <param name="x">The first operand</param>
    /// <param name="y">The second operand</param>
    /// <param name="z">The third operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vfmas(Vector256<double> x, Vector256<double> y, Vector256<double> z)
        => MultiplyAddSubtract(x,y,z);

    /// <summary>
    /// _mm_round_ps:
    /// Round to nearest integer
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vround(Vector128<float> x)
        => RoundToNearestInteger(x);

    /// <summary>
    /// _mm_round_pd:
    /// Round to nearest integer
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vround(Vector128<double> x)
        => RoundToNearestInteger(x);

    /// <summary>
    /// _mm_round_ss:
    /// Round towards zero
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vroundz(Vector128<float> x)
        => RoundToZero(x);

    /// <summary>
    /// _mm_round_sd:
    /// Round towards zero
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vroundz(Vector128<double> x)
        => RoundToZero(x);

    /// <summary>
    /// _mm256_round_ps:
    /// Round to nearest integer
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vround(Vector256<float> x)
        => RoundToNearestInteger(x);

    /// <summary>
    /// __m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC) VROUNDPD ymm, ymm/m256, imm8(8)
    /// Round to nearest integer
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vround(Vector256<double> x)
        => RoundToNearestInteger(x);

    /// <summary>
    /// __m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)VROUNDPS ymm, ymm/m256, imm8(11)
    /// Round towards zero
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vroundz(Vector256<float> x)
        => RoundToZero(x);

    /// <summary>
    /// __m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC) VROUNDPD ymm, ymm/m256, imm8(11)
    /// Round towards zero
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vroundz(Vector256<double> x)
        => RoundToZero(x);

    /// <summary>
    /// __m128 _mm_mul_ps (__m128 a, __m128 b) MULPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Mul]
    public static Vector128<float> vmul(Vector128<float> x,Vector128<float> y)
        => Multiply(x, y);

    /// <summary>
    /// __m128d _mm_mul_pd (__m128d a, __m128d b) MULPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Mul]
    public static Vector128<double> vmul(Vector128<double> x,Vector128<double> y)
        => Multiply(x, y);

    /// <summary>
    /// __m256 _mm256_mul_ps (__m256 a, __m256 b) VMULPS ymm, ymm, ymm/m256
    /// Multiplies corresponding components and returns the result
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Mul]
    public static Vector256<float> vmul(Vector256<float> x,Vector256<float> y)
        => Multiply(x, y);

    /// <summary>
    /// __m256d _mm256_mul_pd (__m256d a, __m256d b) VMULPD ymm, ymm, ymm/m256
    /// Multiplies corresponding components and returns the result
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Mul]
    public static Vector256<double> vmul(Vector256<double> x, Vector256<double> y)
        => Multiply(x, y);

    /// <summary>
    /// __m128 _mm_movehl_ps (__m128 a, __m128 b) MOVHLPS xmm, xmm
    /// z[0] = x[3]
    /// z[1] = y[3]
    /// z[2] = x[0]
    /// z[3] = y[0]
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vmovehl(Vector128<float> x, Vector128<float> y)
        => MoveHighToLow(x,y);

    /// <summary>
    /// __m128 _mm_movelh_ps (__m128 a, __m128 b) MOVLHPS xmm, xmm
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vmovelh(Vector128<float> x, Vector128<float> y)
        => MoveLowToHigh(x,y);

    /// <summary>
    /// __m128 _mm_dp_ps (__m128 a, __m128 b, const int imm8) DPPS xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vdot(Vector128<float> x, Vector128<float> y, byte? control = null)
        => DotProduct(x, y, control ?? 0xFF);

    /// <summary>
    /// __m128d _mm_dp_pd (__m128d a, __m128d b, const int imm8) DPPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vdot(Vector128<double> x, Vector128<double> y, byte? control = null)
        => DotProduct(x, y, control ?? 0xFF);

    /// <summary>
    /// __m256 _mm256_dp_ps (__m256 a, __m256 b, const int imm8) VDPPS ymm, ymm, ymm/m256,
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vdot(Vector256<float> x, Vector256<float> y, byte? control = null)
        => DotProduct(x, y, control ?? 0xFF);

    /// <summary>
    /// __m128 _mm_hadd_ps (__m128 a, __m128 b) HADDPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vhadd(Vector128<float> x, Vector128<float> y)
        => HorizontalAdd(x, y);

    /// <summary>
    ///  __m128d _mm_hadd_pd (__m128d a, __m128d b) HADDPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vhadd(Vector128<double> x, Vector128<double> y)
        => HorizontalAdd(x, y);

    /// <summary>
    /// __m256 _mm256_hadd_ps (__m256 a, __m256 b) VHADDPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vhadd(Vector256<float> a, Vector256<float> b)
        => HorizontalAdd(a, b);

    /// <summary>
    /// __m256d _mm256_hadd_pd (__m256d a, __m256d b) VHADDPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vhadd(Vector256<double> x, Vector256<double> y)
        => HorizontalAdd(x, y);

    /// <summary>
    /// __m128 _mm_hsub_ps (__m128 a, __m128 b)
    /// HSUBPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vhsub(Vector128<float> x, Vector128<float> y)
        => HorizontalSubtract(x, y);

    /// <summary>
    /// __m128d _mm_hsub_pd (__m128d a, __m128d b)
    /// HSUBPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vhsub(Vector128<double> x, Vector128<double> y)
        => HorizontalSubtract(x, y);

    /// <summary>
    /// __m256 _mm256_hsub_ps (__m256 a, __m256 b) VHSUBPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vhsub(Vector256<float> x, Vector256<float> y)
        => HorizontalSubtract(x, y);

    /// <summary>
    /// __m256d _mm256_hsub_pd (__m256d a, __m256d b) VHSUBPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vhsub(Vector256<double> x, Vector256<double> y)
        => HorizontalSubtract(x, y);


    /// <summary>
    /// __m128d _mm_sub_ps (__m128d a, __m128d b) SUBPS xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vsub(Vector128<float> x, Vector128<float> y)
        => Subtract(x,y);

    /// <summary>
    /// __m128d _mm_sub_pd (__m128d a, __m128d b) SUBPD xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vsub(Vector128<double> x, Vector128<double> y)
        => Subtract(x,y);

    /// <summary>
    /// __m256 _mm256_sub_ps (__m256 a, __m256 b)
    /// VSUBPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vsub(Vector256<float> x, Vector256<float> y)
        => Subtract(x, y);

    /// <summary>
    /// __m256d _mm256_sub_pd (__m256d a, __m256d b)
    /// VSUBPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vsub(Vector256<double> x, Vector256<double> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512 _mm512_sub_ps (__m512 a, __m512 b)
    /// VSUBPS zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst{er}
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<float> vsub(Vector512<float> x, Vector512<float> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512d _mm512_sub_pd (__m512d a, __m512d b)
    /// VSUBPD zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst{er}
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<double> vsub(Vector512<double> x, Vector512<double> y)
        => Subtract(x, y);

    /// <summary>
    /// Negates each source vector component
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector512<double> vnegate(Vector512<double> x)
        => vsub(default(Vector512<double>), x);

    /// <summary>
    /// Negates each source vector component
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vnegate(Vector128<float> x)
        => vsub(default, x);

    /// <summary>
    /// Negates each source vector component
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vnegate(Vector128<double> x)
        => vsub(default, x);

    /// <summary>
    /// Negates each source vector component
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vnegate(Vector256<float> x)
        => vsub(default, x);

    /// <summary>
    /// Negates each source vector component
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vnegate(Vector256<double> x)
        => vsub(default, x);

    /// <summary>
    /// int _mm256_movemask_ps (__m256 a) VMOVMSKPS reg, ymm
    /// Constructs an integer from the most significant bit of each source vector component
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static int vmovemask(Vector256<float> src)
        => MoveMask(src);

    /// <summary>
    /// int _mm256_movemask_pd (__m256d a) VMOVMSKPD reg, ymm
    /// Constructs an integer from the most significant bit of each source vector component
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static int vmovemask(Vector256<double> src)
        => MoveMask(src);


    /// <summary>
    /// __m256 _mm256_permute2f128_ps (__m256 a, __m256 b, int imm8) VPERM2F128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vperm2x128(Vector256<float> x, Vector256<float> y, Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256d _mm256_permute2f128_pd (__m256d a, __m256d b, int imm8) VPERM2F128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vperm2x128(Vector256<double> x, Vector256<double> y, Perm2x4 spec)
        => Permute2x128(x, y, (byte)spec);

    /// <summary>
    /// __m256 _mm256_permute2f128_ps (__m256 a, __m256 b, int imm8) VPERM2F128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vperm2x128(Vector256<float> x, Vector256<float> y, [Imm] byte spec)
        => Permute2x128(x, y, spec);

    /// <summary>
    /// __m256d _mm256_permute2f128_pd (__m256d a, __m256d b, int imm8) VPERM2F128 ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vperm2x128(Vector256<double> x, Vector256<double> y, [Imm] byte spec)
        => Permute2x128(x, y, spec);

    /// <summary>
    /// Swaps hi/lo 128-bit lanes
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vswaphl(Vector256<float> x)
        => vperm2x128(x,x, Perm2x4.DA);

    /// <summary>
    /// Swaps hi/lo 128-bit lanes
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vswaphl(Vector256<double> x)
        => vperm2x128(x,x, Perm2x4.DA);        


    /// <summary>
    /// __m256 _mm256_permutevar8x32_ps (__m256 a, __m256i idx) VPERMPS ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Asm(ApiAsmClass.VPERMPS)]
    public static Vector256<float> vperm8x32(Vector256<float> src, Vector256<uint> spec)
        => PermuteVar8x32(src, spec.AsInt32());

    /// <summary>
    /// Permutes components in the source vector across lanes as specified by the control vector
    /// __m256 _mm256_permutevar8x32_ps (__m256 a, __m256i idx) VPERMPS ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The control vector</param>
    [MethodImpl(Inline), Asm(ApiAsmClass.VPERMPS)]
    public static Vector256<float> vperm8x32(Vector256<float> src, Vector256<int> spec)
        => PermuteVar8x32(src, spec);

    /// <summary>
    /// __m256d _mm256_permute4x64_pd (__m256d a, const int imm8) VPERMPD ymm, ymm/m256, imm8
    /// Permutes vector content across lanes at 64-bit granularity
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The permutation spec</param>
    [MethodImpl(Inline), Asm(ApiAsmClass.VPERMPD)]
    public static Vector256<double> vperm4x64(Vector256<double> x, [Imm] Perm4L spec)
        => Permute4x64(x,(byte)spec);

    /// <summary>
    /// __m256d _mm256_permute4x64_pd (__m256d a, const int imm8) VPERMPD ymm, ymm/m256, imm8
    /// Permutes components in the source vector across lanes as specified by the control byte
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The control byte</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vperm4x64(Vector256<double> x, [Imm] byte spec)
        => Permute4x64(x,spec);


    [MethodImpl(Inline), Op]
    public static Vector256<float> vreverse(Vector256<float> src)
        => vperm8x32(src,MRev256f32);

    /// <summary>
    /// __m128 _mm_shuffle_ps (__m128 a, __m128 b, unsigned int control) SHUFPS xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vshuffle(Vector128<float> x, Vector128<float> y, [Imm] byte spec)
        => Shuffle(x, y, spec);

    /// <summary>
    /// __m128d _mm_shuffle_pd (__m128d a, __m128d b, int immediate) SHUFPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec"></param>
    /// <remarks>
    /// dst[63:0] := (imm8[0] == 0) ? a[63:0] : a[127:64]
    /// dst[127:64] := (imm8[1] == 0) ? b[63:0] : b[127:64]
    /// </remarks>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vshuffle(Vector128<double> x, Vector128<double> y, [Imm] byte spec)
        => Shuffle(x, y, spec);

    /// <summary>
    /// Transposes a 4x4 matrix of floats, adapted from MSVC intrinsic headers
    /// </summary>
    /// <param name="row0">The first row</param>
    /// <param name="row1">The second row</param>
    /// <param name="row2">The third row</param>
    /// <param name="row3">The fourth row</param>
    [MethodImpl(Inline), Op]
    public static void vtranspose(ref Vector128<float> row0, ref Vector128<float> row1, ref Vector128<float> row2, ref Vector128<float> row3)
    {
        var tmp0 = Shuffle(row0,row1, 0x44);
        var tmp2 = Shuffle(row0, row1, 0xEE);
        var tmp1 = Shuffle(row2, row3, 0x44);
        var tmp3 = Shuffle(row2,row3, 0xEE);
        row0 = Shuffle(tmp0,tmp1, 0x88);
        row1 = Shuffle(tmp0,tmp1, 0xDD);
        row2 = Shuffle(tmp2,tmp3, 0x88);
        row3 = Shuffle(tmp2, tmp3, 0xDD);
    }

    /// <summary>
    /// __m128 _mm_unpackhi_ps (__m128 a, __m128 b) UNPCKHPS xmm, xmm/m128
    /// Creates a 128-bit vector where the lower 64 bits are taken from the
    /// higher 64 bits of the first source vector and the higher 64 bits are taken
    /// from the higher 64 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vunpackhi(Vector128<float> x, Vector128<float> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m128d _mm_unpackhi_pd (__m128d a, __m128d b) UNPCKHPD xmm, xmm/m128
    /// Creates a 128-bit vector where the lower 64 bits are taken from the
    /// higher 64 bits of the first source vector and the higher 64 bits are taken
    /// from the higher 64 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vunpackhi(Vector128<double> x, Vector128<double> y)
        => UnpackHigh(x,y);


    /// <summary>
    /// __m256 _mm256_unpackhi_ps (__m256 a, __m256 b) VUNPCKHPS ymm, ymm, ymm/m256
    /// Creates a 256-bit vector where the lower 128 bits are taken from the
    /// higher 128 bits of the first source vector and the higher 128 bits are taken
    /// from the higher 128 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vunpackhi(Vector256<float> x, Vector256<float> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256d _mm256_unpackhi_pd (__m256d a, __m256d b) VUNPCKHPD ymm, ymm, ymm/m256
    /// Creates a 256-bit vector where the lower 128 bits are taken from the
    /// higher 128 bits of the first source vector and the higher 128 bits are taken
    /// from the higher 128 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vunpackhi(Vector256<double> x, Vector256<double> y)
        => UnpackHigh(x,y);

    [MethodImpl(Inline), Op]
    public static Vector128<float> vnot(Vector128<float> a)
        => Xor(a, CompareEqual(a, a));

    [MethodImpl(Inline), Op]
    public static Vector128<double> vnot(Vector128<double> a)
        => Xor(a, CompareEqual(a, a));

    [MethodImpl(Inline), Op]
    public static Vector256<float> vnot(Vector256<float> a)
        => Xor(a, Compare(a, a, FloatComparisonMode.OrderedEqualNonSignaling));

    [MethodImpl(Inline), Op]
    public static Vector256<double> vnot(Vector256<double> a)
        => Xor(a, Compare(a, a, FloatComparisonMode.OrderedEqualNonSignaling));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vxnor(Vector128<float> x, Vector128<float> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vxnor(Vector128<double> x, Vector128<double> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vxnor(Vector256<float> x, Vector256<float> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes the bitwise XOR between operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vxnor(Vector256<double> x, Vector256<double> y)
        => vnot(Xor(x, y));

    /// <summary>
    /// Computes ~(x | y) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<float> vnor(Vector256<float> x, Vector256<float> y)
        => vnot(Or(x, y));

    /// <summary>
    /// Computes ~(x | y) for vectors x and y
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Nor]
    public static Vector256<double> vnor(Vector256<double> x, Vector256<double> y)
        => vnot(Or(x, y));


    ///  __m128 _mm_max_ps (__m128 a, __m128 b) MAXPS xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vmax(Vector128<float> x, Vector128<float> y)
        => Max(x, y);

    /// <summary>
    ///  __m128d _mm_max_pd (__m128d a, __m128d b)MAXPD xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vmax(Vector128<double> x, Vector128<double> y)
        => Max(x, y);

    /// <summary>
    /// __m256 _mm256_max_ps (__m256 a, __m256 b) VMAXPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vmax(Vector256<float> x, Vector256<float> y)
        => Max(x, y);

    /// <summary>
    /// __m256d _mm256_max_pd (__m256d a, __m256d b)VMAXPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vmax(Vector256<double> x, Vector256<double> y)
        => Max(x, y);

    /// <summary>
    /// __m128 _mm_min_ps (__m128 a, __m128 b) MINPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vmin(Vector128<float> x, Vector128<float> y)
        => Min(x, y);

    /// <summary>
    /// __m128d _mm_min_pd (__m128d a, __m128d b) MINPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vmin(Vector128<double> x, Vector128<double> y)
        => Min(x, y);

    /// <summary>
    /// __m256 _mm256_min_ps (__m256 a, __m256 b) VMINPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vmin(Vector256<float> x, Vector256<float> y)
        => Min(x, y);

    /// <summary>
    /// __m256d _mm256_min_pd (__m256d a, __m256d b) VMINPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vmin(Vector256<double> x, Vector256<double> y)
        => Min(x, y);

    /// <summary>
    /// __m128 _mm_cmpngt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(2)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vngt(Vector128<float> x, Vector128<float> y)
        => CompareNotGreaterThan(x, y);

    /// <summary>
    /// __m128d _mm_cmpngt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(2)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vngt(Vector128<double> x, Vector128<double> y)
        => CompareNotGreaterThan(x, y);

    /// <summary>
    ///  __m128d _mm_cmpnlt_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(5)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vnlt(Vector128<double> x, Vector128<double> y)
        => CompareNotLessThan(x, y);

    /// <summary>
    /// __m128 _mm_cmpnlt_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(5)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vnlt(Vector128<float> x, Vector128<float> y)
        => CompareNotLessThan(x, y);

    /// <summary>
    /// Returns true if the source vector is nonzero, false otherwise
    /// int _mm_testz_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<float> src)
        => !TestZ(src, src);

    /// <summary>
    /// Returns true if the source vector is nonzero, false otherwise
    /// int _mm_testz_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<double> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm256_testz_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<float> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_pd (__m256d a, __m256d b) VTESTPD ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<double> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm_testc_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
    /// Determines whether mask-specified source bits are all on
    /// </summary>
    /// <param name="src">The source bits</param>
    /// <param name="mask">Specifies the bits in the source to test</param>
    [MethodImpl(Inline), TestC]
    public static bit vtestc(Vector128<float> src, Vector128<float> mask)
        => TestC(src, mask);

    /// <summary>
    /// int _mm_testc_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
    /// Determines whether mask-specified source bits are all on
    /// </summary>
    /// <param name="src">The source bits</param>
    /// <param name="mask">Specifies the bits in the source to test</param>
    [MethodImpl(Inline), TestC]
    public static bit vtestc(Vector128<double> src, Vector128<double> mask)
        => TestC(src, mask);

    /// <summary>
    /// int _mm256_testc_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
    /// Determines whether mask-specified source bits are all on
    /// </summary>
    /// <param name="src">The source bits</param>
    /// <param name="mask">Specifies the bits in the source to test</param>
    [MethodImpl(Inline), TestC]
    public static bit vtestc(Vector256<float> src, Vector256<float> mask)
        => TestC(src, mask);

    /// <summary>
    /// int _mm256_testc_pd (__m256d a, __m256d b) VTESTPS ymm, ymm/m256
    /// Determines whether mask-specified source bits are all on
    /// </summary>
    /// <param name="src">The source bits</param>
    /// <param name="mask">Specifies the bits in the source to test</param>
    [MethodImpl(Inline), TestC]
    public static bit vtestc(Vector256<double> src, Vector256<double> mask)
        => TestC(src, mask);

    /// <summary>
    /// int _mm256_testz_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
    /// Determines whether all mask-specified source bits are off
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), TestZ]
    public static bit vtestz(Vector256<float> src, Vector256<float> mask)
        => TestZ(src,mask);

    /// <summary>
    /// int _mm256_testz_pd (__m256d a, __m256d b) VTESTPD ymm, ymm/m256
    /// Determines whether all mask-specified source bits are off
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), TestZ]
    public static bit vtestz(Vector256<double> src, Vector256<double> mask)
        => TestZ(src,mask);

    /// <summary>
    /// int _mm_testz_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
    /// Determines whether all mask-specified source bits are off
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), TestZ]
    public static bit vtestz(Vector128<float> src, Vector128<float> mask)
        => TestZ(src,mask);

    /// <summary>
    /// int _mm_testz_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
    /// Determines whether all mask-specified source bits are off
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="mask">The mask</param>
    [MethodImpl(Inline), TestZ]
    public static bit vtestz(Vector128<double> src, Vector128<double> mask)
        => TestZ(src,mask);

    /// <summary>
    /// int _mm_testnzc_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), TestZnC]
    public static bool vtestznc(Vector128<float> x, Vector128<float> y)
        => TestNotZAndNotC(x, y);

    /// <summary>
    /// int _mm_testnzc_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), TestZnC]
    public static bool vtestznc(Vector128<double> x, Vector128<double> y)
        => TestNotZAndNotC(x, y);

    /// <summary>
    /// int _mm256_testnzc_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), TestZnC]
    public static bool vtestznc(Vector256<float> x, Vector256<float> y)
        => TestNotZAndNotC(x, y);

    /// <summary>
    /// int _mm256_testnzc_pd (__m256d a, __m256d b)VTESTPD ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), TestZnC]
    public static bool vtestznc(Vector256<double> x, Vector256<double> y)
        => TestNotZAndNotC(x, y);

    /// <summary>
    ///  __m128 _mm_cmpeq_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(0)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> veq(Vector128<float> x, Vector128<float> y)
        => CompareEqual(x, y);

    /// <summary>
    /// __m128d _mm_cmpeq_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(0)
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> veq(Vector128<double> x, Vector128<double> y)
        => CompareEqual(x, y);

    /// <summary>
    /// __m128 _mm_and_ps (__m128 a, __m128 b) ANDPS xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vand(Vector128<float> x, Vector128<float> y)
        => And(x, y);

    /// <summary>
    /// __m128d _mm_and_pd (__m128d a, __m128d b) ANDPD xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vand(Vector128<double> x, Vector128<double> y)
        => And(x, y);

    /// <summary>
    /// __m128 _mm_and_ps (__m128 a, __m128 b) ANDPS xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vand(Vector256<float> x, Vector256<float> y)
        => And(x, y);

    /// <summary>
    /// __m128d _mm_and_pd (__m128d a, __m128d b) ANDPD xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vand(Vector256<double> x, Vector256<double> y)
        => And(x, y);


    /// <summary>
    /// int _mm_movemask_ps (__m128 a) MOVMSKPS reg, xmm
    /// Constructs an integer from the most significant bit of each source vector component
    /// </summary>
    [MethodImpl(Inline), Op]
    public static int vmovemask(Vector128<float> src)
        => MoveMask(src);

    /// <summary>
    /// int _mm_movemask_pd (__m128d a) MOVMSKPD reg, xmm
    /// Constructs an integer from the most significant bit of each source vector component
    /// </summary>
    [MethodImpl(Inline), Op]
    public static int vmovemask(Vector128<double> src)
        => MoveMask(src);

    /// <summary>
    /// __m128 _mm_unpacklo_ps (__m128 a, __m128 b) UNPCKLPS xmm, xmm/m128
    /// Creates a 128-bit vector where the lower 64 bits are taken from the
    /// lower 64 bits of the first source vector and the higher 64 bits are taken
    /// from the lower 64 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vunpacklo(Vector128<float> x, Vector128<float> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m128d _mm_unpacklo_pd (__m128d a, __m128d b) UNPCKLPD xmm, xmm/m128
    /// Creates a 128-bit vector where the lower 64 bits are taken from the
    /// lower 64 bits of the first source vector and the higher 64 bits are taken
    /// from the lower 64 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vunpacklo(Vector128<double> x, Vector128<double> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m256 _mm256_unpacklo_ps (__m256 a, __m256 b) VUNPCKLPS ymm, ymm, ymm/m256
    /// Creates a 256-bit vector where the lower 128 bits are taken from the
    /// lower 128 bits of the first source vector and the higher 128 bits are taken
    /// from the lower 128 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vunpacklo(Vector256<float> x, Vector256<float> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m256d _mm256_unpacklo_pd (__m256d a, __m256d b) VUNPCKLPD ymm, ymm, ymm/m256
    /// Creates a 256-bit vector where the lower 128 bits are taken from the
    /// lower 128 bits of the first source vector and the higher 128 bits are taken
    /// from the lower 128 bits of the second source vector
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vunpacklo(Vector256<double> x, Vector256<double> y)
        => UnpackLow(x,y);

    /// <summary>
    /// void _mm_maskstore_ps (float * mem_addr, __m128i mask, __m128 a) VMASKMOVPS m128, xmm, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="mask">The mask</param>
    /// <param name="dst">The memory reference</param>
    [MethodImpl(Inline), Op]
    public static unsafe void maskstore(Vector128<float> src, Vector128<float> mask, ref float dst)
        => MaskStore(gptr(dst), src,mask);

    /// <summary>
    /// void _mm_maskstore_pd (double * mem_addr, __m128i mask, __m128d a) VMASKMOVPD m128, xmm, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="mask">The mask</param>
    /// <param name="dst">The memory reference</param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskstore(Vector128<double> src, Vector128<double> mask, ref double dst)
        => MaskStore(gptr(dst), src,mask);

    /// <summary>
    /// void _mm256_maskstore_ps (float * mem_addr, __m256i mask, __m256 a) VMASKMOVPS m256, ymm, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="mask">The mask</param>
    /// <param name="dst">The memory reference</param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskstore(Vector256<float> src, Vector256<float> mask, ref float dst)
        => MaskStore(gptr(dst), src,mask);

    /// <summary>
    /// void _mm256_maskstore_pd (double * mem_addr, __m256i mask, __m256d a) VMASKMOVPD m256, ymm, ymm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="mask">The mask</param>
    /// <param name="dst">The memory reference</param>
    [MethodImpl(Inline), Op]
    public static unsafe void vmaskstore(Vector256<double> src, Vector256<double> mask, ref double dst)
        => MaskStore(gptr(dst), src,mask);

    /// <summary>
    /// int _mm_extract_ps (__m128 a, const int imm8)EXTRACTPS xmm, xmm/m32, imm8
    /// Extracts the value of an identified source vector component
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="pos">The zero-based index of the source component to extract</param>
    [MethodImpl(Inline), Op]
    public static float vextract(Vector128<float> src, Hex2Kind pos)
        => Extract(src, (byte)pos);

    /// <summary>
    /// __m128 _mm256_extractf128_ps (__m256 a, const int imm8) VEXTRACTF128 xmm/m128, ymm, imm8
    /// Extracts either the lo (pos = 0) or hi (pos = 1) 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="pos">The index of the lane to extract</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vextract(Vector256<float> src, byte pos)
        => ExtractVector128(src, pos);

    /// <summary>
    /// __m128d _mm256_extractf128_pd (__m256d a, const int imm8) VEXTRACTF128 xmm/m128, ymm, imm8
    /// Extracts either the lo (pos = 0) or hi (pos = 1) 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="pos">The index of the lane to extract</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vextract(Vector256<double> src, byte pos)
        => ExtractVector128(src, pos);


    /// <summary>
    /// __m128 _mm256_extractf128_ps (__m256 a, const int imm8) VEXTRACTF128 xmm/m128, ymm, imm8
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vhi(Vector256<float> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128d _mm256_extractf128_pd (__m256d a, const int imm8) VEXTRACTF128 xmm/m128, ymm, imm8
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vhi(Vector256<double> src)
        => ExtractVector128(src, 1);

    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<float> vconcat(Vector128<float> lo, Vector128<float> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// Creates a 256-bit vector by concatenating two 128-bit source vectors
    /// </summary>
    /// <param name="lo">The lower 128-bits of the target vector</param>
    /// <param name="hi">The upper 128-bits of the target vector</param>
    [MethodImpl(Inline), Concat]
    public static Vector256<double> vconcat(Vector128<double> lo, Vector128<double> hi)
        => Avx2.InsertVector128(Avx2.InsertVector128(default, lo, 0), hi, 1);

    /// <summary>
    /// __m128 _mm_blendv_ps (__m128 a, __m128 b, __m128 mask) BLENDVPS xmm, xmm/m128,xmm0
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vblendv(Vector128<float> x, Vector128<float> y, Vector128<float> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// _m128d _mm_blendv_pd (__m128d a, __m128d b, __m128d mask) BLENDVPD xmm, xmm/m128, xmm0
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vblendv(Vector128<double> x, Vector128<double> y, Vector128<double> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128 _mm_blendv_ps (__m128 a, __m128 b, __m128 mask) BLENDVPS xmm, xmm/m128,xmm0
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vblend4x32(Vector128<float> x, Vector128<float> y, Vector128<float> spec)
        =>  BlendVariable(x, y, spec);

    /// <summary>
    /// __m128d _mm_blendv_pd (__m128d a, __m128d b, __m128d mask) BLENDVPD xmm, xmm/m128,xmm0
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vblend2x64(Vector128<double> x, Vector128<double> y, Vector128<double> spec)
        =>  BlendVariable(x, y, spec);

    /// <summary>
    /// __m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask) VBLENDVPS ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vblend8x32(Vector256<float> x, Vector256<float> y, Vector256<float> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask) VBLENDVPS ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vblend4x64(Vector256<double> x, Vector256<double> y, Vector256<double> spec)
        => BlendVariable(x, y, spec);


    /// <summary>
    /// __m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask) VBLENDVPS ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vblendv(Vector256<float> x, Vector256<float> y, Vector256<float> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m256d _mm256_blendv_pd (__m256d a, __m256d b, __m256d mask) VBLENDVPD ymm, ymm,ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vblendv(Vector256<double> x, Vector256<double> y, Vector256<double> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vblend2x64(Vector128<double> x, Vector128<double> y, [Imm] Blend2x64 spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m128 _mm_blend_ps (__m128 a, __m128 b, const int imm8) BLENDPS xmm, xmm/m128, imm8
    /// Produces a new vector by assembling components from two source vectors as dermined by a mask
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vblend(Vector128<float> x, Vector128<float> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
    /// Produces a new vector by assembling components from two source vectors as dermined by a mask
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vblend(Vector128<double> x, Vector128<double> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m256 _mm256_blend_ps (__m256 a, __m256 b, const int imm8) VBLENDPS ymm, ymm, ymm/m256, imm8
    /// Produces a new vector by assembling components from two source vectors as dermined by a mask
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vblend(Vector256<float> x, Vector256<float> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8) VBLENDPD ymm, ymm, ymm/m256, imm8
    /// Produces a new vector by assembling components from two source vectors as dermined by a mask
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vblend(Vector256<double> x, Vector256<double> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8) VBLENDPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vblend4x64(Vector256<double> x, Vector256<double> y, [Imm] Blend4x64 spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m128d _mm_loaddup_pd (double const* mem_addr) MOVDDUP xmm, m64
    /// </summary>
    /// <param name="w">The width selector</param>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<double> vdup64(in double src)
        => LoadAndDuplicateToVector128(gptr(src));

    /// <summary>
    /// __m256 _mm256_moveldup_ps (__m256 a) VMOVSLDUP ymm, ymm/m256
    /// </summary>
    /// <param name="even"></param>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vdup32(N0 even, Vector256<float> src)
        => DuplicateEvenIndexed(src);

    /// <summary>
    /// __m256 _mm256_movehdup_ps (__m256 a) VMOVSHDUP ymm, ymm/m256
    /// </summary>
    /// <param name="odd"></param>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vdup32(N1 odd, Vector256<float> src)
        => DuplicateOddIndexed(src);

    /// <summary>
    /// __m256d _mm256_movedup_pd (__m256d a) VMOVDDUP ymm, ymm/m256
    /// </summary>
    /// <param name="even"></param>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vdup64(N0 even, Vector256<double> src)
        => DuplicateEvenIndexed(src);

    [MethodImpl(Inline), Op]
    public static Vector256<double> vdup64(N1 odd, Vector256<double> src)
        => DuplicateEvenIndexed(ShiftRightLogical(src.AsUInt64(),64).AsDouble());

    /// <summary>
    /// _mm256_insertf128_ps: Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane the target to overwrite, either 0 or 1 respectively
    /// identifying low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vlane(Vector128<float> src, Vector256<float> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vlane(Vector128<double> src, Vector256<double> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vlane(Vector128<double> src, Vector256<double> dst, N0 index)
        => InsertVector128(dst, src, 0);

    /// <summary>
    /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vlane(Vector128<double> src, Vector256<double> dst, N1 index)
        => InsertVector128(dst, src, 1);

    /// <summary>
    /// _m128 _mm256_extractf128_ps (__m256 a, const int imm8)VEXTRACTF128 xmm/m128, ymm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vlo(Vector256<float> src)
        => ExtractVector128(src, 0);

    /// <summary>
    /// __m128d _mm256_extractf128_pd (__m256d a, const int imm8)VEXTRACTF128 xmm/m128, ymm, imm8
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vlo(Vector256<double> src)
        => ExtractVector128(src, 0);

    /// <summary>
    /// _mm256_insertf128_ps: Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane the target to overwrite, either 0 or 1 respectively
    /// identifing low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vinsert(Vector128<float> src, Vector256<float> dst, [Imm] LaneIndex index)
        => InsertVector128(dst, src, (byte)index);

    /// <summary>
    /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
    /// identifing low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vinsert(Vector128<double> src, Vector256<double> dst, [Imm] LaneIndex index)
        => InsertVector128(dst, src, (byte)index);

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vhi(Vector128<float> src)
        => v32f(vscalar(v64i(src).GetElement(1)));

    /// <summary>
    /// Creates a scalar vector from the upper 64 bits of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vhi(Vector128<double> src)
        => vscalar(src.GetElement(1));

    /// <summary>
    /// __int64 _mm_cvtss_si64 (__m128 a) CVTSS2SI r64, xmm/m32
    /// src[0..31] -> r64
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static long vlo64i(Vector128<float> src)
        => ConvertToInt64(src);

    /// <summary>
    ///  __int64 _mm_cvtsd_si64 (__m128d a) CVTSD2SI r64, xmm/m64
    /// src[0..63] -> r64
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="wDst">The target width</param>
    [MethodImpl(Inline), Op]
    public static long vlo64i(Vector128<double> src)
        => ConvertToInt64(src);

    /// <summary>
    /// __m128 _mm_broadcast_ss (float const * mem_addr) VBROADCASTSS xmm, m32
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Broadcast]
    public static unsafe Vector128<float> vbroadcast(W128 w, float src)
        => BroadcastScalarToVector128(gptr(src));

    /// <summary>
    /// Broadcasts a 64-bit floating point value to the upper and lower cells of a 128-bit floating-point vector
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Broadcast]
    public static unsafe Vector128<double> vbroadcast(W128 w, double src)
        => Vector128.Create(src);

    /// <summary>
    /// __m256 _mm256_broadcast_ss (float const * mem_addr) VBROADCASTSS ymm, m32
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Broadcast]
    public static unsafe Vector256<float> vbroadcast(W256 w, float src)
        => BroadcastScalarToVector256(gptr(src));

    /// <summary>
    /// __m256d _mm256_broadcast_sd (double const * mem_addr) VBROADCASTSD ymm, m64
    /// </summary>
    /// <param name="w">The target vector width</param>
    /// <param name="src">The value to broadcast</param>
    [MethodImpl(Inline), Broadcast]
    public static unsafe Vector256<double> vbroadcast(W256 w, double src)
        => BroadcastScalarToVector256(gptr(src));

    /// <summary>
    /// void _mm256_storeu_ps (float * mem_addr, __m256 a) MOVUPS m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    ///<intrinsic>void _mm256_storeu_ps (float * mem_addr, __m256 a) MOVUPS m256, ymm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<float> src, ref float dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm256_storeu_pd (double * mem_addr, __m256d a) MOVUPD m256, ymm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    ///<intrinsic>void _mm256_storeu_pd (double * mem_addr, __m256d a) MOVUPD m256, ymm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<double> src, ref double dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// void _mm_storeu_pd (double* mem_addr, __m128d a) MOVUPD m128, xmm
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<float> src, ref float dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<double> src, ref double dst)
        => Store(refptr(ref dst), src);

    /// <summary>
    ///  void _mm_storeu_ps (float* mem_addr, __m128 a) MOVUPS m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<float> src, ref float dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// void _mm_storeu_pd (double* mem_addr, __m128d a) MOVUPD m128, xmm
    /// Stores vector content to a specified reference, offset by a specified amount
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector128<double> src, ref double dst, int offset)
        => Store(refptr(ref dst, offset), src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    ///<intrinsic>void _mm256_storeu_ps (float * mem_addr, __m256 a) MOVUPS m256, ymm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<float> src, ref float dst)
        => Store(refptr(ref dst),src);

    /// <summary>
    /// Stores vector content to a specified reference
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target memory</param>
    ///<intrinsic>void _mm256_storeu_pd (double * mem_addr, __m256d a) MOVUPD m256, ymm</intrinsic>
    [MethodImpl(Inline), Store]
    public static unsafe void vstore(Vector256<double> src, ref double dst)
        => Store(refptr(ref dst),src);


    /// <summary>
    /// __m128 _mm_add_ps (__m128 a, __m128 b) ADDPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<float> vadd(Vector128<float> x, Vector128<float> y)
        => Add(x, x);

    /// <summary>
    /// __m128d _mm_add_pd (__m128d a, __m128d b) ADDPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<double> vadd(Vector128<double> x, Vector128<double> y)
        => Add(x, y);

    /// <summary>
    /// __m256 _mm256_add_ps (__m256 a, __m256 b) VADDPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<float> vadd(Vector256<float> x, Vector256<float> y)
        => Add(x, y);

    /// <summary>
    /// __m256d _mm256_add_pd (__m256d a, __m256d b) VADDPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<double> vadd(Vector256<double> x, Vector256<double> y)
        => Add(x, y);

    /// <summary>
    /// __m128 _mm_or_ps (__m128 a, __m128 b) ORPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<float> vor(Vector128<float> a, Vector128<float> b)
        => Or(a, b);

    /// <summary>
    /// __m128d _mm_or_pd (__m128d a, __m128d b) ORPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<double> vor(Vector128<double> a, Vector128<double> b)
        => Or(a, b);

    /// <summary>
    /// __m256 _mm256_or_ps (__m256 a, __m256 b) VORPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<float> vor(Vector256<float> a, Vector256<float> b)
        => Or(a, b);

    /// <summary>
    /// __m256d _mm256_or_pd (__m256d a, __m256d b) VORPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<double> vor(Vector256<double> a, Vector256<double> b)
        => Or(a, b);

    /// <summary>
    /// __m128 _mm_xor_ps (__m128 a, __m128 b) XORPS xmm, xmm/m128
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vxor(Vector128<float> lhs, Vector128<float> rhs)
        => Xor(lhs, rhs);

    /// <summary>
    /// __m128d _mm_xor_pd (__m128d a, __m128d b) XORPD xmm, xmm/m128
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vxor(Vector128<double> lhs, Vector128<double> rhs)
        => Xor(lhs, rhs);

    /// <summary>
    /// __m256 _mm256_xor_ps (__m256 a, __m256 b) VXORPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vxor(Vector256<float> lhs, Vector256<float> rhs)
        => Xor(lhs, rhs);

    /// <summary>
    ///  __m256 _mm256_xor_ps (__m256 a, __m256 b) VXORPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vxor(Vector256<double> lhs, Vector256<double> rhs)
        => Xor(lhs, rhs);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vscalar(W256 w, float a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vscalar(W256 w, double a)
        => Vector256.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vscalar(W128 w, float a)
        => Vector128.CreateScalarUnsafe(a);

    /// <summary>
    /// Loads a scalar into the first component of a 256-bit vector
    /// </summary>
    /// <param name="a">The source value</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vscalar(W128 w, double a)
        => Vector128.CreateScalarUnsafe(a);

    [MethodImpl(Inline), Op]
    public static unsafe Vector128<float> vscalar(float src)
        => LoadScalarVector128(&src);

    [MethodImpl(Inline), Op]
    public static unsafe Vector128<double> vscalar(double src)
        => LoadScalarVector128(&src);

    /// <summary>
    /// Extracts the value of an identified source vector component
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="pos">The zero-based index of the source component to extract</param>
    [MethodImpl(Inline), Op]
    public static float vxscalar(Vector128<float> src, byte pos)
        => Extract(src,pos);

    /// <summary>
    /// Extracts the value of an identified source vector component
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="pos">The zero-based index of the source component to extract</param>
    [MethodImpl(Inline), Op]
    public static double vxscalar(Vector128<double> src, byte pos)
        => src.GetElement(pos);

    static Vector256<int> MRev256f32
    {
        [MethodImpl(Inline), Op]
        get => vcpu.vparts(w256i, 7, 6, 5, 4, 3, 2, 1, 0);
    }

}
