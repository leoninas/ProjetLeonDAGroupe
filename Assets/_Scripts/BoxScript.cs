using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoxScript : MonoBehaviour
{
    [SerializeField] private Transform Box;
    [SerializeField] private Camera Cam;

    private float MousePosX; //On d�finit la variable stockant l'abscisse de la souris
    private float MousePosY; //On d�finit la variable stockant l'ordonn�e de la souris
    private float XCor; //On d�finit la variable stockant la position X de la boite
    private float YCor; //On d�finit la variable stockant la position Y de la boite
    private Vector3 Pos;
    private void OnMouseUp()
    {   
        MousePosX = Input.mousePosition.x; //On r�cup�re la position X de la souris
        MousePosY = Input.mousePosition.y; //On r�cup�re la position Y de la souris

        Pos = Cam.ScreenToWorldPoint(new Vector3(MousePosX, MousePosY, 0));

        MousePosX = Pos.x - 1;
        MousePosY = Pos.y - 1;

        XCor = (int)Math.Ceiling(MousePosX / 2f) * 2;
        YCor = (int)Math.Ceiling(MousePosY / 2f) * 2;

        Debug.Log(XCor + " " + YCor);

        Box.position = new Vector3(XCor, YCor, 0);
    }
}
