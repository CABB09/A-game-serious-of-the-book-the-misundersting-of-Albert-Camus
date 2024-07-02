using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetNPC : MonoBehaviour
{
    [SerializeField] private dialogoTrigger npcDialogTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcDialogTrigger.ResetDialogue();
        }
    }
}