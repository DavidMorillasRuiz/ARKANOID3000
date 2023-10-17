using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.ReloadScene();
    }
}
