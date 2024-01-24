using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    [SerializeField] private int BoxLife;

    public void TakeDamage(int damage)
    {
        BoxLife -= damage; //On enl�ve de la vie a la boite
        if (BoxLife <= 0) //On v�rifie si elle est cass�e
        {
            Destroy(gameObject); //On d�truit la boite

            // ?-> appel d'une fonction dans le gameManager recalculant les connexions
        }
    }








    private bool isLinkToWall = false;
    [SerializeField] private GameObject pointUp;
    private PointCheck checkUp;
    [SerializeField] private GameObject pointDown;
    private PointCheck checkDown;
    [SerializeField] private GameObject pointRight;
    private PointCheck checkRight;
    [SerializeField] private GameObject pointLeft;
    private PointCheck checkLeft;

    private bool startCoroutine = true;
    private bool startUpdate = false;

    private void Start()
    {
        checkUp = pointUp.GetComponent<PointCheck>();
        checkDown = pointDown.GetComponent<PointCheck>();
        checkLeft = pointLeft.GetComponent<PointCheck>();
        checkRight = pointRight.GetComponent<PointCheck>();
    }

    private void Update()
    {
        if (startUpdate)
        {
            isLinkToWall = false;
            if (pointUp != null)
            {
                if (Check(pointUp, checkUp.isLink))
                {
                    isLinkToWall = true;
                }
            }
            if (pointDown != null)
            {
                if (Check(pointDown, checkDown.isLink))
                {
                    isLinkToWall = true;
                }
            }
            if (pointLeft != null)
            {
                if (Check(pointLeft, checkLeft.isLink))
                {
                    isLinkToWall = true;
                }
            }
            if (pointRight != null)
            {
                if (Check(pointRight, checkRight.isLink))
                {
                    isLinkToWall = true;
                }
            }

            if (!isLinkToWall)
            {
                StartCoroutine(WaitToDestroy());
            }
        }
        else
        {
            if (startCoroutine)
            {
                startCoroutine = false;
                StartCoroutine(WaitForStartUpdate());
            }
        }
    }

    private IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private IEnumerator WaitForStartUpdate()
    {
        yield return new WaitForSeconds(0.1f);
        startUpdate = true;
    }

    private bool Check(GameObject point, bool isLink)
    {
        if (!isLink)
        {
            Destroy(point);
        }
        return isLink;
    }
}
