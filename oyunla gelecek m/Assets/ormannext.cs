using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ormannext : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
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
