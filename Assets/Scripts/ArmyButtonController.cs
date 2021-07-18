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
        sawAllNotes = (gameObject.GetComponentInParent<CanvasManager>().numberOfNotesRead >= 7); 
        if (!sawAllNotes) Join.interactable = false;
        else { Join.interactable = true; }
    }
}
