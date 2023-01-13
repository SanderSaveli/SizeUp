using UnityEngine;

public class StateMenu : ISceneState
{
    private Button[] buttons;

    public void Enter()
    {
        buttons = GameObject.FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
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
