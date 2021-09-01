using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snake : MonoBehaviour
{
    bool attack = false;

    public Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Animator>().SetBool("attack", attack);

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attack = true;
            Debug.Log("bu snake tmm mı");
            healthbar.fillAmount -= 0.1f;
            if(healthbar.fillAmount == 0)
            {
                GameManager.instance.GameOver();
            }

        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attack = false;
        }


    }
}
