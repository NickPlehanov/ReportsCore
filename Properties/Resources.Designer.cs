﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReportsCore.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ReportsCore.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на № объекта,Объект,Адрес, ОС, ПС,ТРС,Маршрут,Полиция,Сработка,Отправка,Прибытие,Отмена,Результат.
        /// </summary>
        internal static string HeaderReportWord {
            get {
                return ResourceManager.GetString("HeaderReportWord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на № объекта,Объект,Адрес,Дата подключения,Куратор,Кем изменено,Дата изменения,Было,Стало.
        /// </summary>
        internal static string HeaderReportWordChangeCost {
            get {
                return ResourceManager.GetString("HeaderReportWordChangeCost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на №,Объект,Адрес, Ежемес. РР, ОС РР, ПС РР,Скуд РР, Видео РР.
        /// </summary>
        internal static string HeaderReportWordReglamentWorks {
            get {
                return ResourceManager.GetString("HeaderReportWordReglamentWorks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на № объекта,Объект,Адрес, ОС, ПС,ТРС,Маршрут,Полиция,Сработка,Отправка,Прибытие,Отмена,Результат,Опоздание.
        /// </summary>
        internal static string HeaderReportWordWithLate {
            get {
                return ResourceManager.GetString("HeaderReportWordWithLate", resourceCulture);
            }
        }
    }
}
