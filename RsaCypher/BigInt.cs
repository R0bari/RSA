using System;
using System.Collections.Generic;

/** Based on BigInteger.cs by ScottGarland from http://biginteger.codeplex.com/ */
namespace RsaCypher
{
	using DType = System.UInt32; // This could be UInt32, UInt16 or Byte; not UInt64.

	#region DigitsArray
	internal class DigitsArray
	{
		internal DigitsArray(int size)
		{
			Allocate(size, 0);
		}

		internal DigitsArray(int size, int used)
		{
			Allocate(size, used);
		}

		internal DigitsArray(DType[] copyFrom)
		{
			Allocate(copyFrom.Length);
			CopyFrom(copyFrom, 0, 0, copyFrom.Length);
			ResetDataUsed();
		}

		internal DigitsArray(DigitsArray copyFrom)
		{
			Allocate(copyFrom.Count - 1, copyFrom.DataUsed);
			Array.Copy(copyFrom.m_data, 0, m_data, 0, copyFrom.Count);
		}

		private DType[] m_data;

		internal static readonly DType AllBits;		// = ~((DType)0);
		internal static readonly DType HiBitSet;	// = 0x80000000;
		internal static int DataSizeOf
		{
			get { return sizeof(DType); }
		}

		internal static int DataSizeBits
		{
			get { return sizeof(DType) * 8; }
		}

		static DigitsArray()
		{
			unchecked
			{
				AllBits = (DType)~((DType)0);
				HiBitSet = (DType)(((DType)1) << (DataSizeBits) - 1);
			}
		}

		public void Allocate(int size)
		{
			Allocate(size, 0);
		}

		public void Allocate(int size, int used)
		{
			m_data = new DType[size + 1];
			m_dataUsed = used;
		}

		internal void CopyFrom(DType[] source, int sourceOffset, int offset, int length)
		{
			Array.Copy(source, sourceOffset, m_data, 0, length);
		}

		internal void CopyTo(DType[] array, int offset, int length)
		{
			Array.Copy(m_data, 0, array, offset, length);
		}

		internal DType this[int index]
		{
			get
			{
				if (index < m_dataUsed) return m_data[index];
				return (IsNegative ? (DType)AllBits : (DType)0);
			}
			set { m_data[index] = value; }
		}

		private int m_dataUsed;
		internal int DataUsed
		{
			get { return m_dataUsed; }
			set { m_dataUsed = value; }
		}

		internal int Count
		{
			get { return m_data.Length; }
		}

		internal bool IsZero
		{
			get { return m_dataUsed == 0 || (m_dataUsed == 1 && m_data[0] == 0); }
		}

		internal bool IsNegative
		{
			get { return (m_data[m_data.Length - 1] & HiBitSet) == HiBitSet; }
		}

		internal string GetDataAsString()
		{
			string result = "";
			foreach (DType data in m_data) {
				result += data + " ";
			}
			return result;
		}

		internal void ResetDataUsed()
		{
			m_dataUsed = m_data.Length;
			if (IsNegative)
			{
				while (m_dataUsed > 1 && m_data[m_dataUsed - 1] == AllBits)
				{
					--m_dataUsed;
				}
				m_dataUsed++;
			}
			else
			{
				while (m_dataUsed > 1 && m_data[m_dataUsed - 1] == 0)
				{
					--m_dataUsed;
				}
				if (m_dataUsed == 0)
				{
					m_dataUsed = 1;
				}
			}
			m_dataUsed = System.Math.Min(m_data.Length, m_dataUsed);
		}

		internal int ShiftRight(int shiftCount)
		{
			return ShiftRight(m_data, shiftCount);
		}

		internal static int ShiftRight(DType[] buffer, int shiftCount)
		{
			int shiftAmount = DigitsArray.DataSizeBits;
			int invShift = 0;
			int bufLen = buffer.Length;

			while (bufLen > 1 && buffer[bufLen - 1] == 0)
			{
				bufLen--;
			}

			for (int count = shiftCount; count > 0; count -= shiftAmount)
			{
				if (count < shiftAmount)
				{
					shiftAmount = count;
					invShift = DigitsArray.DataSizeBits - shiftAmount;
				}

				ulong carry = 0;
				for (int i = bufLen - 1; i >= 0; i--)
				{
					ulong val = ((ulong)buffer[i]) >> shiftAmount;
					val |= carry;

					carry = ((ulong)buffer[i]) << invShift;
					buffer[i] = (DType)(val);
				}
			}

			while (bufLen > 1 && buffer[bufLen - 1] == 0)
			{
				bufLen--;
			}

			return bufLen;
		}

		internal int ShiftLeft(int shiftCount)
		{
			return ShiftLeft(m_data, shiftCount);
		}

		internal static int ShiftLeft(DType[] buffer, int shiftCount)
		{
			int shiftAmount = DigitsArray.DataSizeBits;
			int bufLen = buffer.Length;

			while (bufLen > 1 && buffer[bufLen - 1] == 0)
			{
				bufLen--;
			}

			for (int count = shiftCount; count > 0; count -= shiftAmount)
			{
				if (count < shiftAmount)
				{
					shiftAmount = count;
				}

				ulong carry = 0;
				for (int i = 0; i < bufLen; i++)
				{
					ulong val = ((ulong)buffer[i]) << shiftAmount;
					val |= carry;

					buffer[i] = (DType)(val & DigitsArray.AllBits);
					carry = (val >> DigitsArray.DataSizeBits);
				}

				if (carry != 0)
				{
					if (bufLen + 1 <= buffer.Length)
					{
						buffer[bufLen] = (DType)carry;
						bufLen++;
						carry = 0;
					}
					else
					{
						throw new OverflowException();
					}
				}
			}
			return bufLen;
		}

