using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class containing general easing functions 
/// </summary>
public static class Easeee
{

	public enum EaseType
	{
		In,
		Out,
		InOut
	}

	/// <summary>
	/// Apply an ease to a interpolation value from zero to one
	/// </summary>
	/// <param name="easeType">The easing type to use - In, Out or InOut</param>
	/// <param name="power">The easing power to use (2 for quadratic, 3 for cubic, etc)</param>
	/// <param name="t">The interpolation parameter to apply easing to</param>
	/// <returns>An eased version of the interpolation parameter t</returns>
	public static float Ease(EaseType easeType, int power, float t)
	{
		switch (easeType) {
			case EaseType.In:
				return EaseIn(power, t);
			case EaseType.Out:
				return EaseOut(power, t);
			case EaseType.InOut:
				return EaseInOut(power, t);
			default:
				throw new System.FormatException("Unexpected value provided for EaseType: " + easeType.ToString());
		}
	}

	/// <summary>
	/// Apply an ease in to an interpolation value from zero to one
	/// </summary>
	/// <param name="power">The easing power to use (2 for quadratic, 3 for cubic, etc)</param>
	/// <param name="t">The interpolation parameter to apply easing to</param>
	/// <returns></returns>
	public static float EaseIn(int power, float t)
	{
		t = Mathf.Clamp01(t);
		return power < 2 ? t : Mathf.Pow(t, power);
	}

	/// <summary>
	/// Apply an ease out to an interpolation value from zero to one
	/// </summary>
	/// <param name="power">The easing power to use (2 for quadratic, 3 for cubic, etc)</param>
	/// <param name="t">The interpolation parameter to apply easing to</param>
	/// <returns></returns>
	public static float EaseOut(int power, float t)
	{
		t = Mathf.Clamp01(t);
		if (power < 2) return t;

		return (power % 2 == 0 ? -1f : 1f) * Mathf.Pow(t - 1f, power) + 1f;
	}

	/// <summary>
	/// Apply an ease in and out to an interpolation value from zero to one
	/// </summary>
	/// <param name="power">The easing power to use (2 for quadratic, 3 for cubic, etc)</param>
	/// <param name="t">The interpolation parameter to apply easing to</param>
	/// <returns></returns>
	public static float EaseInOut(int power, float t)
	{
		t = Mathf.Clamp01(t);
		if (power < 2) return t;

		if (t < 0.5f) return Mathf.Pow(2f, power - 1) * Mathf.Pow(t, power);
		return (power % 2 == 0 ? -1f : 1f) * Mathf.Pow(2f, power - 1) * Mathf.Pow(t - 1f, power) + 1f;
	}
	
}