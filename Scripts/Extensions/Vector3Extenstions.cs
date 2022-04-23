using System;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
	public static class Vector3Extenstions
	{
		public static bool IsWithinDistanceOf(this Vector3 thisVector, Vector3 otherVector, float distance, bool includeX = true, bool includeY = true, bool includeZ = true)
		{
			// Bad arguments
			if (distance < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(distance));
			}

			// Trivial case
			if (!includeX && !includeY && !includeZ)
			{
				return true;
			}

			// Keep total of differences for quick exit
			float deltaTotal = 0;

			// Calculate X difference and check for quick exit
			float deltaX = 0;
			if (includeX)
			{
				deltaX = Math.Abs(thisVector.x - otherVector.x);
				if (deltaX > distance)
				{
					return false;
				}
				deltaTotal += deltaX;
			}

			// Calculate Y difference and check for quick exit
			float deltaY = 0;
			if (includeY)
			{
				deltaY = Math.Abs(thisVector.y - otherVector.y);
				if (deltaY > distance)
				{
					return false;
				}
				deltaTotal += deltaY;
				if (deltaTotal > distance)
				{
					return false;
				}
			}

			// Calculate Z difference and check for quick exit
			float deltaZ = 0;
			if (includeZ)
			{
				deltaZ = Math.Abs(thisVector.z - otherVector.z);
				if (deltaZ > distance)
				{
					return false;
				}
				deltaTotal += deltaZ;
				if (deltaTotal > distance)
				{
					return false;
				}
			}

			// Slow calculation
			return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2) + Math.Pow(deltaZ, 2)) <= distance;
		}
	}
}
