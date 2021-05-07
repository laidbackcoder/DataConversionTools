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
	/// Helper Methods for Working with Base64 strings
	/// </summary>
	public class Base64Tools
	{
		/// <summary>
		/// Check if Base64 String is Valid and Throw Appropriate Exception if not
		/// </summary>
		/// <param name="base64Str">Base64 String</param>
		public static void CheckBase64(string base64Str)
		{
			if (!Base64Valid(base64Str))
			{
				throw new InvalidBase64Exception("Base64 String contains invalid characters, and has an Invalid number of characters");
			}
			else if (!Base64LengthValid(base64Str))
			{
				throw new InvalidBase64Exception("Base64 String has an invalid number of characters");
			}
			else if (!Base64CharsValid(base64Str))
			{
				throw new InvalidBase64Exception("Base64 String contains invalid characters");
			}
		}
		
		/// <summary>
		/// Check if Base64 String is Valid
		/// </summary>
		/// <param name="base64Str">Base64 String</param>
		/// <returns>True if Valid</returns>
		public static bool Base64Valid(string base64Str)
		{
			if (Base64CharsValid(base64Str) && Base64LengthValid(base64Str))
			{
				return true;   	
			}
			else
			{
				return false;
			}
		}
		
		#region Private Helper Methods
		
			/// <summary>
			/// Check Base64 String does not contain any Invalid Characters
			/// </summary>
			/// <param name="base64Str">Base64 String</param>
			/// <returns>True if All Chars are Valid</returns>
			private static bool Base64CharsValid(string base64Str)
			{				
				return Regex.IsMatch(base64Str.Trim(), @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
			}
			
			/// <summary>
			/// Check Base64 String contains valid Number of Characters (MOD 4)
			/// </summary>
			/// <param name="base64Str">Base64 String</param>
			/// <returns>True if Length is Valid</returns>
			private static bool Base64LengthValid(string base64Str)
			{
				return base64Str.Trim().Length % 4 == 0;
			}
		
		#endregion
	}
}
