using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigenereCipherCore;

namespace VigenereCipherApp.VigenereCiphers
{
	public class VigenereCipher : IEncryption, IDecryption
	{
		public List<string> Alphabet { get; private set; } = new();
		public void AlhabetFill()
		{
			for (int i = 0; i <= 9; i++)
			{
				Alphabet.Add(i.ToString());
			}
			for (char i = 'a'; i <= 'z'; i++)
			{
				Alphabet.Add(i.ToString());
			}
		}

		public VigenereCipher()
		{
			AlhabetFill();
		}

		public VigenereCipher(List<string> alphabet)
		{
			Alphabet = alphabet;
		}

		protected bool CheckPossibilityOfEncryption(string message, string key)
		{
			if (key.Length == 0 || message.Length == 0)
				return false;


			/*if (!message.All(letter => Alphabet.Contains(letter.ToString())))
                return false;

            if (!key.All(letter => Alphabet.Contains(letter.ToString())))
                return false;*/

			return true;
		}

		public virtual string Decrypt(string message, string key)
		{
			message = message.ToLower().Replace(" ", "");
			key = key.ToLower().Replace(" ", "");

			/*message = message.Replace(" ", "");
            key = key.Replace(" ", "");*/

			string result = "";

			if (!CheckPossibilityOfEncryption(message, key))
				return result;

			for (int i = 0; i < message.Length; i++)
			{
				string messageLetter = message[i].ToString();

				if (!Alphabet.Contains(messageLetter))
				{
					result += messageLetter;
					continue;
				}

				string keyLetter = key[i % key.Length].ToString();
				int AlphabetIndexMessageLetter = Alphabet.FindIndex(symbol => symbol == messageLetter);
				int AlphabetIndexKeyLetter = Alphabet.FindIndex(symbol => symbol == keyLetter);

				int resultIndex = AlphabetIndexMessageLetter - AlphabetIndexKeyLetter;
				if (resultIndex < 0)
					resultIndex += Alphabet.Count;

				result += Alphabet[resultIndex % Alphabet.Count];
			}


			return result;

		}

		public virtual string Encrypt(string message, string key)
		{
			message = message.ToLower().Replace(" ", "");
			key = key.ToLower().Replace(" ", "");

			/*message = message.Replace(" ", "");
			key = key.Replace(" ", "");*/

			string result = "";

			if (!CheckPossibilityOfEncryption(message, key))
				return result;


			for (int i = 0; i < message.Length; i++)
			{
				string messageLetter = message[i].ToString();

				if (!Alphabet.Contains(messageLetter))
				{
					result += messageLetter;
					continue;
				}

				string keyLetter = key[i % key.Length].ToString();
				int AlphabetIndexMessageLetter = Alphabet.FindIndex(symbol => symbol == messageLetter);
				int AlphabetIndexKeyLetter = Alphabet.FindIndex(symbol => symbol == keyLetter);

				result += Alphabet[(AlphabetIndexMessageLetter + AlphabetIndexKeyLetter) % Alphabet.Count];
			}

			return result;
		}
	}
}
