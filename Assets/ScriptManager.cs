using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ScriptManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=4jvGgn4b1V8 github hosting                8;28;30 AM 25/01/2025

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
    public TextMeshProUGUI hypotheticalText;
    public TextMeshProUGUI CountDown; 
    public TextMeshProUGUI ClassesText;
    public TextMeshProUGUI ClassesNameText;

    public TextMeshProUGUI ArchiveMsg;

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
    public string[] hypotheticalIndex = {"Confirmed", "Hypothetical"};
    public string[] statsClasses = new string [6];
    public int[,] statsClassesCredits = new int [6, 5]; //row = statsClass, col = 0 = total, 4 = not achived, 3 = achived, 2 = merit, 1 = excellence
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

    public int removeRowInput;

    public int archiveInputRow;

    public int SaveIndexSwitch;
    public int CreditsTotal;
    public int CreditsTotalOpt;
    public int AchievedCredits;
    public int MeritCredits;
    public int ExcellenceCredits;
    public int NotAchievedCredits;
    public int CreditsAndHypo;
    public int ExcellenceAndHypo;
    public int MeritAndHypo;
    public int AchievedAndHypo;
    public int NotAchievedAndHypo;
    public int ExcellenceOpt;
    public int MeritOpt;
    public int AchievedOpt;
    public int NotAchievedOpt;
    public int CreditsOpt;
    public int Inprogress;

    public bool classRegis;

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
    public void ReadArchiveRow(string info)
    {
        archiveInputRow = Convert.ToInt32(info);
    }
    public void ReadRemoveRow(string info)
    {
        removeRowInput = Convert.ToInt32(info);
    }
    /*
    public void ReadClassStat1(int info)
    {
        statsClasses[0] = info;
    }
    public void ReadClassStat2(int info)
    {
        statsClasses[1] = info;
    }
    public void ReadClassStat3(int info)
    {
        statsClasses[2] = info;
    }
    public void ReadClassStat4(int info)
    {
        statsClasses[3] = info;
    }
    public void ReadClassStat5(int info)
    {
        statsClasses[4] = info;
    }
    public void ReadClassStat6(int info)
    {
        statsClasses[5] = info;
    }
    public void ReadClassStat7(int info)
    {
        statsClasses[6] = info;
    }*/



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
       StandardIndex[inputRow, 9] = hypotheticalIndex[hypotheticalInput];

       SpawnStandard();
    }

    public void SpawnStandard()
    {
        for (int i = 0; i < 10; i++)
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
                hypotheticalText.text = StandardIndex[i, 9];
                
                stringDisplay.CopyStandard(i, Convert.ToInt32(StandardIndex[i, 8]));
            }
        }
    }
    
    public void Archive()
    {
        for (int i = 0; i < 30; i++)
        {
            if ((Convert.ToInt32(ArchiveIndex[i, 1]) == 0) && (StandardIndex[archiveInputRow, 9] == "Confirmed") && (Convert.ToInt32(StandardIndex[archiveInputRow, 8]) > 0)) //sets row for overwriting if credits == 0
            {
                for (int k = 0; k < 10; k++)
                {
                    ArchiveIndex[i, k] = StandardIndex[archiveInputRow, k]; // write target standard to archive
                    StandardIndex[archiveInputRow, k] = ""; // delete target standard
                }
                ArchiveMsg.text = "Archived Row: "+archiveInputRow+".\nNow export and refresh the page";
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
                importParserCol = 0;
                importParserRow = 0;
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
        CreditsTotalOpt = 0;
        AchievedCredits = 0;
        MeritCredits = 0;
        ExcellenceCredits = 0;
        CreditsAndHypo = 0;
        ExcellenceAndHypo = 0;
        MeritAndHypo = 0;
        AchievedAndHypo = 0;
        NotAchievedAndHypo = 0;
        ExcellenceOpt = 0;
        MeritOpt = 0;
        AchievedOpt = 0;
        NotAchievedOpt = 0;
        CreditsOpt = 0;
        Inprogress = 0;

        CreditsTotalText.text = "";
        ClassesText.text = "";
        ClassesNameText.text = "";

        for (int i = 0; i < 6; i++)
        {
            for (int k = 0; k < 5; k++)
            {
                statsClassesCredits[i, k] = 0;
            }
        }






        for (int i = 0; i < 10; i++)
        {
            if (Convert.ToInt32(StandardIndex[i, 8]) < 1)
            {
                Inprogress += Convert.ToInt32(StandardIndex[i, 1]);
            }
        }

        for (int i = 0; i < 30; i++)
        {
            if (Convert.ToInt32(ArchiveIndex[i, 8]) < 1)
            {
                Inprogress += Convert.ToInt32(ArchiveIndex[i, 1]);
            }
        }

        for (int i = 0; i < 10; i++) // STANDARD ZONE
        {
            if ((Convert.ToInt32(StandardIndex[i, 8]) > 1) && (StandardIndex[i, 9] == "Confirmed")) // total credits, only marked, only confirmed
            {
                CreditsTotal += Convert.ToInt32(StandardIndex[i, 1]);
                /*
                if ((Convert.ToInt32(StandardIndex[i, 4])) == "Not Read/Write")
                */
                switch(Convert.ToInt32(StandardIndex[i, 8]))
                {
                    case 2:
                    {
                        AchievedCredits += Convert.ToInt32(StandardIndex[i, 1]);
                        break;
                    }

                    case 3:
                    {
                        MeritCredits += Convert.ToInt32(StandardIndex[i, 1]);
                        break;
                    }

                    case 4:
                    {
                        ExcellenceCredits += Convert.ToInt32(StandardIndex[i, 1]);
                        break;
                    }
                }
            }
            if ((Convert.ToInt32(StandardIndex[i, 8]) == 1) && (StandardIndex[i, 9] == "Confirmed"))
            {
                NotAchievedCredits += Convert.ToInt32(StandardIndex[i, 1]);
            }

            if (Convert.ToInt32(StandardIndex[i, 8]) > 1) // Credits + Hypothetical
            {
                CreditsAndHypo += Convert.ToInt32(StandardIndex[i, 1]);
                switch(Convert.ToInt32(StandardIndex[i, 8]))
                {
                    case 2:
                    {
                        AchievedAndHypo += Convert.ToInt32(StandardIndex[i, 1]);
                        break;
                    }

                    case 3:
                    {
                        MeritAndHypo += Convert.ToInt32(StandardIndex[i, 1]);
                        break;
                    }

                    case 4:
                    {
                        ExcellenceAndHypo += Convert.ToInt32(StandardIndex[i, 1]);
                        break;
                    }
                }
            }
            if ((Convert.ToInt32(StandardIndex[i, 8]) == 1))
            {
                NotAchievedAndHypo += Convert.ToInt32(StandardIndex[i, 1]);
            }


            /*
            if ()
            */

            if (Convert.ToInt32(StandardIndex[i, 8]) != 1) // total credits (incl in progress assesments)
            {
                CreditsTotalOpt += Convert.ToInt32(StandardIndex[i, 1]);
            }

            //for all in classes[], check if class is equal to classes[i]


            

        }
        
        for (int i = 0; i < 30; i++) // ARCHIVE ZONE
        {
            if (Convert.ToInt32(ArchiveIndex[i, 8]) > 1) // Real Credits
            {
                CreditsTotal += Convert.ToInt32(ArchiveIndex[i, 1]);
                switch(Convert.ToInt32(ArchiveIndex[i, 8]))
                {
                    case 2:
                    {
                        AchievedCredits += Convert.ToInt32(ArchiveIndex[i, 1]);
                        break;
                    }

                    case 3:
                    {
                        MeritCredits += Convert.ToInt32(ArchiveIndex[i, 1]);
                        break;
                    }

                    case 4:
                    {
                        ExcellenceCredits += Convert.ToInt32(ArchiveIndex[i, 1]);
                        break;
                    }
                }
            }
            if ((Convert.ToInt32(ArchiveIndex[i, 8]) == 1))
            {
                NotAchievedCredits += Convert.ToInt32(ArchiveIndex[i, 1]);
            }

            if (Convert.ToInt32(ArchiveIndex[i, 8]) > 1) // Credits + Hypothetical
            {
                CreditsAndHypo += Convert.ToInt32(ArchiveIndex[i, 1]);
                switch(Convert.ToInt32(ArchiveIndex[i, 8]))
                {
                    case 2:
                    {
                        AchievedAndHypo += Convert.ToInt32(ArchiveIndex[i, 1]);
                        break;
                    }

                    case 3:
                    {
                        MeritAndHypo += Convert.ToInt32(ArchiveIndex[i, 1]);
                        break;
                    }

                    case 4:
                    {
                        ExcellenceAndHypo += Convert.ToInt32(ArchiveIndex[i, 1]);
                        break;
                    }
                }
            }
            if ((Convert.ToInt32(ArchiveIndex[i, 8]) == 1))
            {
                NotAchievedAndHypo += Convert.ToInt32(ArchiveIndex[i, 1]);
            }


            if ((Convert.ToInt32(ArchiveIndex[i, 8]) != 1))
            {
                CreditsTotalOpt += Convert.ToInt32(ArchiveIndex[i, 1]);
            }


            
        }

        // finds subjects in standardIndex
        for (int k = 0; k < 6; k++) //for each class index
        {
            for (int i = 0; i < 10; i++) //check each row
            {
                Debug.Log("check each row "+StandardIndex[i, 2]);
                classRegis = false;
                if (Convert.ToInt32(StandardIndex[i, 1]) > 0) // if not empty
                {
                    //check if same as last
                    Debug.Log("check if same as last "+StandardIndex[i, 2]);
                    for (int j = 0; j < 6; j++) // outputs true if
                    {
                        Debug.Log("comparing"+statsClasses[j]+"to"+StandardIndex[i, 2]);

                        if (statsClasses[j] == StandardIndex[i, 2]) // if true then its already registered
                        { 
                            classRegis = true;
                            Debug.Log("already registered "+StandardIndex[i, 2]);
                        }
                    }

                    if (classRegis == false)
                    {
                        statsClasses[k] = StandardIndex[i, 2];
                        Debug.Log("not registered "+StandardIndex[i, 2]);
                    }
                }  
            }
            for (int i = 0; i < 30; i++) //check each row
            {
                Debug.Log("ARCHIVE ------------------------- check each row "+ArchiveIndex[i, 2]);
                classRegis = false;
                if (Convert.ToInt32(ArchiveIndex[i, 1]) > 0) // if not empty
                {
                    //check if same as last
                    Debug.Log("check if same as last "+ArchiveIndex[i, 2]);
                    for (int j = 0; j < 6; j++) // outputs true if
                    {
                        Debug.Log("comparing"+statsClasses[j]+"to"+ArchiveIndex[i, 2]);

                        if (statsClasses[j] == ArchiveIndex[i, 2]) // if true then its already registered
                        { 
                            classRegis = true;
                            Debug.Log("already registered "+ArchiveIndex[i, 2]);
                        }
                    }

                    if (classRegis == false)
                    {
                        statsClasses[k] = ArchiveIndex[i, 2];
                        Debug.Log("not registered "+ArchiveIndex[i, 2]);
                    }
                }  
            }
        }

        for (int i = 0; i < 6; i++) // CLASSES (already filtered out 0 cr standards)
        {
            for (int k = 0; k < 10; k++) // STANDARD
            {
                if ((StandardIndex[k, 2] == statsClasses[i]) && (StandardIndex[k, 9] == "Confirmed"))
                {
                    statsClassesCredits[i, 0] += Convert.ToInt32(StandardIndex[k, 1]); // total

                    switch(Convert.ToInt32(StandardIndex[k, 8]))
                    {
                        case 1:
                        {
                            statsClassesCredits[i, 4] += Convert.ToInt32(StandardIndex[k, 1]);
                            break;
                        }
                        case 2:
                        {
                            statsClassesCredits[i, 3] += Convert.ToInt32(StandardIndex[k, 1]);
                            break;
                        }

                        case 3:
                        {
                            statsClassesCredits[i, 2] += Convert.ToInt32(StandardIndex[k, 1]);
                            break;
                        }

                        case 4:
                        {
                            statsClassesCredits[i, 1] += Convert.ToInt32(StandardIndex[k, 1]);
                            break;
                        }
                    }
                    
                }
            }
            Debug.Log(statsClassesCredits[i, 0]+" with class "+statsClasses[i]);
            for (int k = 0; k < 30; k++)
            {
                if (ArchiveIndex[k, 2] == statsClasses[i])
                {
                    statsClassesCredits[i, 0] += Convert.ToInt32(ArchiveIndex[k, 1]); // total

                    switch(Convert.ToInt32(ArchiveIndex[k, 8]))
                    {
                        case 1:
                        {
                            statsClassesCredits[i, 4] += Convert.ToInt32(ArchiveIndex[k, 1]);
                            break;
                        }
                        case 2:
                        {
                            statsClassesCredits[i, 3] += Convert.ToInt32(ArchiveIndex[k, 1]);
                            break;
                        }

                        case 3:
                        {
                            statsClassesCredits[i, 2] += Convert.ToInt32(ArchiveIndex[k, 1]);
                            break;
                        }

                        case 4:
                        {
                            statsClassesCredits[i, 1] += Convert.ToInt32(ArchiveIndex[k, 1]);
                            break;
                        }
                    }
                    
                }
            }
        }



        Debug.Log(statsClasses[0]);
        Debug.Log(statsClasses[1]);
        Debug.Log(statsClasses[2]);
        Debug.Log(statsClasses[3]);
        Debug.Log(statsClasses[4]);
        Debug.Log(statsClasses[5]);
  
        NotAchievedOpt += NotAchievedAndHypo + Inprogress;
        AchievedOpt += AchievedAndHypo + Inprogress;
        MeritOpt += MeritAndHypo + Inprogress;
        ExcellenceOpt += ExcellenceAndHypo + Inprogress;
        CreditsOpt += CreditsAndHypo + Inprogress;

        CreditsTotalText.text = ""+
        CreditsTotal+"      "+ExcellenceCredits+"       "+MeritCredits+"       "+AchievedCredits+"       "+NotAchievedCredits+"\n"+
        CreditsAndHypo+"      "+ExcellenceAndHypo+"       "+MeritAndHypo+"       "+AchievedAndHypo+"       "+NotAchievedAndHypo+"\n"+
        CreditsOpt+"      "+ExcellenceOpt+"      "+MeritOpt+"      "+AchievedOpt+"      "+NotAchievedOpt;

        CountDown.text = ""+
        (60-CreditsTotal)+"\n"+
        (50-MeritCredits)+"\n"+
        (50-ExcellenceCredits);

        for (int i = 0; i < 6; i++)
        {
            if (statsClasses[i] != "")
            {
                ClassesNameText.text += ""+statsClasses[i]+"\n";
                ClassesText.text += ""+statsClassesCredits[i, 0]+"       "+statsClassesCredits[i, 1]+"       "+statsClassesCredits[i, 2]+"       "+statsClassesCredits[i, 3]+"       "+statsClassesCredits[i, 4];
                ClassesText.text += "\n";
            }
            
        }
        
    }
}
