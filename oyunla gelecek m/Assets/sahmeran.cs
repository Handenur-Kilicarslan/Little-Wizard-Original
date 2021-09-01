using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sahmeran : MonoBehaviour
{
    bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<Animator>().SetBool("isAttack", isAttack);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttack = true;
        }
    }
}
