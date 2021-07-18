using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordButton : MonoBehaviour
{
    // Start is called before the first frame update
   public void openDiscord()
    {
        Application.OpenURL("https://discord.gg/CmDnBBUAdp");
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
