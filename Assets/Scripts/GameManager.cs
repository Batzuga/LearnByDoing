using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject winScreen;
    [SerializeField] TextMeshPro scoreText;
    int bagsCollected;

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
  
    public void CollectBag()
    {
        bagsCollected++;
        scoreText.text = $"MoneyBag {bagsCollected}/1";
    }

    public bool MissionComplete(string currentAnimation)
    {
        if (bagsCollected != 1) return false;     
        audioSource.Play();
        winScreen.SetActive(true);
        return true;
    }
}
