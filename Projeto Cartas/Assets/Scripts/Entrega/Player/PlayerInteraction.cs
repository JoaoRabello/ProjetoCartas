using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private bool _canInteract = false;
    public bool CanInteract { get => _canInteract; set => _canInteract = value; }

    private bool _inFrontLetterBox = false;
    private LetterBox _letterBox;
    private LetterBag _letterBag;
    [SerializeField] private Text _actualAdresseeText;
    private string actualAdressee;
    private NPC _npc;

    void Start()
    {
        _letterBag = GetComponent<LetterBag>();    
    }

    void Update()
    {
        _actualAdresseeText.text = actualAdressee;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_inFrontLetterBox)
            {
                _letterBag.TakeLetters(_letterBox.letters);
                actualAdressee = _letterBag._letters[0].adressee;
            }
            if (_canInteract)
            {
                if (_npc.NpcName.Equals(actualAdressee))
                {
                    _npc.ReceiveLetter(_letterBag._letters[0]);
                    _letterBag.RemoveLetter();
                    actualAdressee = _letterBag._letters[0].adressee;
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPCArea"))
        {
            _canInteract = true;
            _npc = other.GetComponent<NPC>();
        }
        if (other.CompareTag("LetterBoxArea"))
        {
            _inFrontLetterBox = true;
            _letterBox = other.GetComponent<LetterBox>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPCArea"))
        {
            _canInteract = false;
            _npc = null;
        }
        if (other.CompareTag("LetterBoxArea"))
        {
            _inFrontLetterBox = false;
            _letterBox = null;
        }
    }
}
