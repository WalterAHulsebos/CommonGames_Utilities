﻿namespace Utilities.CGTK
{
	 using System;
	 using System.Collections;
	 using System.Collections.Generic;
	 using UnityEngine;

	 using Random = System.Random;
	 
	 public static partial class CGRandom
	 {
		 private static readonly Random _Random = new Random();
		 
		 /// <summary>
		 /// Returns random value in range
		 /// </summary>
		 public static float RandomRange(float min, float max, Random random = null)
		 {
			 Random usedRandom = random ?? _Random;
			 float lerp = (float)usedRandom.NextDouble();
			 return Mathf.Lerp(min, max, lerp);
		 }
	 
		 public static Vector3 RandomVector3(float min, float max, Random random = null)
		 {
			 Random usedRandom = random ?? _Random;
			 return new Vector3(
				 RandomRange(min, max, random), 
				 RandomRange(min, max, random), 
				 RandomRange(min, max, random));
		 }
	 
		 public static Vector3Int RandomVector3Int(float min, float max, Random random = null)
		 {
			 Vector3 vector = RandomVector3(min, max, random);
			 return new Vector3Int(
				 Mathf.RoundToInt(vector.x), 
				 Mathf.RoundToInt(vector.y), 
				 Mathf.RoundToInt(vector.z));
		 }	
	}
}