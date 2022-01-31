using UnityEngine;
using UnityEngine.UI;

public class UIMainScene : MonoBehaviour
{
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (SessionManager.Instance != null)
        {
            bestScoreText.text = "Best Score : " + SessionManager.Instance.bestPlayerName + " : " + SessionManager.Instance.bestScore;
        }
    }

}
