using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kristal : MonoBehaviour
{
    public GameObject laser1;
    public GameObject laser2;
    public GameObject sahmeran;
    public GameObject zehir;

    public AudioSource laser;
    bool isTimerActive=false;
    double timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (isTimerActive)
        {
            timer += 0.02;
        }
        if (timer > 3)
        {
            laser1.gameObject.SetActive(false);
            laser2.gameObject.SetActive(false);
            sahmeran.gameObject.SetActive(false);
            zehir.SetActive(true);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kristalinYeri")
        {
            isTimerActive = true;

            laser1.gameObject.SetActive(true);
            laser2.gameObject.SetActive(true);
            laser.Play();

        }
    }
}
