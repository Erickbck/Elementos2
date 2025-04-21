using UnityEngine;

public class player : MonoBehaviour
{

//Vai se foder denis
//vai se foder denis parte 2
//vai se foder denis parte 3
//vai se foder denis parte 4

    public float Speed;
    public float JumpForce;
    

    bool Pulando;
    bool PuloDuplo;

    private Rigidbody2D rig;
    private Animator anim;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("MovDireito", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("MovDireito", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("MovDireito", false);
        }

    }

    void jump()
    {

        if(Input.GetButtonDown("Jump"))
        {
            if(!Pulando)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                PuloDuplo = true;
                anim.SetBool("PuloDir", true);

            }
            else
            {
                if(PuloDuplo)
                {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                PuloDuplo = false;
                anim.SetBool("PuloDir", false);
                anim.SetBool("PuloDir", true);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.layer == 8)
        {
            Pulando = false;
            anim.SetBool("PuloDir", false);

        }
    }

    void OnCollisionExit2D(Collision2D colisao)
    {
        if(colisao.gameObject.layer == 8)
        {
            Pulando = true;
            anim.SetBool("PuloDir", true);
        }
    }
}

// teste omg teste teste teste