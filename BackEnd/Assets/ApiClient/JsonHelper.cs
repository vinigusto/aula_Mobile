﻿
using UnityEngine;
using System;

public class JsonHelper
{
	public static T[] getJsonArray<T>(string json)
	{
		// { "array" : ... }
		string newJson = "{\"array\":" + json + "}";
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);

		return wrapper.array;
	}

	[System.Serializable]
	private class Wrapper<T>
	{
		public T[] array;
	}
}