		internal int ShiftLeftWithoutOverflow(int shiftCount)
		{
			if (shiftCount == 0) return m_data.Length;

			List<DType> temporary = new List<DType>(m_data);
			int shiftAmount = DigitsArray.DataSizeBits;

			for (int count = shiftCount; count > 0; count -= shiftAmount)
			{
				if (count < shiftAmount)
				{
					shiftAmount = count;
				}

				ulong carry = 0;
				for (int i = 0; i < temporary.Count; i++)
				{
					ulong val = ((ulong)temporary[i]) << shiftAmount;
					val |= carry;

					temporary[i] = (DType)(val & DigitsArray.AllBits);
					carry = (val >> DigitsArray.DataSizeBits);
				}

				if (carry != 0) 
				{
					DType lastNum = (DType)carry;
					if (IsNegative) 
					{
						int byteCount = (int)Math.Floor(Math.Log(carry, 2));
						lastNum = (0xffffffff << byteCount) | (DType)carry;
					}

					temporary.Add(lastNum);
				}
			}
			m_data = new DType[temporary.Count];
			temporary.CopyTo(m_data);
			return m_data.Length;
		}
	}
	#endregion

	/// <summary>
	/// Represents a integer of abitrary length.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A BigInteger object is immutable like System.String. The object can not be modifed, and new BigInteger objects are
	/// created by using the operations of existing BigInteger objects.
	/// </para>
	/// <para>
	/// Internally a BigInteger object is an array of ? that is represents the digits of the n-place integer. Negative BigIntegers
	/// are stored internally as 1's complements, thus every BigInteger object contains 1 or more padding elements to hold the sign.
	/// </para>
	/// </remarks>
	/// <example>
	/// <code>
	/// public class MainProgram
	/// {
	///		[STAThread]
	///		public static void Main(string[] args)
	///		{
	///			BigInteger a = new BigInteger(25);
	///			a = a + 100;
	///			
	///			BigInteger b = new BigInteger("139435810094598308945890230913");
	///			
	///			BigInteger c = b / a;
	///			BigInteger d = b % a;
	///			
	///			BigInteger e = (c * a) + d;
	///			if (e != b)
	///			{
	///				Console.WriteLine("Can never be true.");
	///			}
	///		}
	///	</code>
	/// </example>
	public class BigInt
	{
		private DigitsArray m_digits;

		#region Constructors
		/// <summary>
		/// Create a BigInteger with an integer value of 0.
		/// </summary>
		public BigInt()
		{
			m_digits = new DigitsArray(1, 1);
		}

		/// <summary>
		/// Creates a BigInteger with the value of the operand.
		/// </summary>
		/// <param name="number">A long.</param>
		public BigInt(long number)
		{
			m_digits = new DigitsArray((8 / DigitsArray.DataSizeOf) + 1, 0);
			while (number != 0 && m_digits.DataUsed < m_digits.Count)
			{
				m_digits[m_digits.DataUsed] = (DType)(number & DigitsArray.AllBits);
				number >>= DigitsArray.DataSizeBits;
				m_digits.DataUsed++;
			}
			m_digits.ResetDataUsed();
		}

		/// <summary>
		/// Creates a BigInteger with the value of the operand. Can never be negative.
		/// </summary>
		/// <param name="number">A unsigned long.</param>
		public BigInt(ulong number)
		{
			m_digits = new DigitsArray((8 / DigitsArray.DataSizeOf) + 1, 0);
			while (number != 0 && m_digits.DataUsed < m_digits.Count)
			{
				m_digits[m_digits.DataUsed] = (DType)(number & DigitsArray.AllBits);
				number >>= DigitsArray.DataSizeBits;
				m_digits.DataUsed++;
			}
			m_digits.ResetDataUsed();
		}

		/// <summary>
		/// Creates a BigInteger initialized from the byte array.
		/// </summary>
		/// <param name="array"></param>
		public BigInt(byte[] array)
		{
			ConstructFrom(array, 0, array.Length);
		}

		/// <summary>
		/// Creates a BigInteger initialized from the byte array ending at <paramref name="length" />.
		/// </summary>
		/// <param name="array">A byte array.</param>
		/// <param name="length">Int number of bytes to use.</param>
		public BigInt(byte[] array, int length)
		{
			ConstructFrom(array, 0, length);
		}

		/// <summary>
		/// Creates a BigInteger initialized from <paramref name="length" /> bytes starting at <paramref name="offset" />.
		/// </summary>
		/// <param name="array">A byte array.</param>
		/// <param name="offset">Int offset into the <paramref name="array" />.</param>
		/// <param name="length">Int number of bytes.</param>
		public BigInt(byte[] array, int offset, int length)
		{
			ConstructFrom(array, offset, length);
		}

		private void ConstructFrom(byte[] array, int offset, int length)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (offset > array.Length || length > array.Length)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (length > array.Length || (offset + length) > array.Length)
			{
				throw new ArgumentOutOfRangeException("length");
			}

			int estSize = length / 4;
			int leftOver = length & 3;
			if (leftOver != 0)
			{
				++estSize;
			}

			m_digits = new DigitsArray(estSize + 1, 0); // alloc one extra since we can't init -'s from here.

			for (int i = offset + length - 1, j = 0; (i - offset) >= 3; i -= 4, j++)
			{
				m_digits[j] = (DType)((array[i - 3] << 24) + (array[i - 2] << 16) + (array[i - 1] <<  8) + array[i]);
				m_digits.DataUsed++;
			}

			DType accumulator = 0;
			for (int i = leftOver; i > 0; i--)
			{
				DType digit = array[offset + leftOver - i];
				digit = (digit << ((i - 1) * 8));
				accumulator |= digit;
			}
			m_digits[m_digits.DataUsed] = accumulator;

