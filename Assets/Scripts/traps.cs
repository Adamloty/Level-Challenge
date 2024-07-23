using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class traps : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator canvas;
 //   [SerializeField] private Respawn respawn;
    [SerializeField] private float wait = 1.20f;
    private Move move;


    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Animator>();
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("trap"))
        {
            canvas.SetTrigger("ontranstion");
            StartCoroutine(again());
           // Destroy(this.gameObject);
        }
    }
    private IEnumerator again()
    {
        //Time.timeScale = 0f;
        move.enabled = false;
        yield return new WaitForSeconds(wait);
      //  Instantiate(player, transform.position, Quaternion.identity);
          int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //  Time.timeScale = 1.0f;
         SceneManager.LoadScene(currentSceneIndex);
    }
    private void Awake()
    {
        if(canvas == null)
        {
            canvas = GameObject.Find("Canvas").GetComponent<Animator>();
        }
    }
}
