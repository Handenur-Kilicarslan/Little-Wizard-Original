using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ormanPlayer : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    bool facingRight = true;
    bool isRun = false;
    bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * 6f, myRigidbody.velocity.y, 0);

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
        if (myRigidbody.velocity.x != 0)
        {
            isRun = true;
            print("koşuyorum");
        }
        else
        {
            isRun = false;
        }
        GetComponentInChildren<Animator>().SetBool("isRun", isRun);
        GetComponentInChildren<Animator>().SetBool("isJump", isJump);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "magara")
        {
            Debug.Log("MAGARADAYIZ");
            Invoke("NextLevel", 1f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