			m_digits.ResetDataUsed();
		}

		/// <summary>
		/// Creates a BigInteger in base-10 from the parameter.
		/// </summary>
		/// <remarks>
		///  The new BigInteger is negative if the <paramref name="digits" /> has a leading - (minus).
		/// </remarks>
		/// <param name="digits">A string</param>
		public BigInt(string digits)
		{
			Construct(digits, 10);
		}

		/// <summary>
		/// Creates a BigInteger in base and value from the parameters.
		/// </summary>
		/// <remarks>
		///  The new BigInteger is negative if the <paramref name="digits" /> has a leading - (minus).
		/// </remarks>
		/// <param name="digits">A string</param>
		/// <param name="radix">A int between 2 and 36.</param>
		public BigInt(string digits, int radix)
		{
			Construct(digits, radix);
		}

		private void Construct(string digits, int radix)
		{
			if (digits == null)
			{
				throw new ArgumentNullException("digits");
			}

			BigInt multiplier = new BigInt(1);
			BigInt result = new BigInt();
			digits = digits.ToUpper(System.Globalization.CultureInfo.CurrentCulture).Trim();

			int nDigits = (digits[0] == '-' ? 1 : 0);

			for (int idx = digits.Length - 1; idx >= nDigits ; idx--)
			{
				int d = (int)digits[idx];
				if (d >= '0' && d <= '9')
				{
					d -= '0';
				}
				else if (d >= 'A' && d <= 'Z')
				{
					d = (d - 'A') + 10;
				}
				else
				{
					throw new ArgumentOutOfRangeException("digits");
				}

				if (d >= radix)
				{
					throw new ArgumentOutOfRangeException("digits");
				}
				result += (multiplier * d);
				multiplier *= radix;
			}

			if (digits[0] == '-')
			{
				result = -result;
			}

			this.m_digits = result.m_digits;
		}

