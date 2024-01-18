using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    private TextMeshPro text; //On définit un composant text
    private Animator anim; //On définit un composant animator
    [SerializeField] private GameObject nextText; //On récupère un composant text -> le texte à afficher après celui-ci (peut être nul si pas de texte à afficher)
    private void OnEnable()
    {
        text = GetComponent<TextMeshPro>(); //On récupère le composant text
        anim = GetComponent<Animator>(); // On récupère le composant animator
        
        text.enabled = true; //On active le composant text pour voir le texte (On l'a caché pour ne pas travailler avec)
        anim.enabled = true; //On active l'animator afin de lancer l'annimation

        StartCoroutine(WaitForDestroy()); //On appelle fonction qui va détruire le texte au bout de 1.2 seconde dès le début
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1.6f); //On attend 1.6 secondes (le f permet la conversion en float
        showNextText(); //On appelle la fonction qui affiche le prochain text à afficher
        Destroy(gameObject); //On détruit le gameObject contenant le script (= le texte)
    }

    private void showNextText() //Cette fonction sert à enchainer en montrant un autre texte à la suite de celui-ci
    {
        if (nextText != null) //On vérifie qu'on a bien un texte suivant
        {
            nextText.SetActive(true); //On active le texte suivant (il est censé être disable afin de ne pas s'affciher)
        }
    }
}
