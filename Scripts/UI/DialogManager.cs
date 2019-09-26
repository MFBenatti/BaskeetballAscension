using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    #region [ Singleton ]
    public static DialogManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("UI (User Interface)")]
    [SerializeField]
    private Text m_NameText;

    [SerializeField]
    private Image m_AvatarImage;

    [SerializeField]
    private Text m_DialogText;

    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private EventSystem m_EventSystem;

    [SerializeField]
    private GameObject m_SelectedObject;

    [SerializeField]
    private AudioSource m_AudioSource;

    private Queue<DialogSentence> m_Sentences;

    private IEnumerator m_TypeSentenceCoroutine;

    private bool m_IsOpen;

    public void Start()
    {
        m_Sentences = new Queue<DialogSentence>();
    }

    public void UpdateUI(Dialog dialog)
    {
        if (m_NameText)
        {
            m_NameText.text = dialog.Name;
        }

        if (m_AvatarImage)
        {
            m_AvatarImage.sprite = dialog.Avatar;
        }
    }

    private void LateUpdate()
    {
        if (m_IsOpen && Time.timeScale != 0)
        {
            SelectObjectOnInput(true);
        }   
    }

    public void SelectObjectOnInput(bool canSelect)
    {
        if (m_EventSystem && m_SelectedObject)
        {
            if (canSelect)
            {
                m_EventSystem.SetSelectedGameObject(null);
                m_EventSystem.SetSelectedGameObject(m_SelectedObject);
                Canvas.ForceUpdateCanvases();
            }
            else
            {
                m_EventSystem.SetSelectedGameObject(null);
                Canvas.ForceUpdateCanvases();
            }
        } 
    }

    public void OpenDialogAnimation(bool open)
    {
        if (m_Animator)
        {
            m_Animator.SetBool("IsOpen", open);
        }
    }

    public void BeginDialog(Dialog dialog)
    {
        if (m_IsOpen)
        {
            return;
        }

        m_IsOpen = true;
        SelectObjectOnInput(m_IsOpen);

        OpenDialogAnimation(true);

        m_Sentences.Clear();

        UpdateUI(dialog);

        foreach (var sentence in dialog.Sentences)
        {
            m_Sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (m_AudioSource)
        {
            m_AudioSource.Stop();
        }

        if (m_Sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        DialogSentence sentence = m_Sentences.Dequeue();

        if (m_TypeSentenceCoroutine != null)
        {
            StopCoroutine(m_TypeSentenceCoroutine);
        }

        m_TypeSentenceCoroutine = TypeSequence(sentence);
        StartCoroutine(m_TypeSentenceCoroutine);
    }

    IEnumerator TypeSequence(DialogSentence sentence)
    {
        if (m_AudioSource)
        {
            m_AudioSource.clip = sentence.Voice;
            m_AudioSource.Play();
        }

        m_DialogText.text = string.Empty;
        foreach(char letter in sentence.Text.ToCharArray())
        {
            while (Time.timeScale == 0)
            {
                yield return null;
            }

            m_DialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        m_IsOpen = false;
        OpenDialogAnimation(m_IsOpen);
        SelectObjectOnInput(m_IsOpen);
    }
}

[Serializable]
public class Dialog
{
    [SerializeField]
    private string m_Name;

    public string Name
    {
        get { return m_Name; }
        set { m_Name = value; }
    }

    [SerializeField]
    private Sprite m_Avatar;

    public Sprite Avatar
    {
        get { return m_Avatar; }
        set { m_Avatar = value; }
    }

    [SerializeField]
    private List<DialogSentence> m_Sentences;

    public List<DialogSentence> Sentences
    {
        get { return m_Sentences; }
        set { m_Sentences = value; }
    }
}

[Serializable]
public class DialogSentence
{
    [SerializeField]
    [TextArea(1, 10)]
    private string m_Text;

    public string Text
    {
        get { return m_Text; }
        set { m_Text = value; }
    }

    [SerializeField]
    private AudioClip m_Voice;

    public AudioClip Voice
    {
        get { return m_Voice; }
        set { m_Voice = value; }
    }
}

