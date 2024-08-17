using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class OfficeManager : MonoBehaviour
{
    public GameObject _cam;
    private Animator _camAnimator;

    private void Start()
    {
        _cam = Camera.main.gameObject;
        _camAnimator = _cam.GetComponent<Animator>();
    }
    public void OfficeInteraction(int _ID)
    {
        switch (_ID)
        {
            case 0:
                DialogueManager.Instance.StartDialogue(2);
                break;
            case 1:
                DialogueManager.Instance.StartDialogue(3);
                break;
            case 2:
                DialogueManager.Instance.StartDialogue(4);
                break;
            case 3:
                DialogueManager.Instance.StartDialogue(5);
                _camAnimator.SetBool("LookAtLamp", true);
                break;
            case 4:
                DialogueManager.Instance.StartDialogue(6);
                break;
            default:
                break;
        }
    }
}
