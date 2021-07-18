using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArmyButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool sawAllNotes = false;
    public Button Join;
    public void goToVN() {
        if (!sawAllNotes) return;
        SceneManager.LoadScene("OutsideFPSRoom");
    }
    public void BeNothing()
    {
        Debug.Log("e");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void Update()
    {
        if (!sawAllNotes) Join.enabled = false;
        else { Join.enabled = true; }
    }
}
