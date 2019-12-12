using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private string npcName = null;
    private bool _showWord = false;
    [SerializeField] private GameObject _text;

    public string NpcName { get => npcName;}

    public void Interact()
    {
        //TODO: Interactions
        if(_showWord == false)
        {
            StartCoroutine(Word());
        }
    }

    public void ReceiveLetter(Letter letter)
    {
        print("Received");
        Interact();
    }

    private void Talk()
    {
        //TODO: Talks
    }

    private IEnumerator Word()
    {
        _showWord = true;
        _text.SetActive(true);
        yield return new WaitForSeconds(2f);
        _showWord = false;
        _text.SetActive(false);
    }

}
