// Class: ButtonGroup
// Source: KTO custom UI component — group of buttons with single-selection
//
// PARTIAL PORT 2026-04-25: minimal API for UIPanel.ButtonGroup_SetSelect.

using UnityEngine;

public class ButtonGroup : MonoBehaviour
{
    public bool IsSelected;
    public void SetSelect(bool selected) { IsSelected = selected; }
}
