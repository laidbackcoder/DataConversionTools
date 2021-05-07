// <summary>
// Project Name         :   Data Conversion Tools
// Project Description  :   A simple C# Library for working with Binary, Hex and Strings
// Project Website      :   https://github.com/laidbackcoder/DataConversionTools
// License              :   MIT License
// License URL          :   https://github.com/laidbackcoder/DataConversionTools/blob/master/LICENSE
// </summary>
using NUnit.Framework;
using PT.DataConversionTools.Exceptions;

namespace PT.DataConversionTools.Tests
{
	/// <summary>
	/// Test Fixtures for the <see cref="DataConverter" /> class.
	/// </summary>
	[TestFixture]
	public class DataConverterTests
	{
		[Test]
		public void DataConverter_BytesTostring_OutputSameAsKnownString()
		{			
			byte[] initialBytes = { 0x61, 0x62, 0x63 };
			string expectedString = "abc";
								
			string actualString = DataConverter.BytesToString(initialBytes);
			
			Assert.AreEqual(expectedString, actualString);
		}
		
		[Test]
		public void DataConverter_StringToBytes_OutputSameAsKnownBytes()
		{			
			string initialString = "abc";
			byte[] expectedBytes = { 0x61, 0x62, 0x63 };
								
			byte[] actualBytes = DataConverter.StringToBytes(initialString);
			
			Assert.AreEqual(expectedBytes, actualBytes);
		}
		
		[Test]
		public void DataConverter_BytesToHex_OutputSameAsKnownHex()
		{			
			byte[] initialBytes = { 0xAA, 0xBB, 0xCC };
			string expectedHex = "aabbcc";
								
			string actualHex = DataConverter.BytesToHex(initialBytes);
			
			Assert.AreEqual(expectedHex, actualHex);
		}
		
		[Test]
		public void DataConverter_HexToBytes_OutputSameAsKnownBytes()
		{
			string initialHex = "aabbcc";
			byte[] expectedBytes = { 0xAA, 0xBB, 0xCC };
								
			byte[] actualBytes = DataConverter.HexToBytes(initialHex);
			
			Assert.AreEqual(expectedBytes, actualBytes);
		}
		
		[Test]
		public void DataConverter_HexToBytes_ThrowsExceptionWhenNumberOfHexCharsAreOdd()
		{
			Assert.Throws<InvalidHexException>(() => 
            {        
	            DataConverter.HexToBytes("AAB");
            });
		}
		
		[Test]
		public void DataConverter_HexToBytes_DoesNotThrowsExceptionWhenNumberOfHexCharsAreEven()
		{
			Assert.DoesNotThrow(() => 
            {        
	            DataConverter.HexToBytes("AABB");
            });
		}
		
		[Test]
		public void DataConverter_HexToBytes_ThrowsExceptionWhenHexContainsInvalidChars()
		{
			Assert.Throws<InvalidHexException>(() => 
            {        
			    // 'G' is not Valid in Hex                                                               	
	            DataConverter.HexToBytes("AABG");
            });
		}
		
		[Test]
		public void DataConverter_HexToBytes_DoesNotThrowsExceptionWhenAllHexCharsAreValid()
		{
			Assert.DoesNotThrow(() => 
            {   
				// Testing with Every Valid Char			                    	
	            DataConverter.HexToBytes("0123456789ABCDEF");
            });
		}
		
		[Test]
		public void DataConverter_StringToHex_OutputSameAsKnownHex()
		{			
			string initialString = "abc";
			string expectedHex = "616263";
								
			string actualHex = DataConverter.StringToHex(initialString);
			
			Assert.AreEqual(expectedHex, actualHex);
		}
				
		[Test]
		public void DataConverter_HexToString_OutputSameAsKnownBytes()
		{
			string initialHex = "616263";
			string expectedString = "abc";
								
			string actualString = DataConverter.HexToString(initialHex);
			
			Assert.AreEqual(expectedString, actualString);
		}
		
		[Test]
		public void DataConverter_HexToString_ThrowsExceptionWhenNumberOfHexCharsAreOdd()
		{
			Assert.Throws<InvalidHexException>(() => 
            {        
	            DataConverter.HexToString("AAB");
            });
		}
		
		[Test]
		public void DataConverter_HexToString_DoesNotThrowsExceptionWhenNumberOfHexCharsAreEven()
		{
			Assert.DoesNotThrow(() => 
            {        
	            DataConverter.HexToString("AABB");
            });
		}
		
		[Test]
		public void DataConverter_HexToString_ThrowsExceptionWhenHexContainsInvalidChars()
		{
			Assert.Throws<InvalidHexException>(() => 
            {        
			    // 'G' is not Valid in Hex                                                               	
	            DataConverter.HexToString("AABG");
            });
		}
		
		[Test]
		public void DataConverter_HexToString_DoesNotThrowsExceptionWhenAllHexCharsAreValid()
		{
			Assert.DoesNotThrow(() => 
            {   
				// Testing with Every Valid Char			                    	
	            DataConverter.HexToString("0123456789ABCDEF");
            });
		}
	}
}
