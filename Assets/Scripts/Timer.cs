using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour {
    [SerializeField] private int contestTime = 60;
    private TextMeshPro timeCounterText;
    private float currentTime;
    private ContestManager contestManager; 
    // Use this for initialization
    void Start () {
        currentTime = contestTime;
        timeCounterText = GetComponent<TextMeshPro>();
        contestManager = GameObject.Find("ContestManager").GetComponent<ContestManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTime <= 0 || !contestManager.ContestState()) return;
        currentTime -=  Time.deltaTime;
        timeCounterText.text = currentTime.ToString("00");
	}
   public void resetTimer()
    {
        currentTime = contestTime;
        timeCounterText.text = currentTime.ToString("00");
    }

    public bool hasTimerEnd()
    {
        if (currentTime <= 0) return true;
        return false;
    }
    

    
}
