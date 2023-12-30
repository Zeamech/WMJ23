using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour
{
    public static Minigame Instance;
    public List<GameObject> Targets = new List<GameObject>();
    public List<AllySO> Allies = new List<AllySO>();
    public enum Song {One, Two, Three}
    public Song song;
    public ClickLine ClickLineScript;
    public GameManager GameManager;

    public Image Creature;
    public AllySO BlueSquirrel;
    public AllySO GoldBear;
    public AllySO GreenArdo;
    public AllySO PinkFox;
    public AllySO SelectedAlly;

    public AudioListener Listener;
    public AudioSource AudioDataSong1;
    public AudioSource AudioDataSong2;
    public AudioSource AudioDataSong3;

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
    public GameObject HowToPlay;
    public GameObject LoseScreen;
    public GameObject GameWonScreen;

    public Scene Map;
    

    private void Awake()
    {
        Instance = this;
        GameManager = GetComponent<GameManager>();
        Creature = GameObject.Find("Creature").GetComponent<Image>();
    }

    public void Start()
    {
        for (int i = 0; i < Allies.Count; i++)
        {
            if (Allies[i].Owned)
            {
                Allies.Remove(Allies[i]);
            }
        }

        int random = Random.Range(0, Allies.Count);
        SelectedAlly = Allies[random];
        Debug.Log(SelectedAlly);
        if (SelectedAlly.Icon != null)
        {
            Creature.sprite = SelectedAlly.Icon;
        }
        else
        {
            Creature.sprite = null;
        }
    }

    IEnumerator SpawnTargetsRandom()
    {
        for (int i = 0; i < NumberOfTargets; i++)
        {
            Transform CloneParent = GameObject.Find("Target Prefabs").transform;
            Countdown = Random.Range(MinSpawnSpeed, MaxSpawnSpeed);
            int Spawner = Random.Range(1, 4);
            switch (Spawner)
            {
                case 1: Instantiate(TargetPrefab, Spawner1.transform.position, Spawner1.transform.rotation, CloneParent); Target.Instance.TargetSpeed = TargetSpeed; break;
                case 2: Instantiate(TargetPrefab, Spawner2.transform.position, Spawner2.transform.rotation, CloneParent); Target.Instance.TargetSpeed = TargetSpeed; break;
                case 3: Instantiate(TargetPrefab, Spawner3.transform.position, Spawner3.transform.rotation, CloneParent); Target.Instance.TargetSpeed = TargetSpeed; break;
            }
            RefreshList();
            yield return new WaitForSeconds(Countdown);
        }
    }

    public void RefreshList()
    {
        Targets.Clear();
        Transform CloneParent = GameObject.Find("Target Prefabs").transform;
        foreach(Transform prefab in CloneParent)
        {
            if(prefab != null)
            {
                Targets.Add(prefab.gameObject);
            }
            
        }
    }

    public void TargetRemoveList(GameObject Target)
    {
        var Colour = Target.GetComponent<Renderer>();
        if (Colour.material.color != Color.green)
        {
            GameLose();
        }
        else 
        {
            RefreshList();
            Targets.Remove(Target);
        }
        
    }

    public void CheckClickedTarget(GameObject Target)
    {
        var Colour = Target.GetComponent<Renderer>();
        if (ClickLineScript.ClickNow)
        {
            Colour.material.color = Color.green;
            TargetsClicked++;
            Debug.Log("Target Hit");
        }
        if (TargetsClicked == NumberOfTargets)
        {
            GameWon();
        }
    }

    public void StartGame()
    {
        LoseScreen.SetActive(false);
        HowToPlay.SetActive(false);
        SongSelection();
        StartCoroutine(SpawnTargetsRandom());
    }

    public void SongSelection()
    {
        switch (song)
        {
            case Song.One: AudioDataSong1.Play(); TargetSpeed = 1; NumberOfTargets = 1; MinSpawnSpeed = 0.2f; MaxSpawnSpeed = 1; break;
            case Song.Two: AudioDataSong2.Play(); TargetSpeed = 2; NumberOfTargets = 2; MinSpawnSpeed = 0.2f; MaxSpawnSpeed = 1; break;
            case Song.Three: AudioDataSong3.Play(); TargetSpeed = 1.5f; NumberOfTargets = 8; MinSpawnSpeed = 1.5f; MaxSpawnSpeed = 3; break;
        }
    }

    public void GameLose()
    {
        StopAllCoroutines();
        for (var i = 0; i < Targets.Count; i++)
        {
            Destroy(Targets[i].gameObject);
            Targets.Remove(Targets[i]);
        }
        NumberOfTargets = 0;
        LoseScreen.SetActive(true);
        AudioDataSong1.Stop();
        AudioDataSong2.Stop();
        AudioDataSong3.Stop();
    }

    public void GameWon()
    {
        StopAllCoroutines();
        for (var i = 0; i < Targets.Count; i++)
        {
            Destroy(Targets[i].gameObject);
            Targets.Remove(Targets[i]);
        }
        NumberOfTargets = 0;
        GameWonScreen.SetActive(true);
        AudioDataSong1.Stop();
        AudioDataSong2.Stop();
        AudioDataSong3.Stop();
        GameManager.Party.Add(Instantiate(SelectedAlly, GameObject.Find("Party").transform).GetComponent<Ally>());
    }

    public void BackToMap()
    {
        SceneManager.LoadScene("Map");
    }
}
