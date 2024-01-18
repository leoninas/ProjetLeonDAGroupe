using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //On s'occupe de faire en sorte que le GameManger soit une instance (qu'il puisse être appeler de n'importe quel script, sans avoir besoin de le référencer)
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



    private int nbPanda = 3; //On définit un entier servant à compter le nombre de pandas restants

    public void LoadScene(string sceneName) //On définit une fonction servant à charger une autre scene
    {
        SceneManager.LoadScene(sceneName); //On charge la scene ayant le nom sceneName
        Time.timeScale = 1; //Par précaution on remet l'écoulement du temps à 1 (la vitesse normal)
    }

    public void Quit() //On défint une fonction permettant de fermer l'application
    {
        Application.Quit(); //ferme l'application -> ne marche que dans un build
    }

    public void CountPanda() //On définit une fonction dans laquelle on compte les pandas restant
    {
        nbPanda -= 1; //On enlève un au nombre de pandas 
        if (nbPanda <= 0) //On vérifie si ne reste plus de pandas
        {
            EndGame(); //On appelle la fonction de fin de partie
        }
    }

    private void EndGame() //On définit la fonction de fin de partie
    {
        //On ajoute ici les éléments / animation de fin de partie 
        LoadScene("HomeScene"); //On recharge le menu home pour que le joueur puisse lancer une nouvelle partie
    }
}
