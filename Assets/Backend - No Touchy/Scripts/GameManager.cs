using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Windows;

/// <summary>
/// Don't make changes to the Game Manager. It keeps track that you're not cheating ;).
/// </summary>
/// 
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject winScreen;
    Player player;
    [SerializeField] Light2D tmp;
    [SerializeField] GameObject bubble;
    [SerializeField] TextMeshPro bubbleTxt;
    Vector2 playerStartp;
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
        player = GameObject.FindFirstObjectByType<Player>();
        playerStartp = player.transform.position;
    }


    private void Update()
    {
        if(tmp != null && tmp.intensity == 1f)
        {
            Trophy.instance.Toggle(true);
            bubble.SetActive(false);
        }
        else if(tmp.intensity < 1f)
        {
            Trophy.instance.Toggle(false);
            bubble.SetActive(true);
            bubbleTxt.text = "I'm so scared! It's so dark!\r\nWhere did the sun go!? ";
        }
        else if(tmp.intensity > 1f)
        {
            bubble.SetActive(true);
            bubbleTxt.text = "Aaaaaah! My eeeeyes! It's too bright. Aaaah!";
        }
    }

    public bool MissionComplete()
    {
        if (!Trophy.instance.EndGame()) return false;
        audioSource.Play();
        winScreen.SetActive(true);
        return true;
    }
}
