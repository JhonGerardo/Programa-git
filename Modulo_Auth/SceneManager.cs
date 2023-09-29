using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneManager : MonoBehaviour
{

    [Header("Login")]
    [SerializeField] private InputField m_loginUserNameInput = null;
    [SerializeField] private InputField m_loginPasswordInput = null;

    [Header("Registro")]
    [SerializeField] private GameObject m_registerUI     = null;
    [SerializeField] private GameObject m_loginUI        = null;
    [SerializeField] private Text      m_text                 = null;
    [SerializeField] private InputField  m_userNameInput   = null;
    [SerializeField] private InputField m_edadInput       = null;
    [SerializeField] private InputField m_pasword         = null;
    [SerializeField] private InputField m_reEnterPassword = null;



    private NetworkManager m_networkManager = null;

    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();

    }

    public void Submitlogin()
    {
        if (m_loginUserNameInput.text == "" || m_loginPasswordInput.text == "")
        {
            m_text.text = "Error, debes llenar todos los campos";
            return;
        }

        m_text.text = "Procesando...";

        m_networkManager.CheckUser(m_loginUserNameInput.text, m_loginPasswordInput.text, delegate (Response response)
        {
            m_text.text = response.message;
        });
    }


    public void SubmitRegister()
    {
        if (m_userNameInput.text == "" || m_edadInput.text == "" || m_pasword.text == "" || m_reEnterPassword.text == "")
        {
            m_text.text = "Error, debes llenar todos los campos";
            return;

        }
        if (m_pasword.text == m_reEnterPassword.text)
        {
            m_text.text = "Procesando los datos...";

            m_networkManager.CreateUser(m_userNameInput.text, m_edadInput.text, m_pasword.text, delegate (Response response)
            {
                m_text.text = response.message;
            });
        }

        else
        {
            m_text.text = " Las contraseñas ingresadas no son iguales, por favor verificar";
        }
    }
    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }
    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);

    }
}
