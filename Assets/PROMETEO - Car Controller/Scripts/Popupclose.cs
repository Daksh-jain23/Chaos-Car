using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popupclose : MonoBehaviour
{
    // Start is called before the first frame update
    public Uiscript Uiscript;
    public void close()
    {
        Uiscript.destroy_popup(gameObject);
    }
    public void close_inactive()
    {
        gameObject.SetActive(false);
    }
}
