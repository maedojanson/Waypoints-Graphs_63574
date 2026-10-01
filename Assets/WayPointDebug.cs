using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WayPointDebug : MonoBehaviour
{
    private TextMesh textMesh;

    void Update()
    {
        // Se estivermos no Editor do Unity
        if (!Application.isPlaying)
        {
            // 1. Procura o componente TextMesh no próprio objeto ou nos filhos (ex: wpname)
            if (textMesh == null)
            {
                textMesh = GetComponentInChildren<TextMesh>();
            }

            // 2. Calcula o número com base na ordem na Hierarchy (GetSiblingIndex)
            // Se for o primeiro filho é 1 (WP001), o segundo é 2 (WP002), etc.
            int index = transform.GetSiblingIndex() + 1;
            string formattedName = "WP" + index.ToString("D3");

            // 3. Atualiza o nome do GameObject na Hierarchy
            if (gameObject.name != formattedName)
            {
                gameObject.name = formattedName;
            }

            // 4. Atualiza o texto visual que flutua por cima da esfera vermelha
            if (textMesh != null && textMesh.text != formattedName)
            {
                textMesh.text = formattedName;
            }
        }
    }
}
