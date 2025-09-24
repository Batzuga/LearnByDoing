using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collect()
    {
        GameManager.instance.CollectCoin();
        Destroy(this.gameObject);
    }
}
