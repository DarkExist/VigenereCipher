using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipherCore
{
	public interface IDecryption
	{
		public string Decrypt(string message, string key);
	}
}
