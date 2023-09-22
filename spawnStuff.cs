using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnStuff : MonoBehaviour
{
    public GameObject[] Enemies = new GameObject[4];
    public Transform[] spawners = new Transform[4];
    private float initialTime;
    private bool spawnedStart = true;
    

    private int randomInt(int passedInt)
    {
        return Random.Range(0, passedInt - 1);
    }

    private float fractional(float currentTime)
    {
        if (currentTime - initialTime < 60f)
            return 1f;
        else return 60f / (currentTime - initialTime);
    }


    IEnumerator Countdown()
    {
        spawnedStart = true;
        yield return new WaitForSeconds(7f);
        Transform newTransform = spawners[randomInt(spawners.Length-1)];
        GameObject newEnemy = Instantiate(Enemies[randomInt(Enemies.Length-1)], newTransform.position + new Vector3(0f, 1.5f, 0f), newTransform.rotation) as GameObject;
        yield return new WaitForSeconds(25f * fractional(Time.time));
        spawnedStart = false;
        yield return null;
    }

    void Start()
    {
        initialTime = Time.time;
        StartCoroutine(Countdown());
    }

    void Update()
    {
        if(!spawnedStart)
            StartCoroutine(Countdown());
    }


}
