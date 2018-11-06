using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour {
    public void onStartClick() {
        SceneManager.LoadScene(1);
    }

    public void onExitClick() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit ();
        #endif
    }
}