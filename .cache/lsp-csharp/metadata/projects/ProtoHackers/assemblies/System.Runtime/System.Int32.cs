using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace System;

/// <summary>Represents a 32-bit signed integer.</summary>
public readonly struct Int32 : IComparable, IComparable<int>, IConvertible, IEquatable<int>, IFormattable, IParsable<int>, ISpanFormattable, ISpanParsable<int>, IAdditionOperators<int, int, int>, IAdditiveIdentity<int, int>, IBinaryInteger<int>, IBinaryNumber<int>, IBitwiseOperators<int, int, int>, IComparisonOperators<int, int, bool>, IEqualityOperators<int, int, bool>, IDecrementOperators<int>, IDivisionOperators<int, int, int>, IIncrementOperators<int>, IModulusOperators<int, int, int>, IMultiplicativeIdentity<int, int>, IMultiplyOperators<int, int, int>, INumber<int>, INumberBase<int>, ISubtractionOperators<int, int, int>, IUnaryNegationOperators<int, int>, IUnaryPlusOperators<int, int>, IUtf8SpanFormattable, IUtf8SpanParsable<int>, IShiftOperators<int, int, int>, IMinMaxValue<int>, ISignedNumber<int>
{
	private readonly int _dummyPrimitive;

	/// <summary>Represents the largest possible value of an <see cref="T:System.Int32" />. This field is constant.</summary>
	public const int MaxValue = 2147483647;

	/// <summary>Represents the smallest possible value of <see cref="T:System.Int32" />. This field is constant.</summary>
	public const int MinValue = -2147483648;

	static int IAdditiveIdentity<int, int>.AdditiveIdentity
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets an instance of the binary type in which all bits are set.</summary>
	static int IBinaryNumber<int>.AllBitsSet
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets the maximum value of the current type.</summary>
	static int IMinMaxValue<int>.MaxValue
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets the minimum value of the current type.</summary>
	static int IMinMaxValue<int>.MinValue
	{
		get
		{
			throw null;
		}
	}

	static int IMultiplicativeIdentity<int, int>.MultiplicativeIdentity
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets the value <c>1</c> for the type.</summary>
	static int INumberBase<int>.One
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets the radix, or base, for the type.</summary>
	static int INumberBase<int>.Radix
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets the value <c>0</c> for the type.</summary>
	static int INumberBase<int>.Zero
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets the value <c>-1</c> for the type.</summary>
	static int ISignedNumber<int>.NegativeOne
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Computes the absolute of a value.</summary>
	/// <param name="value">The value for which to get its absolute.</param>
	/// <returns>The absolute of <code data-dev-comment-type="paramref">value</code>.</returns>
	public static int Abs(int value)
	{
		throw null;
	}

	/// <summary>Clamps a value to an inclusive minimum and maximum value.</summary>
	/// <param name="value">The value to clamp.</param>
	/// <param name="min">The inclusive minimum to which <code data-dev-comment-type="paramref">value</code> should clamp.</param>
	/// <param name="max">The inclusive maximum to which <code data-dev-comment-type="paramref">value</code> should clamp.</param>
	/// <returns>The result of clamping <code data-dev-comment-type="paramref">value</code> to the inclusive range of <code data-dev-comment-type="paramref">min</code> and <code data-dev-comment-type="paramref">max</code>.</returns>
	public static int Clamp(int value, int min, int max)
	{
		throw null;
	}

	/// <summary>Compares this instance to a specified 32-bit signed integer and returns an indication of their relative values.</summary>
	/// <param name="value">An integer to compare.</param>
	/// <returns>A signed number indicating the relative values of this instance and <paramref name="value" />.
	///
	///  <list type="table"><listheader><term> Return Value</term><description> Description</description></listheader><item><term> Less than zero</term><description> This instance is less than <paramref name="value" />.</description></item><item><term> Zero</term><description> This instance is equal to <paramref name="value" />.</description></item><item><term> Greater than zero</term><description> This instance is greater than <paramref name="value" />.</description></item></list></returns>
	public int CompareTo(int value)
	{
		throw null;
	}

	/// <summary>Compares this instance to a specified object and returns an indication of their relative values.</summary>
	/// <param name="value">An object to compare, or <see langword="null" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="value" /> is not an <see cref="T:System.Int32" />.</exception>
	/// <returns>A signed number indicating the relative values of this instance and <paramref name="value" />.
	///
	///  <list type="table"><listheader><term> Return Value</term><description> Description</description></listheader><item><term> Less than zero</term><description> This instance is less than <paramref name="value" />.</description></item><item><term> Zero</term><description> This instance is equal to <paramref name="value" />.</description></item><item><term> Greater than zero</term><description> This instance is greater than <paramref name="value" />, or <paramref name="value" /> is <see langword="null" />.</description></item></list></returns>
	public int CompareTo(object? value)
	{
		throw null;
	}

	/// <summary>Copies the sign of a value to the sign of another value.</summary>
	/// <param name="value">The value whose magnitude is used in the result.</param>
	/// <param name="sign">The value whose sign is used in the result.</param>
	/// <returns>A value with the magnitude of <code data-dev-comment-type="paramref">value</code> and the sign of <code data-dev-comment-type="paramref">sign</code>.</returns>
	public static int CopySign(int value, int sign)
	{
		throw null;
	}

	/// <summary>Creates an instance of the current type from a value, throwing an overflow exception for any values that fall outside the representable range of the current type.</summary>
	/// <param name="value">The value that's used to create the instance of <code data-dev-comment-type="typeparamref">TSelf</code>.</param>
	/// <typeparam name="TOther">The type of <code data-dev-comment-type="paramref">value</code>.</typeparam>
	/// <returns>An instance of <code data-dev-comment-type="typeparamref">TSelf</code> created from <code data-dev-comment-type="paramref">value</code>.</returns>
	public static int CreateChecked<TOther>(TOther value) where TOther : INumberBase<TOther>
	{
		throw null;
	}

	/// <summary>Creates an instance of the current type from a value, saturating any values that fall outside the representable range of the current type.</summary>
	/// <param name="value">The value that's used to create the instance of <code data-dev-comment-type="typeparamref">TSelf</code>.</param>
	/// <typeparam name="TOther">The type of <code data-dev-comment-type="paramref">value</code>.</typeparam>
	/// <returns>An instance of <code data-dev-comment-type="typeparamref">TSelf</code> created from <code data-dev-comment-type="paramref">value</code>, saturating if <code data-dev-comment-type="paramref">value</code> falls outside the representable range of <code data-dev-comment-type="typeparamref">TSelf</code>.</returns>
	public static int CreateSaturating<TOther>(TOther value) where TOther : INumberBase<TOther>
	{
		throw null;
	}

	/// <summary>Creates an instance of the current type from a value, truncating any values that fall outside the representable range of the current type.</summary>
	/// <param name="value">The value that's used to create the instance of <code data-dev-comment-type="typeparamref">TSelf</code>.</param>
	/// <typeparam name="TOther">The type of <code data-dev-comment-type="paramref">value</code>.</typeparam>
	/// <returns>An instance of <code data-dev-comment-type="typeparamref">TSelf</code> created from <code data-dev-comment-type="paramref">value</code>, truncating if <code data-dev-comment-type="paramref">value</code> falls outside the representable range of <code data-dev-comment-type="typeparamref">TSelf</code>.</returns>
	public static int CreateTruncating<TOther>(TOther value) where TOther : INumberBase<TOther>
	{
		throw null;
	}

	/// <summary>Computes the quotient and remainder of two values.</summary>
	/// <param name="left">The value which <code data-dev-comment-type="paramref">right</code> divides.</param>
	/// <param name="right">The value which divides <code data-dev-comment-type="paramref">left</code>.</param>
	/// <returns>The quotient and remainder of <code data-dev-comment-type="paramref">left</code> divided-by <code data-dev-comment-type="paramref">right</code>.</returns>
	public static (int Quotient, int Remainder) DivRem(int left, int right)
	{
		throw null;
	}

	/// <summary>Returns a value indicating whether this instance is equal to a specified <see cref="T:System.Int32" /> value.</summary>
	/// <param name="obj">An <see cref="T:System.Int32" /> value to compare to this instance.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="obj" /> has the same value as this instance; otherwise, <see langword="false" />.</returns>
	public bool Equals(int obj)
	{
		throw null;
	}

	/// <summary>Returns a value indicating whether this instance is equal to a specified object.</summary>
	/// <param name="obj">An object to compare with this instance.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="obj" /> is an instance of <see cref="T:System.Int32" /> and equals the value of this instance; otherwise, <see langword="false" />.</returns>
	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		throw null;
	}

	/// <summary>Returns the hash code for this instance.</summary>
	/// <returns>A 32-bit signed integer hash code.</returns>
	public override int GetHashCode()
	{
		throw null;
	}

	/// <summary>Returns the <see cref="T:System.TypeCode" /> for value type <see cref="T:System.Int32" />.</summary>
	/// <returns>The enumerated constant, <see cref="F:System.TypeCode.Int32" />.</returns>
	public TypeCode GetTypeCode()
	{
		throw null;
	}

	/// <summary>Determines if a value represents an even integral number.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">value</code> is an even integer; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool IsEvenInteger(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is negative.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">value</code> is negative; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool IsNegative(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value represents an odd integral number.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">value</code> is an odd integer; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool IsOddInteger(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is positive.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">value</code> is positive; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool IsPositive(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is a power of two.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">value</code> is a power of two; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool IsPow2(int value)
	{
		throw null;
	}

	/// <summary>Computes the number of leading zeros in a value.</summary>
	/// <param name="value">The value whose leading zeroes are to be counted.</param>
	/// <returns>The number of leading zeros in <code data-dev-comment-type="paramref">value</code>.</returns>
	public static int LeadingZeroCount(int value)
	{
		throw null;
	}

	/// <summary>Computes the log2 of a value.</summary>
	/// <param name="value">The value whose log2 is to be computed.</param>
	/// <returns>The log2 of <code data-dev-comment-type="paramref">value</code>.</returns>
	public static int Log2(int value)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which is greater.</summary>
	/// <param name="x">The value to compare with <code data-dev-comment-type="paramref">y</code>.</param>
	/// <param name="y">The value to compare with <code data-dev-comment-type="paramref">x</code>.</param>
	/// <returns>
	///   <code data-dev-comment-type="paramref">x</code> if it is greater than <code data-dev-comment-type="paramref">y</code>; otherwise, <code data-dev-comment-type="paramref">y</code>.</returns>
	public static int Max(int x, int y)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which is greater.</summary>
	/// <param name="x">The value to compare with <code data-dev-comment-type="paramref">y</code>.</param>
	/// <param name="y">The value to compare with <code data-dev-comment-type="paramref">x</code>.</param>
	/// <returns>
	///   <code data-dev-comment-type="paramref">x</code> if it is greater than <code data-dev-comment-type="paramref">y</code>; otherwise, <code data-dev-comment-type="paramref">y</code>.</returns>
	public static int MaxMagnitude(int x, int y)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which is lesser.</summary>
	/// <param name="x">The value to compare with <code data-dev-comment-type="paramref">y</code>.</param>
	/// <param name="y">The value to compare with <code data-dev-comment-type="paramref">x</code>.</param>
	/// <returns>
	///   <code data-dev-comment-type="paramref">x</code> if it is less than <code data-dev-comment-type="paramref">y</code>; otherwise, <code data-dev-comment-type="paramref">y</code>.</returns>
	public static int Min(int x, int y)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which is lesser.</summary>
	/// <param name="x">The value to compare with <code data-dev-comment-type="paramref">y</code>.</param>
	/// <param name="y">The value to compare with <code data-dev-comment-type="paramref">x</code>.</param>
	/// <returns>
	///   <code data-dev-comment-type="paramref">x</code> if it is less than <code data-dev-comment-type="paramref">y</code>; otherwise, <code data-dev-comment-type="paramref">y</code>.</returns>
	public static int MinMagnitude(int x, int y)
	{
		throw null;
	}

	/// <summary>Parses a span of UTF-8 characters into a value.</summary>
	/// <param name="utf8Text">The span of UTF-8 characters to parse.</param>
	/// <param name="style">A bitwise combination of number styles that can be present in <code data-dev-comment-type="paramref">utf8Text</code>.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <code data-dev-comment-type="paramref">utf8Text</code>.</param>
	/// <returns>The result of parsing <code data-dev-comment-type="paramref">utf8Text</code>.</returns>
	public static int Parse(ReadOnlySpan<byte> utf8Text, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
	{
		throw null;
	}

	/// <summary>Parses a span of UTF-8 characters into a value.</summary>
	/// <param name="utf8Text">The span of UTF-8 characters to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <code data-dev-comment-type="paramref">utf8Text</code>.</param>
	/// <returns>The result of parsing <code data-dev-comment-type="paramref">utf8Text</code>.</returns>
	public static int Parse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider)
	{
		throw null;
	}

	/// <summary>Converts the span representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent.</summary>
	/// <param name="s">A span containing the characters representing the number to convert.</param>
	/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	/// <param name="provider">An object that supplies culture-specific information about the format of <paramref name="s" />.</param>
	/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s" />.</returns>
	public static int Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null)
	{
		throw null;
	}

	/// <summary>Parses a span of characters into a value.</summary>
	/// <param name="s">The span of characters to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <code data-dev-comment-type="paramref">s</code>.</param>
	/// <returns>The result of parsing <code data-dev-comment-type="paramref">s</code>.</returns>
	public static int Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
	{
		throw null;
	}

	/// <summary>Converts the string representation of a number to its 32-bit signed integer equivalent.</summary>
	/// <param name="s">A string containing a number to convert.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="s" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="s" /> is not in the correct format.</exception>
	/// <exception cref="T:System.OverflowException">
	///   <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
	/// <returns>A 32-bit signed integer equivalent to the number contained in <paramref name="s" />.</returns>
	public static int Parse(string s)
	{
		throw null;
	}

	/// <summary>Converts the string representation of a number in a specified style to its 32-bit signed integer equivalent.</summary>
	/// <param name="s">A string containing a number to convert.</param>
	/// <param name="style">A bitwise combination of the enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="s" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.
	///
	///  -or-
	///
	///  <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="s" /> is not in a format compliant with <paramref name="style" />.</exception>
	/// <exception cref="T:System.OverflowException">
	///   <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>.
	///
	///  -or-
	///
	///  <paramref name="s" /> includes non-zero, fractional digits.</exception>
	/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s" />.</returns>
	public static int Parse(string s, NumberStyles style)
	{
		throw null;
	}

	/// <summary>Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent.</summary>
	/// <param name="s">A string containing a number to convert.</param>
	/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	/// <param name="provider">An object that supplies culture-specific information about the format of <paramref name="s" />.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="s" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.
	///
	///  -or-
	///
	///  <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="s" /> is not in a format compliant with <paramref name="style" />.</exception>
	/// <exception cref="T:System.OverflowException">
	///   <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>.
	///
	///  -or-
	///
	///  <paramref name="s" /> includes non-zero, fractional digits.</exception>
	/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s" />.</returns>
	public static int Parse(string s, NumberStyles style, IFormatProvider? provider)
	{
		throw null;
	}

	/// <summary>Converts the string representation of a number in a specified culture-specific format to its 32-bit signed integer equivalent.</summary>
	/// <param name="s">A string containing a number to convert.</param>
	/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="s" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="s" /> is not of the correct format.</exception>
	/// <exception cref="T:System.OverflowException">
	///   <paramref name="s" /> represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
	/// <returns>A 32-bit signed integer equivalent to the number specified in <paramref name="s" />.</returns>
	public static int Parse(string s, IFormatProvider? provider)
	{
		throw null;
	}

	/// <summary>Computes the number of bits that are set in a value.</summary>
	/// <param name="value">The value whose set bits are to be counted.</param>
	/// <returns>The number of set bits in <code data-dev-comment-type="paramref">value</code>.</returns>
	public static int PopCount(int value)
	{
		throw null;
	}

	/// <summary>Rotates a value left by a given amount.</summary>
	/// <param name="value">The value which is rotated left by <code data-dev-comment-type="paramref">rotateAmount</code>.</param>
	/// <param name="rotateAmount">The amount by which <code data-dev-comment-type="paramref">value</code> is rotated left.</param>
	/// <returns>The result of rotating <code data-dev-comment-type="paramref">value</code> left by <code data-dev-comment-type="paramref">rotateAmount</code>.</returns>
	public static int RotateLeft(int value, int rotateAmount)
	{
		throw null;
	}

	/// <summary>Rotates a value right by a given amount.</summary>
	/// <param name="value">The value which is rotated right by <code data-dev-comment-type="paramref">rotateAmount</code>.</param>
	/// <param name="rotateAmount">The amount by which <code data-dev-comment-type="paramref">value</code> is rotated right.</param>
	/// <returns>The result of rotating <code data-dev-comment-type="paramref">value</code> right by <code data-dev-comment-type="paramref">rotateAmount</code>.</returns>
	public static int RotateRight(int value, int rotateAmount)
	{
		throw null;
	}

	/// <summary>Computes the sign of a value.</summary>
	/// <param name="value">The value whose sign is to be computed.</param>
	/// <returns>A positive value if <code data-dev-comment-type="paramref">value</code> is positive, <xref data-throw-if-not-resolved="true" uid="System.Numerics.INumberBase`1.Zero"></xref> if <code data-dev-comment-type="paramref">value</code> is zero, and a negative value if <code data-dev-comment-type="paramref">value</code> is negative.</returns>
	public static int Sign(int value)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToBoolean(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>
	///   <see langword="true" /> if the value of the current instance is not zero; otherwise, <see langword="false" />.</returns>
	bool IConvertible.ToBoolean(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToByte(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.Byte" />.</returns>
	byte IConvertible.ToByte(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToChar(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.Char" />.</returns>
	char IConvertible.ToChar(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>This conversion is not supported. Attempting to use this method throws an <see cref="T:System.InvalidCastException" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <exception cref="T:System.InvalidCastException">In all cases.</exception>
	/// <returns>This conversion is not supported. No value is returned.</returns>
	DateTime IConvertible.ToDateTime(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToDecimal(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.Decimal" />.</returns>
	decimal IConvertible.ToDecimal(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToDouble(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.Double" />.</returns>
	double IConvertible.ToDouble(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt16(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to an <see cref="T:System.Int16" />.</returns>
	short IConvertible.ToInt16(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt32(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, unchanged.</returns>
	int IConvertible.ToInt32(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToInt64(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to an <see cref="T:System.Int64" />.</returns>
	long IConvertible.ToInt64(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToSByte(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to an <see cref="T:System.SByte" />.</returns>
	sbyte IConvertible.ToSByte(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToSingle(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.Single" />.</returns>
	float IConvertible.ToSingle(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToType(System.Type,System.IFormatProvider)" />.</summary>
	/// <param name="type">The type to which to convert this <see cref="T:System.Int32" /> value.</param>
	/// <param name="provider">An object that provides information about the format of the returned value.</param>
	/// <returns>The value of the current instance, converted to <paramref name="type" />.</returns>
	object IConvertible.ToType(Type type, IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt16(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.UInt16" />.</returns>
	ushort IConvertible.ToUInt16(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt32(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.UInt32" />.</returns>
	uint IConvertible.ToUInt32(IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>For a description of this member, see <see cref="M:System.IConvertible.ToUInt64(System.IFormatProvider)" />.</summary>
	/// <param name="provider">This parameter is ignored.</param>
	/// <returns>The value of the current instance, converted to a <see cref="T:System.UInt64" />.</returns>
	ulong IConvertible.ToUInt64(IFormatProvider provider)
	{
		throw null;
	}

	static int IAdditionOperators<int, int, int>.op_Addition(int left, int right)
	{
		throw null;
	}

	static int IAdditionOperators<int, int, int>.op_CheckedAddition(int left, int right)
	{
		throw null;
	}

	int IBinaryInteger<int>.GetByteCount()
	{
		throw null;
	}

	int IBinaryInteger<int>.GetShortestBitLength()
	{
		throw null;
	}

	/// <param name="source" />
	/// <param name="isUnsigned" />
	/// <param name="value" />
	static bool IBinaryInteger<int>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out int value)
	{
		throw null;
	}

	/// <param name="source" />
	/// <param name="isUnsigned" />
	/// <param name="value" />
	static bool IBinaryInteger<int>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out int value)
	{
		throw null;
	}

	bool IBinaryInteger<int>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten)
	{
		throw null;
	}

	bool IBinaryInteger<int>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten)
	{
		throw null;
	}

	static int IBitwiseOperators<int, int, int>.op_BitwiseAnd(int left, int right)
	{
		throw null;
	}

	static int IBitwiseOperators<int, int, int>.op_BitwiseOr(int left, int right)
	{
		throw null;
	}

	static int IBitwiseOperators<int, int, int>.op_ExclusiveOr(int left, int right)
	{
		throw null;
	}

	static int IBitwiseOperators<int, int, int>.op_OnesComplement(int value)
	{
		throw null;
	}

	static bool IComparisonOperators<int, int, bool>.op_GreaterThan(int left, int right)
	{
		throw null;
	}

	static bool IComparisonOperators<int, int, bool>.op_GreaterThanOrEqual(int left, int right)
	{
		throw null;
	}

	static bool IComparisonOperators<int, int, bool>.op_LessThan(int left, int right)
	{
		throw null;
	}

	static bool IComparisonOperators<int, int, bool>.op_LessThanOrEqual(int left, int right)
	{
		throw null;
	}

	/// <summary>Decrements a value.</summary>
	/// <param name="value">The value to decrement.</param>
	/// <returns>The result of decrementing <paramref name="value" />.</returns>
	static int IDecrementOperators<int>.op_CheckedDecrement(int value)
	{
		throw null;
	}

	/// <summary>Decrements a value.</summary>
	/// <param name="value">The value to decrement.</param>
	/// <returns>The result of decrementing <paramref name="value" />.</returns>
	static int IDecrementOperators<int>.op_Decrement(int value)
	{
		throw null;
	}

	static int IDivisionOperators<int, int, int>.op_Division(int left, int right)
	{
		throw null;
	}

	static bool IEqualityOperators<int, int, bool>.op_Equality(int left, int right)
	{
		throw null;
	}

	static bool IEqualityOperators<int, int, bool>.op_Inequality(int left, int right)
	{
		throw null;
	}

	/// <summary>Increments a value.</summary>
	/// <param name="value">The value to increment.</param>
	/// <returns>The result of incrementing <paramref name="value" />.</returns>
	static int IIncrementOperators<int>.op_CheckedIncrement(int value)
	{
		throw null;
	}

	/// <summary>Increments a value.</summary>
	/// <param name="value">The value to increment.</param>
	/// <returns>The result of incrementing <paramref name="value" />.</returns>
	static int IIncrementOperators<int>.op_Increment(int value)
	{
		throw null;
	}

	static int IModulusOperators<int, int, int>.op_Modulus(int left, int right)
	{
		throw null;
	}

	static int IMultiplyOperators<int, int, int>.op_CheckedMultiply(int left, int right)
	{
		throw null;
	}

	static int IMultiplyOperators<int, int, int>.op_Multiply(int left, int right)
	{
		throw null;
	}

	/// <summary>Determines if a value is in its canonical representation.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is in its canonical representation; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsCanonical(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value represents a complex number.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is a complex number; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsComplexNumber(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is finite.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is finite; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsFinite(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value represents a pure imaginary number.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is a pure imaginary number; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsImaginaryNumber(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is infinite.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is infinite; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsInfinity(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value represents an integral number.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is an integer; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsInteger(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is NaN.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is NaN; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsNaN(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is negative infinity.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is negative infinity; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsNegativeInfinity(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is normal.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is normal; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsNormal(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is positive infinity.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is positive infinity; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsPositiveInfinity(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value represents a real number.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is a real number; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsRealNumber(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is subnormal.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is subnormal; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsSubnormal(int value)
	{
		throw null;
	}

	/// <summary>Determines if a value is zero.</summary>
	/// <param name="value">The value to be checked.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="value" /> is zero; otherwise, <see langword="false" />.</returns>
	static bool INumberBase<int>.IsZero(int value)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which has the greater magnitude and returning the other value if an input is <c>NaN</c>.</summary>
	/// <param name="x">The value to compare with <paramref name="y" />.</param>
	/// <param name="y">The value to compare with <paramref name="x" />.</param>
	/// <returns>
	///   <paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
	static int INumberBase<int>.MaxMagnitudeNumber(int x, int y)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which has the lesser magnitude and returning the other value if an input is <c>NaN</c>.</summary>
	/// <param name="x">The value to compare with <paramref name="y" />.</param>
	/// <param name="y">The value to compare with <paramref name="x" />.</param>
	/// <returns>
	///   <paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
	static int INumberBase<int>.MinMagnitudeNumber(int x, int y)
	{
		throw null;
	}

	/// <param name="value" />
	/// <param name="result" />
	/// <typeparam name="TOther" />
	static bool INumberBase<int>.TryConvertFromChecked<TOther>(TOther value, out int result)
	{
		throw null;
	}

	/// <param name="value" />
	/// <param name="result" />
	/// <typeparam name="TOther" />
	static bool INumberBase<int>.TryConvertFromSaturating<TOther>(TOther value, out int result)
	{
		throw null;
	}

	/// <param name="value" />
	/// <param name="result" />
	/// <typeparam name="TOther" />
	static bool INumberBase<int>.TryConvertFromTruncating<TOther>(TOther value, out int result)
	{
		throw null;
	}

	/// <summary>Tries to convert an instance of the the current type to another type, throwing an overflow exception for any values that fall outside the representable range of the current type.</summary>
	/// <param name="value">The value that's used to create the instance of <typeparamref name="TOther" />.</param>
	/// <param name="result">When this method returns, contains an instance of <typeparamref name="TOther" /> converted from <paramref name="value" />.</param>
	/// <typeparam name="TOther">The type to which <paramref name="value" /> should be converted.</typeparam>
	/// <returns>
	///   <see langword="false" /> if <typeparamref name="TOther" /> is not supported; otherwise, <see langword="true" />.</returns>
	static bool INumberBase<int>.TryConvertToChecked<TOther>(int value, [MaybeNullWhen(false)] out TOther result)
	{
		throw null;
	}

	/// <summary>Tries to convert an instance of the the current type to another type, saturating any values that fall outside the representable range of the current type.</summary>
	/// <param name="value">The value that's used to create the instance of <typeparamref name="TOther" />.</param>
	/// <param name="result">When this method returns, contains an instance of <typeparamref name="TOther" /> converted from <paramref name="value" />.</param>
	/// <typeparam name="TOther">The type to which <paramref name="value" /> should be converted.</typeparam>
	/// <returns>
	///   <see langword="false" /> if <typeparamref name="TOther" /> is not supported; otherwise, <see langword="true" />.</returns>
	static bool INumberBase<int>.TryConvertToSaturating<TOther>(int value, [MaybeNullWhen(false)] out TOther result)
	{
		throw null;
	}

	/// <summary>Tries to convert an instance of the the current type to another type, truncating any values that fall outside the representable range of the current type.</summary>
	/// <param name="value">The value that's used to create the instance of <typeparamref name="TOther" />.</param>
	/// <param name="result">When this method returns, contains an instance of <typeparamref name="TOther" /> converted from <paramref name="value" />.</param>
	/// <typeparam name="TOther">The type to which <paramref name="value" /> should be converted.</typeparam>
	/// <returns>
	///   <see langword="false" /> if <typeparamref name="TOther" /> is not supported; otherwise, <see langword="true" />.</returns>
	static bool INumberBase<int>.TryConvertToTruncating<TOther>(int value, [MaybeNullWhen(false)] out TOther result)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which is greater and returning the other value if an input is <c>NaN</c>.</summary>
	/// <param name="x">The value to compare with <paramref name="y" />.</param>
	/// <param name="y">The value to compare with <paramref name="x" />.</param>
	/// <returns>
	///   <paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
	static int INumber<int>.MaxNumber(int x, int y)
	{
		throw null;
	}

	/// <summary>Compares two values to compute which is lesser and returning the other value if an input is <c>NaN</c>.</summary>
	/// <param name="x">The value to compare with <paramref name="y" />.</param>
	/// <param name="y">The value to compare with <paramref name="x" />.</param>
	/// <returns>
	///   <paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
	static int INumber<int>.MinNumber(int x, int y)
	{
		throw null;
	}

	static int IShiftOperators<int, int, int>.op_LeftShift(int value, int shiftAmount)
	{
		throw null;
	}

	static int IShiftOperators<int, int, int>.op_RightShift(int value, int shiftAmount)
	{
		throw null;
	}

	static int IShiftOperators<int, int, int>.op_UnsignedRightShift(int value, int shiftAmount)
	{
		throw null;
	}

	static int ISubtractionOperators<int, int, int>.op_CheckedSubtraction(int left, int right)
	{
		throw null;
	}

	static int ISubtractionOperators<int, int, int>.op_Subtraction(int left, int right)
	{
		throw null;
	}

	static int IUnaryNegationOperators<int, int>.op_CheckedUnaryNegation(int value)
	{
		throw null;
	}

	static int IUnaryNegationOperators<int, int>.op_UnaryNegation(int value)
	{
		throw null;
	}

	static int IUnaryPlusOperators<int, int>.op_UnaryPlus(int value)
	{
		throw null;
	}

	/// <summary>Converts the numeric value of this instance to its equivalent string representation.</summary>
	/// <returns>The string representation of the value of this instance, consisting of a negative sign if the value is negative, and a sequence of digits ranging from 0 to 9 with no leading zeroes.</returns>
	public override string ToString()
	{
		throw null;
	}

	/// <summary>Converts the numeric value of this instance to its equivalent string representation using the specified culture-specific format information.</summary>
	/// <param name="provider">An object that supplies culture-specific formatting information.</param>
	/// <returns>The string representation of the value of this instance as specified by <paramref name="provider" />.</returns>
	public string ToString(IFormatProvider? provider)
	{
		throw null;
	}

	/// <summary>Converts the numeric value of this instance to its equivalent string representation, using the specified format.</summary>
	/// <param name="format">A standard or custom numeric format string.</param>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="format" /> is invalid or not supported.</exception>
	/// <returns>The string representation of the value of this instance as specified by <paramref name="format" />.</returns>
	public string ToString([StringSyntax("NumericFormat")] string? format)
	{
		throw null;
	}

	/// <summary>Converts the numeric value of this instance to its equivalent string representation using the specified format and culture-specific format information.</summary>
	/// <param name="format">A standard or custom numeric format string.</param>
	/// <param name="provider">An object that supplies culture-specific formatting information.</param>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="format" /> is invalid or not supported.</exception>
	/// <returns>The string representation of the value of this instance as specified by <paramref name="format" /> and <paramref name="provider" />.</returns>
	public string ToString([StringSyntax("NumericFormat")] string? format, IFormatProvider? provider)
	{
		throw null;
	}

	/// <summary>Computes the number of trailing zeros in a value.</summary>
	/// <param name="value">The value whose trailing zeroes are to be counted.</param>
	/// <returns>The number of trailing zeros in <code data-dev-comment-type="paramref">value</code>.</returns>
	public static int TrailingZeroCount(int value)
	{
		throw null;
	}

	/// <summary>Tries to format the value of the current integer number instance into the provided span of characters.</summary>
	/// <param name="destination">The span in which to write this instance's value formatted as a span of characters.</param>
	/// <param name="charsWritten">When this method returns, contains the number of characters that were written in <paramref name="destination" />.</param>
	/// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for <paramref name="destination" />.</param>
	/// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="destination" />.</param>
	/// <returns>
	///   <see langword="true" /> if the formatting was successful; otherwise, <see langword="false" />.</returns>
	public bool TryFormat(Span<char> destination, out int charsWritten, [StringSyntax("NumericFormat")] ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		throw null;
	}

	/// <summary>Tries to format the value of the current instance as UTF-8 into the provided span of bytes.</summary>
	/// <param name="utf8Destination">The span in which to write this instance's value formatted as a span of bytes.</param>
	/// <param name="bytesWritten">When this method returns, contains the number of bytes that were written in <code data-dev-comment-type="paramref">utf8Destination</code>.</param>
	/// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for <code data-dev-comment-type="paramref">utf8Destination</code>.</param>
	/// <param name="provider">An optional object that supplies culture-specific formatting information for <code data-dev-comment-type="paramref">utf8Destination</code>.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if the formatting was successful; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public bool TryFormat(Span<byte> utf8Destination, out int bytesWritten, [StringSyntax("NumericFormat")] ReadOnlySpan<char> format = default(ReadOnlySpan<char>), IFormatProvider? provider = null)
	{
		throw null;
	}

	/// <summary>Tries to parse a span of UTF-8 characters into a value.</summary>
	/// <param name="utf8Text">The span of UTF-8 characters to parse.</param>
	/// <param name="style">A bitwise combination of number styles that can be present in <code data-dev-comment-type="paramref">utf8Text</code>.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <code data-dev-comment-type="paramref">utf8Text</code>.</param>
	/// <param name="result">On return, contains the result of successfully parsing <code data-dev-comment-type="paramref">utf8Text</code> or an undefined value on failure.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">utf8Text</code> was successfully parsed; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool TryParse(ReadOnlySpan<byte> utf8Text, NumberStyles style, IFormatProvider? provider, out int result)
	{
		throw null;
	}

	/// <summary>Tries to parse a span of UTF-8 characters into a value.</summary>
	/// <param name="utf8Text">The span of UTF-8 characters to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <code data-dev-comment-type="paramref">utf8Text</code>.</param>
	/// <param name="result">On return, contains the result of successfully parsing <code data-dev-comment-type="paramref">utf8Text</code> or an undefined value on failure.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">utf8Text</code> was successfully parsed; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool TryParse(ReadOnlySpan<byte> utf8Text, IFormatProvider? provider, out int result)
	{
		throw null;
	}

	/// <summary>Tries to convert a UTF-8 character span containing the string representation of a number to its 32-bit signed integer equivalent.</summary>
	/// <param name="utf8Text">A span containing the UTF-8 characters representing the number to convert.</param>
	/// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent to the number contained in <paramref name="utf8Text" /> if the conversion succeeded, or zero if the conversion failed. This parameter is passed uninitialized; any value originally supplied in result will be overwritten.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="utf8Text" /> was converted successfully; otherwise, <see langword="false" />.</returns>
	public static bool TryParse(ReadOnlySpan<byte> utf8Text, out int result)
	{
		throw null;
	}

	/// <summary>Converts the span representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
	/// <param name="s">A span containing the characters that represent the number to convert. The span is interpreted using the style specified by <paramref name="style" />.</param>
	/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
	/// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, is not in a format compliant with <paramref name="style" />, or represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>
	public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out int result)
	{
		throw null;
	}

	/// <summary>Tries to parse a span of characters into a value.</summary>
	/// <param name="s">The span of characters to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <code data-dev-comment-type="paramref">s</code>.</param>
	/// <param name="result">When this method returns, contains the result of successfully parsing <code data-dev-comment-type="paramref">s</code>, or an undefined value on failure.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">s</code> was successfully parsed; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out int result)
	{
		throw null;
	}

	/// <summary>Converts the span representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
	/// <param name="s">A span containing the characters that represent the number to convert.</param>
	/// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, is not in a format compliant with <paramref name="style" />, or represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>
	public static bool TryParse(ReadOnlySpan<char> s, out int result)
	{
		throw null;
	}

	/// <summary>Converts the string representation of a number in a specified style and culture-specific format to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
	/// <param name="s">A string containing a number to convert. The string is interpreted using the style specified by <paramref name="style" />.</param>
	/// <param name="style">A bitwise combination of enumeration values that indicates the style elements that can be present in <paramref name="s" />. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer" />.</param>
	/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
	/// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, is not in a format compliant with <paramref name="style" />, or represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="style" /> is not a <see cref="T:System.Globalization.NumberStyles" /> value.
	///
	///  -or-
	///
	///  <paramref name="style" /> is not a combination of <see cref="F:System.Globalization.NumberStyles.AllowHexSpecifier" /> and <see cref="F:System.Globalization.NumberStyles.HexNumber" /> values.</exception>
	/// <returns>
	///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>
	public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out int result)
	{
		throw null;
	}

	/// <summary>Tries to parse a string into a value.</summary>
	/// <param name="s">The string to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <code data-dev-comment-type="paramref">s</code>.</param>
	/// <param name="result">When this method returns, contains the result of successfully parsing <code data-dev-comment-type="paramref">s</code> or an undefined value on failure.</param>
	/// <returns>
	///   <code data-dev-comment-type="langword">true</code> if <code data-dev-comment-type="paramref">s</code> was successfully parsed; otherwise, <code data-dev-comment-type="langword">false</code>.</returns>
	public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out int result)
	{
		throw null;
	}

	/// <summary>Converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.</summary>
	/// <param name="s">A string containing a number to convert.</param>
	/// <param name="result">When this method returns, contains the 32-bit signed integer value equivalent of the number contained in <paramref name="s" />, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the <paramref name="s" /> parameter is <see langword="null" /> or <see cref="F:System.String.Empty" />, is not of the correct format, or represents a number less than <see cref="F:System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="F:System.Int32.MaxValue">Int32.MaxValue</see>. This parameter is passed uninitialized; any value originally supplied in <paramref name="result" /> will be overwritten.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="s" /> was converted successfully; otherwise, <see langword="false" />.</returns>
	public static bool TryParse([NotNullWhen(true)] string? s, out int result)
	{
		throw null;
	}
}
