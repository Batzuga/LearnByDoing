using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject winScreen;
    [SerializeField] TextMeshPro scoreText;
    int bagsCollected;
    [SerializeField] GameObject trophy;
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
        Rigidbody2D rb = trophy.GetComponent<Rigidbody2D>();
        if (rb == null || rb.gravityScale <= 0 || !rb.simulated) return false; 
        audioSource.Play();
        winScreen.SetActive(true);
        return true;
    }
}
