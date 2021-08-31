using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiecontroller : MonoBehaviour
{
    bool broken = false;
    //  [SerializeField] GameObject smoke;
    [SerializeField] ParticleSystem smoke;
    Animator anim;
    Rigidbody2D rb;
    int directionchoice = 1;
    int positive = 1;
     float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    bool b = true;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
            speed = 20;
        else speed = 5;

        if (broken) return;


        if (directionchoice == 1)
        {
            transform.Translate ( Vector3.right * positive * speed * Time.deltaTime);

            anim.SetFloat("vert", 0);
                

            if (positive < -0.5f) anim.SetFloat("hort", -1f);
            else if (positive > 0.5f) anim.SetFloat("hort", 1f);
            else anim.SetFloat("hort", 0f);

        }
    else { transform.Translate(Vector3.up * positive * speed * Time.deltaTime);



            anim.SetFloat("hort", 0);


            if (positive < -0.5f) anim.SetFloat("vert", -1f);
            else if (positive > 0.5f) anim.SetFloat("vert", 1f);
            else anim.SetFloat("vert", 0f);


        }
        if (b)
        {
            b = false;
            StartCoroutine(generatee());
        }

        
    }

    IEnumerator generatee() {
    yield  return new WaitForSeconds(0.8f);
        b = true;
        directionchoice = Random.Range(0, 2);
        positive = Random.Range(-1, 2);
    
    }

    public void fix()
    {
        broken = true;
        anim.SetTrigger("Fixed");
        rb.simulated = false;
        smoke.Stop();
//        smoke.SetActive(true);

    }





}
