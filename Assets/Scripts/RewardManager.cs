using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour {
    private Timer timer;
    private ContestManager contestManager;
    [SerializeField] private GameObject loseReward;
    [SerializeField] private GameObject winReward;

	// Use this for initialization
	void Start () {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        contestManager = GameObject.Find("ContestManager").GetComponent<ContestManager>();
    }

    // Update is called once per frame
    void Update () {
        if (!timer.hasTimerEnd()) return;
        youLose();
        contestManager.StopContest();

    }

    public bool hasWon(List<string> playerSandwich, List<GameObject> randomIngred)
    {
        if (timer.hasTimerEnd()) return false;
        if (playerSandwich.Count != randomIngred.Count) return false;
        for (int i = 0; i < randomIngred.Count; i++)
        {
            string[] randomIngredName = randomIngred[i].name.Split('(');
            string[] playerSandwichName = playerSandwich[i].Split('(');
            if (playerSandwichName[0] != randomIngredName[0]) return false;
        }
        return true;
    }
    public void youLose()
    {
        loseReward.SetActive(true);
        StartCoroutine(wait());
    }

    public void youWin()
    {
        winReward.SetActive(true);
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        float waitDelay = 4;
        if (winReward.activeSelf) waitDelay = 15f;
        yield return new WaitForSeconds(waitDelay);
        loseReward.SetActive(false);
        winReward.SetActive(false);
    }
}