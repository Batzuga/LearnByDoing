using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    int score;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
    }

}
