using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decreasehealth : MonoBehaviour
{
    // Start is called before the first frame update
    bool candecrase = true;
    float decrasetime = 0.5f;
    playermovement p;
    // Update is called once per frame
    void Update()
    {
        if (candecrase == false)
        {

            decrasetime += Time.deltaTime;



        }
        if (decrasetime >= 5)
        {
            candecrase = true;
            decrasetime = 0;


        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        p = collision.GetComponent<playermovement>();
        if (p != null)
        {if (candecrase)
            {
                p.updatelives(-1);
                if (p.getcurrentlivs == 0) Destroy(collision.gameObject);
                candecrase = false;

                p.anm.SetTrigger("Hit");

            }
        

        }
    }




}
