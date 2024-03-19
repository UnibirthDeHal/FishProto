using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public Text cangeText;
    public Text comboText;

    float prosperity = 0f;
    float money = 0f;
    float combo = 0f;

    // Start is called before the first frame update
    void Start()
    {
        cangeText.text = "î…ê∑ìx\n" + prosperity + "\nÇ®ìXÇÃÇ®ã‡\n" + money;
        comboText.text = "COMBO\n" + combo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            prosperity += 10f;
            money += 10f;
            combo += 1f;
        }
        cangeText.text = "î…ê∑ìx\n" + prosperity + "\nÇ®ìXÇÃÇ®ã‡\n" + money;
        comboText.text = "COMBO\n" + combo;
    }
}
