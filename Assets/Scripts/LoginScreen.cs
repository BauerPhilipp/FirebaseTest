using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LoginScreen : VisualElement
{

    #region Uxml Editor settings
    public new class UxmlFactory : UxmlFactory<LoginScreen, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits 
    {
        UxmlStringAttributeDescription ueberschriftLabel = new UxmlStringAttributeDescription() { name = "Überschrift"};

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            (ve as LoginScreen).Ueberschrift = ueberschriftLabel.GetValueFromBag(bag, cc);
        }

    }


    #endregion

    #region Stylesheet constanten

    const string styleSheet_LoginScreen = "StyleSheet_LoginScreen";
    const string ussMaincontainer = "mainContainer";
    const string ussLoginTextfeld = "textfeldLogin";
    const string ussButtons = "buttons";
    const string ussButtonsHover = "buttons:hover";
    const string ussButtonContainer = "buttonContainer";
    const string ussUeberschrift = "ueberschrift";
    const string ussLabelButtons = "labelButtons";

    #endregion

    string ueberschrift;
    public string Ueberschrift
    {
        get => ueberschrift;
        set {
            ueberschrift = value;
            ueberschriftLabel.text = ueberschrift;
        }
    }
    
    Label ueberschriftLabel;



    public LoginScreen()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(styleSheet_LoginScreen));
        #region mainContainer
        VisualElement mainContainer = new VisualElement() { name = "mainContainer"};
        hierarchy.Add(mainContainer);
        mainContainer.AddToClassList(ussMaincontainer);
        #endregion

        #region Überschrift
        ueberschriftLabel = new Label() { name = "Überschrift" };
        mainContainer.Add(ueberschriftLabel);
        ueberschriftLabel.AddToClassList(ussUeberschrift);
        #endregion

        #region Textfelder
        TextField emailTextfield = new TextField() { name = "EmailTextfield" };
        mainContainer.Add(emailTextfield);
        emailTextfield.AddToClassList(ussLoginTextfeld);
        emailTextfield.RegisterCallback<ChangeEvent<string>>(OnEmailChanged);

        TextField passwortTextfield = new TextField() { name = "EmailTextfield" };
        mainContainer.Add(passwortTextfield);
        passwortTextfield.isPasswordField = true; 
        passwortTextfield.AddToClassList(ussLoginTextfeld);
        passwortTextfield.RegisterCallback<ChangeEvent<string>>(OnPasswordChanged);

        #endregion

        #region Buttons
        VisualElement buttonContainer = new VisualElement() { name = "ButtonContainer"};
        buttonContainer.AddToClassList(ussButtonContainer);
        mainContainer.Add(buttonContainer);

        VisualElement loginButton = new VisualElement() { name = "LoginButton"};
        loginButton.AddToClassList(ussButtons);
        buttonContainer.Add(loginButton);
        Label loginButtonLabel = new Label() { text = "Login" };
        loginButtonLabel.AddToClassList(ussLabelButtons);
        loginButton.Add(loginButtonLabel);

        VisualElement registerButton = new VisualElement() { name = "RegisterButton" };
        registerButton.AddToClassList(ussButtons);
        buttonContainer.Add(registerButton);
        Label registerButtonLabel = new Label() { text = "Register" };
        registerButtonLabel.AddToClassList(ussLabelButtons);
        registerButton.Add(registerButtonLabel);


        #endregion



    }


    void OnEmailChanged(ChangeEvent<string> e)
    {
        Debug.Log(e.newValue);
    }

    void OnPasswordChanged(ChangeEvent<string> e)
    {
        Debug.Log(e.newValue);
    }
}
