using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public ParticleSystem teleport;
    public ParticleSystem gravity;
    public ParticleSystem portal;

    Rigidbody2D myRigidbody;
    bool isGround = false;
    bool facingRight = true;
    bool isRun = false;
    bool isJump = false;
    bool isDead = false;
    float jumpSpeed = 340f;
    public AudioSource torchSound;
    public AudioSource diamondSes;
    public AudioSource teleportSound;

    public AudioSource çokHeyecanlıSes;
    public GameObject çokHeyecanlıTetik;

    public AudioSource lavlarSes;
    public GameObject lavlarTetik;

    public AudioSource inanılmazSes;
    public GameObject inanılmazTetik;

    public AudioSource yerÇekimiSes;
    public GameObject yerÇekimiTetik;

    public GameObject zehir;

    bool changeGravityDown = false;

    public int DiamondCount = 0;
    public int LevelScore;

    [SerializeField] GameObject sarkıt1;
    //public AudioSource sesZıplama;
    //public AudioSource buEngeller;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
     
            if (!changeGravityDown)
            {
                if (myRigidbody.velocity.x < 0 && facingRight)
                {
                    facingRight = !facingRight;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else if (myRigidbody.velocity.x > 0 && !facingRight)
                {
                    facingRight = !facingRight;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else
            {



                if (myRigidbody.velocity.x < 0 && facingRight)
                {
                    facingRight = !facingRight;
                    
                    transform.eulerAngles = new Vector3(0, 0, 180);


                }
                else if (myRigidbody.velocity.x > 0 && !facingRight)
                {
                    facingRight = !facingRight;
                    transform.eulerAngles = new Vector3(0, 180, 180);
                }

            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                isRun = false;
            }
            else
            {
                isRun = true;
            }
            if (Input.GetAxis("Vertical") == 0)
            {
                isJump = false;
            }
            else
            {
                isJump = true;
            }
            GetComponentInChildren<Animator>().SetBool("isRun", isRun);
            GetComponentInChildren<Animator>().SetBool("isJump", isJump);
        GetComponentInChildren<Animator>().SetBool("isDead", isDead);

        GameManager.instance.LevelSonuScoreTxt.text = LevelScore.ToString();
        
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            if (!changeGravityDown)
            {
                myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * 6f, myRigidbody.velocity.y, 0);

                if (Input.GetAxis("Vertical") > 0 && isGround)
                {
                    myRigidbody.velocity = Vector3.zero;
                    GameManager.instance.JumpSound();

                    myRigidbody.AddForce(new Vector2(0, jumpSpeed));
                    isGround = false;

                }
            }
            else
            {

                myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * 6f, myRigidbody.velocity.y, 0);


                //myRigidbody.AddForce(new Vector2(0, 60));

                if (Input.GetAxis("Vertical") > 0 && isGround)
                {
                    myRigidbody.velocity = Vector3.zero;

                    GameManager.instance.JumpSound();

                    myRigidbody.AddForce(new Vector2(0, -jumpSpeed));
                    //transform.position = transform.position + new Vector3(0, -10, 0);
                    isGround = false;


                }
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            GameManager.instance.Deneme();
        }

        //neden oncollisionstay yaptın burayı enter yapsak olur.
      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            isDead = true;
            Debug.Log("sen varya bittin bittin");
            //ölme animasnu fonksiyn içinde oynar

            Invoke("GameOverGecikme", 1.5f);
        }

        if (collision.gameObject.tag == "Diamond")
        {
            diamondSes.Play();
            Debug.Log("Diamond'a Çarptık");
            DiamondCount++;
            LevelScore += 100;
            GameManager.instance.Diamondtext.text = DiamondCount.ToString();
            GameManager.instance.scoreTxt.text = LevelScore.ToString();
            
            Destroy(collision.gameObject);
            //diamond toplama sesi
            
        }

    

        if (collision.gameObject.tag == "Teleport")
        {
            teleport.Play();
            teleportSound.Play();

        }
        if (collision.gameObject.tag == "ChangeGravityDown" && !changeGravityDown)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);

            gravity.Play();
            changeGravityDown = true;
            //platformAfterGravityChange.gameObject.SetActive(true);
            myRigidbody.gravityScale = -1;

        }
        if (collision.gameObject.tag == "sarkıt1")
        {
            portal.Play();

            sarkıt1.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "ChangeGravityUp" && changeGravityDown)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

            gravity.Play();
            changeGravityDown = false;
            //platformAfterGravityChange.gameObject.SetActive(true);
            myRigidbody.gravityScale = 1;
            print("girdi");

        }
        if (collision.gameObject.tag == "buEngeller")
        {
            GameManager.instance.EngelSound();

        }
        if (collision.gameObject.tag == "torch")
        {
            GameManager.instance.torch();

        }
        if (collision.gameObject.tag == "torchSound")
        {
            torchSound.Play();
        }
        if (collision.gameObject.tag == "lastScene")
        {
            GameManager.instance.lastScene();
        }
        if (collision.gameObject.tag == "lav")
        {
            GameManager.instance.lastScene();
        }
        if (collision.gameObject.tag == "çokHeyecanlı")
        {
            çokHeyecanlıSes.Play();
            çokHeyecanlıTetik.SetActive(false);
        }
        if (collision.gameObject.tag == "lavlar")
        {
            lavlarSes.Play();
            lavlarTetik.SetActive(false);
        }
        if (collision.gameObject.tag == "inanılmaz")
        {
            inanılmazSes.Play();
            inanılmazTetik.SetActive(false);
        }
        if (collision.gameObject.tag == "yerÇekimi")
        {
            yerÇekimiSes.Play();
            yerÇekimiTetik.SetActive(false);
        }
        if (collision.gameObject.tag == "zehir")
        {
            zehir.gameObject.SetActive(false);
            print("oyun bitti");
            Invoke("EndGameGecikme", 2f);
            
        }
    }

    void EndGameGecikme()
    {
        GameManager.instance.EndPanel.SetActive(true);
    }
    void GameOverGecikme()
    {
        GameManager.instance.GameOver();
    }
}