		/// <summary>
		/// Copy constructor, doesn't copy the digits parameter, assumes <code>this</code> owns the DigitsArray.
		/// </summary>
		/// <remarks>The <paramef name="digits" /> parameter is saved and reset.</remarks>
		/// <param name="digits"></param>
		private BigInt(DigitsArray digits)
		{
			digits.ResetDataUsed();
			this.m_digits = digits;
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// A bool value that is true when the BigInteger is negative (less than zero).
		/// </summary>
		/// <value>
		/// A bool value that is true when the BigInteger is negative (less than zero).
		/// </value>
		public bool IsNegative { get { return m_digits.IsNegative; } }

		/// <summary>
		/// A bool value that is true when the BigInteger is exactly zero.
		/// </summary>
		/// <value>
		/// A bool value that is true when the BigInteger is exactly zero.
		/// </value>
		public bool IsZero { get { return m_digits.IsZero; } }
		#endregion

		#region Implicit Type Operators Overloads

		/// <summary>
		/// Creates a BigInteger from a long.
		/// </summary>
		/// <param name="value">A long.</param>
		/// <returns>A BigInteger initialzed by <paramref name="value" />.</returns>
		public static implicit operator BigInt(long value)
		{
			return (new BigInt(value));
		}

		/// <summary>
		/// Creates a BigInteger from a ulong.
		/// </summary>
		/// <param name="value">A ulong.</param>
		/// <returns>A BigInteger initialzed by <paramref name="value" />.</returns>
		public static implicit operator BigInt(ulong value)
		{
			return (new BigInt(value));
		}

		/// <summary>
		/// Creates a BigInteger from a int.
		/// </summary>
		/// <param name="value">A int.</param>
		/// <returns>A BigInteger initialzed by <paramref name="value" />.</returns>
		public static implicit operator BigInt(int value)
		{
			return (new BigInt((long)value));
		}

		/// <summary>
		/// Creates a BigInteger from a uint.
		/// </summary>
		/// <param name="value">A uint.</param>
		/// <returns>A BigInteger initialzed by <paramref name="value" />.</returns>
		public static implicit operator BigInt(uint value)
		{
			return (new BigInt((ulong)value));
		}
		#endregion

		#region Addition and Subtraction Operator Overloads
		/// <summary>
		/// Adds two BigIntegers and returns a new BigInteger that represents the sum.
		/// </summary>
		/// <param name="leftSide">A BigInteger</param>
		/// <param name="rightSide">A BigInteger</param>
		/// <returns>The BigInteger result of adding <paramref name="leftSide" /> and <paramref name="rightSide" />.</returns>
		public static BigInt operator + (BigInt leftSide, BigInt rightSide)
		{
			int size = System.Math.Max(leftSide.m_digits.DataUsed, rightSide.m_digits.DataUsed);
			DigitsArray da = new DigitsArray(size + 1);

			long carry = 0;
			for (int i = 0; i < da.Count; i++)
			{
				long sum = (long)leftSide.m_digits[i] + (long)rightSide.m_digits[i] + carry;
				carry  = (long)(sum >> DigitsArray.DataSizeBits);
				da[i] = (DType)(sum & DigitsArray.AllBits);
			}

			return new BigInt(da);
		}

		/// <summary>
		/// Adds two BigIntegers and returns a new BigInteger that represents the sum.
		/// </summary>
		/// <param name="leftSide">A BigInteger</param>
		/// <param name="rightSide">A BigInteger</param>
		/// <returns>The BigInteger result of adding <paramref name="leftSide" /> and <paramref name="rightSide" />.</returns>
		public static BigInt Add(BigInt leftSide, BigInt rightSide)
		{
			return leftSide + rightSide;	
		}

		/// <summary>
		/// Increments the BigInteger operand by 1.
		/// </summary>
		/// <param name="leftSide">The BigInteger operand.</param>
		/// <returns>The value of <paramref name="leftSide" /> incremented by 1.</returns>
		public static BigInt operator ++ (BigInt leftSide)
		{
			return (leftSide + 1);
		}

		/// <summary>
		/// Increments the BigInteger operand by 1.
		/// </summary>
		/// <param name="leftSide">The BigInteger operand.</param>
		/// <returns>The value of <paramref name="leftSide" /> incremented by 1.</returns>
		public static BigInt Increment(BigInt leftSide)
		{
			return (leftSide + 1);
		}

		/// <summary>
		/// Substracts two BigIntegers and returns a new BigInteger that represents the sum.
		/// </summary>
		/// <param name="leftSide">A BigInteger</param>
		/// <param name="rightSide">A BigInteger</param>
		/// <returns>The BigInteger result of substracting <paramref name="leftSide" /> and <paramref name="rightSide" />.</returns>
		public static BigInt operator - (BigInt leftSide, BigInt rightSide)
		{
			int size = System.Math.Max(leftSide.m_digits.DataUsed, rightSide.m_digits.DataUsed) + 1;
			DigitsArray da = new DigitsArray(size);

			long carry = 0;
			for (int i = 0; i < da.Count; i++)
			{
				long diff = (long)leftSide.m_digits[i] - (long)rightSide.m_digits[i] - carry;
				da[i] = (DType)(diff & DigitsArray.AllBits);
				da.DataUsed++;
				carry = ((diff < 0) ? 1 : 0);
			}
			return new BigInt(da);
		}

		/// <summary>
		/// Substracts two BigIntegers and returns a new BigInteger that represents the sum.
		/// </summary>
		/// <param name="leftSide">A BigInteger</param>
		/// <param name="rightSide">A BigInteger</param>
		/// <returns>The BigInteger result of substracting <paramref name="leftSide" /> and <paramref name="rightSide" />.</returns>
		public static BigInt Subtract(BigInt leftSide, BigInt rightSide)
		{
			return leftSide - rightSide;
		}

		/// <summary>
		/// Decrements the BigInteger operand by 1.
		/// </summary>
		/// <param name="leftSide">The BigInteger operand.</param>
		/// <returns>The value of the <paramref name="leftSide" /> decremented by 1.</returns>
		public static BigInt operator -- (BigInt leftSide)
		{
			return (leftSide - 1);
		}

		/// <summary>
		/// Decrements the BigInteger operand by 1.
		/// </summary>
		/// <param name="leftSide">The BigInteger operand.</param>
		/// <returns>The value of the <paramref name="leftSide" /> decremented by 1.</returns>
		public static BigInt Decrement(BigInt leftSide)
		{
			return (leftSide - 1);
		}
		#endregion

		#region Negate Operator Overload
		/// <summary>
		/// Negates the BigInteger, that is, if the BigInteger is negative return a positive BigInteger, and if the
		/// BigInteger is negative return the postive.
		/// </summary>
		/// <param name="leftSide">A BigInteger operand.</param>
		/// <returns>The value of the <paramref name="this" /> negated.</returns>
		public static BigInt operator - (BigInt leftSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (leftSide.IsZero)
			{
				return new BigInt(0);
			}

			DigitsArray da = new DigitsArray(leftSide.m_digits.DataUsed + 1, leftSide.m_digits.DataUsed + 1);

			for (int i = 0; i < da.Count; i++)
			{
				da[i] = (DType)(~(leftSide.m_digits[i]));
			}

			// add one to result (1's complement + 1)
			bool carry = true;
			int index = 0;
			while (carry && index < da.Count)
			{
				long val = (long)da[index] + 1;
				da[index] = (DType)(val & DigitsArray.AllBits);
				carry = ((val >> DigitsArray.DataSizeBits) > 0);
				index++;
			}

			return new BigInt(da);
		}

		/// <summary>
		/// Negates the BigInteger, that is, if the BigInteger is negative return a positive BigInteger, and if the
		/// BigInteger is negative return the postive.
		/// </summary>
		/// <returns>The value of the <paramref name="this" /> negated.</returns>
		public BigInt Negate()
		{
			return -this;
		}

		/// <summary>
		/// Creates a BigInteger absolute value of the operand.
		/// </summary>
		/// <param name="leftSide">A BigInteger.</param>
		/// <returns>A BigInteger that represents the absolute value of <paramref name="leftSide" />.</returns>
		public static BigInt Abs(BigInt leftSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}
			if (leftSide.IsNegative)
			{
				return -leftSide;
			}
			return leftSide;
		}
		#endregion

		#region Multiplication, Division and Modulus Operators
		/// <summary>
		/// Multiply two BigIntegers returning the result.
		/// </summary>
		/// <remarks>
		/// See Knuth.
		/// </remarks>
		/// <param name="leftSide">A BigInteger.</param>
		/// <param name="rightSide">A BigInteger</param>
		/// <returns></returns>
		public static BigInt operator * (BigInt leftSide, BigInt rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}
			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			bool leftSideNeg = leftSide.IsNegative;
			bool rightSideNeg = rightSide.IsNegative;

			leftSide = Abs(leftSide);
			rightSide = Abs(rightSide);

			DigitsArray da = new DigitsArray(leftSide.m_digits.DataUsed + rightSide.m_digits.DataUsed);
			da.DataUsed = da.Count;

			for (int i = 0; i < leftSide.m_digits.DataUsed; i++)
			{
				ulong carry = 0;
				for (int j = 0, k = i; j < rightSide.m_digits.DataUsed; j++, k++)
				{
					ulong val = ((ulong)leftSide.m_digits[i] * (ulong)rightSide.m_digits[j]) + (ulong)da[k] + carry;

					da[k] = (DType)(val & DigitsArray.AllBits);
					carry = (val >> DigitsArray.DataSizeBits);
				}

				if (carry != 0)
				{
					da[i + rightSide.m_digits.DataUsed] = (DType)carry;
				}
			}

