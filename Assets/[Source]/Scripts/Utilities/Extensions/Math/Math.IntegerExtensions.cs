﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.CGTK;

namespace Utilities.Extensions
{
	public static partial class Math
	{
		public static int Abs(this int value)
		{
			return Mathf.Abs(value);
		}

		public static int ClosestPowerOfTwo(this int value)
		{
			return Mathf.ClosestPowerOfTwo(value);
		}
	}
}
