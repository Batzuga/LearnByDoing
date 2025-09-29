using UnityEngine;

public class Door : MonoBehaviour
{
    [HideInInspector] public bool isOpen;
    SpriteRenderer rend;
    BoxCollider2D col;
    public Sprite openTexture;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        col.enabled = true;
        isOpen = false;
    }


    void OpenDoor()
    {
        isOpen = true;
        rend.sprite = openTexture;
        col.enabled = false;
    }
}
