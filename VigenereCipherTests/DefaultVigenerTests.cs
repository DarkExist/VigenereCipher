using VigenereCipherApp.VigenereCiphers;

namespace VigenereCipherTests
{
	public class DefaultVigenerTests
	{
		public class EncryptTests
		{
			[Theory]
			[MemberData("MessageArrange")]
			public void Encrypt(string message, string key, string expectedResult)
			{
				VigenereCipher vigenereCipher = new();

				var testResult = vigenereCipher.Encrypt(message, key);
				Assert.Equal(expectedResult, testResult);
			}

			public static IEnumerable<object[]> MessageArrange()
			{
				List<Tuple<string, string, string>> EncryptTestList = new();

				EncryptTestList.Add(Tuple.Create("attackatdawn", "lemon", "v7fyz5of1xh1"));
				EncryptTestList.Add(Tuple.Create("encrypt", "hamster", "vxyjr3k"));
				EncryptTestList.Add(Tuple.Create("houseonthestreet", "key", "12scsm77fy6rbscd"));
				EncryptTestList.Add(Tuple.Create("csharp", "dotnet", "pgax5i"));
				EncryptTestList.Add(Tuple.Create("pythonlang", "duck", "2s511hxu0a"));

				foreach (var item in EncryptTestList)
				{
					yield return new object[] { item.Item1, item.Item2, item.Item3 };
				}
			}
		}

		public class DecryptTests()
		{
			[Theory]
			[MemberData("MessageArrange")]
			public void Decrypt(string message, string key, string expectedResult)
			{
				VigenereCipher vigenereCipher = new();

				var testResult = vigenereCipher.Decrypt(message, key);
				Assert.Equal(expectedResult, testResult);
			}



			public static IEnumerable<object[]> MessageArrange()
			{
				List<Tuple<string, string, string>> DecryptTestList = new();

				DecryptTestList.Add(Tuple.Create("v7fyz5of1xh1", "lemon", "attackatdawn"));
				DecryptTestList.Add(Tuple.Create("vxyjr3k", "hamster", "encrypt"));
				DecryptTestList.Add(Tuple.Create("12scsm77fy6rbscd", "key", "houseonthestreet"));
				DecryptTestList.Add(Tuple.Create("pgax5i", "dotnet", "csharp"));
				DecryptTestList.Add(Tuple.Create("2s511hxu0a", "duck", "pythonlang"));

				foreach (var item in DecryptTestList)
				{
					yield return new object[] { item.Item1, item.Item2, item.Item3 };
				}
			}
		}
	}
}