using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHider : MonoBehaviour
{
    public Image text;
    public void HideButton()
    {
        text.enabled = false;

        GetComponent<Button>().interactable = false;
        GetComponent<RawImage>().enabled = false;
    }
}
