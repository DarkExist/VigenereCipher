using System.Security.Cryptography;

namespace VigenereCipherCore;

public class HashFunctions
{
	public static Dictionary<string, HashAlgorithm> Algorithms { get; private set; } =
		new Dictionary<string, HashAlgorithm>()
		{
				{ "SHA-256", SHA256.Create() },
				{ "MD5", MD5.Create() },
		};
}
