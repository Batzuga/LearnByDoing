using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject winScreen;
    [SerializeField] TextMeshPro scoreText;
    int coinsCollected;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if(instance != null)
        {
            if(instance != this)
            {
                Destroy(this);
            }
        }
    }
  
    public void CollectCoin()
    {
        coinsCollected++;
        scoreText.text = $"{coinsCollected}/3";
    }

    public bool MissionComplete(string currentAnimation)
    {
        if (currentAnimation != "Cody_Jumping") return false;     
        audioSource.Play();
        winScreen.SetActive(true);
        return true;
    }
}
