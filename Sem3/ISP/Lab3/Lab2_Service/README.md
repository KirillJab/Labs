## Converter
Универсальный парсер XML и Json.
T DeserializeJson<T>(string), T DeserializeXML<T>(string) - методы класса Converter для преобразования JSON или XML строки соответственно в объект любого класса. Используют приватные методы T Deserizalize<T>(List<string>), List<string> SplitJSON(string) и List<string> SplitXML(string) для своей работы 
### Lab2_Service
Windows служба, разработанная мной в рамках второй лабораторной работы.
При запуске при помощи класса OptionsManager загружает файлы конфигурации __config.xml__ и __appsettings.json__. Если программа находит оба эти файла, то настроки загружаются из __appsettings.json__. Если этот файл не найден или некорректен, то загружается __config.xml__. Если же и __config.xml__ не найден или некоректен, то загружаются стандартные настройки (файл логгов __"C:\Lab3_Yablonsky\TargetDirectory\log.txt"__)

Загрузкой настроек занимается класс OptionsManager, имеющий метод Options GetOptions<T>(). Все настройки логически разбиты на классы:
Класс | Функция класса
------------ | -------------
DirectoryOptions | настройки путей к папкам
EncryptionOptions | настройки шифрования
LoggingOptions | настроки логгирования
ArchiveOptions | настройки архивирования
