using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using Unity.Mathematics;
using UnityEngine.Animations;
using UnityEditor.Experimental.GraphView;

public class playermovement : MonoBehaviour
{ [SerializeField]
    int maxlives=5;

    public AudioClip throwclip;

  public  Animator anm;
   public float speed = 10f;

    [SerializeField] AudioSource adc;

    [SerializeField] GameObject prejectileprefab;

    public void playcollictiblehealth(AudioClip ac)
    {
        adc.PlayOneShot(ac);
    }

    public int getcurrentlivs { get { return maxlives; } }
    Rigidbody2D rb;
    Vector2 dierection = new Vector2 (1,0);

    // Start is called before the first frame update
    void Start()
    { rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift)) speed = 20; else speed = 10;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(0, move.x) || !Mathf.Approximately(0, move.y))
        {
            dierection.Set(move.x, move.y);
            dierection.Normalize();

        }

        if (Input.GetButtonDown("Fire1"))
        {   
                   GameObject projectile=    Instantiate(prejectileprefab, rb.position+Vector2.up*0.5f, quaternion.identity);
            adc.PlayOneShot(throwclip);
            projectilecontroller pr = projectile.GetComponent<projectilecontroller>();
            
    
            //pr.direction.Set ( dierection.x,dierection.y);
            //pr.force = 1000f;
         //   pr.sset(dierection, 100f);    
                pr.lanuch(dierection, 200f);


        }




        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up *0.2f, dierection, 1.5f,LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NPC nn = hit.collider.gameObject.GetComponent<NPC>();
                if (nn != null) nn.dialog();
                
                //Debug.Log("fuckuuuuuuuuuuuuuuuuuuuuuu");

            }




        }




        anm.SetFloat("Look X", dierection.x);
        anm.SetFloat("Look Y", dierection.y);
        anm.SetFloat("Speed", dierection.magnitude);


//        anm.SetFloat("Speed", math.max(math.abs(horizontal), math.abs(vertical)) * speed * Time.fixedTime);

        //  float virtical = Input.GetAxis("Vertical");
        // transform.Translate(Vector3.right* horizontal * Time.deltaTime);
        Vector3 v,v1;
        v1 = transform.position;
        v1.y += vertical * Time.deltaTime*speed;
        transform.position = v1;
        //        v = transform.position;
        v = rb.position;     
        v.x += horizontal * Time.deltaTime*speed;
        //transform.position = v;
        // rb.position = v;
        rb.MovePosition(v);
        


        

            //+horizontal * Time.deltaTime;
        // transform.position = Vector2.up * virtical * Time.deltaTime;
        
    }



    public void updatelives (int li) {
        maxlives = math.max(0, math.min(5, maxlives + li));

        healthbar.instance.updatesize(maxlives / (float)5);
      //  currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

    }
}
