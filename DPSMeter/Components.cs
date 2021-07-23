using UnityEngine;
using TMPro;
using System.Collections;

namespace DPSMeter
{
    class DPSMeter : MonoBehaviour
    {
        public static DPSMeter instance;

        public void AddDamage(int damage)
        {
            dps += damage;
            timeSinceCombat = 0;
        }

        float dps = 0;
        float combatTime = 0;
        float timeSinceCombat = 1000;


        public TextMeshProUGUI text;
        void Awake()
        {
            if (instance)
                Destroy(this);
            else
                instance = this;
            text = gameObject.GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            timeSinceCombat += Time.deltaTime;

            if (timeSinceCombat > 10f)
            {
                combatTime = 0;
                dps = 0;
                text.enabled = false;
            }
            else
            {
                combatTime += Time.deltaTime;
                text.enabled = true;
                text.text = "DPS: " + (dps / combatTime).ToString("N0");
            }
        }
    }
}
