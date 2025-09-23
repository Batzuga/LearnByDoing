using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject winScreen;


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
  
    public void MissionComplete()
    {
        audioSource.Play();
        winScreen.SetActive(true);

    }
}
