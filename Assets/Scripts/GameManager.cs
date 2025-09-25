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
    bool scorefound;
    int coinValue;

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
        scorefound = false;
    }

    /// <summary>
    /// For checking purposes only, don't touch anything inside GameManager.
    /// </summary>
    /// <param name="value"></param>
    public void CollectCoinCheck(int value)
    {
        coinValue = value;
    }

    private void Update()
    {
        TextMeshProUGUI[] scoreText = GameObject.FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None);
        foreach(TextMeshProUGUI tmp in scoreText)
        {
            Debug.Log(tmp.name);
            string t = tmp.text;
            MatchCollection matches = Regex.Matches(t, @"\d+");

            foreach(Match match in matches)
            {
                if (int.TryParse(match.Value, out var v))
                {
                    if (v == coinValue)
                    {
                        scorefound = true;
                    }
                }             
            }       
        }
    }
    public void CollectBag()
    {

    }

    public bool MissionComplete(string currentAnimation)
    {
        if(!scorefound) return false;
        audioSource.Play();
        winScreen.SetActive(true);
        return true;
    }
}
