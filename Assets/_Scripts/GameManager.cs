using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //On s'occupe de faire en sorte que le GameManger soit une instance (qu'il puisse être appelé de n'importe quel script, sans avoir besoin de le référencer)
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
    [SerializeField] private GameObject Box; //On récupère les prefab des boites
    [SerializeField] private GameObject Box2; 
    [SerializeField] private GameObject Box3;
    private GameObject CurrentBox;

    private int NbWaves = 0;
    [SerializeField] private GameObject Scrap; //On récupère le prefab d'un débris

    [SerializeField] private BlockingScripts BoxButton2; //On récupère les scripts des boutons de choix de matériaux
    [SerializeField] private BlockingScripts BoxButton3;

    private void Start()
    {
        StartCoroutine(WaitForNextWave()); //On démarre le système de vague de débris
        CurrentBox = Box; //On choisit le premier matériaux comme étant le matériaux actuel
    }

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

    public void SetCurrentBox(int NewCurrentBox) //On définit une fonction permettant de changer de matériaux de construction
    {
        if (NewCurrentBox == 0) //On change de matériaux en fonction du numéro donné en argument
        {
            CurrentBox = Box;
        }
        else if (NewCurrentBox == 1)
        {
            CurrentBox = Box2;
        }
        else
        {
            CurrentBox = Box3;
        }
    }

    public void SpawnBox(Vector3 spawnPos)
    {
        Instantiate(CurrentBox, spawnPos, Quaternion.identity); //Fait apparaître une boite à la position demandée et tout droit
    }

    private void NewWave()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            NbWaves++;
            Debug.Log(NbWaves);
        }

        for(int i = 0; i < Random.Range(1, 4) + NbWaves / 3; i++) //On répète un nombre de fois compris entre 1 et 3 + le nombre de vague divisé par 3
        {
            float Xcor = Random.Range(-14f, 24f); //On génère aléatoirement des coordonnées
            float Ycor = Random.Range(19f, 37f);

            StartCoroutine(SpawnScrap(Xcor, Ycor)); //On fait apparaitre un débris au coordonnées choisies aléatoirement
        }

        StartCoroutine(WaitForNextWave()); //On appelle la fonction qui va attendre 10 secondes 

        //On s'occupe de débloquer les nouveaux matériaux de construction : 
        if (NbWaves > 9)
        {
            BoxButton2.Unlock(); //On appelle la fonction Unlock dans boxButton2 afin de débloquer le second matériaux de construction
        }
        if (NbWaves > 19) 
        {
            Debug.Log("Deblocage");
            BoxButton3.Unlock(); //On appelle la fonction Unlock dans boxButton3 afin de débloquer le troisième matériaux de construction
        }
    }

    private IEnumerator WaitForNextWave()
    {
        yield return new WaitForSeconds(10f); //On attend 10 secondes 
        NewWave(); //On réappelle la fonction NewWave pour passer à la vague suivante
    }

    private IEnumerator SpawnScrap(float Xcor, float Ycor)
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 1f)); //Attend entre 0.1 et 1 seconde
        Instantiate(Scrap, new Vector3(Xcor, Ycor, 0), Quaternion.identity); //Fait apparaître un débris à la position Xcor, Ycor et tout droit
    }
}
