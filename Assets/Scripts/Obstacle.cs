using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent <PlayerController>() != null)
        {
            //If the worm hits the trigger collider in between the rocks then
            //tell the game control that the bird scored.
            GameController.instance.Scored();
        }
    }
}