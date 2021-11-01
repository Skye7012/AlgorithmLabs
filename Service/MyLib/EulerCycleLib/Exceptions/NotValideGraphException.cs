using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.EulerCycleLib.Exceptions
{
	public class NotValideGraphException : Exception
	{
		/// <summary>
		/// Не корректный граф!
		/// </summary>
		public NotValideGraphException() : base("Не корректный граф!")
		{
			
		}
	}
}
