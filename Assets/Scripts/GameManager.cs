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
    [SerializeField] Door door;

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
        if (!door.isOpen && door.GetComponent<SpriteRenderer>().sprite != door.openTexture && door.GetComponent<BoxCollider2D>().enabled) return false;
        audioSource.Play();
        winScreen.SetActive(true);
        return true;
    }
}
