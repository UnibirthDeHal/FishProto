using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public Text cangeText;
    public Text comboText;

    int prosperity = 0;
    int money = 0;
    int combo = 0;

    // Start is called before the first frame update
    void Start()
    {
        prosperity = this.GetComponent<ScoreManagement>().Score;
        money= this.GetComponent<ScoreManagement>().Money;
        combo = this.GetComponent<ScoreManagement>().Combo;

        cangeText.text = "î…ê∑ìx\n" + prosperity + "\nÇ®ìXÇÃÇ®ã‡\n" + money;
        comboText.text = "COMBO\n" + combo;
    }

    // Update is called once per frame
    void Update()
    {
        prosperity = this.GetComponent<ScoreManagement>().Score;
        money = this.GetComponent<ScoreManagement>().Money;
        combo = this.GetComponent<ScoreManagement>().Combo;

        cangeText.text = "î…ê∑ìx\n" + prosperity + "\nÇ®ìXÇÃÇ®ã‡\n" + money;
        comboText.text = "COMBO\n" + combo;
    }
}
