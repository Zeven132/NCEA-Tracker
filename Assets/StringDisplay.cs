using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StringDisplay : MonoBehaviour
{
    
    public ScriptManager scriptManager;

    // Change strings FIRST
    // THEN instantiate the whole stringparent obj into the row

    public void CopyStandard(int row, int grade)
    {
        transform.SetParent(scriptManager.rowpos[row].transform); // position set to slot
        if (scriptManager.rowpos[row].transform.childCount < 3)
        {
            Instantiate(scriptManager.gradeDesign[grade], scriptManager.rowpos[row].transform);
            Instantiate(scriptManager.StandardStringPrefab, scriptManager.rowpos[row].transform);
            
        }
        else if (scriptManager.inputRow == row)
        {
            Destroy(scriptManager.rowpos[row].transform.GetChild(1).gameObject);
            Destroy(scriptManager.rowpos[row].transform.GetChild(0).gameObject);
            scriptManager.StandardIndex[row, 0] = "";
            scriptManager.StandardIndex[row, 1] = "";
            scriptManager.StandardIndex[row, 2] = "";
            scriptManager.StandardIndex[row, 3] = "";
            scriptManager.StandardIndex[row, 4] = "";
            scriptManager.StandardIndex[row, 5] = "";
            scriptManager.StandardIndex[row, 6] = "";
            scriptManager.StandardIndex[row, 7] = "";
            scriptManager.StandardIndex[row, 8] = "";
            scriptManager.StandardIndex[row, 9] = "";
        }
        scriptManager.StandardStringPrefab.transform.SetParent(transform.root);
 

       
    }

    public void RemoveStandard()
    {
        
        try
        {
            Destroy(scriptManager.rowpos[scriptManager.removeRowInput].transform.GetChild(1).gameObject);
            Destroy(scriptManager.rowpos[scriptManager.removeRowInput].transform.GetChild(0).gameObject);

            scriptManager.StandardIndex[scriptManager.removeRowInput, 0] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 1] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 2] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 3] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 4] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 5] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 6] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 7] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 8] = "";
            scriptManager.StandardIndex[scriptManager.removeRowInput, 9] = "";
            

            //scriptManager.ParseSaveImport();

        }
        catch
        {
            RemoveStandard();
        }

    }
    

}