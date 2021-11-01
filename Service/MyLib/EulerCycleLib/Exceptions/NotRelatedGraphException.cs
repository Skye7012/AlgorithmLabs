using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.EulerCycleLib.Exceptions
{
	public class NotRelatedGraphException : Exception
	{
		/// <summary>
		/// Не связный граф!
		/// </summary>
		public NotRelatedGraphException() : base("Не связный граф!")
		{
			
		}
	}
}
