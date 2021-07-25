using UnityEngine;
using TMPro;
using System.Collections;

namespace DPSMeter
{
    class DPSMeter : MonoBehaviour
    {
        public static DPSMeter instance;

        const float highDamage = 1000f;
        Gradient dpsColor;

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
            dpsColor = new Gradient();
            dpsColor.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 0.3f),
                                                      new GradientColorKey(Color.yellow, 0.7f), new GradientColorKey(Color.red, 1.0f) },
                             new GradientAlphaKey[] { new GradientAlphaKey(1, 0), new GradientAlphaKey(1, 1) });
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
                float f = (dps / combatTime);
                text.text = "DPS: " + f.ToString("N0");
                text.color = dpsColor.Evaluate(f / highDamage);
            }
        }
    }
}
