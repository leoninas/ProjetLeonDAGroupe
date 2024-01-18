using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //On s'occupe de faire en sorte que le GameManger soit une instance (qu'il puisse �tre appeler de n'importe quel script, sans avoir besoin de le r�f�rencer)
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    private int nbPanda = 3; //On d�finit un entier servant � compter le nombre de pandas restants

    public void LoadScene(string sceneName) //On d�finit une fonction servant � charger une autre scene
    {
        SceneManager.LoadScene(sceneName); //On charge la scene ayant le nom sceneName
        Time.timeScale = 1; //Par pr�caution on remet l'�coulement du temps � 1 (la vitesse normal)
    }

    public void Quit() //On d�fint une fonction permettant de fermer l'application
    {
        Application.Quit(); //ferme l'application -> ne marche que dans un build
    }

    public void CountPanda() //On d�finit une fonction dans laquelle on compte les pandas restant
    {
        nbPanda -= 1; //On enl�ve un au nombre de pandas 
        if (nbPanda <= 0) //On v�rifie si ne reste plus de pandas
        {
            EndGame(); //On appelle la fonction de fin de partie
        }
    }

    private void EndGame() //On d�finit la fonction de fin de partie
    {
        //On ajoute ici les �l�ments / animation de fin de partie 
        LoadScene("HomeScene"); //On recharge le menu home pour que le joueur puisse lancer une nouvelle partie
    }
}
