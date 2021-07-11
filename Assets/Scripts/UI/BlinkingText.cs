using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BlinkingText : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text;
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
        StartCoroutine("BlinkText");
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            text.enabled = !text.enabled;
        }
    }
}
