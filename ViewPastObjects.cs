using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewPastObjects : MonoBehaviour
{
    #region Singleton
    private static ViewPastObjects _instance;
    public static ViewPastObjects Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ViewPastObjects>();
            }

            return _instance;
        }
    }


    #endregion
    public bool IsActive;
    public GameObject Linter;
    public GameObject[] AreaLight;

    [Header("Timer")]
    public float MaxTimer = 100;
    public float currentTimer;
    public GameObject LightEffect;
    public int SpeedTimerToEnd = 2;

    [Header("UI")]
    public Slider PowerEnergy;

    public void Awake()
    {
        currentTimer = MaxTimer;
        PowerEnergy.maxValue = MaxTimer;
        PowerEnergy.value = MaxTimer;
    }

    public void Update()
    {
           PowerEnergy.value = currentTimer;
           UsePower(Time.deltaTime * SpeedTimerToEnd);

    }
    public void UsePower(float amount)
    {
        if(currentTimer - amount > 0 )
        {
            ClickLinterOn(amount);
        }
        else
        {
            IsActive = false;
            Linter.SetActive(false);
            LightEffect.GetComponent<ChangeMaterial>().ChangeMateria(false);
        }
    }
    
    void ClickLinterOn(float amount)
    {
        if (Input.GetMouseButtonDown(1))
        {
            FindObjectOfType<AudioManager>().playonce = true;

        }
        if (Input.GetMouseButton(1))
        {

            FindObjectOfType<AudioManager>().PlayOnce("EncenderLampara");
            LightEffect.GetComponent<ChangeMaterial>().ChangeMateria(true);
            currentTimer -= amount;
            PowerEnergy.value = currentTimer;
            IsActive = true;
            Linter.SetActive(true);
        }

         if (Input.GetMouseButtonUp(1))
        {
            LightEffect.GetComponent<ChangeMaterial>().ChangeMateria(false);

            FindObjectOfType<AudioManager>().Stop("EncenderLampara");

            IsActive = false;
            Linter.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.CompareTag("Past") || other.gameObject.CompareTag("Nota") || other.gameObject.CompareTag("Carta")) && IsActive == true )
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }


        if ((other.gameObject.CompareTag("Esconmbro") && IsActive == true))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        if ((other.gameObject.CompareTag("Esconmbro") && IsActive == false))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        if ((other.gameObject.CompareTag("CajaFuerte") && IsActive == true) && other.gameObject.activeInHierarchy == true)
        {
            CajaFuerteControl.Instance.UICajaFuerte.GetComponent<Image>().sprite = CajaFuerteControl.Instance.Past_im;
        }
        if ((other.gameObject.CompareTag("CajaFuerte") && IsActive == false))
        {
            CajaFuerteControl.Instance.UICajaFuerte.GetComponent<Image>().sprite = CajaFuerteControl.Instance.Present_im;
        }



        else if ((other.gameObject.CompareTag("Past") || other.gameObject.CompareTag("Nota") || other.gameObject.CompareTag("Carta")) && IsActive == false)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
        if ((other.gameObject.CompareTag("Present") || other.gameObject.CompareTag("Caja") || other.gameObject.CompareTag("puerta")) && IsActive == true  )
        {
            other.gameObject.GetComponent<ChangeMaterial>().ChangeMateria(true);
        }
        if ((other.gameObject.CompareTag("Present") || other.gameObject.CompareTag("Caja") || other.gameObject.CompareTag("puerta")) && IsActive == false)
        {
            other.gameObject.GetComponent<ChangeMaterial>().ChangeMateria(false);
        }




    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("CajaFuerte"))
        {
            CajaFuerteControl.Instance.UICajaFuerte.GetComponent<Image>().sprite = CajaFuerteControl.Instance.Present_im;
        }
        if (other.gameObject.CompareTag("Esconmbro"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        if (other.gameObject.CompareTag("Past") || other.gameObject.CompareTag("Nota") || other.gameObject.CompareTag("Carta"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }

        if (other.gameObject.CompareTag("Present") || other.gameObject.CompareTag("Caja") || other.gameObject.CompareTag("puerta"))
        {
            other.gameObject.GetComponent<ChangeMaterial>().ChangeMateria(false);
        }


    }



    public IEnumerator RegenStamina(float RegenTick)
    {
        while(currentTimer < MaxTimer)
        {
            currentTimer += MaxTimer / 100;
            PowerEnergy.value = currentTimer;
            yield return new WaitForSeconds(RegenTick);
        }
    }
}
