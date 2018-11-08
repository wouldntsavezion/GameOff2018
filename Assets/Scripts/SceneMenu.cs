using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour {
    private void Start() {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 20;
    }

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