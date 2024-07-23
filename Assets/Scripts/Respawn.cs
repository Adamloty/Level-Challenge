using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float wait = 1.20f;
    [SerializeField] private GameObject player;
    private Move move;
    void Start()
    {
        move=GameObject.FindWithTag("Player").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator again()
    {
        //Time.timeScale = 0f;
        move.enabled = false;
        yield return new WaitForSeconds(wait);
        Instantiate(player,transform.position, Quaternion.identity);
        //   int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //  Time.timeScale = 1.0f;
        // SceneManager.LoadScene(currentSceneIndex);
    }
}
