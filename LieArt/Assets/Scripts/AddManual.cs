using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AddManual : MonoBehaviour
{
    void Awake()
    {
        string currentSceneName;

		//----Bgm----
		currentSceneName = SceneManager.GetActiveScene().name;
		switch (currentSceneName) {
		case "Main":
			Sound.PlayBgm ("main");
			break;
		case "Vote":
			Sound.PlayBgm ("vote");
			break;
		}

        //---------Manualが必要か判断し、必要なら追加する---------
        GameObject ManualPanel = GameObject.Find("ManualPanel");
        if (currentSceneName == "PlayerSelect" || currentSceneName == "ThemeCheck" || currentSceneName == "Main" || currentSceneName == "Vote" || currentSceneName == "Result")
        {
            SceneManager.LoadScene("Manual", LoadSceneMode.Additive);
        }
        //--------------------------------------------------------
    }
}
