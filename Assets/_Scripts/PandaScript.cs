using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{
    [SerializeField] int PandaLife; //On définit le nombre de vies du panda

    public void TakeDamage(int damage) //On définit une fonction pour enlever de la vie au panda
    {
        PandaLife -= damage; //On enlève de la vie au panda
        if (PandaLife <= 0) //On vérifie s'il est mort
        {
            Destroy(gameObject); //On détruit le panda
            GameManager.instance.CountPanda(); //On utilise le GameManger static pour appeler la fonction CountPanda
        }
    }
}
