using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuScript : MonoBehaviour
{
    private void OnEnable() //Cette fonction s'execute quand le script (le gameObject dans ce cas) est aciv�
    {
        GameManager.instance.LoadScene("HomeScene"); //On charge la scene du menu gr�ce au GameManager
    }
}
