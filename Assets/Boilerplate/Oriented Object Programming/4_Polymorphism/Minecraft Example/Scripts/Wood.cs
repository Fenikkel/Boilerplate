using UnityEngine;
using UnityEngine.UI;

public class Wood : Block
{
    protected override void HitBlock()
    {
        base.HitBlock();

        RectTransform rt = GetComponent<RectTransform>();

        rt.localScale = new Vector3(rt.localScale.x * -1, rt.localScale.y, rt.localScale.z); ;
    }
}
