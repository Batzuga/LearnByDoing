using UnityEngine;

public class Trophy : MonoBehaviour
{
    public static Trophy instance;

    bool goalAcive;

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

    public bool EndGame()
    {
        if(!goalAcive)
        {
            Debug.Log("Mee-yarrr!");
            transform.position = new Vector2(9, 2);
        }
        return goalAcive;
    }
}
