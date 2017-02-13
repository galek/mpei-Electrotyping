/* Copyright (C) 2008-2017, Nick Galko. All rights reserved.
*
* Your use and or redistribution of this software in source and / or
* binary form, with or without modification, is subject to: (i) your
* ongoing acceptance of and compliance with the terms and conditions of
* the License Agreement; and (ii) your inclusion of this notice
* in any version of this software that you use or redistribute.
* A copy of the License Agreement is available on repository of project
*/

namespace WindowsFormsApplication1
{
    public static class EduHelpers
    {
        //const string m_Less = "МЕНЬШЕЕ";
        //const string m_Bigger = "БОЛЬШЕЕ";
        //const string m_U0 = "напряжение";
        //const string m_R0 = "сопротивление";

        //const string m_Out1 = "Для достижения требуемого результата вам необходимо либо";
        //const string m_Out1_1 = "напряжение, либо ";
        //const string m_Out1_2 = "Либо регулируйте один из параметров в одну из сторон";

        public static string GetResult(int _v1, int _v2, bool _skip)
        {
            if (!_skip)
            {
                if (_v1 > _v2)
                    return "Полученное вами значение недостаточно для выполнения задачи. Увеличивайте параметры напряжения, или уменьшайте сопротивление металла";
                else if (_v1 < _v2)
                    return "Полученное вами значение больше требуемого для выполнения задачи. Уменьшите параметры напряжения, или увеличьте сопротивление металла";
                else if (_v1 == _v2)
                    return "Поздравляем, вы достигли нужного значения";

                return "Варьируйте параметры для достижения требуемого значения";
            }

            return "";
        }
    }
}