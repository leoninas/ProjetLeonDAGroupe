using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseDetectorScript : MonoBehaviour
{
    [SerializeField] private Camera Cam;

    private float MousePosX; //On d�finit la variable stockant l'abscisse de la souris
    private float MousePosY; //On d�finit la variable stockant l'ordonn�e de la souris
    private float XCor; //On d�finit la variable stockant la position X de la boite
    private float YCor; //On d�finit la variable stockant la position Y de la boite
    private Vector3 Pos; //On d�finit un vecteur qui servira � stocker diff�rentes positions

    private void OnMouseUp()
    {   
        MousePosX = Input.mousePosition.x; //On r�cup�re la position X de la souris
        MousePosY = Input.mousePosition.y; //On r�cup�re la position Y de la souris

        Pos = Cam.ScreenToWorldPoint(new Vector3(MousePosX, MousePosY, 0)); //On transform les coordonn�es en pixel dans la cam�ra vers des coordonn�es globales

        //Les lignes suivantes servent � faire le lien entre les coordonn�es globales de la souris et un point d'abscisse et d'ordonn�e multiple de 2 afin de placer la boite dans une grille virtuelle
        MousePosX = Pos.x - 1;
        MousePosY = Pos.y - 1;

        XCor = (int)Math.Ceiling(MousePosX / 2f) * 2;
        YCor = (int)Math.Ceiling(MousePosY / 2f) * 2;

        Pos = new Vector3(XCor, YCor, 0);

        //Debug.Log("D�tect�");

        GameManager.instance.SpawnBox(Pos);
    }
}
