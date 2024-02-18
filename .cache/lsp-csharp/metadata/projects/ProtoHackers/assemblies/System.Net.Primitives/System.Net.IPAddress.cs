using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace System.Net;

/// <summary>Provides an Internet Protocol (IP) address.</summary>
public class IPAddress : ISpanFormattable, IFormattable, ISpanParsable<IPAddress>, IParsable<IPAddress>, IUtf8SpanFormattable
{
	/// <summary>Provides an IP address that indicates that the server must listen for client activity on all network interfaces. This field is read-only.</summary>
	public static readonly IPAddress Any;

	/// <summary>Provides the IP broadcast address. This field is read-only.</summary>
	public static readonly IPAddress Broadcast;

	/// <summary>The <see cref="M:System.Net.Sockets.Socket.Bind(System.Net.EndPoint)" /> method uses the <see cref="F:System.Net.IPAddress.IPv6Any" /> field to indicate that a <see cref="T:System.Net.Sockets.Socket" /> must listen for client activity on all network interfaces.</summary>
	public static readonly IPAddress IPv6Any;

	/// <summary>Provides the IP loopback address. This property is read-only.</summary>
	public static readonly IPAddress IPv6Loopback;

	/// <summary>Provides an IP address that indicates that no network interface should be used. This property is read-only.</summary>
	public static readonly IPAddress IPv6None;

	/// <summary>Provides the IP loopback address. This field is read-only.</summary>
	public static readonly IPAddress Loopback;

	/// <summary>Provides an IP address that indicates that no network interface should be used. This field is read-only.</summary>
	public static readonly IPAddress None;

	/// <summary>An Internet Protocol (IP) address.</summary>
	/// <exception cref="T:System.Net.Sockets.SocketException">The address family is <see cref="F:System.Net.Sockets.AddressFamily.InterNetworkV6" />.</exception>
	/// <returns>The long value of the IP address.</returns>
	[Obsolete("IPAddress.Address is address family dependent and has been deprecated. Use IPAddress.Equals to perform comparisons instead.")]
	public long Address
	{
		get
		{
			throw null;
		}
		set
		{
		}
	}

	/// <summary>Gets the address family of the IP address.</summary>
	/// <returns>Returns <see cref="F:System.Net.Sockets.AddressFamily.InterNetwork" /> for IPv4 or <see cref="F:System.Net.Sockets.AddressFamily.InterNetworkV6" /> for IPv6.</returns>
	public AddressFamily AddressFamily
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets whether the IP address is an IPv4-mapped IPv6 address.</summary>
	/// <returns>Returns <see cref="T:System.Boolean" />.
	///
	///  <see langword="true" /> if the IP address is an IPv4-mapped IPv6 address; otherwise, <see langword="false" />.</returns>
	public bool IsIPv4MappedToIPv6
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets whether the address is an IPv6 link local address.</summary>
	/// <returns>
	///   <see langword="true" /> if the IP address is an IPv6 link local address; otherwise, <see langword="false" />.</returns>
	public bool IsIPv6LinkLocal
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets whether the address is an IPv6 multicast global address.</summary>
	/// <returns>
	///   <see langword="true" /> if the IP address is an IPv6 multicast global address; otherwise, <see langword="false" />.</returns>
	public bool IsIPv6Multicast
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets whether the address is an IPv6 site local address.</summary>
	/// <returns>
	///   <see langword="true" /> if the IP address is an IPv6 site local address; otherwise, <see langword="false" />.</returns>
	public bool IsIPv6SiteLocal
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets whether the address is an IPv6 Teredo address.</summary>
	/// <returns>
	///   <see langword="true" /> if the IP address is an IPv6 Teredo address; otherwise, <see langword="false" />.</returns>
	public bool IsIPv6Teredo
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets whether the address is an IPv6 Unique Local address.</summary>
	public bool IsIPv6UniqueLocal
	{
		get
		{
			throw null;
		}
	}

