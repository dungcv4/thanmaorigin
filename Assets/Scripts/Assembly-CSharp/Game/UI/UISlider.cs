// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1631)
//      KTO_DecompiledReference/_root/UISlider.c
//
// CHẾ CHÁO FIX 2026-05-02: previous version derived from MonoBehaviour — gốc derives from Slider.
// All prefabs with UISlider component would have lost Slider behavior. Now restored.
//
// Extends UnityEngine.UI.Slider with extra onPointerUp event + bButtonClick flag.
// All overrides have empty bodies in gốc IL2CPP — base Slider methods do the work.
// (RVAs 0x1B3949D..0x1B396CE — short stubs).

using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class UISlider : Slider
    {
        // Fields (matches dump.cs offsets 0x168, 0x170)
        private SliderEvent _onPointerUpBacking;
        public bool bButtonClick;

        // Auto-property
        public SliderEvent onPointerUp
        {
            get { return _onPointerUpBacking; }
            set { _onPointerUpBacking = value; }
        }

        // gốc overrides + helpers — empty bodies in IL2CPP
        public override void OnPointerUp(PointerEventData eventData) { base.OnPointerUp(eventData); }
        public override void OnPointerDown(PointerEventData eventData) { base.OnPointerDown(eventData); }
        public override void OnDrag(PointerEventData eventData) { base.OnDrag(eventData); }
        public void resetSlider() { }
        protected override void OnDestroy() { base.OnDestroy(); }
        public void EnableButtonClick() { }
    }
}
