using System.Collections;
using CargoShipScripts;
using UnityEngine;

namespace TMP
{
    public class TMP : MonoBehaviour
    {
        [SerializeField] private CargoShip cargoShip;
        [SerializeField] private float landingTime;
        [SerializeField] private float flyAwayTime;
        [SerializeField] private float cameraSpeed;

        [SerializeField] private GameObject camera;
        
        private void Awake()
        {
            StartCoroutine(Landing());
        }

        private IEnumerator Landing()
        {
            cargoShip.Init(landingTime, flyAwayTime);
            
            yield return new WaitForSeconds(landingTime);

            camera.transform.parent = null;
            
            while (true)
            {
                camera.transform.position += Vector3.down * (Time.deltaTime * cameraSpeed);
                yield return new WaitForEndOfFrame();
                
                if(camera.transform.position.y < -100) break;
            }
        }
    }
}
