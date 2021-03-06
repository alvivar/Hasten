// Lists are super cool.

// 2016/01/01 11:52 AM

using System.Collections.Generic;
using UnityEngine;

public static class ListUtil
{
	// Returns a list of all numbers between two numbers, using a divisor as the
	// distance between each number.
	public static List<float> GetNumbersBetween(float number1, float number2, float divisor)
	{
		// Round numbers? <~
		number1 = Mathf.Round(number1 / divisor) * divisor;
		number2 = Mathf.Round(number2 / divisor) * divisor;
		divisor = Mathf.Round(divisor / divisor) * divisor;

		List<float> result = new List<float>();
		float min = Mathf.Min(number1, number2);
		float max = Mathf.Max(number1, number2);

		while (min < max)
		{
			if (!result.Contains(min))
				result.Add(min);

			min += divisor;
		}

		if (!result.Contains(max))
			result.Add(max);

		return result;
	}

	// Returns a list of all Vector3 permutations using lists of x, y and z as
	// source values.
	public static List<Vector3> PermuteToVector3(List<float> xs, List<float> ys, List<float> zs)
	{
		List<Vector3> result = new List<Vector3>();

		foreach (float x in xs)
		{
			Vector3 permutation = Vector3.zero;

			foreach (float y in ys)
			{
				foreach (float z in zs)
				{
					permutation.x = x;
					permutation.y = y;
					permutation.z = z;

					if (!result.Contains(permutation))
						result.Add(permutation);
				}
			}
		}

		return result;
	}
}