using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
	public static class ObjectExtensions
	{
		public static IEnumerable<T> FindObjectsOfType<T>() where T : Object
		{
			return Object.FindObjectsOfType(typeof(T)).Select(x => (T) x);
		}
	}
}
