using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInformationPlayer : MonoBehaviour
{
    public GameObject heroes;
    private void Start()
    {
        GameObject child = heroes.transform.Find(PlayerInformationStatic.PrefabHero).gameObject;
        child.SetActive(true);
    }
}
