using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    public float wait = 2f;
    public GameObject wintext;
    bool end = false;
    public GameObject spinner;

    void FixedUpdate()
    {
        if (end)
        {
            wait -= Time.fixedDeltaTime;
            if (wait <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null)
        {
            win();
            p.cam.gameObject.transform.SetParent(spinner.transform);
        }
    }
    public void win()
    {
        wintext.SetActive(true);
        end = true;
    }
}
