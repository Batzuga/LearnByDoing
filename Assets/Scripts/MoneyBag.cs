using UnityEngine;

public class MoneyBag : MonoBehaviour
{
    Texture2D texture;
    Sprite sprite;
    float ppu = 0;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        texture = sprite.texture;
        ppu = sprite.pixelsPerUnit;
    }
    public void Collect()
    {
        if(texture.filterMode == FilterMode.Point && ppu == 32 )
        {
            GameManager.instance.CollectBag();
            Destroy(gameObject);
        }
    }
}