	/// <summary>Gets or sets the IPv6 address scope identifier.</summary>
	/// <exception cref="T:System.Net.Sockets.SocketException">
	///   <see langword="AddressFamily" /> = <see langword="InterNetwork" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="scopeId" /> &lt; 0
	///
	/// -or-
	///
	/// <paramref name="scopeId" /> &gt; 0x00000000FFFFFFFF</exception>
	/// <returns>A long integer that specifies the scope of the address.</returns>
	public long ScopeId
	{
		get
		{
			throw null;
		}
		set
		{
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.IPAddress" /> class with the address specified as a <see cref="T:System.Byte" /> array.</summary>
	/// <param name="address">The byte array value of the IP address.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="address" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="address" /> contains a bad IP address.</exception>
	public IPAddress(byte[] address)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.IPAddress" /> class with the address specified as a <see cref="T:System.Byte" /> array and the specified scope identifier.</summary>
	/// <param name="address">The byte array value of the IP address.</param>
	/// <param name="scopeid">The long value of the scope identifier.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="address" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="address" /> contains a bad IP address.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="scopeid" /> &lt; 0 or
	///
	///  <paramref name="scopeid" /> &gt; 0x00000000FFFFFFFF</exception>
	public IPAddress(byte[] address, long scopeid)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.IPAddress" /> class with the address specified as an <see cref="T:System.Int64" />.</summary>
	/// <param name="newAddress">The long value of the IP address. For example, the value 0x2414188f in big-endian format would be the IP address "143.24.20.36".</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="newAddress" /> &lt; 0 or
	///
	///  <paramref name="newAddress" /> &gt; 0x00000000FFFFFFFF</exception>
	public IPAddress(long newAddress)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.IPAddress" /> class with the address specified as a byte span.</summary>
	/// <param name="address">The byte representation of the IP address, in network byte order, with the most significant byte first in index position 0.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="address" /> contains a bad IP address.</exception>
	public IPAddress(ReadOnlySpan<byte> address)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Net.IPAddress" /> class with the address specified as a byte span and the specified scope identifier.</summary>
	/// <param name="address">The byte span value of the IP address.</param>
	/// <param name="scopeid">The long value of the scope identifier.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="address" /> contains a bad IP address.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="scopeid" /> &lt; 0
	///
	/// -or-
	///
	/// <paramref name="scopeid" /> &gt; 0x00000000FFFFFFFF</exception>
	public IPAddress(ReadOnlySpan<byte> address, long scopeid)
	{
	}

	/// <summary>Compares two IP addresses.</summary>
	/// <param name="comparand">An <see cref="T:System.Net.IPAddress" /> instance to compare to the current instance.</param>
	/// <returns>
	///   <see langword="true" /> if the two addresses are equal; otherwise, <see langword="false" />.</returns>
	public override bool Equals([NotNullWhen(true)] object? comparand)
	{
		throw null;
	}

	/// <summary>Provides a copy of the <see cref="T:System.Net.IPAddress" /> as an array of bytes in network order.</summary>
	/// <returns>A <see cref="T:System.Byte" /> array.</returns>
	public byte[] GetAddressBytes()
	{
		throw null;
	}

	/// <summary>Returns a hash value for an IP address.</summary>
	/// <returns>An integer hash value.</returns>
	public override int GetHashCode()
	{
		throw null;
	}

	/// <summary>Converts a short value from host byte order to network byte order.</summary>
	/// <param name="host">The number to convert, expressed in host byte order.</param>
	/// <returns>A short value, expressed in network byte order.</returns>
	public static short HostToNetworkOrder(short host)
	{
		throw null;
	}

	/// <summary>Converts an integer value from host byte order to network byte order.</summary>
	/// <param name="host">The number to convert, expressed in host byte order.</param>
	/// <returns>An integer value, expressed in network byte order.</returns>
	public static int HostToNetworkOrder(int host)
	{
		throw null;
	}

	/// <summary>Converts a long value from host byte order to network byte order.</summary>
	/// <param name="host">The number to convert, expressed in host byte order.</param>
	/// <returns>A long value, expressed in network byte order.</returns>
	public static long HostToNetworkOrder(long host)
	{
		throw null;
	}

	/// <summary>Indicates whether the specified IP address is the loopback address.</summary>
	/// <param name="address">An IP address.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="address" /> is the loopback address; otherwise, <see langword="false" />.</returns>
	public static bool IsLoopback(IPAddress address)
	{
		throw null;
	}

	/// <summary>Maps the <see cref="T:System.Net.IPAddress" /> object to an IPv4 address.</summary>
	/// <returns>Returns <see cref="T:System.Net.IPAddress" />.
	///
	///  An IPv4 address.</returns>
	public IPAddress MapToIPv4()
	{
		throw null;
	}

	/// <summary>Maps the <see cref="T:System.Net.IPAddress" /> object to an IPv6 address.</summary>
	/// <returns>Returns <see cref="T:System.Net.IPAddress" />.
	///
	///  An IPv6 address.</returns>
	public IPAddress MapToIPv6()
	{
		throw null;
	}

	/// <summary>Converts a short value from network byte order to host byte order.</summary>
	/// <param name="network">The number to convert, expressed in network byte order.</param>
	/// <returns>A short value, expressed in host byte order.</returns>
	public static short NetworkToHostOrder(short network)
	{
		throw null;
	}

	/// <summary>Converts an integer value from network byte order to host byte order.</summary>
	/// <param name="network">The number to convert, expressed in network byte order.</param>
	/// <returns>An integer value, expressed in host byte order.</returns>
	public static int NetworkToHostOrder(int network)
	{
		throw null;
	}

	/// <summary>Converts a long value from network byte order to host byte order.</summary>
	/// <param name="network">The number to convert, expressed in network byte order.</param>
	/// <returns>A long value, expressed in host byte order.</returns>
	public static long NetworkToHostOrder(long network)
	{
		throw null;
	}

	/// <summary>Converts an IP address represented as a character span to an <see cref="T:System.Net.IPAddress" /> instance.</summary>
	/// <param name="ipSpan">A character span that contains an IP address in dotted-quad notation for IPv4 and in colon-hexadecimal notation for IPv6.</param>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="ipString" /> is not a valid IP address.</exception>
	/// <returns>The converted IP address.</returns>
	public static IPAddress Parse(ReadOnlySpan<char> ipSpan)
	{
		throw null;
	}

	/// <summary>Converts an IP address string to an <see cref="T:System.Net.IPAddress" /> instance.</summary>
	/// <param name="ipString">A string that contains an IP address in dotted-quad notation for IPv4 and in colon-hexadecimal notation for IPv6.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="ipString" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.FormatException">
	///   <paramref name="ipString" /> is not a valid IP address.</exception>
	/// <returns>An <see cref="T:System.Net.IPAddress" /> instance.</returns>
	public static IPAddress Parse(string ipString)
	{
		throw null;
	}

	/// <summary>Parses a span of characters into a value.</summary>
	/// <param name="s">The span of characters to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
	/// <returns>The result of parsing <paramref name="s" />.</returns>
	static IPAddress ISpanParsable<IPAddress>.Parse(ReadOnlySpan<char> s, IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>Parses a string into a value.</summary>
	/// <param name="s">The string to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
	/// <returns>The result of parsing <paramref name="s" />.</returns>
	static IPAddress IParsable<IPAddress>.Parse(string s, IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>Converts an Internet address to its standard notation.</summary>
	/// <exception cref="T:System.Net.Sockets.SocketException">The address family is <see cref="F:System.Net.Sockets.AddressFamily.InterNetworkV6" /> and the address is bad.</exception>
	/// <returns>A string that contains the IP address in either IPv4 dotted-quad or in IPv6 colon-hexadecimal notation.</returns>
	public override string ToString()
	{
		throw null;
	}

	/// <summary>Formats the value of the current instance using the specified format.</summary>
	/// <param name="format">The format to use.
	///  -or-
	///  A <see langword="null" /> reference (<see langword="Nothing" /> in Visual Basic) to use the default format defined for the type of the <see cref="T:System.IFormattable" /> implementation.</param>
	/// <param name="formatProvider">The provider to use to format the value.
	///  -or-
	///  A <see langword="null" /> reference (<see langword="Nothing" /> in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system.</param>
	/// <returns>The value of the current instance in the specified format.</returns>
	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		throw null;
	}

	/// <summary>Tries to format the current IP address into the provided span.</summary>
	/// <param name="destination">When this method returns, the IP address as a span of characters.</param>
	/// <param name="charsWritten">When this method returns, the number of characters written into the span.</param>
	/// <returns>
	///   <see langword="true" /> if the formatting was successful; otherwise, <see langword="false" />.</returns>
	public bool TryFormat(Span<char> destination, out int charsWritten)
	{
		throw null;
	}

	/// <summary>Tries to format the current IP address into the provided span.</summary>
	/// <param name="utf8Destination">The span into which to write the IP address as a span of UTF-8 bytes.</param>
	/// <param name="bytesWritten">When this method returns, contains the number of bytes written into the <paramref name="utf8Destination" />.</param>
	/// <returns>
	///   <see langword="true" /> if the formatting was successful; otherwise, <see langword="false" />.</returns>
	public bool TryFormat(Span<byte> utf8Destination, out int bytesWritten)
	{
		throw null;
	}

	/// <summary>Tries to format the value of the current instance into the provided span of characters.</summary>
	/// <param name="destination">The span in which to write this instance's value formatted as a span of characters.</param>
	/// <param name="charsWritten">When this method returns, contains the number of characters that were written in <paramref name="destination" />.</param>
	/// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for <paramref name="destination" />.</param>
	/// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="destination" />.</param>
	/// <returns>
	///   <see langword="true" /> if the formatting was successful; otherwise, <see langword="false" />.</returns>
	bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>Tries to format the value of the current instance as UTF-8 into the provided span of bytes.</summary>
	/// <param name="utf8Destination">The span in which to write this instance's value formatted as a span of bytes.</param>
	/// <param name="bytesWritten">When this method returns, contains the number of bytes that were written in <paramref name="utf8Destination" />.</param>
	/// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for <paramref name="utf8Destination" />.</param>
	/// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="utf8Destination" />.</param>
	/// <returns>
	///   <see langword="true" /> if the formatting was successful; otherwise, <see langword="false" />.</returns>
	bool IUtf8SpanFormattable.TryFormat(Span<byte> utf8Destination, out int bytesWritten, ReadOnlySpan<char> format, IFormatProvider provider)
	{
		throw null;
	}

	/// <summary>Tries to parse a span of characters into a value.</summary>
	/// <param name="ipSpan">The byte span to parse.</param>
	/// <param name="address">When this method returns, the <see cref="T:System.Net.IPAddress" /> version of the byte span.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="ipSpan" /> was able to be parsed as an IP address; otherwise, <see langword="false" />.</returns>
	public static bool TryParse(ReadOnlySpan<char> ipSpan, [NotNullWhen(true)] out IPAddress? address)
	{
		throw null;
	}

	/// <summary>Determines whether a string is a valid IP address.</summary>
	/// <param name="ipString">The string to parse.</param>
	/// <param name="address">The <see cref="T:System.Net.IPAddress" /> version of the string.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="ipString" /> is <see langword="null" />.</exception>
	/// <returns>
	///   <see langword="true" /> if <paramref name="ipString" /> was able to be parsed as an IP address; otherwise, <see langword="false" />.</returns>
	public static bool TryParse([NotNullWhen(true)] string? ipString, [NotNullWhen(true)] out IPAddress? address)
	{
		throw null;
	}

	/// <summary>Tries to parse a span of characters into a value.</summary>
	/// <param name="s">The span of characters to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
	/// <param name="result">When this method returns, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="s" /> was successfully parsed; otherwise, <see langword="false" />.</returns>
	static bool ISpanParsable<IPAddress>.TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out IPAddress result)
	{
		throw null;
	}

	/// <summary>Tries to parse a string into an <see cref="T:System.Net.IPAddress" />.</summary>
	/// <param name="s">The string to parse.</param>
	/// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
	/// <param name="result">When this method returns, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
	/// <returns>
	///   <see langword="true" /> if <paramref name="s" /> was successfully parsed; otherwise, <see langword="false" />.</returns>
	static bool IParsable<IPAddress>.TryParse([NotNullWhen(true)] string s, IFormatProvider provider, [NotNullWhen(true)] out IPAddress result)
	{
		throw null;
	}

	/// <summary>Tries to write the current IP address into a span of bytes in network order.</summary>
	/// <param name="destination">When this method returns, the IP address as a span of bytes.</param>
	/// <param name="bytesWritten">When this method returns, the number of bytes written into the span.</param>
	/// <returns>
	///   <see langword="true" /> if the IP address is successfully written to the given span; otherwise, <see langword="false" />.</returns>
	public bool TryWriteBytes(Span<byte> destination, out int bytesWritten)
	{
		throw null;
	}
}
