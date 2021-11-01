using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.EulerCycleLib.Exceptions
{
	public class EmptyAdjacencyListException : Exception
	{
		/// <summary>
		/// Список связности пуст
		/// </summary>
		public EmptyAdjacencyListException() : base("Список связности пуст")
		{
			
		}
	}
}
