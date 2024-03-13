using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] (int,int) TimeSignature;
    int bpm = NoteManager.Instance.BPM;
    float timeBetweenBeatsInSeconds;
    int currentBeatNum = 0;
    float startTime;
    
    private void Start()
    {
        bpm = NoteManager.Instance.BPM;
        timeBetweenBeatsInSeconds = 60 / bpm;
        EventManager.StartListening("BPMChanged", SetBPM);
        EventManager.StartListening("StratedRecording", StartMetronome);

    }
    void SetBPM(Dictionary<string, object> _message)
    {
        bpm = (int)_message["BPM"];
        timeBetweenBeatsInSeconds = 60 / bpm;
    }
    void StartMetronome(Dictionary<string,object> _message) 
    {
        startTime = Time.time;
    }
    private void Update()
    {
        if(!NoteManager.Instance.PlayPaused)
        {  
            float elapsedTime = Time.time - startTime;
            var beats = Mathf.Round(elapsedTime / timeBetweenBeatsInSeconds);
        }
    }
   
    IEnumerator CountBeats()
    {
        if(currentBeatNum == TimeSignature.Item1)
        {

        }
        currentBeatNum ++;
        yield return new WaitForSecondsRealtime(timeBetweenBeatsInSeconds);
        if(!NoteManager.Instance.PlayPaused)
        {
            StartCoroutine(CountBeats());
        }
    }
}  