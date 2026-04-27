// 1-1 PORT 2026-04-27: I2.Loc.LanguageSourceData fields restored from KTO IL2CPP dump.
// Source: KTO_Resources/il2cpp_full_dump/dump.cs class LanguageSourceData (TypeDefIndex 1504)
// Existing LanguageData + TermData defs are in separate files (already 1-1 ported).
// Purpose: enable UnityPy TypeTreeGenerator to decode I2Languages.asset binary
// for Vietnamese translation extraction from APK.
using System;
using System.Collections.Generic;
using UnityEngine;

namespace I2.Loc
{
    [Serializable]
    public class LanguageSourceData
    {
        public ILanguageSource owner;                                      // 0x10
        public bool UserAgreesToHaveItOnTheScene;                          // 0x18
        public bool UserAgreesToHaveItInsideThePluginsFolder;              // 0x19
        public bool GoogleLiveSyncIsUptoDate;                              // 0x1A
        public bool mIsGlobalSource;                                       // 0x1B
        public List<TermData> mTerms;                                      // 0x20  ← TRANSLATIONS
        public bool CaseInsensitiveTerms;                                  // 0x28
        public MissingTranslationAction OnMissingTranslation;              // 0x38
        public string mTerm_AppName;                                       // 0x40
        public List<LanguageData> mLanguages;                              // 0x48  ← LANGUAGE LIST
        public bool IgnoreDeviceLanguage;                                  // 0x50
        public eAllowUnloadLanguages _AllowUnloadingLanguages;             // 0x54
        public string Google_WebServiceURL;                                // 0x58
        public string Google_SpreadsheetKey;                               // 0x60
        public string Google_SpreadsheetName;                              // 0x68
        public string Google_LastUpdatedVersion;                           // 0x70
        public eGoogleUpdateFrequency GoogleUpdateFrequency;               // 0x78
        public eGoogleUpdateFrequency GoogleInEditorCheckFrequency;        // 0x7C
        public eGoogleUpdateSynchronization GoogleUpdateSynchronization;   // 0x80
        public float GoogleUpdateDelay;                                    // 0x84
        public List<UnityEngine.Object> Assets;                            // 0x90

        public enum MissingTranslationAction { Empty = 0, Fallback = 1, ShowWarning = 2, ShowKey = 3 }
        public enum eAllowUnloadLanguages { Never = 0, OnDisable = 1, EveryFrame = 2 }
        public enum eGoogleUpdateFrequency { Always = 0, Never = 1, Daily = 2, Weekly = 3, Monthly = 4, OnlyOnce = 5, EveryOtherDay = 6 }
        public enum eGoogleUpdateSynchronization { None = 0, OnSceneLoaded = 1, AsSoonAsDownloaded = 2, Manual = 3 }
    }

    public interface ILanguageSource { }
}
