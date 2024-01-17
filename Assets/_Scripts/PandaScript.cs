using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaScript : MonoBehaviour
{
    [SerializeField] int PandaLife; //On d�finit le nombre de vies du panda

    public void TakeDamage(int damage) //On d�finit une fonction pour enlever de la vie au panda
    {
        PandaLife -= damage; //On enl�ve de la vie au panda
        if (PandaLife <= 0) //On v�rifie s'il est mort
        {
            Destroy(gameObject); //On d�truit le panda
            //appel d'une fonction dans le game manager qui enl�ve un panda au compteur et qui v�rifie si la partie est finie
        }
    }
}
