// <summary>
// Project Name         :   Data Conversion Tools
// Project Description  :   A simple C# Library to for working with Binary, Hex and Strings
// Project Website      :   https://github.com/laidbackcoder/DataConversionTools
// License              :   MIT License
// License URL          :   https://github.com/laidbackcoder/DataConversionTools/blob/master/LICENSE
// </summary>
using System;
using System.Runtime.Serialization;

namespace PT.DataConversionTools.Exceptions
{
	/// <summary>
	/// Invalid Base64 Exception
	/// </summary>
	public class InvalidBase64Exception : Exception, ISerializable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidBase64Exception" /> class.
		/// </summary>
		/// <param name="message">Error Message</param>
	 	public InvalidBase64Exception(string message) : base(message)
		{
		}
	}
}