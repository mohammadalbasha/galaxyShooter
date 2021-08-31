using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilecontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    //public Vector2 direction;
    //public float force;
    /*
    public void sset (Vector2 v,float f)
    
    {
        direction = v;
        force = f;
       // addforce = true;

    }

    // Start is called before the first frame update
    /*void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }*/

    // awake instead of start to get rigidbody in the same frame


    // Update is called once per frame

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    /*
    private void FixedUpdate()
    { if (addforce)
        {
            rb.AddForce(direction * force);

            addforce = false;

        }
        }

    */
    public void lanuch(Vector2 direction, float power)
    {


                rb.AddForce(direction*power);
       
        ;
    }


   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // .collider necaues collision here isnt game object
        enemiecontroller e = collision.collider.GetComponent<enemiecontroller>();
        if (e != null) e.fix();
        //else return;
        //collision.rigidbody.simulated(true);
        Destroy(gameObject);

    }
}
