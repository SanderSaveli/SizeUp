using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateDeathMenu : ISceneState
{
    private List<Button> _deathMenuButton = new List<Button>();
    public void Enter()
    {
        Button[] buttonsToSpawn =
            GameObject.FindObjectOfType<ButtonRepository>()
            .GetAllButtons()
            .Where(it => it.GetComponent<IDeathMenuButton>() != null).ToArray();

        Transform UiCanvas =
            GameObject.FindGameObjectWithTag("UiCanvas").transform;

        foreach (Button button in buttonsToSpawn)
        {
            Button newButton = GameObject.Instantiate(button, UiCanvas);
            _deathMenuButton.Add(newButton);
            _deathMenuButton.Last().Show();
        }
    }

    public void Exit()
    {
        foreach (Button button in _deathMenuButton)
        {
            button.Hide();
        }
    }
}
