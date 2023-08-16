using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using GameOptionsUtility;
using System.Linq;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_Dropdown))]
public class CustomDropDownResolution : MonoBehaviour { 

        public DropDownRefreshRate dropDownRefreshRate;

        private void OnEnable()
        {
            var dropdown = GetComponent<TMP_Dropdown>();

            InitializeEntries();
            dropdown.onValueChanged.AddListener(UpdateOptions);
            UpdateOptions(dropdown.value);
        }

        private void OnDisable()
        {
            GetComponent<TMP_Dropdown>().onValueChanged.RemoveListener(UpdateOptions);
        }

        public void InitializeEntries()
        {
            var dropdown = GetComponent<TMP_Dropdown>();

            dropdown.options.Clear();
            int selected = 0;
            int i = 0;
            foreach (var res in Screen.resolutions.OrderByDescending(o => o.width))
            {
                string option = $"{res.width}x{res.height}";

                if (!dropdown.options.Any(o => o.text == option))
                {
                    dropdown.options.Add(new TMP_Dropdown.OptionData(option));
                    if (res.width == GameOption.Get<GraphicOption>().width && res.height == GameOption.Get<GraphicOption>().height)
                        selected = i;
                    i++;
                }
            }

            dropdown.SetValueWithoutNotify(selected);

            if (dropDownRefreshRate != null)
            {
                dropDownRefreshRate.InitializeEntries();
            }

        }

        void UpdateOptions(int value)
        {
            string option = GetComponent<TMP_Dropdown>().options[value].text;
            string[] values = option.Split('x');
            GameOption.Get<GraphicOption>().width = int.Parse(values[0]);
            GameOption.Get<GraphicOption>().height = int.Parse(values[1]);
        }
}
