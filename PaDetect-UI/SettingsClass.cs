using System.Xml.Linq;

namespace PaDetect_UI {
    internal static class SettingsClass {
        private static readonly string settingsDoc = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory?.FullName + "/app-setting.xml";
        private static XDocument? settings;
        private static bool isLoaded = false;
        private static readonly object locker = new object();

        internal static void Load() {
            lock (locker) {
                if (isLoaded) return;
                if (File.Exists(settingsDoc)) {
                    settings = XDocument.Load(settingsDoc);
                    isLoaded = true;
                    return;
                }
                settings = new XDocument(new XElement("PaDetect"));
                settings.Save(settingsDoc);
                isLoaded = true;
            }

        }

        internal static void Unload() {
            lock (locker) {
                if (!isLoaded) return;
                settings = null;
                isLoaded = false;
            }
        }

        private static XElement? GetXElementValue(string key) {
            return settings?.Element("PaDetect")?.Element(key);
        }

        internal static string GetValue(string key) {
            lock (locker) {
                if (!isLoaded) return "";
                XElement? element = GetXElementValue(key);
                return element != null ? element.Value : "";
            }
        }

        internal static void SetValue(string key, string value) {
            lock (locker) {
                if (!isLoaded) return;
                XElement? element = GetXElementValue(key);
                if (element == null) {
                    element = new XElement(key, value);
                    settings?.Element("PaDetect")?.Add(element);
                    settings?.Save(settingsDoc);
                    return;
                }
                element.Value = value;
                settings?.Save(settingsDoc);
            }

        }
    }
}
