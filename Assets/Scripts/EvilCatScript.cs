using UnityEngine;

public class EvilCatScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject goal = GameObject.FindGameObjectWithTag("Goal");
        Destroy(goal);
        Debug.Log("Meow-ha-haa!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
