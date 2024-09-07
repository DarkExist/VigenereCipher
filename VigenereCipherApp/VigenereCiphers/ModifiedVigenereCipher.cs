using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VigenereCipherCore;

namespace VigenereCipherApp.VigenereCiphers
{
	public class ModifiedVigenereCipher : VigenereCipher
	{
		private readonly HashAlgorithm hashAlgorithm = HashFunctions.Algorithms["SHA-256"];
		public ModifiedVigenereCipher() : base() { }

		public ModifiedVigenereCipher(List<string> alphabet) : base(alphabet) { }

		public override string Decrypt(string message, string key)
		{
			message = message.ToLower().Replace(" ", "");
			key = key.ToLower().Replace(" ", "");

			string result = "";

			if (!CheckPossibilityOfEncryption(message, key))
				return result;

			var hashKey = CreateHashKey(key, message.Length);

			return base.Decrypt(message, hashKey);
		}

		public override string Encrypt(string message, string key)
		{
			message = message.ToLower().Replace(" ", "");
			key = key.ToLower().Replace(" ", "");

			string result = "";

			if (!CheckPossibilityOfEncryption(message, key))
				return result;

			var hashKey = CreateHashKey(key, message.Length);

			return base.Encrypt(message, hashKey);
		}

		private string CreateHashKey(string key, int messageLength)
		{
			string hashKey = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(key)).ToString()!;

			while (hashKey.Length < messageLength)
			{
				hashKey += hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(hashKey)).ToString()!;
			}

			return hashKey;
		}
	}
}
