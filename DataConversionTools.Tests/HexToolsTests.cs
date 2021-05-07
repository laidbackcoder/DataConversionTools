// <summary>
// Project Name         :   Data Conversion Tools
// Project Description  :   A simple C# Library to for working with Binary, Hex and Strings
// Project Website      :   https://github.com/laidbackcoder/DataConversionTools
// License              :   MIT License
// License URL          :   https://github.com/laidbackcoder/DataConversionTools/blob/master/LICENSE
// </summary>
using NUnit.Framework;
using PT.DataConversionTools.Exceptions;

namespace PT.DataConversionTools.Tests
{
	/// <summary>
	/// Test Fixtures for the <see cref="HexTools" /> class.
	/// </summary>
	[TestFixture]
	public class HexToolsTests
	{
		[Test]
		public void HexTools_CheckHex_ThrowsExceptionWhenNumberOfHexCharsAreOdd()
		{
			Assert.Throws<InvalidHexException>(() => 
            {        
	            HexTools.CheckHex("AAB");
            });
		}
		
		[Test]
		public void HexTools_CheckHex_DoesNotThrowsExceptionWhenNumberOfHexCharsAreEven()
		{
			Assert.DoesNotThrow(() => 
            {        
	            HexTools.CheckHex("AABB");
            });
		}
		
		[Test]
		public void HexTools_CheckHex_ThrowsExceptionWhenHexContainsInvalidChars()
		{
			Assert.Throws<InvalidHexException>(() => 
            {        
			    // 'G' is not Valid in Hex                                                               	
	            HexTools.CheckHex("AABG");
            });
		}
		
		[Test]
		public void HexTools_CheckHex_DoesNotThrowsExceptionWhenAllHexCharsAreValid()
		{
			Assert.DoesNotThrow(() => 
            {   
				// Testing with Every Valid Char			                    	
	           HexTools.CheckHex("0123456789ABCDEF");
            });
		}
	}
}
