using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour
{
public    Image mask;
    float wide;


    public static healthbar instance { get; private set; }

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        wide = mask.rectTransform.rect.width;
        
    }

    // Update is called once per frame
  public void updatesize(float x)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, wide * x);

    }
}
