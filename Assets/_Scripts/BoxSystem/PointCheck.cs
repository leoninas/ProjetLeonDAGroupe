using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCheck : MonoBehaviour
{
    public bool isLink = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Box") || collision.transform.CompareTag("FirstGround"))
        {
            isLink = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Box") || collision.transform.CompareTag("FirstGround"))
        {
            isLink = false;
        }
    }
}
