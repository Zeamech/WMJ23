using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public List<GameObject> Targets = new List<GameObject>();
    public Target TargetScript;
    public ClickLine ClickLineScript;

    public GameObject TargetPrefab;
    public float TargetSpeed;
    public int NumberOfTargets;
    public float MinSpawnSpeed;
    public float MaxSpawnSpeed;
    private float Countdown;
    private int TargetsClicked;

    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargetsRandom());
        TargetScript = GetComponent<Target>();
        ClickLineScript = GetComponent<ClickLine>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetMovement();
        CheckClickedTarget();
    }

    IEnumerator SpawnTargetsRandom()
    {
        for (int i = 0; i < NumberOfTargets; i++)
        {
            Countdown = Random.Range(MinSpawnSpeed, MaxSpawnSpeed);
            int Spawner = Random.Range(1, 4);
            switch (Spawner)
            {
                case 1: Targets.Add(Instantiate(TargetPrefab, Spawner1.transform.position, Spawner1.transform.rotation)); break;
                case 2: Targets.Add(Instantiate(TargetPrefab, Spawner2.transform.position, Spawner2.transform.rotation)); break;
                case 3: Targets.Add(Instantiate(TargetPrefab, Spawner3.transform.position, Spawner3.transform.rotation)); break;
            }
            yield return new WaitForSeconds (Countdown);

        }
    }

    public void TargetMovement()
    {
        foreach(var target in Targets)
        {
            target.transform.Translate(Vector2.down * TargetSpeed * Time.deltaTime);
        }
    }

    public void CheckClickedTarget()
    {
        if(TargetsClicked == NumberOfTargets)
        {
            //GameWon
        }
        else
        {
            //GameLose
        }
        if(TargetScript.Clicked && ClickLineScript.ClickNow)
        {
            TargetsClicked++;
        }
    }
}
