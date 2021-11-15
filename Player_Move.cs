using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    #region Singleton
    private static Player_Move _instance;
    public static Player_Move Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Player_Move>();
            }

            return _instance;
        }
    }
    #endregion
    [Header("Player Settings")]
    public float speed;
    public float rotationSpeed;
    public Rigidbody rg;
    public  bool CanPick = true;
    public GameObject ItemPicked;
    public Transform positionPicked;
    public Text[] UITextScene;
    
    public bool Isdead;
    public ViewPastObjects Power;
    [Header("Linter Settings")]
    public GameObject Linter;
    [Header("Caja fuerte")]
    public GameObject CajaFuerteUI;

    [Header("Music")]
    public AudioSource[] walking;

    [Header("Animator")]
    public Animator anim;


    bool playOnceAudio = true;
    bool UseAndThrow = false;
    void Update()
    {
        if (!Isdead)
        {
            if (CodigoDeCartas.Instance.CajaFuerte.activeInHierarchy == false)
            {
                PlayerActions();
            }
           PlayerMovement();
        }
    }
    public void AddPowerToPast(float AddPower)
    {
        if(Power.currentTimer < Power.MaxTimer)
        {
            Power.currentTimer += AddPower;
            Power.PowerEnergy.value = Power.currentTimer;
        }
    }

    void PlayerMovement()
    {
        

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rg.velocity = new Vector3(horizontalInput * speed, rg.velocity.y, verticalInput * speed) ;
        Vector3 Rotation = new Vector3(horizontalInput, 0f, verticalInput);
        if (Rotation != Vector3.zero)
        {
            WaitSongTime();
            anim.SetBool("iswalking",true);
            Quaternion toRotation = Quaternion.LookRotation(Rotation, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        
        else
        {
            walking[0].Stop();
            anim.SetBool("iswalking", false);

        }
    }

    void WaitSongTime()
    {
        if (walking[0].isPlaying == false)
        {
            walking[0].Play();

        }
        else
            return;

    }
    void PlayerActions()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!CanPick)
                ThrowDrop();
            else
                PickUp();
        }

        if (!CanPick && ItemPicked)
            ItemPicked.transform.position = positionPicked.position;
        //    PickUp();

        /*
        if (CanPick == false && ItemPicked == null)
        {
            ItemPicked.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            ItemPicked.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            ItemPicked.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            ItemPicked.GetComponent<Rigidbody>().freezeRotation = true;

            ItemPicked.transform.GetComponent<Rigidbody>().useGravity = true;

        }
        */


        /*
        if (Input.GetKeyUp(KeyCode.E))
        {


            if(CanPick == false && ItemPicked != null)
            {
                ItemPicked.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                ItemPicked.transform.GetComponent<Rigidbody>().useGravity = false;
                ThrowDrop();

            }

        }
        */
    }
    void ThrowDrop()
    {
        if (!ItemPicked)
            return;

        //Set our Gravity to true again.
        ItemPicked.GetComponent<Rigidbody>().useGravity = true;
        // we don't have anything to do with our ball field anymore
        ItemPicked = null;
        //Apply velocity on throwing
     //   positionPicked.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Unparent our ball
        positionPicked.GetChild(0).parent = null;
        CanPick = true;
        /*
        if (ItemPicked == null)
            return;
        else
        {
            ItemPicked = null;
            transform.GetChild(7).SetParent(null);
            CanPick = true;
        }
        if (!CanPick && ItemPicked)
            ItemPicked.transform.position = transform.position ;
        */

    }
    void PickUp()
    {
        if (!ItemPicked)
            return;
        else
        {
            if (!CanPick)
                return;
            
            //We set the object parent to our guide empty object.
            ItemPicked.transform.SetParent(positionPicked);
            
            //Set gravity to false while holding it
            ItemPicked.GetComponent<Rigidbody>().useGravity = false;

            //we apply the same rotation our main object (Camera) has.
           // ItemPicked.transform.localRotation = transform.rotation;
            //We re-position the ball on our guide object 
            ItemPicked.transform.position = positionPicked.position;

            CanPick = false;
            //We set the object parent to our guide empty object.
          //  ItemPicked.transform.SetParent(transform);
           // ItemPicked.transform.position = positionPicked.transform.position;
           // CanPick = false;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            if (!ItemPicked)
            {
                    ItemPicked = other.transform.parent.gameObject;
                   
                // if we don't have anything holding
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pick")
        {
            if (CanPick)
            ItemPicked = null;
        }
    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("Carta"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(collision.gameObject.GetComponent<Codigo>().cuarto == CodigoDeCartas.Instance.UltimoCuarto)
                {
                    CodigoDeCartas.Instance.Cuadro.GetComponent<Rigidbody>().isKinematic = false;
                    CodigoDeCartas.Instance.Cuadro.GetComponent<Rigidbody>().useGravity = true;
                    GameObject.FindGameObjectWithTag("Caja").GetComponent<Animator>().SetBool("Desplazar", true);
                }

                    if(playOnceAudio == true)
                    {
                        FindObjectOfType<AudioManager>().Play("HojadePapel");
                        playOnceAudio = false;
                    }

                    CodigoDeCartas.Instance.CartaDeCuartoAbierta[collision.gameObject.GetComponent<Codigo>().cuarto] = true;
                    UITextScene[collision.gameObject.GetComponent<Codigo>().cuarto].text =
                    CodigoDeCartas.Instance.Numeros[collision.gameObject.GetComponent<Codigo>().cuarto].ToString();
                    collision.transform.GetChild(0).gameObject.SetActive(true);
                    if (collision.gameObject.GetComponent<Notas>().GetNOTASLUGARES == Notas.NOTASLUGARES.bano)
                    {
                        NivelBano.Instance.NotasRecolectadas[collision.gameObject.GetComponent<Notas>().NotasNum] = true;

                    }
                    else if (collision.gameObject.GetComponent<Notas>().GetNOTASLUGARES == Notas.NOTASLUGARES.cocina)
                    {
                        NIvelTcela.Instance.NotasRecolectadas[collision.gameObject.GetComponent<Notas>().NotasNum] = true;

                    }
                    else if (collision.gameObject.GetComponent<Notas>().GetNOTASLUGARES == Notas.NOTASLUGARES.Oficina)
                    {
                        Nivel_Final.Instance.NotasRecolectadas[collision.gameObject.GetComponent<Notas>().NotasNum] = true;

                    }

                


            }
        }
        if (collision.gameObject.CompareTag("puerta"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                FindObjectOfType<AudioManager>().Play("PuertaAbierta");
                collision.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Caja"))
        {
            Debug.Log("Caja");
            if (Input.GetKey(KeyCode.E))
            {
                CajaFuerteUI.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.CompareTag("Nota"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (playOnceAudio == true)
                {
                    FindObjectOfType<AudioManager>().Play("HojadePapel");
                    playOnceAudio = false;
                }
                FindObjectOfType<AudioManager>().playonce = true;
                if (collision.gameObject.GetComponent<Notas>().GetNOTASLUGARES == Notas.NOTASLUGARES.bano)
                {
                                    NivelBano.Instance.NotasRecolectadas[collision.gameObject.GetComponent<Notas>().NotasNum] = true;

                }
                else if(collision.gameObject.GetComponent<Notas>().GetNOTASLUGARES == Notas.NOTASLUGARES.cocina)
                {
                    NIvelTcela.Instance.NotasRecolectadas[collision.gameObject.GetComponent<Notas>().NotasNum] = true;

                }
                else if (collision.gameObject.GetComponent<Notas>().GetNOTASLUGARES == Notas.NOTASLUGARES.Oficina)
                {
                    Nivel_Final.Instance.NotasRecolectadas[collision.gameObject.GetComponent<Notas>().NotasNum] = true;

                }

                collision.transform.GetChild(0).gameObject.SetActive(true);
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Carta"))
        {
            if (collision.transform.GetChild(0).gameObject.activeInHierarchy == true)
            {
                collision.transform.GetChild(0).gameObject.SetActive(false);
                playOnceAudio = true;
            }
        }
        if (collision.gameObject.CompareTag("Caja"))
        {
            CajaFuerteUI.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Nota"))
        {
            if (collision.transform.GetChild(0).gameObject.activeInHierarchy == true)
            {
                collision.transform.GetChild(0).gameObject.SetActive(false);
                playOnceAudio = true;
            }
        }
    }

}
