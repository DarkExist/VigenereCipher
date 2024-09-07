using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipherApp
{
	public class ReadFile
	{
		public readonly string currentFolder = Directory.GetCurrentDirectory();
		public string ReadFromTxt(string filename)
		{
			string text;

			if (filename == null || !filename.EndsWith(".txt"))
			{
				throw new ArgumentException("Only txt files is available");
			}
			try
			{
				using (StreamReader reader = new StreamReader(filename))
				{
					text = reader.ReadToEnd();

				}
			}
			catch (Exception)
			{
				throw;
			}

			return text;
		}
	}
}
