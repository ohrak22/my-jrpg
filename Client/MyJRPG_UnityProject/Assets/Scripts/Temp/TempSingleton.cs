using UnityEngine;
using System.Collections;

// Component Type.
public class TempSingleton : MonoBehaviour
{
	private static TempSingleton m_Instance;

	public static TempSingleton Instance
	{
		get
		{
			if(m_Instance == null)
			{
				m_Instance = (TempSingleton)FindObjectOfType(typeof(TempSingleton));

				if(FindObjectsOfType(typeof(TempSingleton)).Length > 1)
				{
					return m_Instance;
				}

				if(m_Instance == null)
				{
					GameObject singleton = new GameObject("TempSingleton");
					m_Instance = singleton.AddComponent<TempSingleton>();

					DontDestroyOnLoad(singleton);
				}
			}

			return m_Instance;
		}
	}
}

// Non Component Type.
public class MySingleton
{
	private static MySingleton instance;

	public static MySingleton Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new MySingleton();
			}

			return instance;
		}
	}
}

