using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class ModeManager
    {
        public enum Edu_Scenario
        {
            Edu_Scenario_First = 0,
            Edu_Scenario_Second,
            Edu_Scenario_Third,
            Edu_Scenario_NUM
        }
        enum WorkMode
        {
            WorkMode_Work = 0,
            WorkMode_Edu,
            WorkMode_NUM
        };
        WorkMode mWorkMode = WorkMode.WorkMode_Work;

        List<Descriptor> m_EduScenarios = new List<Descriptor>();
        List<Descriptor> m_WorkScenarios = new List<Descriptor>();

        Descriptor m_DefDescriptor = new Descriptor(0/*timestart*/, 1500.0/*timeend*/, 0.1/*h_step*/,
                                                    /*u0_min*/300, /*u0_value*/ 300, /*u0_max*/ 1000,
                                                    /*r0_min*/ 0.1, /*r0_value*/ 0.1, /*r0_max*/ 1,
                                                    /*Edu_targetValueD*/ 0.0, /*Edu_taskDesc*/ "");

        public ModeManager()
        {
            RegisterScenarios();
        }

        public void RegisterScenarios()
        {
            _RegisterWorkScenarios();
            _RegisterEduScenarios();
        }
        private void _RegisterWorkScenarios()
        {
            // Первый сценарий
            m_WorkScenarios.Add(new Descriptor
                (
                0/*timestart*/, 1500.0/*timeend*/, 0.1/*h_step*/,
                /*u0_min*/300, /*u0_value*/ 300, /*u0_max*/ 1000,
                /*r0_min*/ 0.1, /*r0_value*/ 0.1, /*r0_max*/ 1,
                /*Edu_targetValueD*/ 0.0, /*Edu_taskDesc*/ "WorkMode"
                ));
        }
        private void _RegisterEduScenarios()
        {
            // TODO: Разнообразить сценарии
            // Первый сценарий
            m_EduScenarios.Add(new Descriptor
                (
                0/*timestart*/, 1500.0/*timeend*/, 0.1/*h_step*/,
                /*u0_min*/300, /*u0_value*/ 300, /*u0_max*/ 1000,
                /*r0_min*/ 0.1, /*r0_value*/ 0.1, /*r0_max*/ 1,
                /*Edu_targetValueD*/ 0.0, /*Edu_taskDesc*/ "EduMode 1"
                ));
            // Второй сценарий
            m_EduScenarios.Add(new Descriptor
                (
                0/*timestart*/, 1500.0/*timeend*/, 0.1/*h_step*/,
                /*u0_min*/300, /*u0_value*/ 300, /*u0_max*/ 1000,
                /*r0_min*/ 0.1, /*r0_value*/ 0.1, /*r0_max*/ 1,
                /*Edu_targetValueD*/ 0.0, /*Edu_taskDesc*/ "EduMode 2"
                ));
            // 3 сценарий
            m_EduScenarios.Add(new Descriptor
                (
                0/*timestart*/, 1500.0/*timeend*/, 0.1/*h_step*/,
                /*u0_min*/300, /*u0_value*/ 300, /*u0_max*/ 1000,
                /*r0_min*/ 0.1, /*r0_value*/ 0.1, /*r0_max*/ 1,
                /*Edu_targetValueD*/ 0.0, /*Edu_taskDesc*/ "EduMode 3"
                ));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public Descriptor GetScenario(int _type)
        {
            if (mWorkMode == WorkMode.WorkMode_Work)
            {
                if (_type >= m_WorkScenarios.Count)
                {
                    Debug.Assert(_type > m_WorkScenarios.Count, "Запрошенный сценарий не найден, переключение в стандартный режим");
                    return m_DefDescriptor;
                }
                return m_WorkScenarios[_type];
            }
            else if (mWorkMode == WorkMode.WorkMode_Edu)
            {
                if (_type >= m_EduScenarios.Count)
                {
                    Debug.Assert(_type > m_EduScenarios.Count, "Запрошенный сценарий не найден, переключение в стандартный режим");
                    return m_DefDescriptor;
                }
                MessageBox.Show("[debug]_type >= m_EduScenarios.Count - найден запрошенный режим " + _type.ToString() + " Count " + m_EduScenarios.Count.ToString());
                return m_EduScenarios[_type];
            }
            Debug.Fail("Некорректный режим работы - переключение в стандартный режим");

            Debug.Assert(mWorkMode != WorkMode.WorkMode_Edu && mWorkMode != WorkMode.WorkMode_Work,
                "Некорректный режим работы - переключение в стандартный режим");
            return m_DefDescriptor;
        }

        public void SwitchToEduMode()
        {
            mWorkMode = WorkMode.WorkMode_Edu;
        }

        public void SwitchToWorkMode()
        {
            mWorkMode = WorkMode.WorkMode_Work;
        }
    }
}
