using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseDetectorScript : MonoBehaviour
{
    [SerializeField] private Camera Cam;

    private float MousePosX; //On définit la variable stockant l'abscisse de la souris
    private float MousePosY; //On définit la variable stockant l'ordonnée de la souris
    private float XCor; //On définit la variable stockant la position X de la boite
    private float YCor; //On définit la variable stockant la position Y de la boite
    private Vector3 Pos; //On définit un vecteur qui servira à stocker différentes positions

    private void OnMouseUp()
    {   
        MousePosX = Input.mousePosition.x; //On récupère la position X de la souris
        MousePosY = Input.mousePosition.y; //On récupère la position Y de la souris

        Pos = Cam.ScreenToWorldPoint(new Vector3(MousePosX, MousePosY, 0)); //On transform les coordonnées en pixel dans la camèra vers des coordonnées globales

        //Les lignes suivantes servent à faire le lien entre les coordonnées globales de la souris et un point d'abscisse et d'ordonnée multiple de 2 afin de placer la boite dans une grille virtuelle
        MousePosX = Pos.x - 1;
        MousePosY = Pos.y - 1;

        XCor = (int)Math.Ceiling(MousePosX / 2f) * 2;
        YCor = (int)Math.Ceiling(MousePosY / 2f) * 2;

        Pos = new Vector3(XCor, YCor, 0);

        //Debug.Log("Détecté");

        GameManager.instance.SpawnBox(Pos);
    }
}
