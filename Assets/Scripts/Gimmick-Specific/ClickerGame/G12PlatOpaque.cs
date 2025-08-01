using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G12PlatOpaque : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer sr;
    public G12PlatPurchasing G12PP;
    public BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (this.G12PP.platformBought)
        {
            sr.color = new Color(1f, 1f, 1f, 1f);
            boxCollider.isTrigger = false;
        }
        else
        {
            sr.color = new Color(1f, 1f, 1f, .3f);
            boxCollider.isTrigger = true;
        }
    }
}
