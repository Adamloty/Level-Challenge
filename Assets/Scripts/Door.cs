using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("open");
            collision.gameObject.SetActive(false);
            //   collision.collider.transform.GetChild(0).transform.SetParent(null);
            StartCoroutine(WaitAnimComplete(2));
        }
    }
    private IEnumerator WaitAnimComplete(int scene)
   {
        yield return new WaitForSeconds(1.05f);
        SceneManager.LoadScene(scene);
   }
}