			//da.ResetDataUsed();
			BigInt result = new BigInt(da);
			return (leftSideNeg != rightSideNeg ? -result : result);
		}

		/// <summary>
		/// Multiply two BigIntegers returning the result.
		/// </summary>
		/// <param name="leftSide">A BigInteger.</param>
		/// <param name="rightSide">A BigInteger</param>
		/// <returns></returns>
		public static BigInt Multiply(BigInt leftSide, BigInt rightSide)
		{
			return leftSide * rightSide;
		}

		/// <summary>
		/// Divide a BigInteger by another BigInteger and returning the result.
		/// </summary>
		/// <param name="leftSide">A BigInteger divisor.</param>
		/// <param name="rightSide">A BigInteger dividend.</param>
		/// <returns>The BigInteger result.</returns>
		public static BigInt operator / (BigInt leftSide, BigInt rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.IsZero)
			{
				throw new DivideByZeroException();
			}

			bool divisorNeg = rightSide.IsNegative;
			bool dividendNeg = leftSide.IsNegative;

			leftSide = Abs(leftSide);
			rightSide = Abs(rightSide);

			if (leftSide < rightSide)
			{
				return new BigInt(0);
			}

			BigInt quotient;
			BigInt remainder;
			Divide(leftSide, rightSide, out quotient, out remainder);

			return (dividendNeg != divisorNeg ? -quotient : quotient);
		}

		/// <summary>
		/// Divide a BigInteger by another BigInteger and returning the result.
		/// </summary>
		/// <param name="leftSide">A BigInteger divisor.</param>
		/// <param name="rightSide">A BigInteger dividend.</param>
		/// <returns>The BigInteger result.</returns>
		public static BigInt Divide(BigInt leftSide, BigInt rightSide)
		{
			return leftSide / rightSide;
		}

		private static void Divide(BigInt leftSide, BigInt rightSide, out BigInt quotient, out BigInt remainder)
		{
			if (leftSide.IsZero)
			{
				quotient = new BigInt();
				remainder = new BigInt();
				return;
			}

			if (rightSide.m_digits.DataUsed == 1)
			{
				SingleDivide(leftSide, rightSide, out quotient, out remainder);
			}
			else
			{
				MultiDivide(leftSide, rightSide, out quotient, out remainder);
			}
		}

		private static void MultiDivide(BigInt leftSide, BigInt rightSide, out BigInt quotient, out BigInt remainder)
		{
			if (rightSide.IsZero)
			{
				throw new DivideByZeroException();
			}

			DType val = rightSide.m_digits[rightSide.m_digits.DataUsed - 1];
			int d = 0;
			for (uint mask = DigitsArray.HiBitSet; mask != 0 && (val & mask) == 0; mask >>= 1)
			{
				d++;
			}

			int remainderLen = leftSide.m_digits.DataUsed + 1;
			DType[] remainderDat = new DType[remainderLen];
			leftSide.m_digits.CopyTo(remainderDat, 0, leftSide.m_digits.DataUsed);

			DigitsArray.ShiftLeft(remainderDat, d);
			rightSide = rightSide << d;

			ulong firstDivisor = rightSide.m_digits[rightSide.m_digits.DataUsed - 1];
			ulong secondDivisor = (rightSide.m_digits.DataUsed < 2 ? (DType)0 : rightSide.m_digits[rightSide.m_digits.DataUsed - 2]);

			int divisorLen = rightSide.m_digits.DataUsed + 1;
			DigitsArray dividendPart = new DigitsArray(divisorLen, divisorLen);
			DType[] result = new DType[leftSide.m_digits.Count + 1];
			int resultPos = 0;

			ulong carryBit = (ulong)0x1 << DigitsArray.DataSizeBits; // 0x100000000
			for (int j = remainderLen - rightSide.m_digits.DataUsed, pos = remainderLen - 1; j > 0; j--, pos--)
			{
				ulong dividend = ((ulong)remainderDat[pos] << DigitsArray.DataSizeBits) + (ulong)remainderDat[pos - 1];
				ulong qHat = (dividend / firstDivisor);
				ulong rHat = (dividend % firstDivisor);

				while (pos >= 2)
				{
					if (qHat == carryBit || (qHat * secondDivisor) > ((rHat << DigitsArray.DataSizeBits) + remainderDat[pos - 2]))
					{
						qHat--;
						rHat += firstDivisor;
						if (rHat < carryBit)
						{
							continue;
						}
					}
					break;
				}

				for (int h = 0; h < divisorLen; h++)
				{
					dividendPart[divisorLen - h - 1] = remainderDat[pos - h];
				}

				BigInt dTemp = new BigInt(dividendPart);
				BigInt rTemp = rightSide * (long)qHat;
				while (rTemp > dTemp)
				{
					qHat--;
					rTemp -= rightSide;
				}

				rTemp = dTemp - rTemp;
				for (int h = 0; h < divisorLen; h++)
				{
					remainderDat[pos - h] = rTemp.m_digits[rightSide.m_digits.DataUsed - h];
				}

				result[resultPos++] = (DType)qHat;
			}

			Array.Reverse(result, 0, resultPos);
			quotient = new BigInt(new DigitsArray(result));

			int n = DigitsArray.ShiftRight(remainderDat, d);
			DigitsArray rDA = new DigitsArray(n, n);
			rDA.CopyFrom(remainderDat, 0, 0, rDA.DataUsed);
			remainder = new BigInt(rDA);
		}

		private static void SingleDivide(BigInt leftSide, BigInt rightSide, out BigInt quotient, out BigInt remainder)
		{
			if (rightSide.IsZero)
			{
				throw new DivideByZeroException();
			}

			DigitsArray remainderDigits = new DigitsArray(leftSide.m_digits);
			remainderDigits.ResetDataUsed();

			int pos = remainderDigits.DataUsed - 1;
			ulong divisor = (ulong)rightSide.m_digits[0];
			ulong dividend = (ulong)remainderDigits[pos];

			DType[] result = new DType[leftSide.m_digits.Count];
			leftSide.m_digits.CopyTo(result, 0, result.Length);
			int resultPos = 0;

			if (dividend >= divisor)
			{
				result[resultPos++] = (DType)(dividend / divisor);
				remainderDigits[pos] = (DType)(dividend % divisor);
			}
			pos--;

			while (pos >= 0)
			{
				dividend = ((ulong)(remainderDigits[pos + 1]) << DigitsArray.DataSizeBits) + (ulong)remainderDigits[pos];
				result[resultPos++] = (DType)(dividend / divisor);
				remainderDigits[pos + 1] = 0;
				remainderDigits[pos--] = (DType)(dividend % divisor);
			}
			remainder = new BigInt(remainderDigits);

			DigitsArray quotientDigits = new DigitsArray(resultPos + 1, resultPos);
			int j = 0;
			for (int i = quotientDigits.DataUsed - 1; i >= 0; i--, j++)
			{
				quotientDigits[j] = result[i];
			}
			quotient = new BigInt(quotientDigits);
		}

		/// <summary>
		/// Perform the modulus of a BigInteger with another BigInteger and return the result.
		/// </summary>
		/// <param name="leftSide">A BigInteger divisor.</param>
		/// <param name="rightSide">A BigInteger dividend.</param>
		/// <returns>The BigInteger result.</returns>
		public static BigInt operator % (BigInt leftSide, BigInt rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}

			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.IsZero)
			{
				throw new DivideByZeroException();
			}

			BigInt quotient;
			BigInt remainder;

			bool dividendNeg = leftSide.IsNegative;
			leftSide = Abs(leftSide);
			rightSide = Abs(rightSide);

			if (leftSide < rightSide)
			{
				return leftSide;
			}

			Divide(leftSide, rightSide, out quotient, out remainder);

			return (dividendNeg ? -remainder : remainder);
		}

		/// <summary>
		/// Perform the modulus of a BigInteger with another BigInteger and return the result.
		/// </summary>
		/// <param name="leftSide">A BigInteger divisor.</param>
		/// <param name="rightSide">A BigInteger dividend.</param>
		/// <returns>The BigInteger result.</returns>
		public static BigInt Modulus(BigInt leftSide, BigInt rightSide)
		{
			return leftSide % rightSide;
		}

		#endregion

		#region Exponentiation

		public BigInt Pow(BigInt power) {
			return Pow (this, power);
		}

		/// <summary>
		/// Returns a base number raised to a specified power. Currently only positive (>= 0) 
		/// exponents allowed.
		/// </summary>
		/// <param name="b">A BigInteger to be raised to a power.</param>
		/// <param name="power">A BigInteger that specifies the power.</param>
		public static BigInt Pow(BigInt b, BigInt power) {

			if (b == null) {
				throw new ArgumentNullException ("b");
			}

			if (power == null) {
				throw new ArgumentNullException("power");
			}

			if (power < 0) {
				throw new ArgumentOutOfRangeException ("power", "Currently negative exponents are not supported");
			}


			BigInt result = 1;
			while (power != 0) {

				if ((power & 1) != 0)
					result *= b;
				power >>= 1;
				b *= b;
			}

			return result;
		}

		#endregion

		#region Bitwise Operator Overloads

		public static BigInt operator & (BigInt leftSide, BigInt rightSide)
		{
			int len = System.Math.Max(leftSide.m_digits.DataUsed, rightSide.m_digits.DataUsed);
			DigitsArray da = new DigitsArray(len, len);
			for (int idx = 0; idx < len; idx++)
			{
				da[idx] = (DType)(leftSide.m_digits[idx] & rightSide.m_digits[idx]);
			}
			return new BigInt(da);
		}

		public static BigInt BitwiseAnd(BigInt leftSide, BigInt rightSide)
		{
			return leftSide & rightSide;
		}

		public static BigInt operator | (BigInt leftSide, BigInt rightSide)
		{
			int len = System.Math.Max(leftSide.m_digits.DataUsed, rightSide.m_digits.DataUsed);
			DigitsArray da = new DigitsArray(len, len);
			for (int idx = 0; idx < len; idx++)
			{
				da[idx] = (DType)(leftSide.m_digits[idx] | rightSide.m_digits[idx]);
			}
			return new BigInt(da);
		}

		public static BigInt BitwiseOr(BigInt leftSide, BigInt rightSide)
		{
			return leftSide | rightSide;
		}

		public static BigInt operator ^ (BigInt leftSide, BigInt rightSide)
		{
			int len = System.Math.Max(leftSide.m_digits.DataUsed, rightSide.m_digits.DataUsed);
			DigitsArray da = new DigitsArray(len, len);
			for (int idx = 0; idx < len; idx++)
			{
				da[idx] = (DType)(leftSide.m_digits[idx] ^ rightSide.m_digits[idx]);
			}
			return new BigInt(da);
		}

		public static BigInt Xor(BigInt leftSide, BigInt rightSide)
		{
			return leftSide ^ rightSide;
		}

		public static BigInt operator ~ (BigInt leftSide)
		{
			DigitsArray da = new DigitsArray(leftSide.m_digits.Count);
			for(int idx = 0; idx < da.Count; idx++)
			{
				da[idx] = (DType)(~(leftSide.m_digits[idx]));
			}

			return new BigInt(da);
		}

		public static BigInt OnesComplement(BigInt leftSide)
		{
			return ~leftSide;
		}

		#endregion

		#region Left and Right Shift Operator Overloads
		public static BigInt operator << (BigInt leftSide, int shiftCount)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}

			DigitsArray da = new DigitsArray(leftSide.m_digits);
			da.DataUsed = da.ShiftLeftWithoutOverflow(shiftCount);

			return new BigInt(da);
		}

		public static BigInt LeftShift(BigInt leftSide, int shiftCount)
		{
			return leftSide << shiftCount;
		}

		public static BigInt operator >> (BigInt leftSide, int shiftCount)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}

			DigitsArray da = new DigitsArray(leftSide.m_digits);
			da.DataUsed = da.ShiftRight(shiftCount);

			if (leftSide.IsNegative)
			{
				for (int i = da.Count - 1; i >= da.DataUsed; i--)
				{
					da[i] = DigitsArray.AllBits;
				}

				DType mask = DigitsArray.HiBitSet;
				for (int i = 0; i < DigitsArray.DataSizeBits; i++)
				{
					if ((da[da.DataUsed - 1] & mask) == DigitsArray.HiBitSet)
					{
						break;
					}
					da[da.DataUsed - 1] |= mask;
					mask >>= 1;
				}
				da.DataUsed = da.Count;
			}

			return new BigInt(da);
		}

		public static BigInt RightShift(BigInt leftSide, int shiftCount)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}

			return leftSide >> shiftCount;
		}
		#endregion

		#region Relational Operator Overloads

		/// <summary>
		/// Compare this instance to a specified object and returns indication of their relative value.
		/// </summary>
		/// <param name="value">An object to compare, or a null reference (<b>Nothing</b> in Visual Basic).</param>
		/// <returns>A signed number indicating the relative value of this instance and <i>value</i>.
		/// <list type="table">
		///		<listheader>
		///			<term>Return Value</term>
		///			<description>Description</description>
		///		</listheader>
		///		<item>
		///			<term>Less than zero</term>
		///			<description>This instance is less than <i>value</i>.</description>
		///		</item>
		///		<item>
		///			<term>Zero</term>
		///			<description>This instance is equal to <i>value</i>.</description>
		///		</item>
		///		<item>
		///			<term>Greater than zero</term>
		///			<description>
		///				This instance is greater than <i>value</i>. 
		///				<para>-or-</para>
		///				<i>value</i> is a null reference (<b>Nothing</b> in Visual Basic).
		///			</description>
		///		</item>
		/// </list>
		/// </returns>
		public int CompareTo(BigInt value)
		{
			return Compare(this, value);
		}

		/// <summary>
		/// Compare two objects and return an indication of their relative value.
		/// </summary>
		/// <param name="leftSide">An object to compare, or a null reference (<b>Nothing</b> in Visual Basic).</param>
		/// <param name="rightSide">An object to compare, or a null reference (<b>Nothing</b> in Visual Basic).</param>
		/// <returns>A signed number indicating the relative value of this instance and <i>value</i>.
		/// <list type="table">
		///		<listheader>
		///			<term>Return Value</term>
		///			<description>Description</description>
		///		</listheader>
		///		<item>
		///			<term>Less than zero</term>
		///			<description>This instance is less than <i>value</i>.</description>
		///		</item>
		///		<item>
		///			<term>Zero</term>
		///			<description>This instance is equal to <i>value</i>.</description>
		///		</item>
		///		<item>
		///			<term>Greater than zero</term>
		///			<description>
		///				This instance is greater than <i>value</i>. 
		///				<para>-or-</para>
		///				<i>value</i> is a null reference (<b>Nothing</b> in Visual Basic).
		///			</description>
		///		</item>
		/// </list>
		/// </returns>
		public static int Compare(BigInt leftSide, BigInt rightSide)
		{
			if (object.ReferenceEquals(leftSide, rightSide))
			{
				return 0;
			}

			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide > rightSide) return 1;
			if (leftSide == rightSide) return 0;
			return -1;
		}

		public static bool operator == (BigInt leftSide, BigInt rightSide)
		{
			if (object.ReferenceEquals(leftSide, rightSide))
			{
				return true;
			}

			if (object.ReferenceEquals(leftSide, null ) || object.ReferenceEquals(rightSide, null ))
			{
				return false;
			}

			if (leftSide.IsNegative != rightSide.IsNegative)
			{
				return false;
			}

			return leftSide.Equals(rightSide);
		}

		public static bool operator != (BigInt leftSide, BigInt rightSide)
		{
			return !(leftSide == rightSide);
		}

		public static bool operator > (BigInt leftSide, BigInt rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.IsNegative != rightSide.IsNegative)
			{
				return rightSide.IsNegative;
			}

			if (leftSide.m_digits.DataUsed != rightSide.m_digits.DataUsed)
			{
				return leftSide.m_digits.DataUsed > rightSide.m_digits.DataUsed;
			}

			for (int idx = leftSide.m_digits.DataUsed - 1; idx >= 0; idx--)
			{
				if (leftSide.m_digits[idx] != rightSide.m_digits[idx])
				{
					return (leftSide.m_digits[idx] > rightSide.m_digits[idx]);
				}
			}
			return false;
		}

		public static bool operator < (BigInt leftSide, BigInt rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.IsNegative != rightSide.IsNegative)
			{
				return leftSide.IsNegative;
			}

			if (leftSide.m_digits.DataUsed != rightSide.m_digits.DataUsed)
			{
				return leftSide.m_digits.DataUsed < rightSide.m_digits.DataUsed;
			}

			for (int idx = leftSide.m_digits.DataUsed - 1; idx >= 0; idx--)
			{
				if (leftSide.m_digits[idx] != rightSide.m_digits[idx])
				{
					return (leftSide.m_digits[idx] < rightSide.m_digits[idx]);
				}
			}
			return false;
		}

		public static bool operator >= (BigInt leftSide, BigInt rightSide)
		{
			return Compare(leftSide, rightSide) >= 0;
		}

		public static bool operator <= (BigInt leftSide, BigInt rightSide)
		{
			return Compare(leftSide, rightSide) <= 0;
		}
		#endregion

		#region Object Overrides
		/// <summary>
		/// Determines whether two Object instances are equal.
		/// </summary>
		/// <param name="obj">An <see cref="System.Object">Object</see> to compare with this instance.</param>
		/// <returns></returns>
		/// <seealso cref="System.Object">System.Object</seealso> 
		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null))
			{
				return false;
			}

			if (object.ReferenceEquals(this, obj))
			{
				return true;
			}

			BigInt c = (BigInt)obj;
			if (this.m_digits.DataUsed != c.m_digits.DataUsed)
			{
				return false;
			}

			for (int idx = 0; idx < this.m_digits.DataUsed; idx++)
			{
				if (this.m_digits[idx] != c.m_digits[idx])
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer has code.</returns>
		/// <seealso cref="System.Object">System.Object</seealso> 
		public override int GetHashCode()
		{
			return this.m_digits.GetHashCode();
		}

		/// <summary>
		///  Returns the array entries as a string. Used for debugging.
		/// </summary>
		/// <returns>The data as string.</returns>
		public string GetDataAsString() {
			return this.m_digits.GetDataAsString ();
		}

		/// <summary>
		/// Converts the numeric value of this instance to its equivalent base 10 string representation.
		/// </summary>
		/// <returns>A <see cref="System.String">String</see> in base 10.</returns>
		/// <seealso cref="System.Object">System.Object</seealso> 
		public override string ToString()
		{
			return ToString(10);
		}
		#endregion

		#region Type Conversion Methods
		/// <summary>
		/// Converts the numeric value of this instance to its equivalent string representation in specified base.
		/// </summary>
		/// <param name="radix">Int radix between 2 and 36</param>
		/// <returns>A string.</returns>
		public string ToString(int radix)
		{
			if (radix < 2 || radix > 36)
			{
				throw new ArgumentOutOfRangeException("radix");
			}

			if (IsZero)
			{
				return "0";
			}

			BigInt a = this;
			bool negative = a.IsNegative;
			a = Abs(this);

			BigInt quotient;
			BigInt remainder;
			BigInt biRadix = new BigInt(radix);

			const string charSet = "0123456789abcdefghijklmnopqrstuvwxyz";
			System.Collections.ArrayList al = new System.Collections.ArrayList();
			while (a.m_digits.DataUsed > 1 || (a.m_digits.DataUsed == 1 && a.m_digits[0] != 0))
			{
				Divide(a, biRadix, out quotient, out remainder);
				al.Insert(0, charSet[(int)remainder.m_digits[0]]);
				a = quotient;
			}

			string result = new String((char[])al.ToArray(typeof(char)));
			if (radix == 10 && negative)
			{
				return "-" + result;
			}

			return result;
		}

		/// <summary>
		/// Returns string in hexidecimal of the internal digit representation.
		/// </summary>
		/// <remarks>
		/// This is not the same as ToString(16). This method does not return the sign, but instead
		/// dumps the digits array into a string representation in base 16.
		/// </remarks>
		/// <returns>A string in base 16.</returns>
		public string ToHexString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.AppendFormat("{0:X}", m_digits[m_digits.DataUsed - 1]);

			string f = "{0:X" + (2 * DigitsArray.DataSizeOf) + "}";
			for (int i = m_digits.DataUsed - 2; i >= 0; i--)
			{
				sb.AppendFormat(f, m_digits[i]);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Returns BigInteger as System.Int16 if possible.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>Int value of BigInteger</returns>
		/// <exception cref="System.Exception">When BigInteger is too large to fit into System.Int16</exception>
		public static int ToInt16(BigInt value)
		{
			if (object.ReferenceEquals(value, null))
			{
				throw new ArgumentNullException("value");
			}
			return System.Int16.Parse(value.ToString(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns BigInteger as System.UInt16 if possible.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception">When BigInteger is too large to fit into System.UInt16</exception>
		public static uint ToUInt16(BigInt value)
		{
			if (object.ReferenceEquals(value, null))
			{
				throw new ArgumentNullException("value");
			}
			return System.UInt16.Parse(value.ToString(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns BigInteger as System.Int32 if possible.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception">When BigInteger is too large to fit into System.Int32</exception>
		public static int ToInt32(BigInt value)
		{
			if (object.ReferenceEquals(value, null))
			{
				throw new ArgumentNullException("value");
			}
			return System.Int32.Parse(value.ToString(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns BigInteger as System.UInt32 if possible.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception">When BigInteger is too large to fit into System.UInt32</exception>
		public static uint ToUInt32(BigInt value)
		{
			if (object.ReferenceEquals(value, null))
			{
				throw new ArgumentNullException("value");
			}
			return System.UInt32.Parse(value.ToString(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns BigInteger as System.Int64 if possible.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception">When BigInteger is too large to fit into System.Int64</exception>
		public static long ToInt64(BigInt value)
		{
			if (object.ReferenceEquals(value, null))
			{
				throw new ArgumentNullException("value");
			}
			return System.Int64.Parse(value.ToString(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture);
		}

		/// <summary>
		/// Returns BigInteger as System.UInt64 if possible.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <exception cref="System.Exception">When BigInteger is too large to fit into System.UInt64</exception>
		public static ulong ToUInt64(BigInt value)
		{
			if (object.ReferenceEquals(value, null))
			{
				throw new ArgumentNullException("value");
			}
			return System.UInt64.Parse(value.ToString(), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture);
		}
		#endregion
	}
}
