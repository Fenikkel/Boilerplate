using UnityEngine;

public class Block : MonoBehaviour
{
    /* Variables */
    [SerializeField]
    protected int _Life = 2;

    [SerializeField]
    protected AudioClip _HitSound;
    [SerializeField]
    protected AudioClip _DestroySound;

    /* Methods */
    public virtual void Mine()
    {
        _Life -= 1;

        if (_Life <= 0) // Destroy block
        {
            DestroyBlock();
        }
        else // Hit the block
        {
            HitBlock();
        }
    }

    protected virtual void DestroyBlock() 
    {
        AudioSource.PlayClipAtPoint(_DestroySound, Vector3.zero);

        Destroy(this.gameObject);
    }

    protected virtual void HitBlock()
    {
        AudioSource.PlayClipAtPoint(_HitSound, Vector3.zero);
    }
}
