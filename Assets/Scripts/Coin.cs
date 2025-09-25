using UnityEngine;

public class Coin : MonoBehaviour
{
    int value;
    private void Start()
    {
        value = Random.Range(1300, 2048);
    }
   
    public void Collect()
    {
        ScoreManager.instance.AddScore(value);
        GameManager.instance.CollectCoinCheck(value);
        Destroy(this.gameObject);
    }
}
