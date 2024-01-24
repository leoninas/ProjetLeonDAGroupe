using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapScript : MonoBehaviour
{
    [SerializeField] private Animator anim; //On r�cup�re l'animator du d�bris
    [SerializeField] private Rigidbody2D rb; //On r�cup�re le rigidbody2D du d�bris

    [SerializeField] private float ExplosionRadius; //On d�finit le rayon de l'explosion
    [SerializeField] private int Damage; //On d�finit le nombre de d�gats que fait le d�bris

    private void OnCollisionEnter2D(Collision2D collision) //On d�tecte les collisions non triggers entrantes
    {
        if (collision.transform.CompareTag("Box") || collision.transform.CompareTag("FirstGround") || collision.transform.CompareTag("Panda")) //On v�rifie si le tag de l'objet rencontr� est celui d'un objet faisant exploser le d�bris
        {
            anim.SetBool("boom", true); //Dans l'animator, on met le bool�en boom qui g�re l'explosion � vrai pour dire que le d�bris explose
            StartCoroutine(WaitForDestroy()); //On appelle la fonction qui va attendre avant de d�truire le d�bris
            rb.simulated = false; //On d�sactive le rigidbody du d�bris afin de l'emp�cher de continuer de tomber et de tourner (il ne doit plus le faire car il explose)

            Collider2D[] hitByExplosion = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius); //On r�cup�re tous les collider2D dans un rayon de ExplosionRadius autour du d�bris -> renvoie une liste de collider2D
            foreach(Collider2D collider in hitByExplosion) //On parcours tous les �l�ments de la liste de Collider2D
            {
                GameObject hitGameObject = collider.gameObject; //On r�cup�re le GameObject auquel appartient le collider2D
                if (hitGameObject.transform.CompareTag("Panda")) //On v�rifie que ce GameObject est un panda
                {
                    PandaScript pandaScript = hitGameObject.GetComponent<PandaScript>(); //On r�cup�re le script PandaScript du panda
                    if (pandaScript != null) //On v�rifie que ce scipt existe
                    {
                        pandaScript.TakeDamage(Damage); //On appelle la fonction TakeDamage du PandaScript du panda touch� et comme argument Damage le nombre de d�gats � infliger au panda
                    }
                }
                if (hitGameObject.transform.CompareTag("Box")) //On v�rifie que ce GameObject est une boite
                {
                    BoxCheck boxCheck = hitGameObject.GetComponent<BoxCheck>(); //On r�cup�re le script BoxCheck du panda
                    if (boxCheck != null) //On v�rifie que ce scipt existe
                    {
                        boxCheck.TakeDamage(1); //On appelle la fonction TakeDamage du Boxheck de la boite touch�e et comme argument 1 le nombre de d�gats � infliger a la boite
                    }
                }
            }
        }
    }

    private IEnumerator WaitForDestroy() //On d�fini la fonction qui va d�truire le d�bris apr�s son explosion
    {
        yield return new WaitForSeconds(0.8f); //On attend le temps de l'animation d'explosion
        Destroy(gameObject); //On d�truit le gameObject contenant le script
    }

    //La fonction suivante permet de visualiser dans quel rayon va exploser notre d�bris en tra�ant un cercle de rayon ExplosionRadius
    /*
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
    */
}
