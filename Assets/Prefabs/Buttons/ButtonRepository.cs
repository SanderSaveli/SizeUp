using UnityEngine;

public class ButtonRepository : MonoBehaviour
{
    [SerializeField] private GameObject[] Buttons;
    public Button[] GetAllButtons()
    {
        Button[] buttons = new Button[Buttons.Length]; 
        int i = 0;
        foreach(var button in Buttons) 
        {
            buttons[i] = button.GetComponent<Button>();
            i++;
        }
        return buttons;
    }
}