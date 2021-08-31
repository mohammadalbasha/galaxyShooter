using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{[SerializeField]
     GameObject img;

    float disblaytime = 4;
    float currentdisplay=-1f;


    // Start is called before the first frame update
    void Start()
    {
        currentdisplay = -1;
    }

    // Update is called once per frame
    void Update()
    {if (currentdisplay <0f)
        {
            img.SetActive(false);
        }

    else
        {
            currentdisplay -= Time.deltaTime;

        }
        
    }


    public void dialog()
    {        
        

        img.SetActive(true);

        currentdisplay = disblaytime;



    }
}
