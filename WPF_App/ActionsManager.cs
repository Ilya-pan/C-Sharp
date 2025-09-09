using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App
{
    /// <summary>
    /// Обработчик действий
    /// </summary>
    public class ActionsManager
    {
        /// <summary>
        /// Получить имя действия
        /// </summary>
        /// <param name="parAction"></param>
        /// <returns></returns>
        public static string GetName(FormAction parAction)
        {
            string actionName = null;
            switch (parAction)
            {
                case FormAction.Create:
                    actionName = "Создать";
                    break;
                case FormAction.CreatePrototype:
                    actionName = "Создать";
                    break;
                case FormAction.Edit:
                    actionName = "Изменить";
                    break;
                case FormAction.Remove:
                    actionName = "Удалить";
                    break;
            }
            return actionName;
        }

        /// <summary>
        /// Получить доступность изменения
        /// </summary>
        /// <param name="parAction"></param>
        /// <returns></returns>
        public static bool IsAllowEdit(FormAction parAction)
        {
            if (parAction == FormAction.Remove) return false;
            return true;
        }
    }
}
