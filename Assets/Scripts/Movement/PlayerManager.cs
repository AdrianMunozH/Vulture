using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class PlayerManager : MonoBehaviour
{
    public Dictionary<String, PlayerMovement> players = new Dictionary<string, PlayerMovement>();
    //test
    public GameObject camPos;
    private VisualEffect vulture;
    
    private String current;
    // noch mit enum ersetzen? 
    public List<String> keys;

    public List<PlayerMovement> val;
    private bool cooldown;
    private BoxCollider _boxCollider;
    
    private PlayerMovement player;
    [SerializeField] public PlayableDirector timeline;
    private HintController hint;
    
    private void Awake()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            players.Add(keys[i],val[i]);
        }
        
        
        if (current == null)
        {
            current = keys[0];
            setCamPos();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        vulture = GameObject.Find("Vulture").GetComponent<VisualEffect>();
        _boxCollider = camPos.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (VirtualInputManager.Instance.MoveRight)
        {
            players[current].MoveRight = true;

        }
        else
        {
            players[current].MoveRight = false;
        }
        if (VirtualInputManager.Instance.MoveLeft)
        {
            players[current].MoveLeft = true;
        }
        else
        {
            players[current].MoveLeft = false;
        }
        
        if (VirtualInputManager.Instance.MoveUp)
        {
            players[current].MoveUp = true;
        }
        else
        {
            players[current].MoveUp = false;
        }
        if (VirtualInputManager.Instance.MoveDown)
        {
            players[current].MoveDown = true;
        }
        else
        {
            players[current].MoveDown = false;
        }

        if (VirtualInputManager.Instance.Jump)
        {
            players[current].Jump = true;
        }
        else
        {
            players[current].Jump = false;
        }
        if (VirtualInputManager.Instance.DoAction)
        {
            players[current].DoAction = true;
        }
        else
        {
            players[current].DoAction = false;
        }

        if (VirtualInputManager.Instance.ChangePlayer && !cooldown && current != "Vulture")
        {
            //current Player wird geändert
            if (ChangePlayer("Vulture"))
            {
                
                changePlayerOnCooldown();
            }
        }
        else
        {
            //Debug.Log("false:" + other.name);
            VirtualInputManager.Instance.ChangePlayer = false;
        }
        
        if (current == "Vulture")
        {
            // Überprüft, ob der Spieler sich bewegt und ob gerade die Earthquakescene gespielt wird
            if (current != "Vulture" && timeline.name.Length > 0 && player.MoveLeft == false && player.MoveRight == false && player.MoveDown == false && timeline.state != PlayState.Playing)
            {
                StartMovement.start(vulture);
            }else
            {
                StopMovement.stop(vulture);
            }
        }
    }


    public bool ChangePlayer(String nextPlayer)
    {
        //TODO
        
        //SoundManager.PlaySound(SoundManager.Sound.VultureMove,SoundAssets._fx);
        bool check;
        if (current.Equals(nextPlayer))
        {
            check = false;
        }
        else if(players.ContainsKey(nextPlayer) && (current == "Vulture" || nextPlayer == "Vulture"))
        {
            // Vulture muss irgendwie noch verschwinden bzw wiederauftauchen.
            if (current == "Vulture")
            {
                players[current].gameObject.SetActive(false);
            }
            else
            {
                players[nextPlayer].transform.position = players[current].transform.position + new Vector3(0,1f,0);
                players[nextPlayer].gameObject.SetActive(true);
            }
            

            players[current].MoveLeft = false;
            players[current].MoveRight = false;
            players[current].Jump = false;
            current = nextPlayer;
            check = true;
            setCamPos();
        }
        else
        {
            //Debug.Log(nextPlayer + " did not work");
            //Debug.Log("contains: " + players.ContainsKey(nextPlayer) + "vulture: " + (current == "Vulture" || nextPlayer == "Vulture"));
            check = false;
        }

        return check;
        //camPos.transform.position = players[current].transform.position;

    }

    public void setCamPos()
    {
        camPos.transform.SetParent(players[current].transform);
        // y höhe ist die des Collider von Moleboy
        camPos.transform.localPosition = new Vector3(0,0,0);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        // Vielleicht lieber das  benutzen
        //Physics.OverlapBox();// gibt eine Liste von objekten die man collided
        
        if (VirtualInputManager.Instance.ChangePlayer && !cooldown && other.gameObject.CompareTag("Player"))
        {
            if (ChangePlayer(other.gameObject.name))
            {
                changePlayerOnCooldown();
            }
        }
        else
        {
            //Debug.Log("false:" + other.name);
            //Debug.Log("Cooldown: " +  cooldown + "other: " + other.gameObject.name);
            VirtualInputManager.Instance.ChangePlayer = false;
        }
        
    }

    private void changePlayerOnCooldown()
    {
        cooldown = true;
        StartCoroutine("ResetCooldown");
    }

    IEnumerator ResetCooldown(){
        yield return new WaitForSeconds(1f);
        cooldown = false;
    }
    
}
