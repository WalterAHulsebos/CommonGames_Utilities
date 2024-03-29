﻿using UnityEngine;

namespace Utilities.CGTK.Greasy
{
	public static class LightTweens
	{
		public static Coroutine ColorTo (this Light light, Color to, float duration, EaseType ease)
		{
			return Greasy.To(light.color, to, duration, ease, x => light.color = x);
		}
		public static Coroutine ColorTo (this Light light, Color to, float duration, EaseMethod ease)
		{
			return Greasy.To(light.color, to, duration, ease, x => light.color = x);
		}

		public static Coroutine IntensityTo (this Light light, float to, float duration, EaseType ease)
		{
			return Greasy.To(light.intensity, to, duration, ease, x => light.intensity = x);
		}
		public static Coroutine IntensityTo (this Light light, float to, float duration, EaseMethod ease)
		{
			return Greasy.To(light.intensity, to, duration, ease, x => light.intensity = x);
		}

		public static Coroutine ShadowStrengthTo (this Light light, float to, float duration, EaseType ease)
		{
			return Greasy.To(light.shadowStrength, to, duration, ease, x => light.shadowStrength = x);
		}
		public static Coroutine ShadowStrengthTo (this Light light, float to, float duration, EaseMethod ease)
		{
			return Greasy.To(light.shadowStrength, to, duration, ease, x => light.shadowStrength = x);
		}
	}
}