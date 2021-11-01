using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib.EulerCycleLib.Exceptions
{
	public class NotFoundSuchStartTopException : Exception
	{
		/// <summary>
		/// Такой стартовой вершины не существует!
		/// </summary>
		/// <param name="startTop">Стартовая вершина</param>
		public NotFoundSuchStartTopException(int startTop) : base($"Стартовой вершины '{startTop}' не существует!")
		{
			
		}
	}
}
