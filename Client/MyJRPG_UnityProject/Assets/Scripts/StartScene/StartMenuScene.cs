using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScene : MonoBehaviour
{
	public enum State
	{
		LoadGameData
	}

	private State state;
	[SerializeField]
	private GameObject menumPanel;
	[SerializeField]
	private GameObject continuePanel;
	[SerializeField]
	private GameState newGameState;

	void Start()
	{
		GameDataManager.Instance.gameState = newGameState;
	}

	void Update()
	{

	}

	public void OnNewGame()
	{
		SceneManager.LoadScene("StartMenu");
	}

	public void OnContinue()
	{
		menumPanel.SetActive(false);
		continuePanel.SetActive(true);
	}

	public void OnSelectSlot(int index)
	{
		GameDataManager.Instance.Load(index);
		if(GameDataManager.Instance.gameState.map == GameState.Map.LocalMap)
		{
			SceneManager.LoadScene("LocalMap");
		}
		else
		{
			SceneManager.LoadScene("WorldMap");
		}
	}

	public void OnQuit()
	{
		Application.Quit();
	}

	[MenuItem("CONTEXT/StartMenuScene/Save")]
	static void Save()
	{
		GameState state = new GameState();
		state.map = GameState.Map.LocalMap;
		state.worldPosition = new Vector2(0, 0);
		state.localPosition = new Vector2(-100, -100);
		string serializedData = JsonConvert.SerializeObject(state);

		// Save static data.
		string path = Application.dataPath + "/Resources/GameDatas/StaticData/DefaultGameState.json";
		File.WriteAllText(path, serializedData);

		// Save dynamic data.
		List<GameState> list = new List<GameState>(4);
		for(int i = 0; i < 4; i++)
		{
			list.Add(state);
		}
		serializedData = JsonConvert.SerializeObject(list);
		path = Application.streamingAssetsPath + "/SaveData.json";
		File.WriteAllText(path, serializedData);

		AssetDatabase.Refresh();
	}
}
