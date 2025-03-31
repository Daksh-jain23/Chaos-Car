using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popupclose : MonoBehaviour
{
    // Start is called before the first frame update
    public Uiscript Uiscript;
    public SoundPlayer SoundPlayer;
    private int index;
    public void set_index(int val)
    {
        index = val;
    }
    public void close()
    {
        SoundPlayer.PlaySound(index);
        Uiscript.destroy_popup(gameObject);
    }
    public void close_inactive()
    {
        gameObject.SetActive(false);
    }
}
