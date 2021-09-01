using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
   // double timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Invoke("NextLevel" ,  68f);
        /*timer += 0.002f;
        if(timer >= 2.42f)
        {
            NextLevel();
        } */
    }


    void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +1);
    }
}
