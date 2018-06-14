using UnityEngine;
using UnityEngine.UI;

public class CreditGrabber : MonoBehaviour {

    int CoinCount = 0;

    [SerializeField]
    Text CointCountText;

	void FixedUpdate ()
    {
        CointCountText.text = "" + CoinCount + "";
	}

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "coin")
        {
            CoinCount = CoinCount + 1;
            Destroy(col.gameObject);
        }
    }
}
