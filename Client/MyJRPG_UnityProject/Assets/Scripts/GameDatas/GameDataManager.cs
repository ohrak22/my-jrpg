using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
	private static GameDataManager m_Instance;

	public static GameDataManager Instance
	{
		get
		{
			if(m_Instance == null)
			{
				m_Instance = (GameDataManager)FindObjectOfType(typeof(GameDataManager));

				if(FindObjectsOfType(typeof(GameDataManager)).Length > 1)
				{
					return m_Instance;
				}

				if(m_Instance == null)
				{
					GameObject singleton = new GameObject("GameDataManager");
					m_Instance = singleton.AddComponent<GameDataManager>();

					DontDestroyOnLoad(singleton);
				}
			}

			return m_Instance;
		}
	}

	public GameState gameState;

	public void Load(int slot)
	{
		string path = Application.streamingAssetsPath + "/SaveData.json";

		if(File.Exists(path))
		{
			string json = File.ReadAllText(path);
			List<GameState> list = JsonConvert.DeserializeObject<List<GameState>>(json);
			gameState = list[slot];
		}
	}

	public void Save(int slot)
	{
		string path = Application.streamingAssetsPath + "/SaveData.json";

		if(File.Exists(path))
		{
			string json = File.ReadAllText(path);
			List<GameState> list = JsonConvert.DeserializeObject<List<GameState>>(json);
			list[slot] = gameState;
			string serializedData = JsonConvert.SerializeObject(list);
			File.WriteAllText(path, serializedData);
		}
	}
}
