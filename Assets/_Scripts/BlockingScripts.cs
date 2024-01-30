using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockingScripts : MonoBehaviour
{
    [SerializeField] private GameObject Padlock; //On définit les composants qui serviront par la suite
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>(); //On récupère le composant button
    }

    public void Unlock() //On définit qui aura pour effet de débloquer le bloc de construction
    {
        Destroy(Padlock); //On supprime le cadenas
        button.enabled = true; //On active le composant button => il devient cliquable
    }
}
