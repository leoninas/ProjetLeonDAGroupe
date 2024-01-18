using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    private TextMeshPro text; //On d�finit un composant text
    private Animator anim; //On d�finit un composant animator
    [SerializeField] private GameObject nextText; //On r�cup�re un composant text -> le texte � afficher apr�s celui-ci (peut �tre nul si pas de texte � afficher)
    private void OnEnable()
    {
        text = GetComponent<TextMeshPro>(); //On r�cup�re le composant text
        anim = GetComponent<Animator>(); // On r�cup�re le composant animator
        
        text.enabled = true; //On active le composant text pour voir le texte (On l'a cach� pour ne pas travailler avec)
        anim.enabled = true; //On active l'animator afin de lancer l'annimation

        StartCoroutine(WaitForDestroy()); //On appelle fonction qui va d�truire le texte au bout de 1.2 seconde d�s le d�but
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1.6f); //On attend 1.6 secondes (le f permet la conversion en float
        showNextText(); //On appelle la fonction qui affiche le prochain text � afficher
        Destroy(gameObject); //On d�truit le gameObject contenant le script (= le texte)
    }

    private void showNextText() //Cette fonction sert � enchainer en montrant un autre texte � la suite de celui-ci
    {
        if (nextText != null) //On v�rifie qu'on a bien un texte suivant
        {
            nextText.SetActive(true); //On active le texte suivant (il est cens� �tre disable afin de ne pas s'affciher)
        }
    }
}
