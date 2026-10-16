using UnityEditorInternal;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
	public static TransitionManager Instance;
	public bool HasLoaded { get; set; }
	
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}


    public void SetLoadedAndTime(bool hasLoaded, float time) 
	{
		Time.timeScale = time;
		Instance.HasLoaded = hasLoaded;
		gameObject.SetActive(true);
	}

	
}
