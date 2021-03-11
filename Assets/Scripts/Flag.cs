using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flag : MonoBehaviour
{

    private SpriteRenderer sr;
    private BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (GameControler.instance.totalScore == 15)
            {
                GameControler.instance.ShowCheckMessageWin();
            }
            else
            {
                GameControler.instance.ShowCheckMessage();
            }
        }
    }

}