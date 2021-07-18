using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GunEnabler : MonoBehaviour
{
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            gameObject.active = false;
        }
        else
        {
            gameObject.active = true;
        }
    }
}
