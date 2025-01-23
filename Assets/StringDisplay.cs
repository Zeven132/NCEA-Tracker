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
        scriptManager.StandardStringPrefab.transform.SetParent(transform.root);
 

       
    }
    

}