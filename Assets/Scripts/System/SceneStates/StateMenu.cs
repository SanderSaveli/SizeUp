using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMenu : ISceneState
{
    private List<Button> _menuButton = new List<Button>();
    public void Enter()
    {
        Button[] buttonsToSpawn =
            GameObject.FindObjectOfType<ButtonRepository>()
            .GetAllButtons()
            .Where(it => it.GetComponent<IMainMenuButton>()!= null).ToArray();

        Transform UiCanvas =
            GameObject.FindGameObjectWithTag("UiCanvas").transform;

        foreach (Button button in buttonsToSpawn)
        {
            Button newButton = GameObject.Instantiate(button, UiCanvas);
            _menuButton.Add(newButton);
            _menuButton.Last().Show();
        }
    }

    public void Exit()
    {
        foreach (Button button in _menuButton)
        {
            button.Hide();
        }
    }
}
