using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRaycasting : MonoBehaviour {
    public float distanceToSee;
    [SerializeField] Text dialogue;
    RaycastHit whatIHit;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee)) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("I touched " + whatIHit.collider.gameObject.name);
                if (whatIHit.collider.gameObject.name == "PaintingWin") {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
            if (whatIHit.collider.gameObject.name == "Dialogue1") {
                dialogue.text = "I love this style of painting, the many small, thin, brush strokes adds so much meaning.";
            }
            else if (whatIHit.collider.gameObject.name == "Dialogue2") {
                dialogue.text = "The artists of this time made such great depictions of lighting, truly amazing!";
            }
        } else {
            dialogue.text = "";
        }
    }
}
