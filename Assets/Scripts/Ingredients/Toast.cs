using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour,IIngredient {
    private float offset = .04f;
    private int ingredientCounter;
    private int tempCounter;
    private ContestManager contestManager;
    private RewardManager rewardManager;
    private void Start()
    {
        contestManager = GameObject.Find("ContestManager").GetComponent<ContestManager>();
        rewardManager = GameObject.Find("RewardManager").GetComponent<RewardManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IIngredient>() == null) return;
        if (other.name.Contains("Toast")) return;
        if (ingredientCounter > tempCounter) offset += .02f;
        var sandwichEffect = other.GetComponent<IIngredient>().sandwichEffect();
        var playerIngred = other.GetComponent<IIngredient>().controllerEffect();
        contestManager.SetPlayerList(ingredientCounter, playerIngred.name);
        sandwichEffect.transform.SetParent(this.transform);
        sandwichEffect.transform.position = transform.position + new Vector3(0f, offset, 0f);
        tempCounter = ingredientCounter++;
        Destroy(other.gameObject);
        Destroy(playerIngred);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!contestManager.ContestState()) return;
        if (collision.gameObject.GetComponent<IIngredient>() == null) return;
        if (collision.gameObject.name.Contains("Toast"))
        {
            if (contestManager.GetPlayerIngredList().Count == 0) return;
            if (!rewardManager.hasWon(contestManager.GetPlayerIngredList(), contestManager.GetRandomIngredList())) 
            {
                rewardManager.youLose();
                Destroy(collision.gameObject);
                contestManager.StopContest();
                Destroy(this.gameObject); return;
            }
            rewardManager.youWin();
            contestManager.StopContest();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    public GameObject controllerEffect()
    {
        return Instantiate(gameObject);
    }

    public GameObject sandwichEffect()
    {
        return null;
    }
}

