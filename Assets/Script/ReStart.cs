using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    //シーンをロードする
    public void LordScene(string str)
    {
        SceneManager.LoadScene(str);
    }
}
