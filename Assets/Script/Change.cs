using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Change : MonoBehaviour
{
    public Text cangeText;
    public Text comboText;
    public Transform Canvas;
    public RawImage Bossimage;
    public RawImage Userimage;
    public VideoClip BossVideo1;
    public VideoClip BossVideo2;
    public VideoClip BossVideo3;

    int prosperity = 0;
    int TargetPros = 0;
    int money = 0;
    int combo = 0;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        prosperity = this.GetComponent<ScoreManagement>().Score;
        money= this.GetComponent<ScoreManagement>().Money;
        combo = this.GetComponent<ScoreManagement>().Combo;

        TargetPros = prosperity + 200;

        cangeText.text = "î…ê∑ìx\n" + prosperity + "\nÇ®ìXÇÃÇ®ã‡\n" + money;
        comboText.text = "COMBO\n" + combo;
        Bossimage.GetComponent<VideoPlayer>().clip = BossVideo1;
    }

    // Update is called once per frame
    void Update()
    {
        prosperity = this.GetComponent<ScoreManagement>().Score;
        money = this.GetComponent<ScoreManagement>().Money;
        combo = this.GetComponent<ScoreManagement>().Combo;

        cangeText.text = "î…ê∑ìx\n" + prosperity + "\nÇ®ìXÇÃÇ®ã‡\n" + money;
        comboText.text = "COMBO\n" + combo;

        switch (combo)
        {
            case 0:

                    Bossimage.GetComponent<VideoPlayer>().clip = BossVideo1;

                break;

            case 2:

                    Bossimage.GetComponent<VideoPlayer>().clip = BossVideo2;

                break;

            case 4:

                    Bossimage.GetComponent<VideoPlayer>().clip = BossVideo3;

                break;
        }

        if (prosperity >= TargetPros)
        {
            Instantiate(Userimage, (Userimage.transform.position + new Vector3(625.0f + (count * 50.0f), 450.0f, 0.0f)), Quaternion.identity, Canvas);
            TargetPros += 200;
            count++;
        }
    }
}
