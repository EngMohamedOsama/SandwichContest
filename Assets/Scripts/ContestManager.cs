using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContestManager : MonoBehaviour {
    [SerializeField] private bool contestSart = false;
    private IIngredient[] ingrediants;
    [SerializeField] private Transform[] spots;
    private List<GameObject> randomIngred = new List<GameObject>();
    private List<string> playerIngred = new List<string>();
    private Timer timer;
	// Use this for initialization
	void Start () {
        ingrediants = GameObject.Find("Ingredients").GetComponentsInChildren<IIngredient>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    public bool ContestState()
    {
        if (contestSart)
        {
            return true;
        }
        return false;
    }
    private void InstantiateIngrediants()
    {
        if (!contestSart) return;
        for (int i = 0; i < spots.Length; i++)
        {
            randomIngred.Insert(i, ingrediants[Random.Range(0, ingrediants.Length)].controllerEffect()); 
            randomIngred[i].transform.position = spots[i].position;
            randomIngred[i].transform.localScale = new Vector3(3f, 3f, 3f);
            string[] scriptName = randomIngred[i].name.Split('(');
            Destroy(randomIngred[i].GetComponent(scriptName[0]));

        }
    }

    private void DestroyIngrediants()
    {
        if (randomIngred.Count == 0) return;
        for(int i =0; i< randomIngred.Count; i++)
        {
            Destroy(randomIngred[i]);
        }
        randomIngred.Clear();
    }

    public void StartContest()
    {
        contestSart = true;
        GetComponent<AudioSource>().Play();
        GameObject.Find("SoundManager").GetComponent<AudioSource>().Stop();
        InstantiateIngrediants();
    }

    public void StopContest()
    {
        contestSart = false;
        GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
        DestroyIngrediants();
        timer.resetTimer();
    }

    public List<GameObject> GetRandomIngredList()
    {
        return randomIngred;
    }

    public List<string> GetPlayerIngredList()
    {
        return playerIngred;
    }

    public void SetPlayerList(int number , string item)
    {
        playerIngred.Insert(number, item);
    }
}
