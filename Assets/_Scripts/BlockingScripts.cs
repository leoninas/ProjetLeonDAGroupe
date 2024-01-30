using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockingScripts : MonoBehaviour
{
    [SerializeField] private GameObject Padlock; //On d�finit les composants qui serviront par la suite
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>(); //On r�cup�re le composant button
    }

    public void Unlock() //On d�finit qui aura pour effet de d�bloquer le bloc de construction
    {
        Destroy(Padlock); //On supprime le cadenas
        button.enabled = true; //On active le composant button => il devient cliquable
    }
}
