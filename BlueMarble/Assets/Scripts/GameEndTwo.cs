using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndTwo : MonoBehaviour
{
    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void Quit()
    {
#if UNITY_EDITOR //유니티 에디터모드에서 
        UnityEditor.EditorApplication.isPlaying = false;
#else //빌드한후
            Application.Quit();
#endif

    }
}