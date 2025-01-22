using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScriptManager : MonoBehaviour
{
    public TextMeshProUGUI InputStrings;

    public string[,] StandardIndex = new string [2, 11];
    public string[] nceaClasses = {"Accounting", "Algebra/Calculus", "Art", "Business", "Chemistry", "Biology", "Dance", "Digital Technology", "Drama", "DVC", "Economics", "English", "French", "Geography", "Health", "History", "Media Studies", "Music", "Physical Education", "Physics", "Psychology", "Science", "Social Studies", "Te Reo Maori", "Textiles"};
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
    public int assesmentStandard;
    public int assesmentClass;
    public int creditValue;
    public int internalExternal;
    public string readOrWrite;

    public int readInput;
    public int writeInput;

    public string titleInput;
    public string dueDateInput;
    public int inputRow;

    string stringInput;
    // AS 92247
    public void ReadStandardNumber(string info)
    {
        Int32.TryParse(info, out assesmentStandard);
        Debug.Log(assesmentStandard);

    }
    // WORTH 4 CREDITS
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

    //DEMONSTRATE UNDERSTSNDING
    public void ReadTitle(string info)
    {
        titleInput = info;
    }

    public void ReadDueDate(string info)
    {
        dueDateInput = info;
    }


    public void ReadRow(string info)
    {
        Int32.TryParse(info, out inputRow);
        Debug.Log(inputRow);
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


       UpdateDebug();
    }

    public void SpawnStandard(int assesmentStandard, int creditValue)
    {


    }

    public void UpdateDebug()
    {
        InputStrings.text = "Input Strings\n";
        for (int i = 0; i < 2; i++)
        {
            for (int k = 0; k < 11; k++)
            {
                InputStrings.text += StandardIndex[i, k] + ", ";
            } 
        }
    }
}
