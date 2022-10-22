using System;

namespace PasswordGenerator
{
	static class RandomText
	{
		public const string СapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
		public const string LowercaseLetters = "qwertyuiopasdfghjklzxcvbnm";
		public const string Numbers = "1234567890";
		public const string SpecialCharacters = "!@#$%^&*()_+{}|\\:\"<>?/,.`~'";

		public static string GenRandText(bool useСapitalLetters, bool useLowercaseLetters, bool useNumbers, bool useSpecialCharacters, int length, string charArray = "")
		{
			if (useСapitalLetters)
				charArray += СapitalLetters;
			if (useLowercaseLetters)
				charArray += LowercaseLetters;
			if (useNumbers)
				charArray += Numbers;
			if (useSpecialCharacters)
				charArray += SpecialCharacters;
			return GenRandText(charArray, length);
		}
		public static string GenRandText(string charArray, int length)
		{
			if(charArray.Length <= 1) 
				throw new Exception("Array length is less than allowed");
			if (length <= 1)
				throw new Exception("The length of the received value is less than the allowed one");
			string pass = "";
			Random rand = new Random();
			int charArrayLen = charArray.Length;
			for (int i = 0; i < length; i++)
				pass += charArray[rand.Next(0, charArrayLen)];
			return pass;
		}
	}
}
