using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = "Best Score: " + SessionManager.Instance.bestPlayerName + " : " + SessionManager.Instance.bestScore;
    }

    public void StartNew()
    {
        SessionManager.Instance.playerName = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SessionManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
