using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

[System.Serializable]
public class TextsInGame
{
    [TextArea]
    public List<string> _texts;
}
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;

    public DialogManager _dialogManager;
    [SerializeField]
    public List<TextsInGame> _dialogs = new List<TextsInGame>();

    public static DialogueManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Buscar una instancia existente en la escena.
                _instance = FindObjectOfType<DialogueManager>();

                if (_instance == null)
                {
                    // Crear un nuevo GameObject con el script adjunto si no se encuentra ninguna instancia.
                    GameObject singletonObject = new GameObject("DialogueManager");
                    _instance = singletonObject.AddComponent<DialogueManager>();

                    // Opcional: Evitar que el objeto sea destruido al cambiar de escena.
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Evitar que el objeto sea destruido al cambiar de escena.
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // Destruir instancias adicionales si ya existe una instancia.
        }
    }

    void Start()
    {
        /* VIEJO CREADOR DE DIALOGO
        //DialogData _dialogData = new DialogData(_Texts[0], "Character");
        var _dialogTexts = new List<DialogData>();
        for (int i = 0; i < _dialogs.Count; i++)
        {
            _dialogTexts.Add(new DialogData(_dialogs[0]._texts[i], "Character"));
            //_dialogTexts[i] = new DialogData(_Texts[i], "Character");
        }

        _dialogManager.Show(_dialogTexts);
        */
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartDialogue(1);
        }
    }

    public void StartDialogue(int _dialogueIndex)
    {
        var _dialogTexts = new List<DialogData>();

        for (int i = 0; i < _dialogs[_dialogueIndex]._texts.Count; i++)
        {
            _dialogTexts.Add(new DialogData(_dialogs[_dialogueIndex]._texts[i], "Character"));
            //_dialogTexts[i] = new DialogData(_Texts[i], "Character");
        }

        _dialogManager.Show(_dialogTexts);
    }
}
