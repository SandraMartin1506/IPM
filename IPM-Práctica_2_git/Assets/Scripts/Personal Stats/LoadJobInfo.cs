using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DialogueSystem;

public class LoadJobInfo : MonoBehaviour
{
    public JOBINFO info;
    public int jobNumber;
    static public string[] jobsInfo= new string[6];
    // Start is called before the first frame update
    void Start()
    {
        if (jobsInfo[jobNumber] != null) { job.text = jobsInfo[jobNumber]; }
        if (jobsInfo[jobNumber + 1] != null) { result.text = jobsInfo[jobNumber + 1]; }

        if (TextOptions.Size != job.fontSize) { job.fontSize = TextOptions.Size; }
        if (TextOptions.Spacing != job.lineSpacing) { job.lineSpacing = TextOptions.Spacing; }
        if (TextOptions.WordS != job.wordSpacing) { job.wordSpacing = TextOptions.WordS; }
        if (TextOptions.Size != result.fontSize) { result.fontSize = TextOptions.Size; }
        if (TextOptions.Spacing != result.lineSpacing) { result.lineSpacing = TextOptions.Spacing; }
        if (TextOptions.WordS != result.wordSpacing) { result.wordSpacing = TextOptions.WordS; }
    }

    [System.Serializable]
    public class JOBINFO
    {
        public TMP_Text job;
        public TMP_Text result;
    }

    public TMP_Text job { get { return info.job; } }
    public TMP_Text result { get { return info.result; } }
}
