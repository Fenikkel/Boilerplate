using UnityEngine;
using UnityEngine.UI;

public class Rock : Block
{
    /* ALERT: this script is simplified for learning. Do NOT make and collect the drops like this :D */
    [SerializeField]
    protected AudioClip _CollectSound;

    [SerializeField]
    protected Sprite _DropSprite;

    public override void Mine()
    {
        _Life -= 1;

        if (_Life == 0) // Destroy block
        {
            this.DestroyBlock();
        }
        else if (_Life < 0) // Collect the drop
        {
            CollectDrop();
        }
        else // Hit the block
        {
            HitBlock();
        }
    }

    protected override void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(_DestroySound, Vector3.zero);
        GetComponent<Image>().sprite = _DropSprite;
    }

    private void CollectDrop() 
    {
        AudioSource.PlayClipAtPoint(_CollectSound, Vector3.zero);
        Destroy(this.gameObject);
    }
}
