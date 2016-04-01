using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyByBase : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (explosion != null)
        {
            //Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            SceneManager.LoadScene("BASE");
        }

        //Destroy(other.gameObject);
        //Destroy(gameObject);
    }
}