namespace VigenereCipherApp
{
	public class SaveFile
	{
		public readonly string currentFolder = Directory.GetCurrentDirectory();

		public async Task SaveToTxtAsync(string message)
		{
			var currentDate = DateTime.Now.ToString("dd'_'MM'_'yyyy'_'HH'_'mm'_'ss");
			string fileName = $"{currentDate}_{GenerateRandomString(5)}";
			try
			{
				await using (StreamWriter outputfile = new StreamWriter(Path.Combine(currentFolder, fileName)))
				{
					outputfile.WriteLine(message);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public string GenerateRandomString(int length)
		{
			var result = string.Empty;
			var random = new Random();
			string Alphabet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";

			for (int i = 0; i < length; i++)
			{
				result += Alphabet[random.Next(Alphabet.Length)];
			}

			return result;
		}
	}
}
