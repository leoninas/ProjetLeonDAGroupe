using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapScript : MonoBehaviour
{
    [SerializeField] private Animator anim; //On récupère l'animator du débris
    [SerializeField] private Rigidbody2D rb; //On récupère le rigidbody2D du débris

    [SerializeField] private float ExplosionRadius; //On définit le rayon de l'explosion
    [SerializeField] private int Damage; //On définit le nombre de dégats que fait le débris

    private void OnCollisionEnter2D(Collision2D collision) //On détecte les collisions non triggers entrantes
    {
        if (collision.transform.CompareTag("Box") || collision.transform.CompareTag("FirstGround") || collision.transform.CompareTag("Panda")) //On vérifie si le tag de l'objet rencontré est celui d'un objet faisant exploser le débris
        {
            anim.SetBool("boom", true); //Dans l'animator, on met le booléen boom qui gère l'explosion à vrai pour dire que le débris explose
            StartCoroutine(WaitForDestroy()); //On appelle la fonction qui va attendre avant de détruire le débris
            rb.simulated = false; //On désactive le rigidbody du débris afin de l'empêcher de continuer de tomber et de tourner (il ne doit plus le faire car il explose)

            Collider2D[] hitByExplosion = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius); //On récupère tous les collider2D dans un rayon de ExplosionRadius autour du débris -> renvoie une liste de collider2D
            foreach(Collider2D collider in hitByExplosion) //On parcours tous les éléments de la liste de Collider2D
            {
                GameObject hitGameObject = collider.gameObject; //On récupère le GameObject auquel appartient le collider2D
                if (hitGameObject.transform.CompareTag("Panda")) //On vérifie que ce GameObject est un panda
                {
                    PandaScript pandaScript = hitGameObject.GetComponent<PandaScript>(); //On récupère le script PandaScript du panda
                    if (pandaScript != null) //On vérifie que ce scipt existe
                    {
                        pandaScript.TakeDamage(Damage); //On appelle la fonction TakeDamage du PandaScript du panda touché et comme argument Damage le nombre de dégats à infliger au panda
                    }
                }
                if (hitGameObject.transform.CompareTag("Box")) //On vérifie que ce GameObject est une boite
                {
                    BoxCheck boxCheck = hitGameObject.GetComponent<BoxCheck>(); //On récupère le script BoxCheck du panda
                    if (boxCheck != null) //On vérifie que ce scipt existe
                    {
                        boxCheck.TakeDamage(1); //On appelle la fonction TakeDamage du Boxheck de la boite touchée et comme argument 1 le nombre de dégats à infliger a la boite
                    }
                }
            }
        }
    }

    private IEnumerator WaitForDestroy() //On défini la fonction qui va détruire le débris après son explosion
    {
        yield return new WaitForSeconds(0.8f); //On attend le temps de l'animation d'explosion
        Destroy(gameObject); //On détruit le gameObject contenant le script
    }

    //La fonction suivante permet de visualiser dans quel rayon va exploser notre débris en traçant un cercle de rayon ExplosionRadius
    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
    */
}
