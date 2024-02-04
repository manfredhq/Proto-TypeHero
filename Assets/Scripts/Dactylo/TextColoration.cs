using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextColoration : MonoBehaviour
{
    public static TextColoration instance;
    
    [SerializeField]
    private TMP_Text m_TextComponent;


    public List<int> greenLetters = new List<int>();

    public List<int> redLetters = new List<int>();

    private Color32 greenColor = new Color32(0, 255, 0, 255);
    private Color32 redColor = new Color32(255, 0, 0, 255);
    private Color32 whiteColor = new Color32(0, 0, 0, 255);

    public int currentLetterIndex = 0;

    private int currentWordLineIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent.ForceMeshUpdate();
        instance = this;
    }


    private void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        m_TextComponent.maxVisibleLines = 2;
    }

    void SetVertexColor(Color32 color, int currentCharacter)
    {
        if (color.Compare(greenColor))
            greenLetters.Add(currentCharacter);
        else if (color.Compare(redColor))
            redLetters.Add(currentCharacter);

        m_TextComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = m_TextComponent.textInfo;

        Color32[] newVertexColors;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            // Get the index of the material used by the current character.
            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;

            // Get the vertex colors of the mesh used by this text element (character or sprite).
            newVertexColors = textInfo.meshInfo[materialIndex].colors32;

            // Get the index of the first vertex used by this text element.
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            // Only change the vertex color if the text element is visible.
            if (textInfo.characterInfo[i].isVisible)
            {
                if (greenLetters.Contains(i))
                {
                    newVertexColors[vertexIndex + 0] = greenColor;
                    newVertexColors[vertexIndex + 1] = greenColor;
                    newVertexColors[vertexIndex + 2] = greenColor;
                    newVertexColors[vertexIndex + 3] = greenColor;
                }
                else if (redLetters.Contains(i))
                {
                    newVertexColors[vertexIndex + 0] = redColor;
                    newVertexColors[vertexIndex + 1] = redColor;
                    newVertexColors[vertexIndex + 2] = redColor;
                    newVertexColors[vertexIndex + 3] = redColor;

                }

                

                
            }
        }
        // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
        m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);


    }

    public void RemoveLastLetterColored()
    {
        //Avoid index errors, also it wouldn't make sens if it would work
        if (currentLetterIndex == 0 || m_TextComponent.text[currentLetterIndex-1] == ' ')
        {
            return;
        }



        if (redLetters.Contains(currentLetterIndex-1))
        {
            currentLetterIndex--;
            redLetters.Remove(currentLetterIndex);
            SetVertexColor(whiteColor, currentLetterIndex);
        }
        else if(greenLetters.Contains(currentLetterIndex-1))
        {
            currentLetterIndex--;
            greenLetters.Remove(currentLetterIndex);
            SetVertexColor(whiteColor, currentLetterIndex);
        }

    }

    public void ColorNextLetterInRed()
    {
        SetVertexColor(redColor, currentLetterIndex);
        currentLetterIndex++;
    }

    public void ColorNextLetterInGreen()
    {
        SetVertexColor(greenColor, currentLetterIndex);
        currentLetterIndex++;
    }

    public string GetText()
    {
        return m_TextComponent.text;
    }

    public void SetText(string newText)
    {
        m_TextComponent.text += newText;
    }

    public void OnChangeWord()
    {
        m_TextComponent.ForceMeshUpdate();

        //reset all the vars that keep track of the word coloration
        // A LA FIN D'UNE LIGNE MAINTENANT
        greenLetters = new List<int>();
        redLetters = new List<int>();
        currentLetterIndex = 0;
    }

    public bool IsLastLetterOfLine()
    {
        var lines = m_TextComponent.textInfo.lineInfo;

        if (currentLetterIndex == lines[0].lastCharacterIndex)
        {
            return true;
        }
        return false;
    }

    public void NextLine()
    {
        var lines = m_TextComponent.textInfo.lineInfo;
        if (lines.Length > 0)
        {
            var lastCharIndex = lines[0].lastCharacterIndex;
            m_TextComponent.text = m_TextComponent.text.Substring(lastCharIndex + 1, m_TextComponent.text.Length - lastCharIndex - 1);
        }

        //empty colored letters lists
        OnChangeWord();
        currentWordLineIndex = 0;

    }

    public int GoodLettersAmountInCurrentWord() 
    {
        var lines = m_TextComponent.textInfo.lineInfo;
        var words = m_TextComponent.textInfo.wordInfo;
        var currentWordInfo = words[currentWordLineIndex];
        int firstCharIndex = currentWordInfo.firstCharacterIndex;
        int lastCharIndex = currentWordInfo.lastCharacterIndex;
        int goodLettersAmount = 0;
        for (int i = firstCharIndex; i <= lastCharIndex; i++)
        {
            if( greenLetters.Exists(gLetterInd => gLetterInd == i))
            {
                goodLettersAmount++;
            }
        }
        return goodLettersAmount;
    }

    public int WrongLettersAmountInCurrentWord()
    {
        var lines = m_TextComponent.textInfo.lineInfo;
        var words = m_TextComponent.textInfo.wordInfo;
        var currentWordInfo = words[currentWordLineIndex];
        int firstCharIndex = currentWordInfo.firstCharacterIndex;
        int lastCharIndex = currentWordInfo.lastCharacterIndex;
        int wrongLettersAmount = 0;
        for (int i = firstCharIndex; i < lastCharIndex; i++)
        {
            if (redLetters.Exists(rLetterInd => rLetterInd == i))
            {
                wrongLettersAmount++;
            }
        }
        return wrongLettersAmount;
    }


    public void NextWord()
    {

        while (m_TextComponent.text[currentLetterIndex] != ' ')
        {
            ColorNextLetterInRed();
        }
        currentWordLineIndex++;
    }

    public bool IsLastWordOfLine()
    {
        var lines = m_TextComponent.textInfo.lineInfo;

        if (currentWordLineIndex+1 == lines[0].wordCount)
        {
            return true;
        }
        return false;
    }

    public bool IsLastLine()
    {
        if(m_TextComponent.textInfo.lineCount == 3)
        {
            return true;
        }
        return false;
    }

    public void ResetText()
    {
        m_TextComponent.text = "";
        currentLetterIndex = 0;
        currentWordLineIndex = 0;
        greenLetters = new List<int>();
        redLetters = new List<int>();
    }
}
