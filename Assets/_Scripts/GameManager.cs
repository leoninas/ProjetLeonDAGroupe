using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //On s'occupe de faire en sorte que le GameManger soit une instance (qu'il puisse �tre appel� de n'importe quel script, sans avoir besoin de le r�f�rencer)
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
    [SerializeField] private GameObject Box; //On r�cup�re le prefab d'une boite

    private int NbWaves = 0;
    [SerializeField] private GameObject Scrap; //On r�cup�re le prefab d'un d�bris

    private void Start()
    {
        StartCoroutine(WaitForNextWave()); //On d�marre le syst�me de vague de d�bris
    }

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

    public void SpawnBox(Vector3 spawnPos)
    {
        Instantiate(Box, spawnPos, Quaternion.identity); //Fait appara�tre une boite � la position demand�e et tout droit
    }

    private void NewWave()
    {
        NbWaves++;
        for(int i = 0; i < Random.Range(1, 4) + NbWaves / 3; i++) //On r�p�te un nombre de fois compris entre 1 et 3 + le nombre de vague divis� par 3
        {
            float Xcor = Random.Range(-14f, 24f); //On g�n�re al�atoirement des coordonn�es
            float Ycor = Random.Range(19f, 37f);

            StartCoroutine(SpawnScrap(Xcor, Ycor));
        }

        StartCoroutine(WaitForNextWave()); //On appelle la fonction qui va attendre 10 secondes 
    }

    private IEnumerator WaitForNextWave()
    {
        Debug.Log("Start Waiting");
        yield return new WaitForSeconds(10f); //On attend 10 secondes 
        NewWave(); //On r�appelle la fonction NewWave pour passer � la vague suivante
    }

    private IEnumerator SpawnScrap(float Xcor, float Ycor)
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        Instantiate(Scrap, new Vector3(Xcor, Ycor, 0), Quaternion.identity); //Fait appara�tre un d�bris � la position Xcor, Ycor et tout droit
    }
}
