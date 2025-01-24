using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScriptManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=4jvGgn4b1V8 github hosting

    /*save methods?
    playerprefs -        no - doesnt support arrays
    json serialization - no - cant use filesystem in webgl
    player copy pasting string - yeah, ill have to do this i guess

    user pastes in string
    ||92843>>4>>accounting>>Internal

    https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split#code-try-5
    https://learn.microsoft.com/en-us/dotnet/standard/base-types/divide-up-strings

    
}







    */
    public StringDisplay stringDisplay;
    public TextMeshProUGUI InputStrings;
    public TMP_InputField InputField;
    
    public TextMeshProUGUI StandardText;
    public TextMeshProUGUI creditText;
    public TextMeshProUGUI classesText;
    public TextMeshProUGUI internalExternalText;
    public TextMeshProUGUI readWriteText;
    public TextMeshProUGUI dueDateText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI CreditsTotalText;

    public GameObject StandardStringPrefab;

    public GameObject[] rowpos = new GameObject [10];
    public GameObject[] gradeDesign = new GameObject [5];

    public string[,] StandardIndex = new string [12, 12];
    public string[,] ArchiveIndex = new string [32, 12];
    public string[] nceaClasses = {"Accounting", "Algebra/Calculus", "Art", "Business", "Chemistry", "Biology", "Dance", "Digital Technology", "Drama", "DVC", "Economics", "English", "French", "Geography", "Health", "History", "Media Studies", "Music", "Outdoor Education", "Physical Education", "Physics", "Psychology", "Science", "Social Studies", "Te Reo Maori", "Textiles"};
    /* 
    in order: 
    standard number,
    credits, 
    class (in dropdown menu order, starting from 1), 
    external/internal (1 for internal, 2 for external)
    read/write: 1 = none, 2 = read, 3 = write, 4 = read & write
    raw due date string
    raw title string
    done? 1 for no, 2 for yes
    1 = NA, 2 = A, 3 = M, 4 = E
    hypothetical results? 1 for no, 2 for yes
    */
    public string[,] readOrWriteIndex = {{"Not Read/Write", "Write"}, {"Read", "Read&Write"}};
    public string[] internalExternalArray = {"Internal", "External"};
    public int importParserCol;
    public int importParserRow;

    
    public int assesmentStandard;
    public int assesmentClass;
    public int creditValue;
    public int internalExternal;
    public string readOrWrite;

    public int readInput;
    public int writeInput;

    public string titleInput;
    public string dueDateInput;
    public int doneInput;
    public int gradeInput;
    public int hypotheticalInput;
    public int inputRow;

    public int SaveIndexSwitch;
    public int CreditsTotal;

    string stringInput;
    public void ReadStandardNumber(string info)
    {
        Int32.TryParse(info, out assesmentStandard);
        Debug.Log(assesmentStandard);

    }

    public void ReadCreditValue(string info)
    {
        Int32.TryParse(info, out creditValue);
        Debug.Log(creditValue);
    }

    public void ReadClassInput(int info)
    {
        assesmentClass = info;
    }

    public void ReadInternalOrExternalInput(bool info)
    {
        internalExternal = Convert.ToInt32(info);
    }

    public void ReadReadInput(bool read)
    {
       readInput = Convert.ToInt32(read);
    }

    public void ReadWriteInput(bool write)
    {
        writeInput = Convert.ToInt32(write);
    }

    public void ReadTitle(string info)
    {
        titleInput = info;
    }

    public void ReadDueDate(string info)
    {
        dueDateInput = info;
    }

    public void ReadDoneInput(bool info)
    {
        doneInput = Convert.ToInt32(info);
    }

    public void ReadGrade(int info)
    {
        gradeInput = info;
    }

    public void ReadHypotheticalInput(bool info)
    {
        hypotheticalInput = Convert.ToInt32(info);
    }

    public void ReadRow(string info)
    {
        Int32.TryParse(info, out inputRow);
        Debug.Log("inputRow: "+inputRow );
    }

    public void WriteData()
    {
       StandardIndex[inputRow, 0] = assesmentStandard.ToString();
       StandardIndex[inputRow, 1] = creditValue.ToString();
       StandardIndex[inputRow, 2] = nceaClasses[assesmentClass];
       StandardIndex[inputRow, 3] = internalExternalArray[internalExternal];
       StandardIndex[inputRow, 4] = readOrWriteIndex[readInput, writeInput];
       StandardIndex[inputRow, 5] = dueDateInput;
       StandardIndex[inputRow, 6] = titleInput;
       StandardIndex[inputRow, 7] = doneInput.ToString();
       StandardIndex[inputRow, 8] = gradeInput.ToString();
       StandardIndex[inputRow, 9] = hypotheticalInput.ToString();

       SpawnStandard();
    }

    public void SpawnStandard()
    {
        for (int i = 0; i < 8; i++)
        {
            if (Convert.ToInt32(StandardIndex[i, 1]) > 0)
            {
                StandardText.text = StandardIndex[i, 0];
                creditText.text = StandardIndex[i, 1];
                classesText.text = StandardIndex[i, 2];
                internalExternalText.text = StandardIndex[i, 3];
                readWriteText.text = StandardIndex[i, 4];
                dueDateText.text = StandardIndex[i, 5];
                titleText.text = StandardIndex[i, 6];
                
                stringDisplay.CopyStandard(i, Convert.ToInt32(StandardIndex[i, 8]));
            }
        }
    }
    
    public void Archive(int row)
    {
        for(int i = 1; i < 30;i++)
        {
            if (Convert.ToInt32(ArchiveIndex[i, 1]) != 0)
            {
                ArchiveIndex[row, i] = StandardIndex[row, i];
            }
        }
      


    }

    public void ParseSaveImport()
    {
        string[] separatingStrings = { ">>" };

        string text = InputStrings.text;
        Debug.Log($"Original text: '{text}'");

        string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
        Debug.Log($"{words.Length} substrings in text:");

        importParserCol = 0;
        importParserRow = 0;
        foreach (var word in words)
        {
            Debug.Log(word);
            if (word != "&&")
            {
                switch (SaveIndexSwitch)
                {
                    case 0:
                    {
                        if ((word != "||") && (importParserRow < 10))
                        {
                            StandardIndex[importParserRow, importParserCol] = word;
                            Debug.Log(StandardIndex[importParserRow, importParserCol]);
                            importParserCol++;
                            

                            
                        }
                        else if (importParserRow < 10)
                        {
                            importParserRow++;
                            importParserCol = 0;
                        }
                        break;
                    }
                    case 1:
                    {
                        if ((word != "||") && (importParserRow < 30))
                        {
                            ArchiveIndex[importParserRow, importParserCol] = word;
                            Debug.Log(StandardIndex[importParserRow, importParserCol]);
                            importParserCol++;
                            
                            
                        }
                        else if (importParserRow < 30)
                        {
            
                            importParserRow++;
                            importParserCol = 0;
                        }
                        break;
                    }
                }
  
                
            }
            else
            {
                SaveIndexSwitch = 1; // switches to archive index
            }
        }

        SpawnStandard();
        UpdateDebug();
        SaveIndexSwitch = 0;
    }
    public void UpdateDebug()
    {
        InputField.text = "";
        for (int i = 0; i < 10; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                InputField.text += StandardIndex[i, k] + ">>";
            } 
            InputField.text += ">>||>>";
        }

        InputField.text += ">>&&>>";

        for (int i = 0; i < 30; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                InputField.text += ArchiveIndex[i, k] + ">>";
            } 
            InputField.text += ">>||>>";
        }
    }

    public void StatisticsUpd()
    {
        CreditsTotal = 0;
        CreditsTotalText.text = "";
        for (int i = 0; i < 10; i++)
        {
            if (Convert.ToInt32(StandardIndex[i, 8]) > 1)
            {
                CreditsTotal += Convert.ToInt32(StandardIndex[i, 1]);
            }
            
            for (int k = i; k < i + 3; k++)
            {
                if (Convert.ToInt32(ArchiveIndex[i, 8]) > 1)
                {
                    CreditsTotal += Convert.ToInt32(ArchiveIndex[i, 1]);
                }
                
            }
        }
        CreditsTotalText.text = "Credits: "+CreditsTotal;

    }
}
