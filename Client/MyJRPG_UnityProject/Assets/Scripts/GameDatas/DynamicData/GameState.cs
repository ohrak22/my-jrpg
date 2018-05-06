using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameState
{
	public enum Map
	{
		LocalMap,
		WorldMap
	}
	public Map map;
	public Vector2 worldPosition;
	public Vector2 localPosition;
	
}
