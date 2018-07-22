using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AscensiveSoftware.Tools.Tools {
    public class UiTextUtil {
        private MonoBehaviour _obj;
        private Text _textObj;
        private float _letterPause = 0.02f;
        private Coroutine _coroutine = null;

        public UiTextUtil(MonoBehaviour obj, Text textObj) {
            _obj = obj;
            _textObj = textObj;
        }

        public void TypeText(string text) {
            if (_coroutine != null)
                _obj.StopCoroutine(_coroutine);
            _coroutine = _obj.StartCoroutine(DoTypeText(text));
        }

        private IEnumerator DoTypeText(string text) {
            _textObj.text = "";
            foreach (var letter in text.ToCharArray()) {
                _textObj.text += letter;
                yield return new WaitForSeconds(_letterPause);
            }
            yield return 0;
        }

    }
}
