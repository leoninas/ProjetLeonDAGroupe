using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuScript : MonoBehaviour
{
    private void OnEnable() //Cette fonction s'execute quand le script (le gameObject dans ce cas) est acivé
    {
        GameManager.instance.LoadScene("HomeScene"); //On charge la scene du menu grâce au GameManager
    }
}
