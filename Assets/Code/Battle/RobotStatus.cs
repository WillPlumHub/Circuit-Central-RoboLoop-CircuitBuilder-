using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class RobotStatus : MonoBehaviour {

    #region Variables
    [Header("Weapon Data")]
    public int WeaponSlots;
    public int UsedSlots = 0;

    [Header("Weapon Slots")]
    public GameObject overLoadSlot; 
    public GameObject[] SlotLocations = new GameObject[4];

    [Header("Robo Stats")]
    public int RoboHealth = 10;
    public int RoboMaxHealth = 10;
    public string sceneToLoad = "StartMenu";
    public GameObject GameOver;

    AudioManager audioManager;
    #endregion

    private void Start() {
        GameOver.SetActive(false);
    }

    void Update() {
        if (RoboHealth <= 0) {
            GameOver.SetActive(true);
            Debug.Log("GAME OVER BITCHES");
            GetComponent<Animator>().SetBool("Dead", true);
            StartCoroutine(OnDeath());
            //send part of that damage to the weapons
        }
        if(RoboHealth > RoboMaxHealth) {
            RoboHealth = RoboMaxHealth;
        }
        UpdateSlider();
    }

    public Transform WeaponSlotSetup() {
        if(UsedSlots < 4) {
            Transform weaponLocation = SlotLocations[UsedSlots].transform;
            UsedSlots++;
            return weaponLocation;
        }
        else {
            Debug.Log("Warning: All slots already assigned");
            Transform weaponLocation = overLoadSlot.transform;
            return weaponLocation;
        }
    }

    public IEnumerator WalkToBattle(float timeToResetBattle)
    {
        GetComponent<Animator>().SetBool("IsWalking", true);
        yield return new WaitForSeconds(timeToResetBattle);
        GetComponent<Animator>().SetBool("IsWalking", false);
    }

    public IEnumerator OnDeath()
    {
        Weapon[] weapons = FindObjectsOfType<Weapon>();
        foreach(Weapon weapon in weapons)
        {
            Destroy(weapon.gameObject);
        }
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    void UpdateSlider()
    {
        Slider healthBar = this.transform.Find("Canvas").transform.GetChild(0).GetComponent<Slider>();
        healthBar.maxValue = RoboMaxHealth;
        healthBar.value = RoboHealth;

    }
}