using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text HealthText;
    private float _health = 100f;
    public GameObject GameOverPanel;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value <= 0)
            {
                DeadPlayer();
            }
            else
            {
                _health = value;
            }
        }
    }

    private void Start()
    {
        HealthText.GetComponent<Text>();
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
        UpdateHealth();
    }

    private void DeadPlayer()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<PlayerController>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("Die");
        StartCoroutine(ButtonManager.OpenNewScene("StartGame", 3f, GameObject.Find("Panel").GetComponent<Animator>()));
    }


    public void GetHelth(float health)
    {
        Health += health;
        UpdateHealth();
    }
    
    public void UpdateHealth()
    {
        HealthText.text = _health.ToString();
    }
}
