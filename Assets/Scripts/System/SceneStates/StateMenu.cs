using UnityEngine;

public class SateMenu : ISceneState
{
    private Button[] buttons;

    public void Enter()
    {
        buttons = GameObject.FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            Debug.Log(button);
            button.Show();
        }
    }

    public void Exit()
    {
        buttons = GameObject.FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.Hide();
        }
    }
}
