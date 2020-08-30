using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void GameOver(GameObject player)
    {
        Destroy(player);
    //    Animator.GameOver.
    }
}
