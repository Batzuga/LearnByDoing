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
    [SerializeField] TextMeshPro tmp;
    [SerializeField] GameObject bubble;
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
        if(bubble && player.transform.hasChanged && Vector2.Distance(playerStartp, player.transform.position) > 0.2f)
        {
            Destroy(bubble);
        }
        if(player != null && player.movementSpeed >= 1)
        {
            Trophy.instance.Toggle(true);
            tmp.text = "I'm now open since you finished your task. That's why I'm looking so radiant!";
            
        }
        else
        {
            Trophy.instance.Toggle(false);
            tmp.text = "I'm the Goal. I'm currently closed. That's why I'm looking a little pale.";
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
