using System;

namespace Assets.Scripts.Extensions
{
	public static class MathHelpers
	{
		public static float Clamp(float value, float minimum = 0, float maximum = 1) => Math.Max(Math.Min(value, maximum), minimum);
	}
}
