using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.UIElements.Runtime;


public class MainMenuManager : MonoBehaviour
{
    public PanelRenderer m_LoginScreenPanel;  // Important! Remember to tick Enable live updates!!!!
    private TextField spdvi_FirstNameTextField;
    private TextField spdvi_LastNameTextField;

    private void OnEnable()
    {
        m_LoginScreenPanel.postUxmlReload = BindGameScreen;  // Important!!!
    }

    private IEnumerable<Object> BindGameScreen()
    {

        var root = m_LoginScreenPanel.visualTree;
        spdvi_FirstNameTextField = root.Query<TextField>("spdvi_FirstNameTextField");  // name of the element in UXML
        spdvi_LastNameTextField = root.Query<TextField>("spdvi_LastNameTextField");  // name of the element in UXML
        return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
