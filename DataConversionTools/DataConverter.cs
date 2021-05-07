// <summary>
// Project Name         :   Data Conversion Tools
// Project Description  :   A simple C# Library for working with Binary, Hex and Strings
// Project Website      :   https://github.com/laidbackcoder/DataConversionTools
// License              :   MIT License
// License URL          :   https://github.com/laidbackcoder/DataConversionTools/blob/master/LICENSE
// </summary>
using System.Globalization;
using System.Text;

namespace PT.DataConversionTools
{
	/// <summary>
	/// General Data Type Conversion Functions
	/// </summary>
	public static class DataConverter
	{
		/// <summary>
		/// Byte Encoding to be used by Default 
		/// </summary>
		private static Encoding encoding = Encoding.Default;
		
		/// <summary>
		/// Convert a Byte[] to a String
		/// </summary>
		/// <param name="bytes">Initial Byte Array</param>
		/// <returns>String from Initial Byte Array</returns>
		public static string BytesToString(byte[] bytes)
		{
			return encoding.GetString(bytes);
		}
				
		/// <summary>
		/// Convert a String to a Byte[]
		/// </summary>
		/// <param name="str">Initial String</param>
		/// <returns>Byte Array from Initial String</returns>
		public static byte[] StringToBytes(string str)
		{
			return encoding.GetBytes(str);
		}
					
		/// <summary>
		/// Convert a Byte[] to a Hex formatted String
		/// </summary>
		/// <param name="bytes">Initial Byte Array</param>
		/// <returns>Hex String from Initial Byte Array</returns>
		public static string BytesToHex(byte[] bytes)
		{
			string output = string.Empty;

            foreach (byte b in bytes)
            {
                output += string.Format("{0:X2}", b).ToLower();
            }
            
            return output;
		}
				
		/// <summary>
		/// Convert a Hex formatted String to a Byte[]
		/// </summary>
		/// <param name="hexStr">Initial Hex String</param>
		/// <returns>Byte Array from Initial Hex String</returns>
		public static byte[] HexToBytes(string hexStr)
		{			
			HexTools.CheckHex(hexStr);			
			
			byte[] output = new byte[hexStr.Length / 2];
			
			for (int i = 0; i < output.Length; i++)
			{
				output[i] = byte.Parse(hexStr.Substring(i * 2, 2), NumberStyles.HexNumber);
			}
					
			return output;
		}
				
		/// <summary>
		/// Convert a Regular String to a Hex formatted String
		/// </summary>
		/// <param name="str">Initial String</param>
		/// <returns>Hex from Initial String</returns>
		public static string StringToHex(string str)
		{
			return BytesToHex(StringToBytes(str));
		}
		
		/// <summary>
		/// Convert a Hex formatted String to a Regular String
		/// </summary>
		/// <param name="hexStr">Initial Hex String</param>
		/// <returns>String from Initial Hex</returns>
		public static string HexToString(string hexStr)
		{
			HexTools.CheckHex(hexStr);	
			
			return BytesToString(HexToBytes(hexStr));
		}
	}
}
