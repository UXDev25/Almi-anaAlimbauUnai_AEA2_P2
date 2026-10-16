using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void LoadScene(string sceneName) 
    {
		TransitionManager.Instance.SetLoadedAndTime(false, 0);
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

		operation.completed += (AsyncOperation op) =>
		{
			TransitionManager.Instance.SetLoadedAndTime(true, 1);
		};
		
	}

	

public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
