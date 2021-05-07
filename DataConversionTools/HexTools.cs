// <summary>
// Project Name         :   Data Conversion Tools
// Project Description  :   A simple C# Library to for working with Binary, Hex and Strings
// Project Website      :   https://github.com/laidbackcoder/DataConversionTools
// License              :   MIT License
// License URL          :   https://github.com/laidbackcoder/DataConversionTools/blob/master/LICENSE
// </summary>
using System.Text.RegularExpressions;
using PT.DataConversionTools.Exceptions;

namespace PT.DataConversionTools
{
	/// <summary>
	/// Helper Methods for Working with Hex strings
	/// </summary>
	public static class HexTools
	{		
		/// <summary>
		/// Check if Hex String is Valid and Throw Appropriate Exception if not
		/// </summary>
		/// <param name="hexStr">Hex String</param>
		public static void CheckHex(string hexStr)
		{
			if (!HexLengthValid(hexStr) && !HexCharsValid(hexStr))
			{
				throw new InvalidHexException("Hex String contains invalid characters, and has an odd number of characters");
			}
			else if (!HexLengthValid(hexStr))
			{
				throw new InvalidHexException("Hex String has an odd number of characters");
			}
			else if (!HexCharsValid(hexStr))
			{
				throw new InvalidHexException("Hex String contains invalid characters");
			}
		}		
		
		/// <summary>
		/// Check if Hex String is Valid
		/// </summary>
		/// <param name="hexStr">Hex String</param>
		/// <returns>True if Valid</returns>
		public static bool HexValid(string hexStr)
		{
			if (HexCharsValid(hexStr) && HexLengthValid(hexStr))
			{
				return true;   	
			}
			else
			{
				return false;
			}
		}		
		
		/// <summary>
		/// Add Value Separator to Hex String
		/// Note: This should be used for display purposes only
		/// </summary>
		/// <param name="hexStr">Hex String</param>
		/// <param name="separator">Hex Pair Separator</param>
		/// <returns>Original Hex String with Values Separated</returns>
		public static string AddSeparatorToHex(string hexStr, char separator)
		{		
			CheckHex(hexStr);			
			CheckHexSeparator(separator);
			
			string hexPairSeparator = separator.ToString();
			int hexPairs = hexStr.Length / 2;
			string output = string.Empty;
						
			for (int i = 0; i < hexPairs; i++)
			{
				// Last Hex Pair
				if (i == (hexPairs - 1))
				{
					output += hexStr.Substring(i * 2, 2);
				}
				else
				{
					output += string.Format("{0}{1}", hexStr.Substring(i * 2, 2), hexPairSeparator);
				}
			}
			
			return output;
		}
		
		/// <summary>
		/// Remove Value Separator from Hex String
		/// Note: This should done before processing any Hex data
		/// </summary>
		/// <param name="hexStr">Hex String</param>
		/// <param name="separator">Hex Pair Separator</param>
		/// <returns>Original Hex String without Separated Values</returns>
		public static string RemoveSeparatorFromHex(string hexStr, char separator)
		{
			CheckHexSeparator(separator);
			
			string output = hexStr.Replace(separator.ToString(), string.Empty);
					
			CheckHex(output);
			
			return output;
		}
		
		#region Private Helper Methods
		
			/// <summary>
			/// Check Hex String does not contain any Invalid Characters
			/// </summary>
			/// <param name="hexStr">Hex String</param>
			/// <returns>True if All Chars are Valid</returns>
			private static bool HexCharsValid(string hexStr)
			{				
				return Regex.IsMatch(hexStr, @"^[a-fA-F0-9]*$", RegexOptions.None);
			}
			
			/// <summary>
			/// Check Hex String contains an Even Number of Characters
			/// </summary>
			/// <param name="hexStr">Hex String</param>
			/// <returns>True if Length is Valid</returns>
			private static bool HexLengthValid(string hexStr)
			{
				return hexStr.Length % 2 == 0;
			}
		
			/// <summary>
			/// Check Hex Pair Separator is Valid and Throw Appropriate Exception if not
			/// </summary>
			/// <param name="separator">Hex Pair Separator</param>
			private static void CheckHexSeparator(char separator)
			{
				if (HexCharsValid(separator.ToString()))
				{
					throw new InvalidHexException("Valid Hex Characters cannot be used as a Hex Pair Separator");
				}
			}
		
		#endregion
	}
}
