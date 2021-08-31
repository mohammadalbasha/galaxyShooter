using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increasehealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int id;
    [SerializeField] AudioClip audioclip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playermovement pp = collision.GetComponent<playermovement>();
        if (pp != null)
        {

            if (id == 0)
            {
                pp.playcollictiblehealth(audioclip);
                if (pp.getcurrentlivs < 5)
                {
                    pp.updatelives(1);
                    Destroy(this.gameObject);

                }
            }
            else
            {if (pp.getcurrentlivs > 0)

                    pp.updatelives(-1);



            }
            if (pp.getcurrentlivs == 0)
            {
                Destroy(collision.gameObject);


            }



        }
    }

}
